using AuditManagementDAL.AuditDbContext;
using AuditManagementDAL.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Azure;
using System.Net.Http;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using Microsoft.AspNetCore.Http.HttpResults;
//using AuditManagementDAL.Migrations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Azure.Core;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Diagnostics;

#region "Variables declaration"

var responseRet = new JwtPayload();
string tableName = string.Empty;
string fieldName = string.Empty;
string[] genToken = new string[] { };  

AuditManagementDAL.HelperClass.HelperAction _helperAct = new AuditManagementDAL.HelperClass.HelperAction();
#endregion


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<auditContextObj>(options => {
        var config = builder.Configuration;
        var connectionString = config.GetConnectionString("AuditAPIConnection");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    });
}
else
{
    builder.Services.AddDbContext<auditContextObj>(options => {
        var config = builder.Configuration;
        var connectionString = config.GetConnectionString("AuditAPIConnection");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    });
}
builder.Services.AddCors();
builder.Services.AddApplicationInsightsTelemetry();
builder.Services
  .AddAuthentication(options =>
  {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
  })
  .AddJwtBearer(opt =>
  {
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = builder.Configuration["JwtBearer:Isssuer"],
        ValidAudience = builder.Configuration["JwtBearer:Audiences"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtBearer:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero
    };
  });
//builder.Services.AddSwaggerGen(option => {
//    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Hindalco API", Version = "v1" });
//    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        In = ParameterLocation.Header,
//        Description = "Please enter a valid token",
//        Name = "Authorization",
//        Type = SecuritySchemeType.Http,
//        BearerFormat = "JWT",
//        Scheme = "Bearer"
//    });
//    option.AddSecurityRequirement(new OpenApiSecurityRequirement
//   {
//    {
//        new OpenApiSecurityScheme
//        {
//            Reference = new OpenApiReference
//            {
//                Type=ReferenceType.SecurityScheme,
//                Id="Bearer"
//            }
//        },
//      genToken=  new string[]{}
//    }
//   });
//});


builder.Services.AddAuthorization();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
app.UseAuthentication();
app.UseAuthorization();

#region "JWT Tokenisation"
/// <summary>
/// Generates JWT Token
/// </summary>
/// 
/// <response code="201">Returns the newly created item</response>
/// <response code="400">If the item is null</response>

app.MapPost("/GenerateToken", async (UserModel umodel, auditContextObj db) =>
{
    try
    {
        if (umodel != null)
        {
            var result = await db.tbl_usermodel.FirstOrDefaultAsync(u => u.UserName == umodel.UserName && u.Password == umodel.Password);
            if (result != null)
            {

                var issuer = builder.Configuration["JwtBearer:Isssuer"];
                var audience = builder.Configuration["JwtBearer:Audiences"];
                var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtBearer:Key"]);
                var tokendescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                new Claim("Uid",umodel.Uid.ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub,umodel.UserName.ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email,umodel.UserName.ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            }),
                    Expires = DateTime.UtcNow.AddSeconds(1800),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenhandler = new JwtSecurityTokenHandler();
                var token = tokenhandler.CreateJwtSecurityToken(tokendescriptor);
                var jwttoken = tokenhandler.WriteToken(token);
                var stringtoken = tokenhandler.WriteToken(token);
                return Results.Ok(jwttoken);
            }
        }
    }
    catch (Exception ex)
    {
        // return null if validation fails
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Unauthorized();
});

app.MapGet("/ValidateJwtToken", async ([FromQuery] string token) =>
{
    try
    {
        responseRet = ValidateInputToken(token);
    }
    catch (Exception ex)
    {
        // return null if validation fails
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return responseRet;
});

JwtPayload ValidateInputToken(string inputToken)
{
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtBearer:Key"]);
    var ReturnValKey = 0;
    var userName = string.Empty;
    try
    {
        tokenHandler.ValidateToken(inputToken, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
            ClockSkew = TimeSpan.Zero
        }, out SecurityToken validatedToken);
        var jwtToken = (JwtSecurityToken)validatedToken;
        ReturnValKey = int.Parse((jwtToken.Claims.First(x => x.Type == "Uid").Value));
        userName = (jwtToken.Claims.First(x => x.Type == "sub").Value);
        var payload = new JwtPayload
        {
            { "uname", userName },
            { "Uid", ReturnValKey},
        };

        if (payload.Count > 0)
        {
            return payload;
        }
        else
        {

        }
        responseRet = payload;
    }

    catch (Exception ex)
    {
        // return null if validation fails
        var retPay = new JwtPayload
          {
              {"Invalid Token",inputToken }
          };
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
        return responseRet = retPay;
    }
    return responseRet;
}

#region "Token Descriptor"


app.MapPost("/GetUserDetails/{BearerToken}", (string BearerToken, auditContextObj db) =>
{
    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
    JwtSecurityToken tokenS = handler.ReadToken(BearerToken) as JwtSecurityToken;
    string profile = tokenS.Claims.First(claim => claim.Type == "profile").Value;
    JObject o = JObject.Parse(profile);
    string cardType = o.SelectToken("$.roles." + "Rolename" + ".Type").ToString();
});

#endregion
#endregion "JWT Tokenisation"

#region "User Creation"
app.MapPost("/SaveUser", async (UserModel uModel, auditContextObj db) =>
{
    try
    {
        db.tbl_usermodel.Add(uModel);
        await db.SaveChangesAsync();
        WriteToFile(AppDomain.CurrentDomain.BaseDirectory);
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message);
    }
    return Results.Created($"/save/{uModel.UserName}", uModel);

});
#endregion "User Creation"

#region "Audit Planner"
//Save  New Audit Calendar

/// <summary>
/// Creates a TodoItem.
/// </summary>
/// <param name="item"></param>
/// <returns>A newly created TodoItem</returns>
/// <remarks>
/// Sample request:
///
///     POST /Todo
///     {
///        "id": 1,
///        "name": "Item #1",
///        "isComplete": true
///     }
///
/// </remarks>
/// <response code="201">Returns the newly created item</response>
/// <response code="400">If the item is null</response>

app.MapPost("/SaveAudit", async (AuditCalendar auditCal, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            db.tbl_auditcalendar.Add(auditCal);
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
        responseRet.Clear();
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Created($"/save/{auditCal.AuditCalendarId}", auditCal);

});

// get all audit calendar
app.MapGet("/GetAllAuditCalendar", async ([FromQuery] string Token, auditContextObj db) =>
{
    List<AuditCalendar> auCal = new List<AuditCalendar>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            auCal = await db.tbl_auditcalendar.ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
        responseRet.Clear();
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (auCal.Count > 0)
    {
        return Results.Ok(auCal);
    }
    else
    {
        return Results.NotFound();
    }
    //  return auCal;
});

// get specfic audit by id
app.MapGet("/GetAuditById/{id}", async (int id, string Token, auditContextObj db) =>
{
    List<AuditCalendar> audCal = new List<AuditCalendar>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audCal = await db.tbl_auditcalendar.Where(a => a.AuditCalendarId == id).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
        responseRet.Clear();
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audCal.Count > 0)
    {
        return Results.Ok(audCal);
    }
    else
    {
        return Results.NotFound();
    }
});


