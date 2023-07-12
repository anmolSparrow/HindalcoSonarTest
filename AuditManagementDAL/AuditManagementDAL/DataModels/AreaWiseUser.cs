﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AuditManagementDAL.DataModels
{
 //   [Keyless]
    public class AreaWiseUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AreaWiseId { get;set; }
        [Required]
        [ForeignKey("UsersCredential")]
        public string? EmpCode { get; set; }
        [Required]
        [ForeignKey("AuditArea")]
        public Guid AuditAreaId { get; set; }
        public string ? UserName { get; set; }
        [Required]
        public string? UserEmail { get; set; }
        [Required]
        public int UserId { get; set;}
        public int RoleId { get;set; }
        public bool IsUserActive { get;set; }
        public Guid OperationUnitId { get; set; }
        public int DeptId { get; set; }

    }
}
