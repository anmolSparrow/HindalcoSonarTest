using log4net;
using log4net.Config;
using MySql.Data.MySqlClient;
using MySql.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

[assembly: XmlConfigurator(Watch = true)]
namespace DynamicSqlCreation
{

    class Program
    {
       // public const string ConnectionString = "Data Source=DBSource; Initial Catalog=master; Integrated Security=False;";
        public const string ConnectionString = "server=server;user=user;password=*****;port=port;";
        public string ScriptPath = string.Empty;
        public string ScriptFileName = string.Empty;
        private static readonly ILog Log = LogHelper.GetLogger();
        public void CreateDBBtn_Click(string DSource = "", string DbName = "", string UserName = "", string Password = "", string scriptpath = "", string ScriptFileName = "")
        {
            try
            {               
                var connectionStringBuilder = new MySqlConnectionStringBuilder(ConnectionString);
                connectionStringBuilder.Server = DSource;
                connectionStringBuilder.UserID = UserName;
                connectionStringBuilder.Password = Password;
                connectionStringBuilder.Port = 3306;
                var connectionString = connectionStringBuilder.ToString();
                Log.Info("HindalcoiOS connection established.  " + DateTime.Now);
                Log.Info("HindalcoiOS DB Creation start.");
                CreateDatabase(connectionString, DbName);
                if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
                {
                    return;
                }
                connectionStringBuilder.Database = DbName;
                connectionString = connectionStringBuilder.ToString();
                if (ExecuteScript(scriptpath, connectionString))
                {
                    Console.WriteLine("Project Creation Done");
                    Log.Info("Project Creation Done." + DateTime.Now);
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Log.Error("DataBase and Tables Creation Errors", ex);
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                Console.WriteLine();
            }
        }  
        public bool CreateDatabase(string connectionString, string DbName)
        {          
            bool Status = false;
            if (!CheckingMysqlDBExists(DbName, connectionString))
            {
                var sql = $"CREATE DATABASE {DbName}";
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var cmd = new MySqlCommand(sql, connection);
                    try
                    {
                        Console.WriteLine("Please wait Creating database");
                        cmd.ExecuteNonQuery();
                        Status = true;
                        Log.Info($"{DbName} DataBase Creation Done.");
                        Console.WriteLine("{0} DB Creation Done", DbName);
                    }
                    catch (SqlException Ex)
                    {
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(Ex.Message.ToString());
                        Console.ResetColor();
                        Console.WriteLine();
                        Status = false;
                        Log.Error($"{DbName} DataBase Creation Error.{Ex.Message}");
                    }
                }
            }
            else
            {
                Log.Info($"{DbName} DataBase already exists.");
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("{0} is already exists in DB\n  please try  different database", DbName);
                Console.ResetColor();
                Status = false;
            }
            return Status;
        }

        private bool Checkingsqldbexist(string databaseName, string connectionString)
        {
            try
            {
                Log.Info($"{databaseName} DataBase Validation Testing");
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand($"SELECT dbid FROM dbo.sysdatabases where name in('{databaseName}')", connection))
                    {
                        var gg = command.ExecuteScalar();
                        if (gg != null)
                        {
                            if (int.Parse(gg.ToString()) > 0)
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"DataBase Creation Error {ex.Message}");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                return false;
            }
        }
        public bool CheckingMysqlDBExists(string databaseName, string connectionString)
        {
            try
            {
                Log.Info("HindalcoiOS DataBase Checking.." + DateTime.Now);
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand($"select SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA where SCHEMA_NAME  in('{databaseName}')", connection))
                    {
                        var gg = command.ExecuteScalar();
                        if (gg != null)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("HindalcoiOS DataBase Creation Error:" + ex.Message);
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                Console.WriteLine();
                return false;
            }
        }
        private bool ExecuteScript(string scriptpath, string connectionString)
        {
            Log.Info("HindalcoiOS Tables Creation started.." + DateTime.Now);
            bool Iscommandstatus = false;
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var fileContent = System.IO.File.ReadAllText(Path.Combine(scriptpath, ScriptFileName + ".sql"));
                var sqlqueries = fileContent.Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var sqlquery in sqlqueries)
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", connection))
                    {
                        try
                        {
                            using (MySqlCommand cmd = new MySqlCommand())
                            {
                                sda.InsertCommand = cmd;
                                sda.InsertCommand.Connection = connection;
                                sda.InsertCommand.CommandType = CommandType.Text;
                                sda.InsertCommand.CommandText = sqlquery;
                                sda.InsertCommand.ExecuteNonQuery();
                                Iscommandstatus = true;
                            }
                        }
                        catch (Exception Ex)
                        {
                            Log.Error("Tables Creation Errors in ." + sqlquery);
                            Console.WriteLine();
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(Ex.Message);
                            Console.ResetColor();
                            Console.Error.WriteLine();
                            Iscommandstatus = false;
                        }
                    }
                }
            }
            return Iscommandstatus;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            if (args.Length > 0)
            {
                try
                {
                    Log.Info("HindalcoiOS: arguments read." + args[2].ToString() + args[3].ToString());
                    //if (args[2].ToString().Equals("TS") && args[3].ToString().Equals("TS"))
                    //{
                    //    p.UserName = "";
                    //    p.Password = "";
                    //}
                    //else
                    //{
                    //    p.UserName = args[2].ToString();
                    //    p.Password = args[3].ToString();
                    //}
                    Log.Info("HindalcoiOS: arguments read END" + DateTime.Now);
                    p.CreateDBBtn_Click(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString());
                    // p.DBSource = ".";// "103.143.84.44";
                    // p.UserName = "sa";
                    // p.Password = "$Y$@DM!NREL2016";                   
                    // p.DName = args[1].ToString();

                }
                catch (Exception ex)
                {
                    Log.Info("HindalcoiOS: arguments read Errors" + ex.Message);
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(ex.Message);
                    Debug.Print(ex.Message);
                    Console.ResetColor();
                    Console.WriteLine();
                }

            }
            else
            {
                Log.Info("HindalcoiOS:DB Name read" + DateTime.Now);
                //p.DBSource = ".";// "demo.sparrowios.com";
                //p.UserName ="sa";
                //p.Password = "1234";//"S1gdmQE47P7%EfN";
                p.ScriptPath = @"C:\Users\Public\Documents\HindalcoiOS\Images\";
                var list = Directory.GetFiles(p.ScriptPath, "*.sql*", SearchOption.AllDirectories).ToList().FirstOrDefault();
                string[] s = (list.ToString()).Split('\\');
                p.ScriptFileName = s[s.Length - 1].Split('.')[0];
                Console.WriteLine("Please Enter Database..");
                string DName = Console.ReadLine();
                p.CreateDBBtn_Click("103.53.41.149", DName, "root", "IndustryOs!!20@21", p.ScriptPath, p.ScriptFileName);
            }

        }
    }

}