// update audit calendar by id
app.MapPut("/UpdateAuditCalendar/{AuditId}", async (int AuditCalendarId, AuditCalendar auditCal, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            var auditcal = await db.tbl_auditcalendar.FindAsync(AuditCalendarId);
            if (auditcal is null) return Results.NotFound();
            auditcal.AuditName = auditCal.AuditName;
            auditcal.AuditType = auditCal.AuditType;
            auditcal.AuditStart = auditCal.AuditStart;
            auditcal.AuditCategory = auditCal.AuditCategory;
            auditcal.AreaCode = auditCal.AreaCode;
            auditcal.DeptId = auditCal.DeptId;
            auditcal.DocumentDate = auditCal.DocumentDate;
            auditcal.DocumentedBy = auditCal.DocumentedBy;
            auditcal.ExpectedDate = auditCal.ExpectedDate;
            auditcal.AuditCalendarId = auditCal.AuditCalendarId;
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
        responseRet.Clear();
        return Results.CreatedAtRoute($"/update/{auditCal.AuditCalendarId}", auditCal);
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

app.MapDelete("/DeleteAuditCalendar/{AuditId}", async (int id, [FromBody] AuditCalendarTemp auditCalH, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            if (await db.tbl_auditcalendar.FindAsync(id) is AuditCalendar auditCal)
            {
                try
                {
                    AuditCalendarHistory audHistory = GenerateModelAudit(auditCal, auditCalH);
                    db.tbl_auditcalendarhistory.Add(audHistory);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    WriteToFile(ex.Message + "\n" + ex.StackTrace);
                }
                db.tbl_auditcalendar.Remove(auditCal);
                await db.SaveChangesAsync();
                return Results.Ok(auditCal);
            }
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    responseRet.Clear();
    return Results.NotFound();
});
#endregion "Audit Planner"

#region "Audit Master"
app.MapPost("/SaveAuditMaster", async (AuditMaster auditMaster, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            db.tbl_auditmaster.Add(auditMaster);
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    responseRet.Clear();
    return Results.Created($"/save/{auditMaster.AuditMasterId}", auditMaster);
});

// get all audit calendar
app.MapGet("/GetAllAuditMasters", async (string Token, auditContextObj db) =>
{
    List<AuditMaster> auMaster = new List<AuditMaster>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            auMaster = await db.tbl_auditmaster.ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
        responseRet.Clear();
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (auMaster.Count > 0)
    {
        return Results.Ok(auMaster);
    }
    else
    {
        return Results.NotFound();
    }
});

// get specfic audit by id
app.MapGet("/GetAuditMasterById/{AuditMasterId}", async (Guid AuditMasterId, string Token, auditContextObj db) =>
{
    List<AuditMaster> auditMasters = new List<AuditMaster>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            auditMasters = await db.tbl_auditmaster.Where(a => a.AuditMasterId == AuditMasterId).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
        responseRet.Clear();
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (auditMasters.Count > 0)
    {
        return Results.Ok(auditMasters);
    }
    else
    {
        return Results.NotFound();
    }
});


app.MapGet("/GetAuditMasterByCategoryId/{AuditCategoryId}", async (string AuditCategorymId, string Token, auditContextObj db) =>
{
    List<AuditMaster> auditCategories = new List<AuditMaster>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            auditCategories = await db.tbl_auditmaster.Where(a => a.AuditCategoryId == AuditCategorymId).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
        responseRet.Clear();
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (auditCategories.Count() > 0)
    {
        return Results.Ok(auditCategories);
    }
    else
    {
        return Results.NotFound();
    }
});
// update audit calendar by id
app.MapPut("/UpdateAuditMaster/{AuditCheckPointId}", async (string AuditCheckPointId, AuditMaster auditMaster, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            var auditExec = await db.tbl_auditmaster.FindAsync(AuditCheckPointId);
            if (auditExec is null) return Results.NotFound();
            auditExec.AuditRemarks = auditMaster.AuditRemarks;
            auditExec.AuditCreatedBy = auditMaster.AuditCreatedBy;
            auditExec.AuditCategoryId = auditMaster.AuditCategoryId;
            // auditExec.AuditCheckPointId = auditMaster.AuditCheckPointId;
            auditExec.AuditCheckPoint = auditMaster.AuditCheckPoint;
            auditExec.CreatedDate = auditMaster.CreatedDate;
            auditExec.AuditUpdatedDate = DateTime.Now;
            auditExec.AuditUpdatedBy = auditMaster.AuditUpdatedBy;
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
        responseRet.Clear();
        return Results.Ok();
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

app.MapDelete("/DeleteAuditMaster/{AuditCheckPointId}", async (int AuditCheckPointId, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            if (await db.tbl_auditmaster.FindAsync(AuditCheckPointId) is AuditMaster auditMaster)
            {
                db.tbl_auditmaster.Remove(auditMaster);
                await db.SaveChangesAsync();
                return Results.Ok(auditMaster);
            }
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    responseRet.Clear();
    return Results.NotFound();
});
#endregion

#region "Audit Management"
app.MapPost("/SaveAuditManagement", async (AuditManagement auditMangement, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            var content = new ByteArrayContent(auditMangement.AttachedFile);
            auditMangement.AttachedFile = await content.ReadAsByteArrayAsync();
            db.tbl_auditmanagement.Add(auditMangement);
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Created($"/save/{auditMangement.AuditManId}", auditMangement);
});


// get all audit calendar
app.MapGet("/GetAllAudits", async (string Token, auditContextObj db) =>
{
    List<AuditManagement> auditManagement = new List<AuditManagement>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            auditManagement = await db.tbl_auditmanagement.ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (auditManagement.Count > 0)
    {
        return Results.Ok(auditManagement);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/GetAuditCalStdDtlClosedData", async (Guid AuditPlanId, string Token, auditContextObj db) =>
{
    int CountVal = 0;
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            CountVal = await db.tbl_auditcalendarstddetaill2.Where(a=>a.AuditPlanId==AuditPlanId && a.Status==8).CountAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Ok(CountVal);
});

app.MapGet("/GetAuditObsDtlClosedData", async (Guid StdDetailId, string Token, auditContextObj db) =>
{
    int CountVal = 0;
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            CountVal = await db.tbl_auditobservationdetailsl2.Where(a => a.StdDetailId == StdDetailId && a.AuditStatus==6).CountAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Ok(CountVal);
});

// get specfic audit by id
app.MapGet("/GetAuditsById/{AuditManId}", async (Guid AuditManId, string Token, auditContextObj db) =>
{
    List<AuditManagement> audMan = new List<AuditManagement>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditmanagement.Where(a => a.AuditManId == AuditManId).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audMan.Count > 0)
    {
        return Results.Ok(audMan);
    }
    else
    {
        return Results.NotFound();
    }
});

// update audit calendar by id
app.MapPut("/UpdateAudits/", async (Guid AuditManId, AuditManagement auditMan, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            var auditman = await db.tbl_auditmanagement.FindAsync(AuditManId);
            if (auditman is null) return Results.NotFound();
            auditman.AuditManId = AuditManId;
            auditman.AuditStartDate = auditMan.AuditStartDate;
            auditman.AuditType = auditMan.AuditType;
            auditman.AuditEndDate = auditMan.AuditEndDate;
            auditman.AuditorId = auditMan.AuditorId;
            auditman.AuditCode = auditMan.AuditCode;
            //  auditman.AreaId = auditMan.AreaId;
            auditman.AuditClosureDate = auditMan.AuditClosureDate;
            auditman.AuditEndDate = auditMan.AuditEndDate;
            auditman.Operationunit = auditMan.Operationunit;
            auditman.Status = auditMan.Status;
            auditman.FinancialYear = auditMan.FinancialYear;
            auditman.FinancialQuarter = auditMan.FinancialQuarter;
            auditman.ExpectedAuditMonth = auditMan.ExpectedAuditMonth;
            auditman.AuditAreaId = auditMan.AuditAreaId;
            auditman.CreatedDate = auditMan.CreatedDate;
            auditman.CreatedBy = auditMan.CreatedBy;
            auditman.CommiteeMemId = auditMan.CommiteeMemId;
            auditman.AuditPlanUpdatedBy = auditMan.AuditPlanUpdatedBy;
            auditman.AuditPlanUpdatedDate = auditMan.AuditPlanUpdatedDate;
            auditman.AuditPlanID = auditMan.AuditPlanID;
            auditman.Remarks = auditMan.Remarks;
            auditman.AuditAreaId = auditMan.AuditAreaId;
            var content = new ByteArrayContent(auditman.AttachedFile);
            auditman.AttachedFile = await content.ReadAsByteArrayAsync();
            //auditman.AttachedFile= auditMan.AttachedFile;
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }

    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Ok();
});

app.MapDelete("/DeleteAuditManagement/{AuditCheckPointId}", async (Guid AuditManId, string Token, [FromBody] AuditManagementTemp auditTemp, auditContextObj db) =>
{
    try
    {

        if (await db.tbl_auditmanagement.FindAsync(AuditManId) is AuditManagement auditManagement)
        {
            try
            {
                responseRet = ValidateInputToken(Token);
                if (responseRet.Count == 0) return Results.BadRequest();
                if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
                {
                    AuditManagementHistory audHistory = GenerateModel(auditManagement, auditTemp);
                    db.tbl_auditmangementhistory.Add(audHistory);
                    await db.SaveChangesAsync();
                }
                else
                {
                    return Results.Unauthorized();
                }
            }
            catch (Exception ex)
            {
                WriteToFile(ex.Message + "\n" + ex.StackTrace);
            }
            db.tbl_auditmanagement.Remove(auditManagement);
            await db.SaveChangesAsync();
            return Results.Ok(auditManagement);
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }

    return Results.NotFound();
});

AuditCalendarHistory GenerateModelAudit(AuditCalendar auditcal, AuditCalendarTemp auditTemp)
{
    AuditCalendarHistory auditCalendarHistory = new AuditCalendarHistory();
    try
    {
        auditCalendarHistory.AuditType = auditcal.AuditType;
        auditCalendarHistory.AuditStart = auditcal.AuditStart;
        auditCalendarHistory.AuditCalendarId = auditcal.AuditCalendarId;
        auditCalendarHistory.AuditCategory = auditcal.AuditCategory;
        auditCalendarHistory.AuditName = auditcal.AuditName;
        auditCalendarHistory.AreaCode = auditcal.AreaCode;
        auditCalendarHistory.DateOfDeletion = auditTemp.DateOfDeletion;
        auditCalendarHistory.DeleterDeptID = auditTemp.DeptID;
        auditCalendarHistory.DeletedByUserName = auditTemp.DeletedByUserName;
        auditCalendarHistory.DeletedIPAddress = auditTemp.DeletedIPAddress;
        auditCalendarHistory.DeletionId = auditTemp.DeletionId;
        auditCalendarHistory.DeptId = auditTemp.DeptID;
        auditCalendarHistory.DocumentDate = auditcal.DocumentDate;
        auditCalendarHistory.DocumentedBy = auditcal.DocumentedBy;
        auditCalendarHistory.ExpectedDate = auditcal.ExpectedDate;
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return auditCalendarHistory;
}
AuditManagementHistory GenerateModel(AuditManagement auditManagement, AuditManagementTemp auditTemp)
{
    AuditManagementHistory audHist = new AuditManagementHistory();
    try
    {
        audHist.AuditType = auditManagement.AuditType;
        audHist.AuditPlanID = auditManagement.AuditPlanID;
        audHist.AuditManId = auditManagement.AuditManId;
        audHist.AuditorId = auditManagement.AuditorId;
        //  audHist.AreaId = auditManagement.AreaId;
        audHist.AuditeeId = auditManagement.AuditeeId;
        audHist.AuditCode = auditManagement.AuditCode;
        audHist.AuditClosureDate = auditManagement.AuditClosureDate;
        audHist.AuditEndDate = auditManagement.AuditEndDate;
        audHist.AuditPlanUpdatedBy = auditManagement.AuditPlanUpdatedBy;
        audHist.AuditPlanUpdatedDate = auditManagement.AuditPlanUpdatedDate;
        audHist.AuditStartDate = auditManagement.AuditStartDate;
        audHist.CommiteeMemId = auditManagement.CommiteeMemId;
        audHist.CreatedBy = auditManagement.CreatedBy;
        audHist.Status = auditManagement.Status;
        audHist.Operationunit = auditManagement.Operationunit;
        audHist.GeoTeamId = auditTemp.GeoTeamId;
        audHist.FinancialYear = auditManagement.FinancialYear;
        audHist.FinancialQuarter = auditManagement.FinancialQuarter;
        audHist.ExpectedAuditMonth = auditManagement.ExpectedAuditMonth;
        audHist.AuditAreaId = auditManagement.AuditAreaId;
        audHist.DeptID = auditTemp.DeptID;
        audHist.DeletedIPAddress = auditTemp.DeletedIPAddress;
        audHist.DateOfDeletion = auditTemp.DateOfDeletion;
        audHist.AuditManId = auditTemp.AuditManId;
        audHist.DeletedByUserName = auditTemp.DeletedByUserName;
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return audHist;
}
AuditPlanHistory GenerateAuditModel(AuditPlan auditplan, AuditPlanTemp auditTemp)
{
    AuditPlanHistory auditPlanHistory = new AuditPlanHistory();
    try
    {
        auditPlanHistory.AuditType = auditplan.AuditType;
        auditPlanHistory.AuditplanId = auditTemp.AuditplanId;
        auditPlanHistory.AuditorId = auditplan.AuditorId;
        auditPlanHistory.AuditeeId = auditplan.AuditeeId;
        auditPlanHistory.AuditCode = auditplan.AuditCode;
        auditPlanHistory.AuditClosureDate = auditplan.AuditClosureDate;
        auditPlanHistory.AuditEndDate = auditplan.AuditEndDate;
        auditPlanHistory.AuditPlanUpdatedBy = auditplan.AuditPlanUpdatedBy;
        auditPlanHistory.AuditPlanUpdatedDate = auditplan.AuditPlanUpdatedDate;
        auditPlanHistory.AuditStartDate = auditplan.AuditStartDate;
        auditPlanHistory.CommitteeMemId = auditplan.CommitteeMemId;
        auditPlanHistory.CreatedBy = auditplan.CreatedBy;
        auditPlanHistory.CreatedDate = auditplan.CreatedDate;
        auditPlanHistory.DepartmentId = auditplan.DepartmentId;
        auditPlanHistory.OperationUnit = auditplan.OperationUnit;
        auditPlanHistory.FinancialYear = auditplan.FinancialYear;
        auditPlanHistory.FinancialQuarter = auditplan.FinancialQuarter;
        auditPlanHistory.ExpectedClosureMonth = auditplan.ExpectedClosureMonth;
        auditPlanHistory.DocStatus = auditplan.DocStatus;
        auditPlanHistory.DateOfDeletion = auditTemp.DateOfDeletion;
        auditPlanHistory.DeletedByUserName = auditTemp.DeletedByUserName;
        auditPlanHistory.DeletedIPAddress = auditTemp.DeletedIPAddress;
        auditPlanHistory.DeptID = auditTemp.DeptID;
        auditPlanHistory.GeoTeamId = auditTemp.GeoTeamId;
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return auditPlanHistory;
}
AuditManagementDetHistory GenerateAuditDetailsModel(AuditManagementDetails auditMan, AuditManagementDetailsTemp auditTemp)
{
    AuditManagementDetHistory auditManHistory = new AuditManagementDetHistory();
    try
    {
        auditManHistory.AuditManId = auditMan.AuditManId;
        auditManHistory.AuditManDetId = auditTemp.AuditManDetId;
        auditManHistory.AuditMasterId = auditMan.AuditMasterId;
        auditManHistory.AuditStatus = auditMan.AuditStatus;
        auditManHistory.CateOfObs = auditMan.CateOfObs;
        auditManHistory.CompletionDate = auditMan.CompletionDate;
        auditManHistory.DateOfDeletion = auditTemp.DateOfDeletion;
        auditManHistory.NarrationOb = auditMan.NarrationOb;
        auditManHistory.AuditStatus = auditMan.AuditStatus;
        auditManHistory.CorrectiveAction = auditMan.CorrectiveAction;
        auditManHistory.DeletedByUserName = auditTemp.DeletedByUserName;
        auditManHistory.DeletedIPAddress = auditTemp.DeletedIPAddress;
        auditManHistory.RiskCategory = auditMan.RiskCategory;
        auditManHistory.UploadedImg = auditMan.UploadedImg;
        auditManHistory.DeviaSafetyStd = auditMan.DeviaSafetyStd;
        auditManHistory.GeoTeamId = auditTemp.GeoTeamId;
        auditManHistory.PreventiveAction = auditMan.PreventiveAction;
        auditManHistory.ResponsPersonId = auditMan.ResponsPersonId;
        auditManHistory.RootCauseObsAuditor = auditMan.RootCauseObsAuditor;
        auditManHistory.RootCauseObsAuditee = auditMan.RootCauseObsAuditee;
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return auditManHistory;
}

AuditExecPlanHistory GenerateAuditExecPlan(AuditExecutionPlan auditExec, AuditExecutionTemp auditTemp)
{
    AuditExecPlanHistory auditPlanHistory = new AuditExecPlanHistory();
    try
    {
        auditPlanHistory.AuditPlanId = auditExec.AuditPlanId;
        auditPlanHistory.AuditorRCA = auditExec.AuditorRCA;
        auditPlanHistory.NarrationOfObservation = auditExec.NarrationOfObservation;
        auditPlanHistory.AuditClosureDate = auditExec.AuditClosureDate;
        auditPlanHistory.DateOfDeletion = auditTemp.DateOfDeletion;
        auditPlanHistory.AuditExecutionId = auditExec.AuditExecutionId;
        auditPlanHistory.DeletedByUserName = auditTemp.DeletedByUserName;
        auditPlanHistory.DeletedIPAddress = auditTemp.DeletedIPAddress;
        auditPlanHistory.DeptID = auditTemp.DeptID;
        auditPlanHistory.DeviationStandard = auditExec.DeviationStandard;
        auditPlanHistory.SnapshotImg = auditExec.SnapshotImg;
        auditPlanHistory.GeoTeamId = auditTemp.GeoTeamId;
        auditPlanHistory.ExecutionStatus = auditExec.ExecutionStatus;
        auditPlanHistory.ExecutedBy = auditExec.ExecutedBy;
        auditPlanHistory.ExcutionCategory = auditExec.ExcutionCategory;
        auditPlanHistory.AuditeeRCA = auditExec.AuditeeRCA;
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return auditPlanHistory;
}

app.MapGet("/GetAuditManagementByDU", async (string AuditorId, string Token, auditContextObj db) =>
{
    List<AuditManagement> audMan = new List<AuditManagement>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditmanagement.Where(a => a.AuditorId == AuditorId).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audMan.Count > 0)
    {
        return Results.Ok(audMan);
    }
    else
    {
        return Results.NotFound();
    }
});


app.MapGet("/GetAuditManagementByDH", async (string AuditeeId, string Token, auditContextObj db) =>
{
    List<AuditManagement> audMan = new List<AuditManagement>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditmanagement.Where(a => a.AuditeeId == AuditeeId).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audMan.Count > 0)
    {
        return Results.Ok(audMan);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/GetAuditManagementCreatedBy", async (string CreatedBy, string Token, auditContextObj db) =>
{
    List<AuditManagement> audMan = new List<AuditManagement>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditmanagement.Where(a => a.CreatedBy == CreatedBy).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audMan.Count > 0)
    {
        return Results.Ok(audMan);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/GetAuditManagementByAuditCommMem", async (string CommiteeMemId, string Token, auditContextObj db) =>
{
    List<AuditManagement> audMan = new List<AuditManagement>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditmanagement.Where(a => a.CommiteeMemId == CommiteeMemId).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audMan.Count > 0)
    {
        return Results.Ok(audMan);
    }
    else
    {
        return Results.NotFound();
    }
});


app.MapGet("/CheckAuditMgmt", async (Guid AuditPlanId, string Token, auditContextObj db) =>
{
    int ret = 0;
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            ret = db.tbl_auditmanagement.Where(a => a.AuditPlanID == AuditPlanId).Count();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Content(ret.ToString());
});


app.MapGet("/CheckAuditMgmtL2", async (Guid AuditPlanId, string Token, auditContextObj db) =>
{
    int ret = 0;
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            ret = db.tbl_auditmanagementl2.Where(a => a.AuditPlanID == AuditPlanId).Count();
            return Results.Ok(ret);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
   return Results.NoContent();
});


app.MapGet("/CheckAuditObsDetailClosureDataL2", async (Guid stdDetailId, string Token, auditContextObj db) =>
{
    int ret = 0;
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            ret = db.tbl_auditobservationdetailsl2.Where(a => a.StdDetailId == stdDetailId && a.AuditStatus==6).Count();
            return Results.Ok(ret);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NoContent();
});

app.MapGet("/CheckAuditStdDtlClosedDataL2", async (Guid AuditManId, string Token, auditContextObj db) =>
{
    int ret = 0;
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            ret = db.tbl_auditmanagementstddetail2.Where(a => a.AuditManId == AuditManId && a.Status ==5 ).Count();
            return Results.Ok(ret);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NoContent();
});

app.MapGet("/CheckAuditMgmtDetailData", async (Guid AuditManId, Guid AuditMasterId, string Token, auditContextObj db) =>
{
    int ret = 0;
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            ret = db.tbl_auditmanagementdetails.Where(a => a.AuditManId == AuditManId && a.AuditMasterId == AuditMasterId).Count();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Content(ret.ToString());
});
#endregion

#region "Audit Managamenent L2"
app.MapGet("/GetAuditManagementByDUL2", async (string AuditorId, string Token, auditContextObj db) =>
{
    List<AuditManagementL2> audMan = new List<AuditManagementL2>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await (from a in db.tbl_auditmanagementstddetail2.AsNoTracking()
                            join b in db.tbl_auditmanagementl2.AsNoTracking()
                            on a.AuditManId equals b.AuditManId
                            where a.AuditorId == AuditorId
                            select new AuditManagementDAL.DataModels.AuditManagementL2
                            {
                                AuditManId = a.AuditManId,
                                Operationunit = b.Operationunit,
                                AuditAreaId = b.AuditAreaId,
                                CreatedDate = b.CreatedDate,
                                CreatedBy = b.CreatedBy,
                                AuditeeId = b.AuditeeId,
                                FinancialYear = b.FinancialYear,
                                FinancialQuarter = b.FinancialQuarter,
                                AuditStartDate = b.AuditStartDate,
                                AuditEndDate = b.AuditEndDate,
                                CommiteeMemId = b.CommiteeMemId,
                                ExpectedAuditMonth = b.ExpectedAuditMonth,
                                AuditClosureDate = b.AuditClosureDate,
                                Status = b.Status,
                                AuditPlanUpdatedBy = b.AuditPlanUpdatedBy,
                                AuditPlanUpdatedDate = b.AuditPlanUpdatedDate,
                                AuditCode = b.AuditCode,
                                AuditPlanID = b.AuditPlanID,
                                AuditType = b.AuditType,
                                Remarks = b.Remarks,
                                DepartmentId = b.DepartmentId,
                            }).Distinct().ToListAsync();
            return Results.Ok(audMan);
        }
        else
        {
            return Results.Unauthorized();
        }
      
    }
   
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

app.MapGet("/GetAuditManagementByDHL2", async (string AuditeeId, string Token, auditContextObj db) =>
{
    List<AuditManagementL2> audMan = new List<AuditManagementL2>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditmanagementl2.Where(a => a.AuditeeId == AuditeeId).ToListAsync();
            return Results.Ok(audMan);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});


app.MapGet("/GetAuditDetailingsByCapaUserL2", async (string ResponsePersonId, string Token, auditContextObj db) =>
{
    List<AuditManagementL2> audMan = new List<AuditManagementL2>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await (from a in db.tbl_auditmanagementstddetail2.AsNoTracking()
                            join b in db.tbl_auditmanagementl2.AsNoTracking()
                            on a.AuditManId equals b.AuditManId
                            join c in db.tbl_auditobservationdetailsl2.AsNoTracking()
                            on a.StdDetailId equals c.StdDetailId
                            where c.ResponsPersonId == ResponsePersonId
                            select new AuditManagementDAL.DataModels.AuditManagementL2
                            {
                                AuditManId = a.AuditManId,
                                Operationunit = b.Operationunit,
                                AuditAreaId = b.AuditAreaId,
                                CreatedDate = b.CreatedDate,
                                CreatedBy = b.CreatedBy,
                                AuditeeId = b.AuditeeId,
                                FinancialYear = b.FinancialYear,
                                FinancialQuarter = b.FinancialQuarter,
                                AuditStartDate = b.AuditStartDate,
                                AuditEndDate = b.AuditEndDate,
                                CommiteeMemId = b.CommiteeMemId,
                                ExpectedAuditMonth = b.ExpectedAuditMonth,
                                AuditClosureDate = b.AuditClosureDate,
                                Status = b.Status,
                                AuditPlanUpdatedBy = b.AuditPlanUpdatedBy,
                                AuditPlanUpdatedDate = b.AuditPlanUpdatedDate,
                                AuditCode = b.AuditCode,
                                AuditPlanID = b.AuditPlanID,
                                AuditType = b.AuditType,
                                Remarks = b.Remarks,
                                DepartmentId = b.DepartmentId,
                            }).Distinct().ToListAsync();
            return Results.Ok(audMan);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});


app.MapGet("/GetAuditManagementCreatedByL2", async (string createdBy, string Token, auditContextObj db) =>
{
    List<AuditManagementL2> audMan = new List<AuditManagementL2>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditmanagementl2.Where(a => a.CreatedBy == createdBy).ToListAsync();
            return Results.Ok(audMan);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});


app.MapPost("/SaveAuditManagementL2", async (AuditManagementL2 auditMangement, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            db.tbl_auditmanagementl2.Add(auditMangement);
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Created($"/save/{auditMangement.AuditManId}", auditMangement);
});

app.MapPut("/UpdateAuditsL2/{AuditManId}", async (Guid AuditManId, AuditManagementL2 auditMaster, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            var auditExec = await db.tbl_auditmanagementl2.FindAsync(AuditManId);
            if (auditExec is null) return Results.NotFound();
            auditExec.AuditAreaId = auditMaster.AuditAreaId;
            auditExec.AuditClosureDate = auditMaster.AuditClosureDate;
            auditExec.AuditCode = auditMaster.AuditCode;
            auditExec.AuditPlanID = auditMaster.AuditPlanID;
            auditExec.AuditEndDate = auditMaster.AuditEndDate;
            auditExec.AuditPlanUpdatedDate = auditMaster.AuditPlanUpdatedDate;
            auditExec.AuditPlanUpdatedBy = auditMaster.AuditPlanUpdatedBy;
            auditExec.AuditeeId = auditMaster.AuditeeId;
            auditExec.AuditStartDate = auditMaster.AuditStartDate;
            auditExec.AuditType = auditMaster.AuditType;
            auditExec.CommiteeMemId = auditMaster.CommiteeMemId;
            auditExec.CreatedBy = auditMaster.CreatedBy;
            auditExec.DepartmentId = auditMaster.DepartmentId;
            auditExec.ExpectedAuditMonth = auditMaster.ExpectedAuditMonth;
            auditExec.FinancialQuarter = auditMaster.FinancialQuarter;
            auditExec.FinancialYear = auditMaster.FinancialYear;
            auditExec.Remarks=auditMaster.Remarks;
            auditExec.Status = auditMaster.Status;
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
        responseRet.Clear();
        return Results.Ok();
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});


#region "Audit Plan L2"
app.MapPost("/SaveAuditPlanL2", async (AuditCalenderL2 auditMangement, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            db.tbl_auditcalenderl2.Add(auditMangement);
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Created($"/save/{auditMangement.AuditplanId}", auditMangement);
});

app.MapPut("/UpdateAuditPlanL2/{AuditplanId}", async (Guid AuditplanId, AuditCalenderL2 auditMaster, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            var auditExec = await db.tbl_auditcalenderl2.FindAsync(AuditplanId);
            if (auditExec is null) return Results.NotFound();
            auditExec.AuditAreaId = auditMaster.AuditAreaId;
            auditExec.AuditClosureDate = auditMaster.AuditClosureDate;
            auditExec.AuditCode = auditMaster.AuditCode;
            auditExec.AuditEndDate = auditMaster.AuditEndDate;
            auditExec.AuditPlanUpdatedDate = auditMaster.AuditPlanUpdatedDate;
            auditExec.AuditPlanUpdatedBy = auditMaster.AuditPlanUpdatedBy;
            auditExec.AuditeeId = auditMaster.AuditeeId;
            auditExec.AuditStartDate = auditMaster.AuditStartDate;
            auditExec.AuditType = auditMaster.AuditType;
            auditExec.DepartmentId = auditMaster.DepartmentId;
            auditExec.FinancialQuarter = auditMaster.FinancialQuarter;
            auditExec.FinancialYear = auditMaster.FinancialYear;
            auditExec.CommitteeMemId = auditMaster.CommitteeMemId;
            auditExec.CreatedById = auditMaster.CreatedById;
            auditExec.CreatedDate = auditMaster.CreatedDate;
            auditExec.OperationUnit = auditMaster.OperationUnit;
            auditExec.ExpectedClosureMonth = auditMaster.ExpectedClosureMonth;
            auditExec.DocStatus=auditMaster.DocStatus;
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
        responseRet.Clear();
        return Results.Ok();
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});


app.MapGet("/GetAuditPlanCreatedByIdL2", async (string createdBy, string Token, auditContextObj db) =>
{
    List<AuditCalenderL2> audMan = new List<AuditCalenderL2>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditcalenderl2.Where(a => a.CreatedById == createdBy).ToListAsync();
            return Results.Ok(audMan);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

app.MapGet("/GetAuditCalByAuditCommMemL2", async (string commiteeMemId, string Token, auditContextObj db) =>
{
    List<AuditCalenderL2> audMan = new List<AuditCalenderL2>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditcalenderl2.Where(a => a.CommitteeMemId == commiteeMemId).ToListAsync();
            return Results.Ok(audMan);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

app.MapGet("/GetAuditCalendarDHL2", async (string auditeeId, string Token, auditContextObj db) =>
{
    List<AuditCalenderL2> audMan = new List<AuditCalenderL2>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditcalenderl2.Where(a => a.AuditeeId == auditeeId).ToListAsync();
            return Results.Ok(audMan);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

app.MapGet("/GetAuditCalendarDUL2", async (string auditorId, string Token, auditContextObj db) =>
{
    List<AuditCalenderL2> audMan = new List<AuditCalenderL2>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan= await (from a in db.tbl_auditcalendarstddetaill2.AsNoTracking()
                   join b in db.tbl_auditcalenderl2.AsNoTracking()
                   on a.AuditPlanId equals b.AuditplanId
                   where a.AuditorId == auditorId.Trim()
                   select new AuditManagementDAL.DataModels.AuditCalenderL2
                   {
                       AuditCode = b.AuditCode,
                       CreatedDate = b.CreatedDate,
                       CreatedById = b.CreatedById,
                       OperationUnit = b.OperationUnit,
                       AuditType = b.AuditType,
                       FinancialYear = b.FinancialYear,
                       FinancialQuarter = b.FinancialQuarter,
                       DepartmentId = b.DepartmentId,
                       AuditAreaId = b.AuditAreaId,
                       AuditeeId = b.AuditeeId,
                       AuditClosureDate = b.AuditClosureDate,
                       ExpectedClosureMonth = b.ExpectedClosureMonth,
                       AuditStartDate = b.AuditStartDate,
                       AuditEndDate = b.AuditEndDate,
                       CommitteeMemId = b.CommitteeMemId,
                       AuditPlanUpdatedBy = b.AuditPlanUpdatedBy,
                       AuditPlanUpdatedDate = b.AuditPlanUpdatedDate,
                       DocStatus = b.DocStatus,
                       AuditplanId=b.AuditplanId
                   }).Distinct().ToListAsync();
        }
      
        else
        {
            return Results.Unauthorized();
        }
        return Results.Ok(audMan);
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

app.MapGet("/GetAllAuditsL2", async (string Token, auditContextObj db) =>
{
    List<AuditManagementL2> auditManagement = new List<AuditManagementL2>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            auditManagement = await db.tbl_auditmanagementl2.ToListAsync();
            return Results.Ok(auditManagement);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

app.MapGet("/CheckAuditDataL2", async (Guid AreaId, string Audtype, string finyear, string qtr, string Token, auditContextObj db) =>
{
    // List<AuditCalenderL2> auditManagement = new List<AuditCalenderL2>();
    int countV = 0;
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            countV = db.tbl_auditcalenderl2.Where(a => a.AuditAreaId == AreaId && a.AuditType == Audtype && a.FinancialYear == finyear && a.FinancialQuarter == qtr).Count();
            return Results.Ok(countV);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();

});

app.MapPost("/SaveAuditCalendarStdDetailL2", async (AuditCalendarStdDetailL2 auditMangement, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            db.tbl_auditcalendarstddetaill2.Add(auditMangement);
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Created($"/save/{auditMangement.AuditPlanId}", auditMangement);
});

app.MapPut("/UpdateAuditCalendarStdDetailL2/{SafetyStandardId}", async (Guid StdDetailId, AuditCalendarStdDetailL2 auditMaster, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            var auditExec = await db.tbl_auditcalendarstddetaill2.FindAsync(StdDetailId);
            if (auditExec is null) return Results.NotFound();
            auditExec.StdSrlNo = auditMaster.StdSrlNo;
            auditExec.AuditorId = auditMaster.AuditorId;
            auditExec.Status = auditMaster.Status;
            auditExec.AuditPlanId = auditMaster.AuditPlanId;
            auditExec.StdDetailId = auditMaster.StdDetailId;
            auditExec.UpdatedBy = auditMaster.UpdatedBy;
            auditExec.UpdatedDate = auditMaster.UpdatedDate;
            auditExec.Remarks = auditMaster.Remarks;
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
        responseRet.Clear();
        return Results.Accepted();
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});


app.MapGet("/GetAuditCalendarStdDetailL2", async (Guid AuditPlanid, string Token, auditContextObj db) =>
{
    List<AuditCalendarStdDetailL2> audMan = new List<AuditCalendarStdDetailL2>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditcalendarstddetaill2.Where(a => a.AuditPlanId == AuditPlanid).ToListAsync();
            return Results.Ok(audMan);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

app.MapPost("/SaveAuditObservationDetailL2", async (AuditObservationDetailL2 auditMangement, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            db.tbl_auditobservationdetailsl2.Add(auditMangement);
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Created($"/save/{auditMangement.AuditMasterId}", auditMangement);
});

app.MapPut("/UpdateAuditObservationDetailL2/{AuditObsId}", async (Guid AuditObsId, AuditObservationDetailL2 auditMaster, string Token, auditContextObj db) =>
{
    List<AuditManagementDAL.DataModels.AuditObservationDetailL2> ilist = new List<AuditObservationDetailL2>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        var content = new ByteArrayContent(auditMaster.UploadedImg);
        auditMaster.UploadedImg = await content.ReadAsByteArrayAsync();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            var auditExec = db.tbl_auditobservationdetailsl2.Where(a=>a.AuditObsId==AuditObsId).FirstOrDefault();
            if (auditExec is null) return Results.NotFound();
            auditExec.SrlNo = auditMaster.SrlNo;
            auditExec.AuditObsId = auditMaster.AuditObsId;
            auditExec.AuditMasterId = auditMaster.AuditMasterId;
            auditExec.Severity = auditMaster.Severity;
            auditExec.StdDetailId = auditMaster.StdDetailId;
            auditExec.NarrationOb = auditMaster.NarrationOb;
            auditExec.RootCauseObsAuditor = auditMaster.RootCauseObsAuditor;
            auditExec.RootCauseObsAuditee = auditMaster.RootCauseObsAuditee;
            auditExec.CorrectiveAction = auditMaster.CorrectiveAction;
            auditExec.PreventiveAction = auditMaster.PreventiveAction;
            auditExec.ResponsPersonId = auditMaster.ResponsPersonId;
            auditExec.CompletionDate = auditMaster.CompletionDate;
            auditExec.UploadedImg = auditMaster.UploadedImg;
            auditExec.AuditStatus = auditMaster.AuditStatus;
            auditExec.ActivityLog = auditMaster.ActivityLog;
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
        responseRet.Clear();
        return Results.Accepted();
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

app.MapGet("/GetAuditObservationDetailL2", async (Guid StdDetailId, string Token, auditContextObj db) =>
{
    List<AuditObservationDetailL2> audMan = new List<AuditObservationDetailL2>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditobservationdetailsl2.Where(a => a.StdDetailId == StdDetailId).ToListAsync();
            return Results.Ok(audMan);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});


app.MapGet("/GetAuditObsDetailCapaL2", async (Guid StdDetailId,string ResponsePerId, string Token, auditContextObj db) =>
{
    List<AuditObservationDetailL2> audMan = new List<AuditObservationDetailL2>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditobservationdetailsl2.Where(a => a.StdDetailId == StdDetailId && a.ResponsPersonId==ResponsePerId).ToListAsync();
            return Results.Ok(audMan);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

app.MapPost("/SaveAuditManagementStdDetaiL2", async (AuditManagementStdDetaiL2 auditMangement, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            db.tbl_auditmanagementstddetail2.Add(auditMangement);
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Created($"/save/{auditMangement.AuditManId}", auditMangement);
});

app.MapPut("/UpdateAuditManagementStdDetaiL2/{StdDetailId}", async (Guid StdDetailId, AuditManagementStdDetaiL2 auditMaster, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            var auditExec = db.tbl_auditmanagementstddetail2.Where(a => a.StdDetailId == StdDetailId).FirstOrDefault();
            if (auditExec is null) return Results.NotFound();
            auditExec.StdSrlNo = auditMaster.StdSrlNo;
            auditExec.AuditorId = auditMaster.AuditorId;
            auditExec.Status = auditMaster.Status;
            auditExec.AuditManId = auditMaster.AuditManId;
            auditExec.StdDetailId = auditMaster.StdDetailId;
            auditExec.UpdatedBy = auditMaster.UpdatedBy;
            auditExec.UpdatedDate = auditMaster.UpdatedDate;
            auditExec.FileAttachment = auditMaster.FileAttachment;
            auditExec.Remarks = auditMaster.Remarks;
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
        responseRet.Clear();
        return Results.Accepted();
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

app.MapGet("/GetAuditManagementStdDetaiL2", async (Guid AuditManId, string Token, auditContextObj db) =>
{
    List<AuditManagementStdDetaiL2> audMan = new List<AuditManagementStdDetaiL2>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditmanagementstddetail2.Where(a => a.AuditManId == AuditManId).ToListAsync();
            return Results.Ok(audMan);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});


app.MapGet("/GetAuditManagementStdDetailCapaL2", async (Guid AuditManId, string ResponsePerId, string Token, auditContextObj db) =>
{
    List<AuditManagementStdDetaiL2> audMan = new List<AuditManagementStdDetaiL2>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await (from a in db.tbl_auditmanagementstddetail2.AsNoTracking()
                           join b in db.tbl_auditobservationdetailsl2.AsNoTracking()
                           on a.StdDetailId equals b.StdDetailId
                           where b.ResponsPersonId == ResponsePerId
                           select new AuditManagementDAL.DataModels.AuditManagementStdDetaiL2
                           {
                               AuditManId = a.AuditManId,
                               SafetyStandardId=a.SafetyStandardId,
                               StdSrlNo=a.StdSrlNo,
                               AuditorId=a.AuditorId,
                               Status=a.Status,
                               StdDetailId=a.StdDetailId,
                               UpdatedBy=a.UpdatedBy,
                               UpdatedDate=a.UpdatedDate,
                               FileAttachment=a.FileAttachment,
                               Remarks=a.Remarks
                           }).Distinct().ToListAsync();

            return Results.Ok(audMan);
        }    
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

#endregion "Audit Plan L2"

#endregion

#region "All Master"
#region "Department"
app.MapPost("/SaveDepartment", async (DepartmentMaster deptMaster, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            db.tbl_department_master.Add(deptMaster);
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Created($"/save/{deptMaster.DepartmentId}", deptMaster);
});

// get all audit calendar
app.MapGet("/GetAllDepartment", async (string Token, auditContextObj db) =>
{
    List<DepartmentMaster> depMast = new List<DepartmentMaster>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            depMast = await db.tbl_department_master.ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Ok(depMast);
});

// get specfic audit by id
app.MapGet("/GetDepartById/{DepartmentId}", async (Guid DepartmentId, auditContextObj db) =>
    await db.tbl_department_master.FindAsync(DepartmentId)
        is DepartmentMaster deptmnt
        ? Results.Ok(deptmnt)
        : Results.NotFound());

// update audit calendar by id
app.MapPut("/UpdateDepartment/{DepartmentCode}", async (string DepartmentCode, DepartmentMaster Departmnt, auditContextObj db) =>
{
    try
    {
        var departmnt = await db.tbl_department_master.FindAsync(DepartmentCode);
        if (departmnt is null) return Results.NotFound();
        departmnt.DepartmentName = Departmnt.DepartmentName;
        //  departmnt.DepartmentCode = Departmnt.DepartmentCode;
        departmnt.CreatedBy = Departmnt.CreatedBy;
        departmnt.OperationUnitCode = Departmnt.OperationUnitCode;
        await db.SaveChangesAsync();
        return Results.Ok();
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

app.MapDelete("/DeleteAuditDepartment/{DepartmentId}", async (Guid DepartmentId, auditContextObj db) =>
{
    if (await db.tbl_department_master.FindAsync(DepartmentId) is DepartmentMaster depat)
    {
        db.tbl_department_master.Remove(depat);
        await db.SaveChangesAsync();
        return Results.Ok(depat);
    }
    return Results.NotFound();
});
#endregion "Department"

#region "Audit Area"
app.MapPost("/SaveAuditArea", async (AuditArea auditArea, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            db.tbl_auditarea.Add(auditArea);
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Created($"/save/{auditArea.AuditAreaId}", auditArea);
});

// get all audit calendar
app.MapGet("/GetAllAuditAreas", async (string Token, auditContextObj db) =>
{
    List<AuditArea> auditAreas = new List<AuditArea>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            auditAreas = await db.tbl_auditarea.ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Ok(auditAreas);
});

// get specfic audit by id

app.MapGet("/GetAuditAreaById/{AuditAreaId}", async (Guid AuditAreaId, string Token, auditContextObj db) =>
{
    List<AuditArea> auditAreas = new List<AuditArea>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            auditAreas = await db.tbl_auditarea.Where(a => a.AuditAreaId == AuditAreaId).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (auditAreas.Count > 0)
    {
        Results.Ok(auditAreas);
    }
    else
    {
        Results.NotFound();
    }
    return Results.Ok(auditAreas);
});

app.MapGet("/GetAuditAreaById/{DepartmentId}", async (int DepartId, string Token, auditContextObj db) =>
{
    List<AuditArea> auditAreas = new List<AuditArea>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            auditAreas = await db.tbl_auditarea.Where(a => a.DepartmentId == DepartId).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (auditAreas.Count > 0)
    {
        Results.Ok(auditAreas);
    }
    else
    {
        Results.NotFound();
    }
    return Results.Ok(auditAreas);
});

// update audit calendar by id

app.MapPut("/UpdateAuditArea/{AuditAreaId}", async (string AuditAreaId, AuditArea auditArea, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            var auditarea = await db.tbl_auditarea.FindAsync(AuditAreaId);
            if (auditarea is null) return Results.NotFound();
            auditarea.AreaName = auditArea.AreaName;
            auditarea.DepartmentId = auditArea.DepartmentId;
            auditarea.AreaCode = auditArea.AreaCode;
            auditarea.UpdatedDate = auditArea.UpdatedDate;
            auditarea.CreatedBy = auditArea.CreatedBy;
            auditarea.OperationUnitId = auditarea.OperationUnitId;
            await db.SaveChangesAsync();
            return Results.Ok();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NoContent();
});

app.MapDelete("/DeleteAuditArea/{AuditAreaId}", async (Guid AuditAreaId, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            if (await db.tbl_auditarea.FindAsync(AuditAreaId) is AuditArea auArea)
            {
                db.tbl_auditarea.Remove(auArea);
                await db.SaveChangesAsync();
                return Results.Ok(auArea);
            }
            else
            {
                return Results.Unauthorized();
            }
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});
#endregion "Audit Area"

#region "Audit Plan"
app.MapPost("/SaveAuditPlan", async (AuditPlan auditPlan, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            db.tbl_auditplan.Add(auditPlan);
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Created($"/save/{auditPlan.AuditplanId}", auditPlan);
});

// get all audit calendar
app.MapGet("/GetAllAuditPlans", async (string Token, auditContextObj db) =>
{
    List<AuditPlan> auditPlans = new List<AuditPlan>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            auditPlans = await db.tbl_auditplan.ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    //  return Results.Ok(auditPlans);
    if (auditPlans.Count > 0)
    {
        return Results.Ok(auditPlans);
    }
    else
    {
        return Results.NotFound();
    }
});

// get specfic audit by id
// gets audit calendar as against to the one who created it.
app.MapGet("/GetAuditPlanById", async (string CreatorId, string Token, auditContextObj db) =>
{
    List<AuditPlan> audPlan = new List<AuditPlan>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audPlan = await db.tbl_auditplan.Where(a => a.CreatedBy == CreatorId).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    //  return Results.Ok(auditPlans);
    if (audPlan.Count > 0)
    {
        return Results.Ok(audPlan);
    }
    else
    {
        return Results.NotFound();
    }
});

// update audit calendar by id

app.MapPut("/UpdateAuditPlan/", async (Guid AuditPlanId, AuditPlan auditPlan, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            var auditplan = await db.tbl_auditplan.FindAsync(AuditPlanId);
            if (auditplan is null) return Results.NotFound();
            auditplan.AuditStartDate = auditPlan.AuditStartDate;
            auditplan.AuditType = auditPlan.AuditType;
            auditplan.AuditEndDate = auditPlan.AuditEndDate;
            auditplan.AuditorId = auditPlan.AuditorId;
            auditplan.AuditCode = auditPlan.AuditCode;
            auditplan.AuditClosureDate = auditPlan.AuditClosureDate;
            auditplan.CommitteeMemId = auditPlan.CommitteeMemId;
            auditplan.AuditeeId = auditPlan.AuditeeId;
            auditplan.CreatedBy = auditPlan.CreatedBy;
            auditplan.FinancialYear = auditPlan.FinancialYear;
            auditplan.OperationUnit = auditPlan.OperationUnit;
            auditplan.FinancialQuarter = auditPlan.FinancialQuarter;
            auditplan.DocStatus = auditPlan.DocStatus;
            auditplan.AuditplanId = auditPlan.AuditplanId;
            auditplan.AuditPlanUpdatedDate = auditPlan.AuditPlanUpdatedDate;
            auditplan.AuditPlanUpdatedBy = auditPlan.AuditPlanUpdatedBy;
            auditplan.CreatedDate = auditPlan.CreatedDate;
            auditplan.DepartmentId = auditPlan.DepartmentId;
            auditplan.ExpectedClosureMonth = auditPlan.ExpectedClosureMonth;
            auditplan.AuditAreaId = auditPlan.AuditAreaId;
            await db.SaveChangesAsync();
            return Results.Accepted($"/update/{auditPlan.AuditplanId}", auditPlan);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

app.MapDelete("/DeleteAuditPlan/{AuditPlanId}", async (Guid AuditPlanId, [FromBody] AuditPlanTemp auditplanTmp, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.NotFound();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            if (await db.tbl_auditplan.FindAsync(AuditPlanId) is AuditPlan auditplan)
            {
                try
                {
                    AuditPlanHistory audhistory = GenerateAuditModel(auditplan, auditplanTmp);
                    db.tbl_auditplanhistory.Add(audhistory);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    WriteToFile(ex.Message + "\n" + ex.StackTrace);
                }
                db.tbl_auditplan.Remove(auditplan);
                await db.SaveChangesAsync();
                return Results.Ok(auditplan);
            }
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

app.MapGet("/GetAuditCalByAuditCommMem", async (string CommiteeMemId, string Token, auditContextObj db) =>
{
    List<AuditPlan> audMan = new List<AuditPlan>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditplan.Where(a => a.CommitteeMemId == CommiteeMemId).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audMan.Count > 0)
    {
        return Results.Ok(audMan);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/GetAuditcalDataCreatedByStatus/{CreatedBy}", async (string CreatorId, int Status, string Token, auditContextObj db) =>
{
    List<AuditPlan> audMan = new List<AuditPlan>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditplan.Where(a => a.CreatedBy == CreatorId && a.DocStatus == Status).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audMan.Count > 0)
    {
        return Results.Ok(audMan);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/GetAuditcalDataCommMemStatus/{CreatedBy}", async (string CommitteeMenId, int Status, string Token, auditContextObj db) =>
{
    List<AuditPlan> audMan = new List<AuditPlan>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditplan.Where(a => a.CommitteeMemId == CommitteeMenId && a.DocStatus == Status).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audMan.Count > 0)
    {
        return Results.Ok(audMan);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/GetAuditcalDataDHStatus/{CreatedBy}", async (string AuditteeId, int Status, string Token, auditContextObj db) =>
{
    List<AuditPlan> audMan = new List<AuditPlan>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditplan.Where(a => a.AuditeeId == AuditteeId && a.DocStatus == Status).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audMan.Count > 0)
    {
        return Results.Ok(audMan);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/GetAuditCalByCreatedBy/{CreatedBy}", async (string CreatedById, string Token, auditContextObj db) =>
{
    List<AuditPlan> audMan = new List<AuditPlan>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditplan.Where(a => a.CreatedBy == CreatedById).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audMan.Count > 0)
    {
        return Results.Ok(audMan);
    }
    else
    {
        return Results.NotFound();
    }
});


app.MapGet("/GetAuditManagementByDU/{CreatedBy}", async (string AuditorId, int Status, string Token, auditContextObj db) =>

{
    List<AuditManagement> audMan = new List<AuditManagement>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditmanagement.Where(a => a.AuditorId == AuditorId && a.Status == Status).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audMan.Count > 0)
    {
        return Results.Ok(audMan);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/GetAuditManagementByDH/{CreatedBy}", async (string AuditeeId, int Status, string Token, auditContextObj db) =>
{
    List<AuditManagement> audMan = new List<AuditManagement>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditmanagement.Where(a => a.AuditeeId == AuditeeId && a.Status == Status).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audMan.Count > 0)
    {
        return Results.Ok(audMan);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/GetAuditManagementByAuditCommMem/{CreatedBy}", async (string CommitteeMemId, int Status, string Token, auditContextObj db) =>
{
    List<AuditManagement> audMan = new List<AuditManagement>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditmanagement.Where(a => a.CommiteeMemId == CommitteeMemId && a.Status == Status).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audMan.Count > 0)
    {
        return Results.Ok(audMan);
    }
    else
    {
        return Results.NotFound();
    }
});


app.MapGet("/GetAuditManagementByCreatedBy/{CreatedBy}", async (string CreatedBy, int Status, string Token, auditContextObj db) =>
{
    List<AuditManagement> audMan = new List<AuditManagement>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditmanagement.Where(a => a.CreatedBy == CreatedBy && a.Status == Status).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audMan.Count > 0)
    {
        return Results.Ok(audMan);
    }
    else
    {
        return Results.NotFound();
    }
});

#endregion "Audit Plan"

#region "Auditee Assigned"

app.MapPost("/SaveAuditeeAssigned", async (AuditAssignee auditAssignee, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            db.tbl_auditassignee.Add(auditAssignee);
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Created($"/save/{auditAssignee.AssigneeFindId}", auditAssignee);
});

// get all audit calendar
app.MapGet("/GetAllAuditAssignee", async (auditContextObj db) =>
 await db.tbl_auditassignee.ToListAsync());

// get specfic audit by id

app.MapGet("/GetAuditAssigneeById/{AssigneeFindId}", async ([FromQuery] string AssigneeFindId, string Token, auditContextObj db) =>
{
    List<AuditPlan> audMan = new List<AuditPlan>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditplan.Where(a => a.AuditCode == AssigneeFindId).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audMan.Count > 0)
    {
        return Results.Ok(audMan);
    }
    else
    {
        return Results.NotFound();
    }
});

// update audit calendar by id

app.MapPut("/UpdateAuditAssignee/{AssigneeFindId}", async (Guid AssigneeFindId, AuditAssignee auditAssignee, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            var auditassignee = await db.tbl_auditassignee.FindAsync(AssigneeFindId);
            if (auditassignee is null) return Results.NotFound();
            auditassignee.AuditeeId = auditAssignee.AuditeeId;
            auditassignee.AssignedDate = auditAssignee.AssignedDate;
            auditassignee.AssignedTo = auditAssignee.AssignedTo;
            auditassignee.AuditeeStatus = auditAssignee.AuditeeStatus;
            await db.SaveChangesAsync();
            return Results.Ok();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

app.MapDelete("/DeleteAuditAssignee/{AssigneeFindId}", async (Guid AssigneeFindId, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            if (await db.tbl_auditassignee.FindAsync(AssigneeFindId) is AuditAssignee auAssign)
            {
                db.tbl_auditassignee.Remove(auAssign);
                await db.SaveChangesAsync();
                return Results.Ok(auAssign);
            }
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});
#endregion "Auditee Assigned"

#region "Audit Category"

app.MapPost("/SaveAuditCategory", async (AuditCategory auditCat, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            db.tbl_auditcategory.Add(auditCat);
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Created($"/save/{auditCat.AuditCategoryId}", auditCat);
});

// get all audit calendar
app.MapGet("/GetAllAuditCategories", async (string Token, auditContextObj db) =>
{
    List<AuditCategory> audCat = new List<AuditCategory>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audCat = await db.tbl_auditcategory.ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audCat.Count > 0)
    {
        return Results.Ok(audCat);
    }
    else
    {
        return Results.NoContent();
    }
});

// get specfic audit by id

app.MapGet("/GetAuditCategoryById/{AuditCategoryCode}", async (string AuditCategoryCode, string Token, auditContextObj db) =>
{
    List<AuditCategory> audList = new List<AuditCategory>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audList = await db.tbl_auditcategory.Where(a => a.AuditCategoryCode == AuditCategoryCode).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audList.Count > 0)
    {
        return Results.Ok(audList);
    }
    else
    {
        return Results.NotFound();
    }
});

// update audit calendar by id

app.MapPut("/UpdateAuditCategory/{AuditCategoryId}", async (Guid AuditCategoryId, AuditCategory auditCat, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            var auditcat = await db.tbl_auditcategory.FindAsync(AuditCategoryId);
            if (auditcat is null) return Results.NotFound();
            auditcat.AuditCategoryName = auditCat.AuditCategoryName;
            auditcat.AuditCategoryCode = auditCat.AuditCategoryCode;
            await db.SaveChangesAsync();
            return Results.Ok();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

app.MapDelete("/DeleteAuditCategory/{AuditCategoryId}", async (Guid AuditCategoryId, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            if (await db.tbl_auditcategory.FindAsync(AuditCategoryId) is AuditCategory auCategory)
            {
                db.tbl_auditcategory.Remove(auCategory);
                await db.SaveChangesAsync();
                return Results.Ok(auCategory);
            }
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});
#endregion "Audit Category"

#region "Audit Execution Plan"

app.MapPost("/SaveAuditExecutionPlan", async (AuditExecutionPlan auditExecPlan, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            db.tbl_auditexecutionplan.Add(auditExecPlan);
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Created($"/save/{auditExecPlan.AuditExecutionId}", auditExecPlan);
});

// get all audit calendar
app.MapGet("/GetAllAuditExecutionPlan", async (string Token, auditContextObj db) =>
{
    List<AuditExecutionPlan> audExec = new List<AuditExecutionPlan>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audExec = await db.tbl_auditexecutionplan.ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }

    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audExec.Count > 0)
    {
        return Results.Ok(audExec);
    }
    else
    {
        return Results.NotFound();
    }
});

// get specfic audit by id

app.MapGet("/GetAuditExecutionPlanById/{AuditExecutionId}", async (int AuditExecutionId, string Token, auditContextObj db) =>
{
    List<AuditExecutionPlan> audExec = new List<AuditExecutionPlan>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audExec = await db.tbl_auditexecutionplan.Where(a => a.AuditExecutionId == AuditExecutionId).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audExec.Count > 0)
    {
        return Results.Ok(audExec);
    }
    else
    {
        return Results.NotFound();
    }
});
// update audit calendar by id

app.MapPut("/UpdateAuditExectionPlan/{AuditExecutionId}", async (string AuditExecutionId, AuditExecutionPlan auditexecPlan, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            var auditExec = await db.tbl_auditexecutionplan.FindAsync(AuditExecutionId);
            if (auditExec is null) return Results.NotFound();
            auditExec.AuditeeRCA = auditexecPlan.AuditeeRCA;
            auditExec.AuditorRCA = auditexecPlan.AuditorRCA;
            auditExec.AuditPlanId = auditexecPlan.AuditPlanId;
            auditExec.AuditClosureDate = auditexecPlan.AuditClosureDate;
            auditExec.DeviationStandard = auditexecPlan.DeviationStandard;
            auditExec.SnapshotImg = auditexecPlan.SnapshotImg;
            auditExec.NarrationOfObservation = auditexecPlan.NarrationOfObservation;
            await db.SaveChangesAsync();
            return Results.Ok();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});


app.MapDelete("/DeleteAuditExecutionPlan/{AuditExecutionId}", async (int AuditExecutionId, [FromBody] AuditExecutionTemp audExecTemp, string Token, auditContextObj db) =>
{
    AuditExecPlanHistory audHistory = null;
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            if (await db.tbl_auditexecutionplan.FindAsync(AuditExecutionId) is AuditExecutionPlan auditExecution)
            {
                audHistory = GenerateAuditExecPlan(auditExecution, audExecTemp);
                db.tbl_auditexecutionhistory.Add(audHistory);
                await db.SaveChangesAsync();
                db.tbl_auditexecutionplan.Remove(auditExecution);
                await db.SaveChangesAsync();
            }
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Ok(audHistory);
});

#endregion "Audit Execution Plan"

#region "Operation Unit"
app.MapPost("/SaveOperationUnit", async (OperationUnit opUnit, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            db.tbl_operationunit.Add(opUnit);
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Created($"/save/{opUnit.OperationUnitCode}", opUnit);
});

// get all  operation unit
app.MapGet("/GetoperationUnit", async (auditContextObj db) =>
    await db.tbl_operationunit.ToListAsync());

// get specfic operation unit by code
app.MapGet("/GetOperationUnitByCode/{OperationCode}", async (Guid OperationCode, string Token, auditContextObj db) =>
{
    List<OperationUnit> opUnit = new List<OperationUnit>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            opUnit = await db.tbl_operationunit.Where(a => a.OperationUnitCode == OperationCode).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (opUnit.Count > 0)
    {
        return Results.Ok(opUnit);
    }
    else
    {
        return Results.NotFound();
    }
});

// update Operation Unit by code

app.MapPut("/UpdateOperationUnit/{OperationCode}", async (string OperationCode, OperationUnit opUnit, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            var operationunit = await db.tbl_operationunit.FindAsync(opUnit);
            if (operationunit is null) return Results.NotFound();
            operationunit.OperationUnitName = opUnit.OperationUnitName;
            await db.SaveChangesAsync();
            return Results.Ok();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

app.MapDelete("/DeleteAuditOperationUnit/{OperationCode}", async (string OperationCode, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            if (await db.tbl_operationunit.FindAsync(OperationCode) is OperationUnit opUnit)
            {
                db.tbl_operationunit.Remove(opUnit);
                await db.SaveChangesAsync();
                return Results.Ok(opUnit);
            }
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

#endregion "Operation Unit"

#endregion "All Masters"

#region "Audit Plan"

//app.MapGet("/CheckAuditData/{DepartmentId}", async ([FromQuery] int DepartmentId, string AuditType, string AuditYear, string AuditQuarter,string Token, auditContextObj db) =>
//{
//    int count = 0;
//    try
//    {
//        responseRet = ValidateInputToken(Token);
//        if (responseRet.Count == 0) return Results.BadRequest();
//        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
//        {
//            count = db.tbl_auditPlan.Where(a => a.DepartmentId == DepartmentId && a.AuditType == AuditType && a.FinancialYear == AuditYear && a.FinancialQuarter == AuditQuarter).Count();
//        }
//        else
//        {
//            return Results.Unauthorized();
//        }
//    }
//    catch (Exception ex)
//    {
//        WriteToFile(ex.Message + "\n" + ex.StackTrace);
//    }
//    return Results.Ok(count);
//});

app.MapGet("/CheckAuditData/{AreaId}", (Guid AreaId, string AuditType, string AuditYear, string AuditQuarter, string Token, auditContextObj db) =>
{
    int count = 0;
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            count = db.tbl_auditplan.Where(a => a.AuditAreaId == AreaId && a.AuditType == AuditType && a.FinancialYear == AuditYear && a.FinancialQuarter == AuditQuarter).Count();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Ok(count);
});
//// Audit Document code generation
/// Generates Audit document code for different Modules like audit management,audit management details, audit plan etc
/// No. of parameter=5
/// parameter names -AudCode,AuditRequestType,FinYear,AudType and last is the dbcontext model
/// AudCode is the Prefix object, AuditRequestType is the Module name ,AudType is whther L1 or L2 or L3
app.MapGet("/GeneratAutoDocumentPlan", async (string AudCode, string AuditRequestType, string FinYear, string AudType, string Token, auditContextObj db) =>
{
    int Startcode = 1;
    string GenCode = string.Empty;
    string audcode = AudCode + "/" + FinYear + "/" + AudType + "-";
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            if (AuditRequestType == "AuditCalendar")
            {
                //  int preCount = 0;
                //  int preCount = db.tbl_auditPlan.Where(x => x.AuditCode == audcode).Count();
                int preCount = db.tbl_auditplan.Count();
                Startcode = preCount + 1;
            }
            if (AuditRequestType == "AuditManagement")
            {
                // int preCount = db.tbl_auditManagement.Where(x => x.AuditCode == audcode).Count();
                int preCount = db.tbl_auditmanagement.Count();
                Startcode = preCount + 1;
            }
            if (AuditRequestType == "AuditManagementDetails")
            {
                int preCount = db.tbl_auditmanagementdetails.Count();
                Startcode = preCount + 1;
            }
            if (AuditRequestType == "AuditCalendarL2")
            {
                //  int preCount = db.tbl_auditManagementDetails.Where(a => a.AuditCode == audcode).Count();
                int preCount = db.tbl_auditcalenderl2.Where(a=>a.FinancialYear== FinYear).Count();
                Startcode = preCount + 1;
            }
            int lenth = Startcode.ToString().Length;
            if (Startcode < 10 && lenth == 1)
            {
                GenCode = audcode + "000" + Startcode;
            }
            if (Startcode > 9 && lenth == 2)
            {
                GenCode = audcode + "00" + Startcode;
            }
            if (lenth == 3)
            {
                GenCode = audcode + "0" + Startcode;
            }
            if (lenth > 3)
            {
                GenCode = audcode + Startcode;
            }
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Content(GenCode);
});

app.MapGet("/GeneratCalStdAutoDocDetailL2", async (string AudCode, string AudReqType, Guid AuditPlanId, string Token, auditContextObj db) =>
{
    int Startcode = 1;
    string GenCode = string.Empty;
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            if (AudReqType == "AuditCalendarStdDetailL2")
            {
                int preCount = db.tbl_auditcalendarstddetaill2.Where(a => a.AuditPlanId == AuditPlanId).Count();
                Startcode = preCount + 1;
                GenCode = GenerateCode(AudCode, Startcode);
            }

            if (AudReqType == "AuditObservationDetailL2")
            {
                int preCount = db.tbl_auditobservationdetailsl2.Where(a => a.StdDetailId == AuditPlanId).Count();
                Startcode = preCount + 1;
                GenCode = GenerateCode(AudCode, Startcode);
            }
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (GenCode != "")
    {
        return Results.Content(GenCode);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/GeneratAutoDocumentDetail", async (string AudCode, string AudType, Guid AuditManId, string Token, auditContextObj db) =>
{
    int Startcode = 1;
    string GenCode = string.Empty;
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            if (AudType == "AuditManagementDetails")
            {
                //  int preCount = db.tbl_auditPlan.Where(x => x.AuditCode == audcode).Count();
                int preCount = db.tbl_auditmanagementdetails.Where(a => a.AuditManId == AuditManId).Count();
                Startcode = preCount + 1;
                GenCode = GenerateCode(AudCode, Startcode);
            }
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (GenCode != "")
    {
        return Results.Content(GenCode);
    }
    else
    {
        return Results.NotFound();
    }
});


app.MapGet("/GetAuditCalendarDH", async (string AuditeeId, int DocStatus, string Token, auditContextObj db) =>
{
    List<AuditPlan> audPlan = new List<AuditPlan>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audPlan = await db.tbl_auditplan.Where(a => a.AuditeeId == AuditeeId && a.DocStatus == DocStatus).ToListAsync();//&& a.AuditType==AuditType)
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audPlan.Count > 0)
    {
        return Results.Ok(audPlan);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/GetAuditCalendarDU", async (string AuditorId, int DocStatus, string Token, auditContextObj db) =>
{
    List<AuditPlan> audPlan = new List<AuditPlan>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audPlan = await db.tbl_auditplan.Where(a => a.AuditorId == AuditorId && a.DocStatus == DocStatus).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audPlan.Count > 0)
    {
        return Results.Ok(audPlan);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/GetAuditCommiteeMembData", async (string AuditComMebId, string Token, auditContextObj db) =>
{
    List<AuditPlan> auditPlan = new List<AuditPlan>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            auditPlan = await db.tbl_auditplan.Where(a => a.CommitteeMemId == AuditComMebId).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (auditPlan.Count > 0)
    {
        return Results.Ok(auditPlan);
    }
    else
    {
        return Results.NotFound();
    }
});


app.MapGet("/GetAuditCalendarDHExt", async (string AuditeeId, string Token, auditContextObj db) =>
{
    List<AuditPlan> auditPlans = new List<AuditPlan>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            auditPlans = await db.tbl_auditplan.Where(a => a.AuditeeId == AuditeeId).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (auditPlans.Count > 0)
    {
        return Results.Ok(auditPlans);
    }
    else
    {
        return Results.NotFound();
    }
});


app.MapGet("/GetAuditCalByCreator", async (string CreatedBy, string Token, auditContextObj db) =>
{
    List<AuditPlan> auditPlans = new List<AuditPlan>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            auditPlans = await db.tbl_auditplan.Where(a => a.CreatedBy == CreatedBy).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (auditPlans.Count > 0)
    {
        return Results.Ok(auditPlans);
    }
    else
    {
        return Results.NotFound();
    }
});
string GenerateCode(string StCode, int StNo)
{
    string retCode = string.Empty;
    try
    {
        int lenth = StCode.ToString().Length;
        if (StNo < 10 && lenth == 1)
        {
            retCode = StCode + "000" + StNo;
        }
        if (StNo > 9 && lenth == 2)
        {
            retCode = StCode + "00" + StNo;
        }
        if (lenth == 3)
        {
            retCode = StCode + "0" + StNo;
        }
        if (lenth > 3)
        {
            retCode = StCode + StNo;
        }
        retCode = StCode + "00" + StNo;
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return retCode;
}

string GenerateDocCode(string StCode, int StNo)
{
    string retCode = string.Empty;
    try
    {
        if (StNo >= 10)
        {
            retCode = StCode + "/" + StNo;
        }
        else
        {
            return retCode = StCode + "/" + "000" + StNo;
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return retCode;
}

#endregion "Audit Plan"

#region "Audit Plan Detailing"

app.MapPost("/SaveAuditdetailing", async (AuditManagementDetails amD, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            var content = new ByteArrayContent(amD.UploadedImg);
            amD.UploadedImg = await content.ReadAsByteArrayAsync();
            db.tbl_auditmanagementdetails.Add(amD);
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Created($"/save/{amD.SrlNo}", amD);
});

// get all  operation unit async
app.MapGet("/GetAuditDetailingsByCapaUser", async (string ResponsPersonId, string Token, auditContextObj db) =>
{
    List<AuditManagement> nList = new List<AuditManagement>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
           
            nList = await (from a in db.tbl_auditmanagementdetails.AsNoTracking()
                           join b in db.tbl_auditmanagement.AsNoTracking()
                           on a.AuditManId equals b.AuditManId
                           where a.ResponsPersonId == ResponsPersonId.Trim()
                           select new AuditManagementDAL.DataModels.AuditManagement
                           {
                               AuditManId = a.AuditManId,
                               Operationunit = b.Operationunit,
                               AuditAreaId = b.AuditAreaId,
                               CreatedDate = b.CreatedDate,
                               CreatedBy = b.CreatedBy,
                               AuditorId = b.AuditorId,
                               FinancialYear = b.FinancialYear,
                               FinancialQuarter = b.FinancialQuarter,
                               AuditStartDate = b.AuditStartDate,
                               AuditEndDate = b.AuditEndDate,
                               CommiteeMemId = b.CommiteeMemId,
                               AuditeeId = b.AuditeeId,
                               ExpectedAuditMonth = b.ExpectedAuditMonth,
                               AuditClosureDate = b.AuditClosureDate,
                               Status = b.Status,
                               AuditPlanUpdatedBy = b.AuditPlanUpdatedBy,
                               AuditPlanUpdatedDate = b.AuditPlanUpdatedDate,
                               AuditCode = b.AuditCode,
                               AuditPlanID = b.AuditPlanID,
                               AuditType = b.AuditType,
                               Remarks = b.Remarks,
                               DepartmentId = b.DepartmentId,
                               AttachedFile = b.AttachedFile,
                               
                           }).Distinct().ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Ok(nList);
});
// db.tbl_auditManagementDetails.Include(a => a.auditManagements).ToListAsync());

// get specfic operation unit by code

app.MapGet("/GetAuditDetailingsById/{SrlNo}", async (string SrlNo, string Token, auditContextObj db) =>
{
    List<AuditManagementDetails> audDetails = new List<AuditManagementDetails>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audDetails = await db.tbl_auditmanagementdetails.Where(a => a.SrlNo == SrlNo).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }

    if (audDetails.Count > 0)
    {
        return Results.Ok(audDetails);
    }
    else
    {
        return Results.NotFound();
    }
});


app.MapGet("/GetAuditDetailingsByManId/{AuditManId}", async (Guid AuditManId, string Token, auditContextObj db) =>
{
    List<AuditManagementDetails> audDetails = new List<AuditManagementDetails>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audDetails = await db.tbl_auditmanagementdetails.Where(a => a.AuditManId == AuditManId).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }

    if (audDetails.Count > 0)
    {
        return Results.Ok(audDetails);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapDelete("/DeleteAuditManageDetails/{AuditManDetId}", async (Guid AuditManDetId, [FromBody] AuditManagementDetailsTemp auditManagTmp, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            if (await db.tbl_auditmanagementdetails.FindAsync(AuditManDetId) is AuditManagementDetails auditMan)
            {
                //######## saving details to history table before deletion from base table #########
                AuditManagementDetHistory audHistory = GenerateAuditDetailsModel(auditMan, auditManagTmp);
                db.tbl_auditmanagementdetailshistory.Add(audHistory);
                await db.SaveChangesAsync();
                //########## Remove details from base table #########
                db.tbl_auditmanagementdetails.Remove(auditMan);
                await db.SaveChangesAsync();
                return Results.Ok(auditMan);
            }
        }
        else
        {
            return Results.Unauthorized();
        }

    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});


app.MapGet("/GetAuditManagementDetail/{ResponsiblePersonId}", async (string ResponsiblePersonId, int AuditStatus, string Token, auditContextObj db) =>
{
    List<AuditManagementDetails> audDetails = new List<AuditManagementDetails>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audDetails = await db.tbl_auditmanagementdetails.Where(a => a.ResponsPersonId == ResponsiblePersonId && a.AuditStatus == AuditStatus).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audDetails.Count > 0)
    {
        return Results.Ok(audDetails);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/GetAuditMgmtDetailByCapaUserId/{ResponsiblePersonId}", async (Guid AuditManid, string ResponsiblePersonId, string Token, auditContextObj db) =>
{
    List<AuditManagementDetails> audDetails = new List<AuditManagementDetails>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audDetails = await db.tbl_auditmanagementdetails.Where(a => a.ResponsPersonId == ResponsiblePersonId && a.AuditManId == AuditManid).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audDetails.Count > 0)
    {
        return Results.Ok(audDetails);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/GetAuditManagementByFinYear/{FinancialYear}", async (string FinancialYear, string Token, auditContextObj db) =>
{
    List<AuditManagement> audMan = new List<AuditManagement>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditmanagement.Where(a => a.FinancialYear == FinancialYear).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audMan.Count > 0)
    {
        return Results.Ok(audMan);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/GetAuditManagementByDeptId/{DeptId}", async (int DeptId, string Token, auditContextObj db) =>
{
    List<AuditManagement> audMan = new List<AuditManagement>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditmanagement.Where(a => a.DepartmentId == DeptId).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audMan.Count > 0)
    {
        return Results.Ok(audMan);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/CheckAuditDetailClosedData/{AuditManId}", async (Guid AuditManid, string Token, auditContextObj db) =>
{
    int valtoReturn = 0;
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            int totalOccur = db.tbl_auditmanagementdetails.Where(a => a.AuditManId == AuditManid).Count();
            int totalCount = db.tbl_auditmanagementdetails.Where(a => a.AuditManId == AuditManid && a.AuditStatus == 6).Count();
            if (totalOccur == totalCount)
            {
                valtoReturn = 1;
            }
            else
            {
                valtoReturn = 0;
            }
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Content(valtoReturn.ToString());
});

app.MapGet("/GetAuditManagementByAuditType/{AuditType}", async (string AuditType, string Token, auditContextObj db) =>
{
    List<AuditManagement> audMan = new List<AuditManagement>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audMan = await db.tbl_auditmanagement.Where(a => a.AuditType == AuditType).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audMan.Count > 0)
    {
        return Results.Ok(audMan);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/GetAuditCalenderByFinYear/{FinancialYear}", async (string FinancialYear, string Token, auditContextObj db) =>
{
    List<AuditPlan> audPlan = new List<AuditPlan>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audPlan = await db.tbl_auditplan.Where(a => a.FinancialYear == FinancialYear).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audPlan.Count > 0)
    {
        return Results.Ok(audPlan);
    }
    else
    {
        return Results.NotFound();
    }
});


app.MapGet("/GetAuditCalenderByAuditType/{AuditType}", async (string AuditType, string Token, auditContextObj db) =>
{
    List<AuditPlan> audPlan = new List<AuditPlan>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audPlan = await db.tbl_auditplan.Where(a => a.AuditType == AuditType).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audPlan.Count > 0)
    {
        return Results.Ok(audPlan);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/CheckAuditDetailSubmittedData/{AuditManId}", async (Guid AuditManId, string Token, auditContextObj db) =>
{
    int ret = 0;
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            ret = db.tbl_auditmanagement.Where(a => a.AuditManId == AuditManId).Count();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Content(ret.ToString());
});

app.MapGet("/GetAuditCalenderByPlanId/{AuditPlanId}", async (Guid AuditPlanId, string Token, auditContextObj db) =>
{
    List<AuditPlan> audPlan = new List<AuditPlan>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audPlan = await db.tbl_auditplan.Where(a => a.AuditplanId == AuditPlanId).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audPlan.Count > 0)
    {
        return Results.Ok(audPlan);
    }
    else
    {
        return Results.NotFound();
    }
});
// update Operation Unit by code

app.MapPut("/UpdateAuditDetailsTbl/{AuditManDetId}", async (Guid AuditManDetId, AuditManagementDetails opUnit, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        var content = new ByteArrayContent(opUnit.UploadedImg);
        opUnit.UploadedImg = await content.ReadAsByteArrayAsync();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            var audDetails = await db.tbl_auditmanagementdetails.FindAsync(AuditManDetId);
            if (audDetails is null) return Results.NotFound();
            audDetails.CompletionDate = opUnit.CompletionDate;
            audDetails.NarrationOb = opUnit.NarrationOb;
            audDetails.AuditStatus = opUnit.AuditStatus;
            audDetails.ResponsPersonId = opUnit.ResponsPersonId;
            audDetails.CateOfObs = opUnit.CateOfObs;
            audDetails.CorrectiveAction = opUnit.CorrectiveAction;
            audDetails.DeviaSafetyStd = opUnit.DeviaSafetyStd;
            audDetails.PreventiveAction = opUnit.PreventiveAction;
            audDetails.UploadedImg = opUnit.UploadedImg;
            audDetails.RootCauseObsAuditor = opUnit.RootCauseObsAuditor;
            audDetails.RootCauseObsAuditee = opUnit.RootCauseObsAuditee;
            audDetails.RiskCategory = opUnit.RiskCategory;
            audDetails.SrlNo = opUnit.SrlNo;
            audDetails.AuditMasterId = opUnit.AuditMasterId;
            await db.SaveChangesAsync();
            return Results.Ok();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

app.MapGet("/GetAuditByCapaUser", async (string PersonResponsibleId, string Token, auditContextObj db) =>
{
    List<AuditManagementDetails> audDetails = new List<AuditManagementDetails>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            audDetails = await db.tbl_auditmanagementdetails.Where(a => a.ResponsPersonId == PersonResponsibleId).ToListAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    if (audDetails.Count > 0)
    {
        return Results.Ok(audDetails);
    }
    else
    {
        return Results.NotFound();
    }
});

#endregion

#region "Audit Filter"

app.MapPost("/GetAuditFilterData/RoleName", async ([FromBody] AuditFilter auditfl, [FromQuery] string roleName, string Token, auditContextObj db) =>
{

    List<AuditManagement> audManagement = new List<AuditManagement>();
    List<AuditPlan> audPlan = new List<AuditPlan>();
    fieldName = GetUserDetails(roleName, fieldName);
    string[] finYear = new string[] { };
    if (auditfl.FromYear != null)
    {
        finYear = auditfl.FromYear.Split(',');
    }
    if (auditfl.TableName != null)
    {
        tableName = auditfl.TableName;
    }
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            //######## case tbl_auditManagement #########
            if (tableName == "tbl_auditmanagement")
            {
                if (auditfl.FromYear != "")
                {
                    if (fieldName == "AuditeeId")
                    {
                        var AssociatedSchoolsArray = auditfl.FromYear.Split(",").ToArray();
                        audManagement = await (from o
                        in db.tbl_auditmanagement
                                               where AssociatedSchoolsArray.Contains(o.FinancialYear)
                                               //   && (o.AuditAreaId == auditfl.AuditAreaID || auditfl.AuditAreaID == 0)
                                               && (o.AuditeeId == null || o.AuditeeId == auditfl.UserId || auditfl.UserId == "")
                                               && (o.AuditType == null || o.AuditType == auditfl.AuditType || auditfl.AuditType == "")
                                               select new AuditManagement
                                               {
                                                   AuditClosureDate = o.AuditClosureDate,
                                                   AuditCode = o.AuditCode,
                                                   AuditeeId = o.AuditeeId,
                                                   AuditEndDate = o.AuditEndDate,
                                                   AuditStartDate = o.AuditStartDate,
                                                   AuditPlanUpdatedBy = o.AuditPlanUpdatedBy,
                                                   AuditManId = o.AuditManId,
                                                   AuditType = o.AuditType,
                                                   AuditorId = o.AuditorId,
                                                   CommiteeMemId = o.CommiteeMemId,
                                                   CreatedBy = o.CreatedBy,
                                                   CreatedDate = o.CreatedDate,
                                                   //AuditAreaId = o.AuditAreaId,
                                                   AuditPlanUpdatedDate = o.AuditPlanUpdatedDate,
                                                   Status = o.Status,
                                                   ExpectedAuditMonth = o.ExpectedAuditMonth,
                                                   FinancialQuarter = o.FinancialQuarter,
                                                   FinancialYear = o.FinancialYear,
                                                   Operationunit = o.Operationunit,
                                                   //AreaId = o.AreaId,
                                                   AuditPlanID = o.AuditPlanID,
                                                   Remarks = o.Remarks
                                               }).ToListAsync();
                    }
                    if (fieldName == "AuditorId")
                    {

                        var AssociatedSchoolsArray = auditfl.FromYear.Split(",").ToArray();
                        audManagement = await (from o
                                     in db.tbl_auditmanagement
                                               where AssociatedSchoolsArray.Contains(o.FinancialYear)
                                               //  && (o.DepartmentId == auditfl.DepartmentId || auditfl.DepartmentId == 0)
                                               && (o.AuditorId == null || o.AuditorId == auditfl.UserId || auditfl.UserId == "")
                                               && (o.AuditType == null || o.AuditType == auditfl.AuditType || auditfl.AuditType == "")
                                               select new AuditManagement
                                               {
                                                   AuditClosureDate = o.AuditClosureDate,
                                                   AuditCode = o.AuditCode,
                                                   AuditeeId = o.AuditeeId,
                                                   AuditEndDate = o.AuditEndDate,
                                                   AuditStartDate = o.AuditStartDate,
                                                   AuditPlanUpdatedBy = o.AuditPlanUpdatedBy,
                                                   AuditManId = o.AuditManId,
                                                   AuditType = o.AuditType,
                                                   AuditorId = o.AuditorId,
                                                   CommiteeMemId = o.CommiteeMemId,
                                                   CreatedBy = o.CreatedBy,
                                                   CreatedDate = o.CreatedDate,
                                                   //AuditAreaId = o.AuditAreaId,
                                                   AuditPlanUpdatedDate = o.AuditPlanUpdatedDate,
                                                   Status = o.Status,
                                                   ExpectedAuditMonth = o.ExpectedAuditMonth,
                                                   FinancialQuarter = o.FinancialQuarter,
                                                   FinancialYear = o.FinancialYear,
                                                   Operationunit = o.Operationunit,
                                                   //AreaId = o.AreaId,
                                                   AuditPlanID = o.AuditPlanID,
                                                   Remarks = o.Remarks
                                               }).ToListAsync();
                    }
                    if (fieldName == "CreatedBy")
                    {
                        var AssociatedSchoolsArray = auditfl.FromYear.Split(",").ToArray();
                        audManagement = await (from o
                                     in db.tbl_auditmanagement
                                               where AssociatedSchoolsArray.Contains(o.FinancialYear)
                                               //&& (o.DepartmentId == auditfl.DepartmentId || auditfl.DepartmentId == 0)
                                               && (o.CreatedBy == null || o.CreatedBy == auditfl.UserId || auditfl.UserId == "")
                                               && (o.AuditType == null || o.AuditType == auditfl.AuditType || auditfl.AuditType == "")
                                               select new AuditManagement
                                               {
                                                   AuditClosureDate = o.AuditClosureDate,
                                                   AuditCode = o.AuditCode,
                                                   AuditeeId = o.AuditeeId,
                                                   AuditEndDate = o.AuditEndDate,
                                                   AuditStartDate = o.AuditStartDate,
                                                   AuditPlanUpdatedBy = o.AuditPlanUpdatedBy,
                                                   AuditManId = o.AuditManId,
                                                   AuditType = o.AuditType,
                                                   AuditorId = o.AuditorId,
                                                   CommiteeMemId = o.CommiteeMemId,
                                                   CreatedBy = o.CreatedBy,
                                                   CreatedDate = o.CreatedDate,
                                                   //AuditAreaId = o.AuditAreaId,
                                                   AuditPlanUpdatedDate = o.AuditPlanUpdatedDate,
                                                   Status = o.Status,
                                                   ExpectedAuditMonth = o.ExpectedAuditMonth,
                                                   FinancialQuarter = o.FinancialQuarter,
                                                   FinancialYear = o.FinancialYear,
                                                   Operationunit = o.Operationunit,
                                                   //AreaId = o.AreaId,
                                                   AuditPlanID = o.AuditPlanID,
                                                   Remarks = o.Remarks
                                               }).ToListAsync();
                    }
                    if (fieldName == "CommiteeMemId")
                    {
                        var AssociatedSchoolsArray = auditfl.FromYear.Split(",").ToArray();
                        audManagement = await (from o
                                     in db.tbl_auditmanagement
                                               where AssociatedSchoolsArray.Contains(o.FinancialYear)
                                               //  && (o.DepartmentId == auditfl.DepartmentId || auditfl.DepartmentId == 0)
                                               && (o.CommiteeMemId == null || o.CommiteeMemId == auditfl.UserId || auditfl.UserId == "")
                                               && (o.AuditType == null || o.AuditType == auditfl.AuditType || auditfl.AuditType == "")
                                               select new AuditManagement
                                               {
                                                   AuditClosureDate = o.AuditClosureDate,
                                                   AuditCode = o.AuditCode,
                                                   AuditeeId = o.AuditeeId,
                                                   AuditEndDate = o.AuditEndDate,
                                                   AuditStartDate = o.AuditStartDate,
                                                   AuditPlanUpdatedBy = o.AuditPlanUpdatedBy,
                                                   AuditManId = o.AuditManId,
                                                   AuditType = o.AuditType,
                                                   AuditorId = o.AuditorId,
                                                   CommiteeMemId = o.CommiteeMemId,
                                                   CreatedBy = o.CreatedBy,
                                                   CreatedDate = o.CreatedDate,
                                                   //AuditAreaId = o.AuditAreaId,
                                                   AuditPlanUpdatedDate = o.AuditPlanUpdatedDate,
                                                   Status = o.Status,
                                                   ExpectedAuditMonth = o.ExpectedAuditMonth,
                                                   FinancialQuarter = o.FinancialQuarter,
                                                   FinancialYear = o.FinancialYear,
                                                   Operationunit = o.Operationunit,
                                                   //AreaId = o.AreaId,
                                                   AuditPlanID = o.AuditPlanID,
                                                   Remarks = o.Remarks
                                               }).ToListAsync();
                    }
                    if (audManagement.Count() > 0)
                    {
                        return Results.Ok(audManagement);
                    }
                    else
                    {
                        return Results.NotFound();
                    }
                }
                else
                {
                    return Results.Problem("Financial Year Required");
                }
            }
            //######## case tbl_auditPlan #########
            if (tableName == "tbl_auditPlan")
            {
                if (auditfl.FromYear != "")
                {
                    if (fieldName == "AuditeeId")
                    {
                        var AssociatedSchoolsArray = auditfl.FromYear.Split(",").ToArray();
                        audPlan = await (from o
                                     in db.tbl_auditplan
                                         where AssociatedSchoolsArray.Contains(o.FinancialYear)
                                         //     && (o.DepartmentId == auditfl.DepartmentId || auditfl.DepartmentId == 0)
                                         && (o.AuditeeId == null || o.AuditeeId == auditfl.UserId || auditfl.UserId == "")
                                         && (o.AuditType == null || o.AuditType == auditfl.AuditType || auditfl.AuditType == "")
                                         select new AuditPlan
                                         {
                                             AuditClosureDate = o.AuditClosureDate,
                                             AuditCode = o.AuditCode,
                                             AuditeeId = o.AuditeeId,
                                             AuditEndDate = o.AuditEndDate,
                                             AuditStartDate = o.AuditStartDate,
                                             AuditPlanUpdatedBy = o.AuditPlanUpdatedBy,
                                             AuditplanId = o.AuditplanId,
                                             AuditType = o.AuditType,
                                             AuditorId = o.AuditorId,
                                             CommitteeMemId = o.CommitteeMemId,
                                             CreatedBy = o.CreatedBy,
                                             CreatedDate = o.CreatedDate,
                                             AuditAreaId = o.AuditAreaId,
                                             AuditPlanUpdatedDate = o.AuditPlanUpdatedDate,
                                             DocStatus = o.DocStatus,
                                             ExpectedClosureMonth = o.ExpectedClosureMonth,
                                             FinancialQuarter = o.FinancialQuarter,
                                             FinancialYear = o.FinancialYear,
                                             OperationUnit = o.OperationUnit,
                                         }).ToListAsync();
                    }
                    if (fieldName == "AuditorId")
                    {
                        var AssociatedSchoolsArray = auditfl.FromYear.Split(",").ToArray();
                        audPlan = await (from o
                                     in db.tbl_auditplan
                                         where AssociatedSchoolsArray.Contains(o.FinancialYear)
                                         //  && (o.DepartmentId == auditfl.DepartmentId || auditfl.DepartmentId == 0)
                                         && (o.AuditorId == null || o.AuditorId == auditfl.UserId || auditfl.UserId == "")
                                         && (o.AuditType == null || o.AuditType == auditfl.AuditType || auditfl.AuditType == "")
                                         select new AuditPlan
                                         {
                                             AuditClosureDate = o.AuditClosureDate,
                                             AuditCode = o.AuditCode,
                                             AuditeeId = o.AuditeeId,
                                             AuditEndDate = o.AuditEndDate,
                                             AuditStartDate = o.AuditStartDate,
                                             AuditPlanUpdatedBy = o.AuditPlanUpdatedBy,
                                             AuditplanId = o.AuditplanId,
                                             AuditType = o.AuditType,
                                             AuditorId = o.AuditorId,
                                             CommitteeMemId = o.CommitteeMemId,
                                             CreatedBy = o.CreatedBy,
                                             CreatedDate = o.CreatedDate,
                                             AuditAreaId = o.AuditAreaId,
                                             AuditPlanUpdatedDate = o.AuditPlanUpdatedDate,
                                             DocStatus = o.DocStatus,
                                             ExpectedClosureMonth = o.ExpectedClosureMonth,
                                             FinancialQuarter = o.FinancialQuarter,
                                             FinancialYear = o.FinancialYear,
                                             OperationUnit = o.OperationUnit,
                                         }).ToListAsync();
                    }
                    if (fieldName == "CreatedBy")
                    {
                        var AssociatedSchoolsArray = auditfl.FromYear.Split(",").ToArray();
                        audPlan = await (from o
                                     in db.tbl_auditplan
                                         where AssociatedSchoolsArray.Contains(o.FinancialYear)
                                         //   && (o.DepartmentId == auditfl.DepartmentId || auditfl.DepartmentId == 0)
                                         && (o.CreatedBy == null || o.CreatedBy == auditfl.UserId || auditfl.UserId == "")
                                         && (o.AuditType == null || o.AuditType == auditfl.AuditType || auditfl.AuditType == "")
                                         select new AuditPlan
                                         {
                                             AuditClosureDate = o.AuditClosureDate,
                                             AuditCode = o.AuditCode,
                                             AuditeeId = o.AuditeeId,
                                             AuditEndDate = o.AuditEndDate,
                                             AuditStartDate = o.AuditStartDate,
                                             AuditPlanUpdatedBy = o.AuditPlanUpdatedBy,
                                             AuditplanId = o.AuditplanId,
                                             AuditType = o.AuditType,
                                             AuditorId = o.AuditorId,
                                             CommitteeMemId = o.CommitteeMemId,
                                             CreatedBy = o.CreatedBy,
                                             CreatedDate = o.CreatedDate,
                                             AuditAreaId = o.AuditAreaId,
                                             AuditPlanUpdatedDate = o.AuditPlanUpdatedDate,
                                             DocStatus = o.DocStatus,
                                             ExpectedClosureMonth = o.ExpectedClosureMonth,
                                             FinancialQuarter = o.FinancialQuarter,
                                             FinancialYear = o.FinancialYear,
                                             OperationUnit = o.OperationUnit,
                                         }).ToListAsync();
                    }
                    if (fieldName == "CommiteeMemId")
                    {
                        var AssociatedSchoolsArray = auditfl.FromYear.Split(",").ToArray();
                        audPlan = await (from o
                                     in db.tbl_auditplan
                                         where AssociatedSchoolsArray.Contains(o.FinancialYear)
                                         // && (o.DepartmentId == auditfl.DepartmentId || auditfl.DepartmentId == 0)
                                         && (o.CommitteeMemId == null || o.CommitteeMemId == auditfl.UserId || auditfl.UserId == "")
                                         && (o.AuditType == null || o.AuditType == auditfl.AuditType || auditfl.AuditType == "")
                                         select new AuditPlan
                                         {
                                             AuditClosureDate = o.AuditClosureDate,
                                             AuditCode = o.AuditCode,
                                             AuditeeId = o.AuditeeId,
                                             AuditEndDate = o.AuditEndDate,
                                             AuditStartDate = o.AuditStartDate,
                                             AuditPlanUpdatedBy = o.AuditPlanUpdatedBy,
                                             AuditplanId = o.AuditplanId,
                                             AuditType = o.AuditType,
                                             AuditorId = o.AuditorId,
                                             CommitteeMemId = o.CommitteeMemId,
                                             CreatedBy = o.CreatedBy,
                                             CreatedDate = o.CreatedDate,
                                             AuditAreaId = o.AuditAreaId,
                                             AuditPlanUpdatedDate = o.AuditPlanUpdatedDate,
                                             DocStatus = o.DocStatus,
                                             ExpectedClosureMonth = o.ExpectedClosureMonth,
                                             FinancialQuarter = o.FinancialQuarter,
                                             FinancialYear = o.FinancialYear,
                                             OperationUnit = o.OperationUnit,
                                         }).ToListAsync();
                    }
                    if (audPlan.Count() > 0)
                    {
                        return Results.Ok(audPlan);
                    }
                    else
                    {
                        return Results.NotFound();
                    }
                }
                else
                {
                    return Results.Problem("Financial Year Required");
                }
            }
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Ok();
});
string GetUserDetails(string roleName, string fieldName)
{
    try
    {
        fieldName = _helperAct.ReturnEmployeeType(roleName);
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return fieldName;
}

#endregion

#region "Logger"
static void WriteToFile(string Message)
{
    string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
    if (!Directory.Exists(path))
    {
        Directory.CreateDirectory(path);
    }
    string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
    if (!File.Exists(filepath))
    {
        // Create a file to write to.   
        using (StreamWriter sw = File.CreateText(filepath))
        {
            sw.WriteLine(Message);
        }
    }
    else
    {
        using (StreamWriter sw = File.AppendText(filepath))
        {
            sw.WriteLine(Message);
        }
    }
}

//void LogError(string message)
//{
//    var logRepository = AuditManagementDAL..GetRepository(Assembly.GetEntryAssembly());
//    XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
//    ILog _logger = LogManager.GetLogger(typeof(LoggerManager));
//    _logger.Info(message);
//}
app.MapPost("/GetUserEncryptionData/", async ([FromBody] UserEncryption encypt) =>
{
    string validKey = string.Empty;
    try
    {
        if ((encypt.Key != null) && (encypt.UserName != null) && (encypt.Password != null))
        {
            validKey = EncryptUserCred(encypt.Key, encypt.UserName, encypt.Password);
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return validKey;
});
string EncryptUserCred(string Key, string username, string password)
{
    string retKey = string.Empty;
    try
    {
        retKey = _helperAct.EncryptString(Key, username, password);
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return retKey;
}

app.MapPost("/GetUserDecryptData/", async ([FromBody] string encryptedKey, string AppKey) =>
{
    string validKey = string.Empty;
    try
    {
        if (encryptedKey != "")
        {
            validKey = DecryptString(AppKey, encryptedKey);
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return validKey;
});
string DecryptString(string key, string cipherText)
{
    byte[] iv = new byte[16];
    byte[] buffer = Convert.FromBase64String(cipherText);

    using (Aes aes = Aes.Create())
    {
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.IV = iv;
        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using (MemoryStream memoryStream = new MemoryStream(buffer))
        {
            using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
            {
                using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}
#region "Task Additon & task Management"
app.MapPost("/SaveCorporateTask", async ([FromBody] TaskDetails tDs, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "invalid token".ToString().Trim())
        {
            if (tDs != null)
            {
                db.tbl_taskdetails.Add(tDs);
                await db.SaveChangesAsync();
            }
            else
            {
                return Results.Problem("empty model not allowed");
            }
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message);
    }
    return Results.Created($"/save/{tDs.TaskId}", tDs);
});
app.MapPut("/UpdateCorporateTask/{TaskCode}", async (string TaskCode, TaskDetails tds, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            var taskDetails = await db.tbl_taskdetails.FindAsync(TaskCode);
            if (taskDetails is null) return Results.NotFound();
            taskDetails.TaskAssignedBy = tds.TaskAssignedBy;
            taskDetails.TaskAssignedTo = tds.TaskAssignedTo;
            taskDetails.AuditplanId = tds.AuditplanId;
            taskDetails.AuditManDetId = tds.AuditManDetId;
            taskDetails.AuditManId = tds.AuditManId;
            taskDetails.AuditeeRemarks = tds.AuditeeRemarks;
            taskDetails.AuditorRemarks = tds.AuditorRemarks;
            taskDetails.CorporateDateofClosure = tds.CorporateDateofClosure;
            taskDetails.createdDate = tds.createdDate;
            taskDetails.UploadSupportDocs = tds.UploadSupportDocs;
            taskDetails.CorporateRemarks = tds.CorporateRemarks;
            taskDetails.CurrentStatus = tds.CurrentStatus;
            taskDetails.Description = tds.Description;
            taskDetails.ExpectedClosureDate = tds.ExpectedClosureDate;
            taskDetails.FinalClosedByCorporateUser = tds.FinalClosedByCorporateUser;
            taskDetails.FinalStatus = tds.FinalStatus;
            await db.SaveChangesAsync();
            return Results.Ok();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});
app.MapGet("/GetCorporateUserTask", async (string PersonResponsibleId, string Token, auditContextObj db) =>
{
    //  List<TaskDetails> ListofTask = new List<TaskDetails>();
    var retObj = 0;
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            //return await db.tbl_taskDetails.Where(a => a.TaskAssignedTo == PersonResponsibleId)
            //                 .GroupBy(a => a.CurrentStatus)
            //                 .Select(g => new { g.Key, Count = g.Count() }).ToListAsync();

            retObj = db.tbl_taskdetails.Where(a => a.TaskAssignedTo == PersonResponsibleId).GroupBy(a => a.CurrentStatus).Count();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Ok(retObj);
});
app.MapPost("/SaveAuditeeTask", async ([FromBody] AuditeeResponse tDs, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "invalid token".ToString().Trim())
        {
            if (tDs != null)
            {
                db.tbl_auditeeresponse.Add(tDs);
                await db.SaveChangesAsync();
            }
            else
            {
                return Results.Problem("Empty Model not allowed");
            }
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message);
    }
    return Results.Created($"/save/{tDs.TaskId}", tDs);
});
app.MapPut("/UpdateAuditeeTask/{TaskCode}", async (string TaskCode, AuditeeResponse responseObj, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            var auditeeResp = await db.tbl_auditeeresponse.FindAsync(TaskCode);
            if (auditeeResp is null) return Results.NotFound();
            auditeeResp.TaskAssignedBy = responseObj.TaskAssignedBy;
            auditeeResp.TaskAssignedTo = responseObj.TaskAssignedTo;
            auditeeResp.AuditplanId = responseObj.AuditplanId;
            auditeeResp.AuditManDetId = responseObj.AuditManDetId;
            auditeeResp.AuditManId = responseObj.AuditManId;
            auditeeResp.AuditorRemarks = responseObj.AuditorRemarks;
            auditeeResp.AuditorRemarks = responseObj.AuditorRemarks;
            auditeeResp.CorporateDateofClosure = responseObj.CorporateDateofClosure;
            auditeeResp.createdDate = responseObj.createdDate;
            auditeeResp.UploadSupportDocs = responseObj.UploadSupportDocs;
            auditeeResp.CorporateRemarks = responseObj.CorporateRemarks;
            auditeeResp.CurrentStatus = responseObj.CurrentStatus;
            auditeeResp.Description = responseObj.Description;
            auditeeResp.ExpectedClosureDate = responseObj.ExpectedClosureDate;
            auditeeResp.FinalClosedByCorporateUser = responseObj.FinalClosedByCorporateUser;
            auditeeResp.FinalStatus = responseObj.FinalStatus;
            await db.SaveChangesAsync();
            return Results.Ok();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});
app.MapGet("/GetAuditeeTask", async (string PersonResponsibleId, string Token, auditContextObj db) =>
{
    List<AuditeeResponse> ListofTask = new List<AuditeeResponse>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            ListofTask = await db.tbl_auditeeresponse.Where(a => a.TaskAssignedTo == PersonResponsibleId).ToListAsync();
            if (ListofTask.Count > 0)
            {
                return Results.Ok(ListofTask);
            }
            else
            {
                return Results.NotFound();
            }
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});
app.MapGet("/GetAuditeeTaskStatusWise", async (string PersonResponsibleId, string TaskStatus, string Token, auditContextObj db) =>
{
    List<AuditeeResponse> ListofTask = new List<AuditeeResponse>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            ListofTask = await db.tbl_auditeeresponse.Where(a => a.TaskAssignedTo == PersonResponsibleId && a.CurrentStatus == TaskStatus).ToListAsync();
            if (ListofTask.Count > 0)
            {
                return Results.Ok(ListofTask.Count);
            }
            else
            {
                return Results.NotFound();
            }
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

app.MapPost("/SaveAuditorTask", async ([FromBody] AuditorResponse audResp, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "invalid token".ToString().Trim())
        {
            if (audResp != null)
            {
                db.tbl_auditorresponse.Add(audResp);
                await db.SaveChangesAsync();
            }
            else
            {
                return Results.Problem("Empty Model not allowed");
            }
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message);
    }
    return Results.Created($"/save/{audResp.TaskId}", audResp);
});


app.MapGet("/GetAuditorTask", async (string PersonResponsibleId, Guid audManId, string Token, auditContextObj db) =>
{
    List<AuditorResponse> ListofTask = new List<AuditorResponse>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            ListofTask = await db.tbl_auditorresponse.Where(a => a.TaskAssignedTo == PersonResponsibleId && a.AuditManId == audManId).ToListAsync();
            if (ListofTask.Count > 0)
            {
                return Results.Ok(ListofTask);
            }
            else
            {
                return Results.NotFound();
            }
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});


app.MapGet("/GetAuditorTaskStatusWise", async (string PersonResponsibleId, string CurrentStatus, string Token, auditContextObj db) =>
{
    List<AuditorResponse> ListofTask = new List<AuditorResponse>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            ListofTask = await db.tbl_auditorresponse.Where(a => a.TaskAssignedTo == PersonResponsibleId && a.CurrentStatus == CurrentStatus).ToListAsync();
            if (ListofTask.Count > 0)
            {
                return Results.Ok(ListofTask.Count);
            }
            else
            {
                return Results.NotFound();
            }
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

app.MapGet("/GetTaskCountPerlogin", async (string PersonResponsibleId, string RoleName, string Token, auditContextObj db) =>
{
    List<AuditManagementDAL.ResponseDTO.LoggedUserTask> tCount = new List<AuditManagementDAL.ResponseDTO.LoggedUserTask>();
    List<TaskDetails> tdetails = new List<TaskDetails>();
    var retObj1 = 0;
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            if (RoleName != null)
            {
                if (_helperAct.RetRoleDeed == 0)
                {
                    var groups = db.tbl_taskdetails.Where(m => m.TaskAssignedTo == PersonResponsibleId).GroupBy(n => n.CurrentStatus)
                              .Select(n => new
                              {
                                  CategoryName = n.Key,
                                  CategoryCount = n.Count()
                              })
                              .OrderBy(n => n.CategoryName);
                    return Results.Ok(groups);
                }
                if (_helperAct.RetRoleDeed == 1)
                {
                    var groups = db.tbl_auditeeresponse.Where(m => m.TaskAssignedTo == PersonResponsibleId).GroupBy(n => n.CurrentStatus)
                              .Select(n => new
                              {
                                  CategoryName = n.Key,
                                  CategoryCount = n.Count()
                              })
                              .OrderBy(n => n.CategoryName);
                    return Results.Ok(groups);

                }
                if (_helperAct.RetRoleDeed == 2)
                {
                    var groups = db.tbl_auditorresponse.Where(m => m.TaskAssignedTo == PersonResponsibleId).GroupBy(n => n.CurrentStatus)
                               .Select(n => new
                               {
                                   CategoryName = n.Key,
                                   CategoryCount = n.Count()
                               })
                               .OrderBy(n => n.CategoryName);
                    return Results.Ok(groups);
                }
            }
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});

#endregion
#endregion "Logger'

#region "Module Management"

app.MapGet("/GetModuleMaster", async (string Token, auditContextObj db) =>
{
    List<AuditManagementDAL.DataModels.ModuleMaster> modMastr = new List<AuditManagementDAL.DataModels.ModuleMaster>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            modMastr = await db.tbl_modulemaster.ToListAsync();
            return Results.Ok(modMastr);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NoContent();
});


app.MapGet("/GetUserRole", async (string Token, auditContextObj db) =>
{
    List<AuditManagementDAL.DataModels.Roles> modMastr = new List<AuditManagementDAL.DataModels.Roles>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            modMastr = await db.roles.ToListAsync();
            return Results.Ok(modMastr);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NoContent();
});
#endregion

#region "RBAC Events"

//app.MapPost("/SaveRBACDetails", async (ModelRBAC rbac, string Token, auditContextObj db) =>
//{
//    try
//    {
//        responseRet = ValidateInputToken(Token);
//        if (responseRet.Count == 0) return Results.BadRequest();
//        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
//        {
//           // db.tbl_.Add(auditMangement);
//            await db.SaveChangesAsync();
//        }
//        else
//        {
//            return Results.Unauthorized();
//        }
//    }
//    catch (Exception ex)
//    {
//        WriteToFile(ex.Message + "\n" + ex.StackTrace);
//    }
//  //  return Results.Created($"/save/{auditMangement.AuditManId}", auditMangement);
//});


app.MapPost("/SaveUseraAreaWise", async (AreaWiseUser awU, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            db.areawiseusers.Add(awU);
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Created($"/save/{awU.EmpCode}", awU);
});

app.MapGet("/GetUsersAreaWise/", async (Guid AuditAreaId, string Token, auditContextObj db) =>
{
    List<AuditManagementDAL.DataModels.AreaWiseUser> areaMaster = new List<AuditManagementDAL.DataModels.AreaWiseUser>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            areaMaster = await db.areawiseusers.Where(a => a.AuditAreaId == AuditAreaId).ToListAsync();
            return Results.Ok(areaMaster);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NoContent();
});


app.MapGet("/GetAllUsersAreaWise/", async (string Token, auditContextObj db) =>
{
    List<AuditManagementDAL.DataModels.AreaWiseUser> areaMaster = new List<AuditManagementDAL.DataModels.AreaWiseUser>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            areaMaster = await db.areawiseusers.ToListAsync();
            return Results.Ok(areaMaster);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NoContent();
});
app.MapPost("/SaveStandardAreaMapper", async (AreaStandardMapper awU, string Token, auditContextObj db) =>
{
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            db.tbl_areastandardmapper.Add(awU);
            await db.SaveChangesAsync();
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.Created($"/save/{awU.SrNo}", awU);
});

app.MapGet("/GetStandardAreaMapper/", async (Guid StdAreaMapId, string Token, auditContextObj db) =>
{
    List<AuditManagementDAL.DataModels.AreaStandardMapper> areaMaster = new List<AuditManagementDAL.DataModels.AreaStandardMapper>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            areaMaster = await db.tbl_areastandardmapper.Where(a => a.StdAreaMapId == StdAreaMapId).ToListAsync();
            return Results.Ok(areaMaster);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NoContent();
});

app.MapGet("/GetAllStandardAreaMapper/", async (string Token, auditContextObj db) =>
{
    List<AuditManagementDAL.DataModels.AreaStandardMapper> areaMaster = new List<AuditManagementDAL.DataModels.AreaStandardMapper>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            areaMaster = await db.tbl_areastandardmapper.ToListAsync();
            return Results.Ok(areaMaster);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NoContent();
});

app.MapGet("/GetAreaStdMapperByAreaId/", async (Guid AreaId, string Token, auditContextObj db) =>
{
    List<AuditManagementDAL.DataModels.AreaStandardMapper> areaMaster = new List<AuditManagementDAL.DataModels.AreaStandardMapper>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            areaMaster = await db.tbl_areastandardmapper.Where(a=>a.AreaId==AreaId && a.L2==1).ToListAsync();
            
            return Results.Ok(areaMaster);
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NoContent();
});

app.MapPut("/UpdateStandardAreaMapper/{TaskCode}", async (Guid AreaId, AreaStandardMapper responseObj, string Token, auditContextObj db) =>
{
    List<AuditManagementDAL.DataModels.AreaStandardMapper> auditeeResp = new List<AuditManagementDAL.DataModels.AreaStandardMapper>();
    try
    {
        responseRet = ValidateInputToken(Token);
        if (responseRet.Count == 0) return Results.BadRequest();
        if (responseRet.ElementAt(0).Key.ToString().Trim() != "Invalid Token".ToString().Trim())
        {
            auditeeResp = await db.tbl_areastandardmapper.Where(a =>a.AreaId == AreaId && a.SafetyStandardId== responseObj.SafetyStandardId).ToListAsync(); ;
            if (auditeeResp is null)
            {
                db.tbl_areastandardmapper.Add(responseObj);
                await db.SaveChangesAsync();
                return Results.Ok();
            }
            else
            {
                int max = auditeeResp.Count();
                for (int x = 0; x < max; x++)
                {
                    auditeeResp[x].SrNo = responseObj.SrNo;
                    auditeeResp[x].SafetyStandardId = responseObj.SafetyStandardId;
                    auditeeResp[x].AreaId = responseObj.AreaId;
                    auditeeResp[x].L2 = responseObj.L2;
                    auditeeResp[x].L3 = responseObj.L3;
                    auditeeResp[x].CreatedBy = responseObj.CreatedBy;
                    auditeeResp[x].UpdatedBy = responseObj.UpdatedBy;
                    auditeeResp[x].UpdatedDate = responseObj.UpdatedDate;
                    await db.SaveChangesAsync();
                }
            }
            return Results.Ok("Data Updated Successfully");
        }
        else
        {
            return Results.Unauthorized();
        }
    }
    catch (Exception ex)
    {
        WriteToFile(ex.Message + "\n" + ex.StackTrace);
    }
    return Results.NotFound();
});
#region "Area Wise Users"
#endregion
#endregion
app.UseHttpsRedirection();
app.Run();

