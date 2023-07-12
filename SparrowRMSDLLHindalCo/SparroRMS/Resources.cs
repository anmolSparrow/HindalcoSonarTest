using MySql.Data.MySqlClient;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SparrowRMS
{
    public sealed class Resources
    {
        #region Thread Safe singleton instance declaration
        private static readonly Resources instance = new Resources(); 
        #endregion

        #region Declaration Public string Fields List
        public string Data;
        public string ServerName;
        public string DbUserName;
        public string DbPassword;
        #endregion

        #region Global data table declaration       
        public DataTable _EmpName = new DataTable();
        public DataTable _EmpCode = new DataTable();
        public DataTable _Trainername = new DataTable();
        public DataTable _TrainingType = new DataTable();
        public DataTable _trainingTitle = new DataTable();
        public DataTable InputInfoDt = new DataTable();
        public DataTable MachineDt = new DataTable();
        public DataTable AreaOwner = new DataTable();
        public DataTable _UnitMaster = new DataTable();
        public DataTable TypeOfAuditDT = new DataTable();
        public DataTable serviceConection = new DataTable();
        public DataTable CouplingType = new DataTable();
        public DataTable TpeofObDT = new DataTable();
        public DataTable TypeOFRecomm = new DataTable();
        public DataTable ExternalAudit = new DataTable();
        public DataTable FetchDocument = new DataTable();
        public DataTable EmployeListTR = new DataTable();
        public DataTable dDepatName = new DataTable();
        public DataTable DepartmentMaster = new DataTable();
        public DataTable ListDetails = new DataTable();
        public DataTable KeyDt = new DataTable();
        public DataTable Safetydt = new DataTable();
        public DataTable EmployeementType = new DataTable();
        #endregion

        #region Global Property Declaration
        public string GetConnection
        {
            get;
            set;
        }
        #endregion

        #region Singleton Class Constructor
        private Resources()
        {
            Data = DateTime.Now.ToString();
        } 
        #endregion

        /// <summary>
        /// Singltone Instance Recall
        /// </summary>
        public static  Resources Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Run time Connectionstring Update
        /// </summary>
        /// <param name="DSource"> Pass Server Name</param>
        /// <param name="DName">Pass Database Name</param>
        /// <param name="Paword">Pass Server Password</param>
        /// <param name="U_ID"> Pass Server Login User</param>
        public  void UpdateConnectring(string DSource, string DName, string Paword = "", string U_ID = "")
        {
            try
            {               
                GetConnection = "server=server;user=user;database=db;password=*****;";
                //if (!string.IsNullOrEmpty(Paword) && !string.IsNullOrEmpty(U_ID))
                //{
                //    DbUserName = U_ID;
                //    DbPassword = Paword;
                //    GetConnection = GetConnection.Replace("DBSource", DSource).Replace("DbName", DName).Replace("_Security", "False") + "; " + "User ID=" + U_ID + "; Password=" + Paword + ";" + "";
                //}
                //else
                //{
                //    GetConnection = GetConnection.Replace("DBSource", DSource).Replace("DbName", DName).Replace("_Security", "true");
                //}
                var connectionStringBuilder = new MySqlConnectionStringBuilder(GetConnection);
                connectionStringBuilder.Server = DSource;
                connectionStringBuilder.UserID = U_ID;
                connectionStringBuilder.Password = Paword;
                connectionStringBuilder.Database = DName;
                connectionStringBuilder.Port = 3306;
                GetConnection = connectionStringBuilder.ToString();
            }
            catch (Exception cnn)
            {
                throw new Exception(cnn.Message);
            }
        }

        #region RP All Method List For DML,DDL and DCL

        /// <summary>
        /// Get Master data
        /// </summary>
        /// <param name="procName">Pass Store Procedure Name</param>
        /// <returns></returns>
        public async Task<DataTable> GetDataTableAsync(string procName)
        {

            return await Task.Run(() =>
            {
                var dt = new DataTable();
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                    return dt;
                }
            });
        }

        /// <summary>
        /// This is Use for Get Asynch DataTable List for Mutiple Hits
        /// </summary>
        /// <param name="Query">Pass Sql Inline Query</param>
        /// <returns> List of DataTable Returns</returns>
        public async Task<DataTable> InLineTableAsync(string Query)
        {

            return await Task.Run(() =>
            {
                var dt = new DataTable();
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.Text;
                        sda.SelectCommand.CommandText = Query;
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                    return dt;
                }
            });
        }

        /// <summary>
        /// Master Data Calling List of Method
        /// </summary>
        public async void callMethod()
        {
            // Task<DataTable> InputMasterDT = GetDataTableAsync("Sp_FetchMaintenaceInputeMaster");
            // InputInfoDt = await InputMasterDT;

            // Task<DataTable> MachineDT = GetDataTableAsync("Sp_Loadachines");
            // MachineDt = await MachineDT;

            // Task<DataTable> EmpDT = GetDataTableAsync("Sp_GetEmployyeCode");
            // _EmpCode = await EmpDT;

            // Task<DataTable> EmpNameDT = GetDataTableAsync("SP_GetEmployeeName");
            // _EmpName = await EmpNameDT;

            // Task<DataTable> AreamasterDT = GetDataTableAsync("SP_GetEmployeeName");
            // AreaOwner = await AreamasterDT;

            // Task<DataTable> UnitMasterDT = GetDataTableAsync("Sp_GetUnitMaster");
            // _UnitMaster = await UnitMasterDT;

            // Task<DataTable>  serviceConectionDT = GetDataTableAsync("Sp_GetServiceCode");

            try
            {
                _UnitMaster = await GetDataTableAsync("Sp_GetUnitMaster");
                _EmpName = await GetDataTableAsync("SP_GetEmployeeName");
                _EmpCode = await GetDataTableAsync("Sp_GetEmployyeCode");
                MachineDt = await GetDataTableAsync("Sp_Loadachines");
                //InputInfoDt = await GetDataTableAsync("Sp_FetchMaintenaceInputeMaster");
                serviceConection = await GetDataTableAsync("Sp_GetServiceCode"); ;
                CouplingType = await GetDataTableAsync("Sp_GetCouplingType");
                TpeofObDT = await GetDataTableAsync("Sp_FetchMasterObservation");
                //TypeOfAuditDT = await GetDataTableAsync("Sp_FetTypeOfAuditMasterKey");
                TypeOFRecomm = await GetDataTableAsync("Sp_FetchRecommnedationMaster");
                AreaOwner = await GetDataTableAsync("Sp_FetchAreamMaster");
                //EmployeListTR = await GetDataTableAsync("SP_GetEmployeeNameForTraining");
                dDepatName = await GetDataTableAsync("Sp_FetchDeptMasterLoad");
                DepartmentMaster = await GetDataTableAsync("Sp_GetDeptMaster");
                //ListDetails = await GetDataTableAsync("Sp_GetTrainingCodeList");
                KeyDt = await GetDataTableAsync("Sp_FetchKeyMasterCompList");
                Safetydt = await GetDataTableAsync("Sp_FetchSafetyComponets");
                //EmployeementType = await GetDataTableAsync("SP_GetEmployeementType");
                string query = "select distinct TTitle  from ListOfTrainingCodeTBL order by TTitle asc";//where TTitle like 'A%'
                string _query = "select distinct  ltrim(rtrim(TrainingType)) as TraingType from GenericTrainingTitleList";
                _trainingTitle = await InLineTableAsync(query);
                _TrainingType = await InLineTableAsync(_query);
                //ExternalAudit = await GetDataTableAsync("Sp_FetchExternalAuditCodeReport");
                FetchDocument = await GetDataTableAsync("Sp_FetchDocumentMaster");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        /// <summary>
        /// This is for Clear Memory Initialization
        /// </summary>
        public void DIsposeDT()
        {
            _EmpName.Clear();
            _EmpCode.Clear();
            _Trainername.Clear();
            _TrainingType.Clear();
            _trainingTitle.Clear();
            InputInfoDt.Clear();
            MachineDt.Clear();
            AreaOwner.Clear();
            _UnitMaster.Clear();
            serviceConection.Clear();
            CouplingType.Clear();
            TpeofObDT.Clear();
            TypeOFRecomm.Clear();
            ExternalAudit.Clear();
            FetchDocument.Clear();
            EmployeListTR.Clear();
            DepartmentMaster.Clear();
            dDepatName.Clear();
            _EmpName.Dispose();
            _EmpCode.Dispose();
            _Trainername.Dispose();
            _TrainingType.Dispose();
            _trainingTitle.Dispose();
            InputInfoDt.Dispose();
            MachineDt.Dispose();
            AreaOwner.Dispose();
            _UnitMaster.Dispose();
            serviceConection.Dispose();
            CouplingType.Dispose();
            TpeofObDT.Dispose();
            TypeOFRecomm.Dispose();
            //   ExternalAudit.Dispose();
            // FetchDocument.Dispose();
            EmployeListTR.Dispose();
            dDepatName.Dispose();
            DepartmentMaster.Dispose();
        }

        /// <summary>
        /// Load  Connector Type From DB
        /// </summary>
        /// <param name="prcName"> Pass ProcName</param>
        /// <returns> DataTable Return</returns>
        public DataTable GetConnectionType(string prcName)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = prcName;
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (MySqlException Ex)
            {
                throw new Exception(Ex.Message);
                // return dt;
            }
            return dt;
        }

        /// <summary>
        /// this is use for Insert Mutiple type Connection Property Fields
        /// </summary>
        /// <param name="variable">Pass list of fields</param>
        /// <param name="TabType">Pass type of connection</param>
        /// <param name="ProcName">Pass  Sql Proc Name</param>
        /// <returns>Data insertion Status if return 1 Data Insert Successfully otherwise Fail</returns>
        public int InsertData(string variable, string TabType, string ProcName)
        {
            int result = 0;
            var value = variable.Split('~');
            //decimal dd = Convert.ToDecimal(value[5]);
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = ProcName;
                            if (TabType == "Pipe")
                            {
                                sda.InsertCommand.Parameters.Add("p_Mlocation", MySqlDbType.TinyText).Value = value[0];
                                sda.InsertCommand.Parameters.Add("p_frmConn", MySqlDbType.TinyText).Value = value[1];
                                sda.InsertCommand.Parameters.Add("p_Conntd", MySqlDbType.TinyText).Value = value[2];
                                sda.InsertCommand.Parameters.Add("p_Uname", MySqlDbType.TinyText).Value = value[3];
                                sda.InsertCommand.Parameters.Add("p_uid", MySqlDbType.Int32).Value = Convert.ToInt32(value[4]);

                                sda.InsertCommand.Parameters.Add("p_Pipesize", MySqlDbType.Decimal).Value = Convert.ToDecimal(value[5]);
                                sda.InsertCommand.Parameters.Add("p_P_Unit", MySqlDbType.TinyText).Value = value[6];

                                sda.InsertCommand.Parameters.Add("p_Schdule", MySqlDbType.Decimal).Value = Convert.ToDecimal(value[7]);
                                sda.InsertCommand.Parameters.Add("p_PipeClass", MySqlDbType.Decimal).Value = Convert.ToDecimal(value[8]);
                                sda.InsertCommand.Parameters.Add("p_MaxworKpressure", MySqlDbType.Decimal).Value = Convert.ToDecimal(value[9]);
                                sda.InsertCommand.Parameters.Add("p_MaxUnit", MySqlDbType.TinyText).Value = value[10];
                                sda.InsertCommand.Parameters.Add("p_maxtemp", MySqlDbType.Decimal).Value = Convert.ToDecimal(value[11]);
                                sda.InsertCommand.Parameters.Add("p_maxTempUnit", MySqlDbType.TinyText).Value = value[12];
                                sda.InsertCommand.Parameters.Add("p_MConstruction", MySqlDbType.TinyText).Value = value[13];
                                sda.InsertCommand.Parameters.Add("p_Ratings", MySqlDbType.TinyText).Value = value[14];
                                sda.InsertCommand.Parameters.Add("p_ANSI", MySqlDbType.TinyText).Value = value[15];
                                sda.InsertCommand.Parameters.Add("p_Standard", MySqlDbType.TinyText).Value = value[16];
                                sda.InsertCommand.Parameters.Add("p_Ffuid", MySqlDbType.TinyText).Value = value[17];
                                sda.InsertCommand.Parameters.Add("p_F_Unit", MySqlDbType.TinyText).Value = value[18];

                                sda.InsertCommand.Parameters.Add("p_TempFluid", MySqlDbType.TinyText).Value = value[19];
                                sda.InsertCommand.Parameters.Add("p_Temp_Unit", MySqlDbType.TinyText).Value = value[20];
                                sda.InsertCommand.Parameters.Add("p_Hazchem", MySqlDbType.TinyText).Value = value[21];
                                sda.InsertCommand.Parameters.Add("p_serconn", MySqlDbType.TinyText).Value = value[22];
                                sda.InsertCommand.Parameters.Add("p_empCode", MySqlDbType.TinyText).Value = value[23];
                                sda.InsertCommand.Parameters.Add("p_RcConnector", MySqlDbType.TinyText).Value = value[24];
                                sda.InsertCommand.Parameters.Add("p_RcCord", MySqlDbType.TinyText).Value = value[25];
                            }
                            else if (TabType == "Cable")
                            {
                                sda.InsertCommand.Parameters.Add("p_Mlocation", MySqlDbType.TinyText).Value = value[0];
                                sda.InsertCommand.Parameters.Add("p_frmConn", MySqlDbType.TinyText).Value = value[1];
                                //sda.InsertCommand.Parameters.Add("p_Conntd", MySqlDbType.TinyText).Value = value[2];
                                sda.InsertCommand.Parameters.Add("p_Uname", MySqlDbType.TinyText).Value = value[2];
                                sda.InsertCommand.Parameters.Add("p_uid", MySqlDbType.Int32).Value = Convert.ToInt32(value[3]);

                                sda.InsertCommand.Parameters.Add("p_V_Range", MySqlDbType.Decimal).Value = Convert.ToDecimal(value[4]);
                                sda.InsertCommand.Parameters.Add("p_V_Unit", MySqlDbType.TinyText).Value = value[5];

                                sda.InsertCommand.Parameters.Add("p_CableSize", MySqlDbType.Decimal).Value = Convert.ToDecimal(value[6]);
                                sda.InsertCommand.Parameters.Add("p_V_UnitSize", MySqlDbType.TinyText).Value = value[7];

                                sda.InsertCommand.Parameters.Add("p_Typesofinsulation", MySqlDbType.TinyText).Value = value[8];
                                sda.InsertCommand.Parameters.Add("p_Numberofcores", MySqlDbType.Decimal).Value = Convert.ToDecimal(value[9]);

                                sda.InsertCommand.Parameters.Add("p_Normalcurrentrating", MySqlDbType.Decimal).Value = Convert.ToDecimal(value[10]);
                                sda.InsertCommand.Parameters.Add("p_N_Unit", MySqlDbType.TinyText).Value = value[11];

                                sda.InsertCommand.Parameters.Add("p_Shortcircuit", MySqlDbType.Decimal).Value = Convert.ToDecimal(value[12]);
                                sda.InsertCommand.Parameters.Add("p_S_Unit", MySqlDbType.TinyText).Value = value[13];
                                sda.InsertCommand.Parameters.Add("p_Conductormaterial", MySqlDbType.TinyText).Value = value[14];
                                sda.InsertCommand.Parameters.Add("p_pInst", MySqlDbType.TinyText).Value = value[15];
                                sda.InsertCommand.Parameters.Add("p_empCode", MySqlDbType.TinyText).Value = value[16];
                                sda.InsertCommand.Parameters.Add("p_Conntd", MySqlDbType.TinyText).Value = value[17];
                                sda.InsertCommand.Parameters.Add("p_RcConnector", MySqlDbType.TinyText).Value = value[18];
                                sda.InsertCommand.Parameters.Add("p_RcCord", MySqlDbType.TinyText).Value = value[19];
                            }
                            else if (TabType == "Bus")
                            {
                                sda.InsertCommand.Parameters.Add("p_BType", MySqlDbType.TinyText).Value = value[0];
                                sda.InsertCommand.Parameters.Add("p_Shortratingcurrent", MySqlDbType.Decimal).Value = Convert.ToDecimal(value[1]);
                                sda.InsertCommand.Parameters.Add("p_Short_Unit", MySqlDbType.TinyText).Value = value[2];
                                sda.InsertCommand.Parameters.Add("p_ShortcircuitTime", MySqlDbType.Decimal).Value = Convert.ToDecimal(value[3]);
                                sda.InsertCommand.Parameters.Add("p_ShortTime_Unit", MySqlDbType.TinyText).Value = value[4];
                                sda.InsertCommand.Parameters.Add("p_BusBarmaterial", MySqlDbType.TinyText).Value = value[5];
                                sda.InsertCommand.Parameters.Add("p_Busrating", MySqlDbType.TinyText).Value = value[6];
                                sda.InsertCommand.Parameters.Add("p_Busenclosure", MySqlDbType.TinyText).Value = value[7];
                                sda.InsertCommand.Parameters.Add("p_Mlocation", MySqlDbType.TinyText).Value = value[8];
                                sda.InsertCommand.Parameters.Add("p_frmConn", MySqlDbType.TinyText).Value = value[9];
                                sda.InsertCommand.Parameters.Add("p_Uname", MySqlDbType.TinyText).Value = value[10];
                                sda.InsertCommand.Parameters.Add("p_uid", MySqlDbType.Int32).Value = Convert.ToInt32(value[11]);
                                sda.InsertCommand.Parameters.Add("p_empCode", MySqlDbType.TinyText).Value = value[12];
                                sda.InsertCommand.Parameters.Add("p_Conntd", MySqlDbType.TinyText).Value = value[13];
                                sda.InsertCommand.Parameters.Add("p_RcConnector", MySqlDbType.TinyText).Value = value[14];
                                sda.InsertCommand.Parameters.Add("p_RcCord", MySqlDbType.TinyText).Value = value[15];
                            }
                            else if (TabType == "Coupling")
                            {
                                sda.InsertCommand.Parameters.Add("p_CType", MySqlDbType.TinyText).Value = value[0];
                                sda.InsertCommand.Parameters.Add("p_diameter", MySqlDbType.TinyText).Value = value[1];
                                sda.InsertCommand.Parameters.Add("p_dunits", MySqlDbType.TinyText).Value = value[2];
                                sda.InsertCommand.Parameters.Add("p_torquelmt", MySqlDbType.TinyText).Value = value[3];
                                sda.InsertCommand.Parameters.Add("p_tunits", MySqlDbType.TinyText).Value = value[4];
                                sda.InsertCommand.Parameters.Add("p_frmConn", MySqlDbType.TinyText).Value = value[5];
                                sda.InsertCommand.Parameters.Add("p_Conntd", MySqlDbType.TinyText).Value = value[6];
                                sda.InsertCommand.Parameters.Add("p_Mlocation", MySqlDbType.TinyText).Value = value[7];
                                sda.InsertCommand.Parameters.Add("p_Uname", MySqlDbType.TinyText).Value = value[8];
                                sda.InsertCommand.Parameters.Add("p_uid", MySqlDbType.Int32).Value = Convert.ToInt32(value[9]);
                                sda.InsertCommand.Parameters.Add("p_empCode", MySqlDbType.TinyText).Value = value[10];
                                sda.InsertCommand.Parameters.Add("p_RcConnector", MySqlDbType.TinyText).Value = value[11];
                                sda.InsertCommand.Parameters.Add("p_RcCord", MySqlDbType.TinyText).Value = value[12];
                            }
                            cmd.Dispose();
                        }
                        result = sda.InsertCommand.ExecuteNonQuery();
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Get List of Tables Fields
        /// </summary>
        /// <returns> Return Fields of DataTable</returns>
        public DataTable CreateCommand()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {

                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("select ColumnName,TableName from Generic", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.Text;
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Close();
                    cnn.Dispose();
                }
            }
            catch (MySqlException Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;

        }
        public int UpdateMultifoorCheck(string MachineTagNo, string cordinates, int mode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "SP_UpdateMultifoorCheck";
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_MachineTagNo", MachineTagNo));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_cordinates", cordinates));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_chkstus", mode));
                            count = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int InsertPDFFile(string Query, string AuditCode, string FineName, byte[] FileBytes, DateTime dt)
        {
            int Status = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.Text;
                            sda.InsertCommand.CommandText = Query;
                            sda.InsertCommand.Parameters.AddWithValue("p_FN", FineName);
                            sda.InsertCommand.Parameters.AddWithValue("p_FB", FileBytes);
                            sda.InsertCommand.Parameters.AddWithValue("p_AuditCode", AuditCode);
                            sda.InsertCommand.Parameters.AddWithValue("ReportUploadDate", dt);
                            Status = sda.InsertCommand.ExecuteNonQuery();
                            sda.InsertCommand.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Close();
                }
            }
            catch (MySqlException Ex)
            {
                throw new Exception(Ex.Message);
            }
            return Status;
        }
        public int InsertPDFFile(string Query, string AuditCode, string FineName, byte[] FileBytes)
        {
            int Status = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.Text;
                            sda.InsertCommand.CommandText = Query;
                            sda.InsertCommand.Parameters.AddWithValue("p_FN", FineName);
                            sda.InsertCommand.Parameters.AddWithValue("p_FB", FileBytes);
                            sda.InsertCommand.Parameters.AddWithValue("p_AuditCode", AuditCode);
                            Status = sda.InsertCommand.ExecuteNonQuery();
                            sda.InsertCommand.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Close();
                }
            }
            catch (MySqlException Ex)
            {
                throw new Exception(Ex.Message);
            }
            return Status;
        }

        /// <summary>
        /// this is Use for Inline Sql Funtion
        /// </summary>
        /// <param name="query">Pass the Sql Query</param>
        /// <returns> Return List of Fields into DataTable</returns>
        public DataTable InlineQuery(string query)
        {
            DataTable dt = null;
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.Text;
                        sda.SelectCommand.CommandText = query;
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// this is use for Delete Inline Sql Query
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Data deletion Status if return 1 Data Deletion Successfully otherwise Fail</returns>
        public int InlineDeleteQuery(string query)
        {
            int dt = 0;
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("", cnn))
                        {
                            sda.DeleteCommand = cmd;

                            sda.DeleteCommand.CommandType = CommandType.Text;
                            sda.DeleteCommand.CommandText = query;
                            dt = sda.DeleteCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();

                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// This is use for update records list into datatable
        /// </summary>
        /// <param name="poc">pass proc Name</param>
        /// <param name="par1">Pass parameter value</param>
        /// <param name="par2">Pass parameter value</param>
        /// <param name="par3">Pass parameter value</param>
        /// <param name="par4">Pass parameter value</param>
        /// <param name="val1">Pass parameter value</param>
        /// <param name="val2">Pass parameter value</param>
        /// <param name="val3">Pass parameter value</param>
        /// <param name="val4">Pass parameter value</param>
        /// <returns>Data Updation Status if return 1 Data Updation Successfully otherwise Fail</returns>
        public int UpdateArea(string poc, string par1, string par2, string par3, string par4, string val1, string val2, string val3, string val4)
        {
            int status = 0;

            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand("", cnn))
                    {
                        if (val3 == "update")
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = poc;
                            sda.UpdateCommand.Parameters.Add(par1, MySqlDbType.TinyText).Value = val1;
                            sda.UpdateCommand.Parameters.Add(par2, MySqlDbType.TinyText).Value = val2;
                            sda.UpdateCommand.Parameters.Add(par3, MySqlDbType.TinyText).Value = val3;
                            sda.UpdateCommand.Parameters.Add(par4, MySqlDbType.TinyText).Value = val4;
                            status = sda.UpdateCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            sda.DeleteCommand = cmd;
                            sda.DeleteCommand.CommandType = CommandType.StoredProcedure;
                            sda.DeleteCommand.CommandText = poc;
                            sda.DeleteCommand.Parameters.Add(par1, MySqlDbType.TinyText).Value = val1;
                            sda.DeleteCommand.Parameters.Add(par2, MySqlDbType.TinyText).Value = val2;
                            sda.DeleteCommand.Parameters.Add(par3, MySqlDbType.TinyText).Value = val3;
                            sda.DeleteCommand.Parameters.Add(par4, MySqlDbType.TinyText).Value = val4;
                            status = sda.DeleteCommand.ExecuteNonQuery();
                        }
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return status;
        }

        /// <summary>
        /// This is use for update record into existing datatable
        /// </summary>
        /// <param name="Proc">Pass Proc Name</param>
        /// <param name="Action"> Type Action</param>
        /// <param name="value"> Pass value </param>
        /// <returns>Data Updation Status if return 1 Data Updation Successfully otherwise Fail</returns>
        public int UpdateAuditRecord(string Proc, string Action, string value)
        {
            int status = 0;
            var split = value.Split('-');
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand("", cnn))
                    {
                        sda.UpdateCommand = cmd;

                        sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                        sda.UpdateCommand.CommandText = Proc;
                        sda.UpdateCommand.Parameters.Add("p_action", MySqlDbType.TinyText).Value = split[0];
                        sda.UpdateCommand.Parameters.Add("p_srno", MySqlDbType.TinyText).Value = split[0];
                        sda.UpdateCommand.Parameters.Add("p_Machinetag", MySqlDbType.TinyText).Value = split[0];
                        sda.UpdateCommand.Parameters.Add("p_Typeofobservation", MySqlDbType.TinyText).Value = split[0];
                        sda.UpdateCommand.Parameters.Add("p_Observation", MySqlDbType.TinyText).Value = split[0];
                        sda.UpdateCommand.Parameters.Add("p_Recommendation", MySqlDbType.TinyText).Value = split[0];
                        sda.UpdateCommand.Parameters.Add("p_Typeofrecommendation", MySqlDbType.TinyText).Value = split[0];
                        sda.UpdateCommand.Parameters.Add("p_btnImage", MySqlDbType.TinyText).Value = split[0];
                        sda.UpdateCommand.Parameters.Add("p_RiskCategory", MySqlDbType.TinyText).Value = split[0];
                        sda.UpdateCommand.Parameters.Add("p_Auditor", MySqlDbType.TinyText).Value = split[0];
                        sda.UpdateCommand.Parameters.Add("p_Responsibility", MySqlDbType.TinyText).Value = split[0];
                        sda.UpdateCommand.Parameters.Add("p_Timeframe", MySqlDbType.TinyText).Value = split[0];
                        sda.UpdateCommand.Parameters.Add("p_Acceptance", MySqlDbType.TinyText).Value = split[0];
                        sda.UpdateCommand.Parameters.Add("p_Area", MySqlDbType.TinyText).Value = split[0];
                        sda.UpdateCommand.Parameters.Add("p_Dtime", MySqlDbType.DateTime).Value = Convert.ToDateTime(split[1]);
                        status = sda.DeleteCommand.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    sda.Dispose();

                }
                cnn.Dispose();
            }
            return status;
        }

        /// <summary>
        /// This is use for save image into byte format 
        /// </summary>
        /// <param name="proc">Pass The Name of Sql Proc</param>
        /// <param name="AuditCode">Pass Name Of AuditCode</param>
        /// <param name="Image">Pass Image Byte</param>
        /// <param name="typdut">Pass Name of Audit Type</param>
        /// <returns>Data insertion Status if return 1 Data Insert Successfully otherwise Fail</returns>
        public int UpdateImage(string proc, string AuditCode, byte[] Image, string typdut)
        {
            int result = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.UpdateCommand = cmd;
                        sda.UpdateCommand.Connection = cnn;
                        sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                        sda.UpdateCommand.CommandText = "Sp_SaveImageData";
                        sda.UpdateCommand.Parameters.Add("p_image", MySqlDbType.VarBinary).Value = Image;
                        sda.UpdateCommand.Parameters.Add("p_AuditCode", MySqlDbType.TinyText).Value = AuditCode;
                        sda.UpdateCommand.Parameters.Add("p_typeaudit", MySqlDbType.TinyText).Value = typdut;
                        cmd.Dispose();
                    }
                    result = sda.UpdateCommand.ExecuteNonQuery();
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return result;
        }

        /// <summary>
        /// his is use for insertion record into sql datatable using list of Fixed parameter
        /// </summary>
        /// <param name="ProcName"></param>
        /// <param name="value"></param>
        /// <returns>Data insertion Status if return 1 Data Insert Successfully otherwise Fail</returns>
        public int InsertRecord(string ProcName, string value)
        {
            var values = value.Split('+');
            decimal d = Convert.ToDecimal(values[8].Trim());
            string value1 = values[5].Trim();
            string value2 = values[6].Trim();
            DateTime dt1 = Convert.ToDateTime(value1);
            DateTime dt2 = Convert.ToDateTime(value2);
            // DateTime dt = Convert.ToDateTime(value[5].ToString());
            int result = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = ProcName;
                            sda.InsertCommand.Parameters.Add("p_MachineTag", MySqlDbType.TinyText).Value = values[0];
                            sda.InsertCommand.Parameters.Add("p_layer", MySqlDbType.VarChar).Value = values[1];
                            sda.InsertCommand.Parameters.Add("p_MachineSybType", MySqlDbType.VarChar).Value = values[2];
                            sda.InsertCommand.Parameters.Add("p_status", MySqlDbType.VarChar).Value = values[3];
                            sda.InsertCommand.Parameters.Add("p_location", MySqlDbType.TinyText).Value = values[4];
                            sda.InsertCommand.Parameters.Add("p_dateOfInst", MySqlDbType.DateTime).Value = dt1;
                            sda.InsertCommand.Parameters.Add("p_purchaseDate", MySqlDbType.DateTime).Value = dt2;
                            sda.InsertCommand.Parameters.Add("p_ExpLifetme", MySqlDbType.TinyText).Value = values[7];
                            sda.InsertCommand.Parameters.Add("p_PurchasePrice", MySqlDbType.Decimal).Value = d;
                            sda.InsertCommand.Parameters.Add("p_SysGenName", MySqlDbType.VarChar).Value = values[9];
                            sda.InsertCommand.Parameters.Add("p_machinlocation", MySqlDbType.TinyText).Value = values[10];
                            sda.InsertCommand.Parameters.Add("p_userName", MySqlDbType.VarChar).Value = values[11];
                            sda.InsertCommand.Parameters.Add("p_userId", MySqlDbType.VarChar).Value = values[12];
                            sda.InsertCommand.Parameters.Add("p_empCode", MySqlDbType.VarChar).Value = values[13];
                            result = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();

                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
                // MachineMasterTblInsert("ABABAB" + "_" + value[8] + value[0]);
            }

            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return result;

        }

        /// <summary>
        /// This is use for insertion record into sql datatable using list of 7 parameter
        /// </summary>
        /// <param name="procname">Pass Sql ProcName</param>
        /// <param name="par1">Pass parameter Name</param>
        /// <param name="par2">Pass parameter Name</param>
        /// <param name="par3">Pass parameter Name</param>
        /// <param name="par4">Pass parameter Name</param>
        /// <param name="par5">Pass parameter Name</param>
        /// <param name="par6">Pass parameter Name</param>
        /// <param name="par7">Pass parameter Name</param>
        /// <param name="values">List of Club values</param>
        /// <returns>Data insertion Status if return 1 Data Insert Successfully otherwise Fail</returns>
        public int AddBreakrecord(string procname, string par1, string par2, string par3, string par4, string par5, string par6, string par7, string values)
        {
            var insert = values.Split('_');
            int result = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procname;
                            sda.InsertCommand.Parameters.Add(par1, MySqlDbType.TinyText).Value = insert[0];
                            sda.InsertCommand.Parameters.Add(par2, MySqlDbType.TinyText).Value = insert[1];
                            sda.InsertCommand.Parameters.Add(par3, MySqlDbType.TinyText).Value = insert[2];
                            sda.InsertCommand.Parameters.Add(par4, MySqlDbType.TinyText).Value = insert[3];
                            sda.InsertCommand.Parameters.Add(par5, MySqlDbType.TinyText).Value = insert[4];
                            sda.InsertCommand.Parameters.Add(par6, MySqlDbType.TinyText).Value = insert[5];
                            // sda.InsertCommand.Parameters.Add(par7, MySqlDbType.DateTime).Value = Convert.ToDateTime(insert[6]);
                            sda.InsertCommand.Parameters.Add(par7, MySqlDbType.TinyText).Value = insert[6];
                            result = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return result;
        }

        /// <summary>
        /// this is Use for Insertion record into data table with mutiple parameter list
        /// </summary>
        /// <param name="procname">Pass Sql Proc Name</param>
        /// <param name="par1">Pass Parameter Name</param>
        /// <param name="par2">Pass Parameter Name</param>
        /// <param name="par3">Pass Parameter Name</param>
        /// <param name="par4">Pass Parameter Name</param>     
        /// <param name="values">List Of Club Values</param>
        /// <param name="s">Return Output Value from Sql Result Set</param>
        public void InsertMasterrecord(string procname, string par1, string par2, string par3, string par4, string values, out string s)
        {
            var insert = values.Split('_');
            // int result = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procname;
                            sda.InsertCommand.Parameters.Add(par1, MySqlDbType.TinyText).Value = insert[0];
                            sda.InsertCommand.Parameters.Add(par2, MySqlDbType.VarChar).Value = insert[1];
                            sda.InsertCommand.Parameters.Add(par3, MySqlDbType.VarChar).Value = insert[2];
                            sda.InsertCommand.Parameters.Add(par4, MySqlDbType.VarChar, 50);
                            sda.InsertCommand.Parameters[par4].Direction = ParameterDirection.Output;
                            sda.InsertCommand.ExecuteNonQuery();
                            //result = sda.InsertCommand.ExecuteNonQuery();
                            s = sda.InsertCommand.Parameters[par4].Value.ToString();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            //return result;
        }

        /// <summary>
        /// this is Use for Insertion record into data table with mutiple parameter list
        /// </summary>
        /// <param name="procname">Pass Sql Proc Name</param>
        /// <param name="par1">Pass Parameter Name</param>
        /// <param name="par2">Pass Parameter Name</param>
        /// <param name="par3">Pass Parameter Name</param>
        /// <param name="par4">Pass Parameter Name</param>
        /// <param name="par5">Pass Parameter Name</param>
        /// <param name="values">List Of Club Values</param>
        /// <param name="s">Return Output Value from Sql Result Set</param>
        public void InsertMasterrecord(string procname, string par1, string par2, string par3, string par4, string par5, string values, out string s)
        {
            var insert = values.Split('_');
            // int result = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procname;
                            sda.InsertCommand.Parameters.Add(par1, MySqlDbType.TinyText).Value = insert[0];
                            sda.InsertCommand.Parameters.Add(par2, MySqlDbType.VarChar).Value = insert[1];
                            sda.InsertCommand.Parameters.Add(par3, MySqlDbType.VarChar).Value = insert[2];
                            sda.InsertCommand.Parameters.Add(par4, MySqlDbType.VarChar).Value = insert[3];
                            sda.InsertCommand.Parameters.Add(par5, MySqlDbType.VarChar, 50);
                            sda.InsertCommand.Parameters[par5].Direction = ParameterDirection.Output;
                            sda.InsertCommand.ExecuteNonQuery();
                            //result = sda.InsertCommand.ExecuteNonQuery();
                            s = sda.InsertCommand.Parameters[par4].Value.ToString();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            //return result;
        }

        /// <summary>
        /// This Is use for Check Existing Record Status Into table 
        /// </summary>
        /// <param name="procname">Pass Sql ProcName</param>
        /// <param name="par1">Pass Output Parameter Name</param>
        /// <returns> Return Output Of Result Set</returns>
        public int CheckCAPADATA(string procname, string par1)
        {
            int Srets = 0;
            try
            {

                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procname;
                            sda.InsertCommand.Parameters.Add(par1, MySqlDbType.Int32, 50);
                            sda.InsertCommand.Parameters[par1].Direction = ParameterDirection.Output;
                            sda.InsertCommand.ExecuteNonQuery();
                            Srets = int.Parse(sda.InsertCommand.Parameters[par1].Value.ToString());
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return Srets;

        }

        /// <summary>
        /// This Is use for Get DataTable From DB
        /// </summary>
        /// <param name="procname">Pass Sql ProcName</param>
        /// <param name="par1"> Pass Parameter Name</param>
        /// <param name="valu">Pass Parameter Value</param>
        /// <returns> Return DataTable</returns>
        public DataTable LastDateReturn(string procname, string par1, string valu)
        {
            DataTable dt = null;
            try
            {

                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = procname;
                            sda.SelectCommand.Parameters.Add(par1, MySqlDbType.TinyText).Value = valu;
                            dt = new DataTable();
                            sda.Fill(dt);
                            sda.Dispose();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;

        }

        /// <summary>
        /// This is use for get data from DB with no 7 string parameter list
        /// </summary>
        /// <param name="procname">Pass Sql ProcName</param>
        /// <param name="par1">Pass parameter name</param>
        /// <param name="par2">Pass parameter name</param>
        /// <param name="par3">Pass parameter name</param>
        /// <param name="par4">Pass parameter name</param>
        /// <param name="par5">Pass parameter name</param>
        /// <param name="par6">Pass parameter name</param>
        /// <param name="par7">Pass parameter name</param>               
        /// <param name="values">List Of club Values</param>
        /// <returns>Data insertion Status if return 1 Data Insert Successfully otherwise Fail</returns>
        public int InsertMasterrecord(string procname, string par1, string par2, string par3, string par4, string par5, string par6, string par7, string values)
        {
            var insert = values.Split('~');
            int result = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procname;
                            sda.InsertCommand.Parameters.Add(par1, MySqlDbType.TinyText).Value = insert[0];
                            sda.InsertCommand.Parameters.Add(par2, MySqlDbType.TinyText).Value = insert[1];
                            sda.InsertCommand.Parameters.Add(par3, MySqlDbType.TinyText).Value = insert[2];
                            sda.InsertCommand.Parameters.Add(par4, MySqlDbType.TinyText).Value = insert[3];
                            sda.InsertCommand.Parameters.Add(par5, MySqlDbType.TinyText).Value = insert[4];
                            sda.InsertCommand.Parameters.Add(par6, MySqlDbType.TinyText).Value = insert[5];
                            sda.InsertCommand.Parameters.Add(par7, MySqlDbType.TinyText).Value = insert[6];
                            result = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return result;
        }

        /// <summary>
        /// This is use for get data from DB with no 8 string parameter list
        /// </summary>
        /// <param name="procname">Pass Sql ProcName</param>
        /// <param name="par1">Pass parameter name</param>
        /// <param name="par2">Pass parameter name</param>
        /// <param name="par3">Pass parameter name</param>
        /// <param name="par4">Pass parameter name</param>
        /// <param name="par5">Pass parameter name</param>
        /// <param name="par6">Pass parameter name</param>
        /// <param name="par7">Pass parameter name</param>
        /// <param name="par8">Pass parameter name</param>          
        /// <param name="values">List Of club Values</param>
        /// <returns>Data insertion Status if return 1 Data Insert Successfully otherwise Fail</returns>
        public int insertMasterrecord(string procname, string par1, string par2, string par3, string par4, string par5, string par6, string par7, string par8, string values)///
        {
            var insert = values.Split('~');
            int result = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procname;
                            sda.InsertCommand.Parameters.Add(par1, MySqlDbType.TinyText).Value = insert[0];
                            sda.InsertCommand.Parameters.Add(par2, MySqlDbType.TinyText).Value = insert[1];
                            sda.InsertCommand.Parameters.Add(par3, MySqlDbType.TinyText).Value = insert[2];
                            sda.InsertCommand.Parameters.Add(par4, MySqlDbType.TinyText).Value = insert[3];
                            sda.InsertCommand.Parameters.Add(par5, MySqlDbType.TinyText).Value = insert[4];
                            sda.InsertCommand.Parameters.Add(par6, MySqlDbType.TinyText).Value = insert[5];
                            sda.InsertCommand.Parameters.Add(par7, MySqlDbType.TinyText).Value = insert[6];
                            sda.InsertCommand.Parameters.Add(par8, MySqlDbType.TinyText).Value = insert[7];
                            result = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return result;
        }

        /// <summary>
        /// This is use for get data from DB with no 10 string parameter list
        /// </summary>
        /// <param name="procname">Pass Sql ProcName</param>
        /// <param name="par1">Pass parameter name</param>
        /// <param name="par2">Pass parameter name</param>
        /// <param name="par3">Pass parameter name</param>
        /// <param name="par4">Pass parameter name</param>
        /// <param name="par5">Pass parameter name</param>
        /// <param name="par6">Pass parameter name</param>
        /// <param name="par7">Pass parameter name</param>
        /// <param name="par8">Pass parameter name</param>
        /// <param name="par9">Pass parameter name</param>
        /// <param name="par10">Pass parameter name</param>      
        /// <param name="values">List Of club Values</param>
        /// <returns>Data insertion Status if return 1 Data Insert Successfully otherwise Fail</returns>
        public int InsertMasterrecord(string procname, string par1, string par2, string par3, string par4, string par5, string par6, string par7, string par8, string par9, string par10, string values)
        {
            var insert = values.Split('_');
            int result = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procname;
                            sda.InsertCommand.Parameters.Add(par1, MySqlDbType.TinyText).Value = insert[0];
                            sda.InsertCommand.Parameters.Add(par2, MySqlDbType.TinyText).Value = insert[1];
                            sda.InsertCommand.Parameters.Add(par3, MySqlDbType.TinyText).Value = insert[2];
                            sda.InsertCommand.Parameters.Add(par4, MySqlDbType.TinyText).Value = insert[3];
                            sda.InsertCommand.Parameters.Add(par5, MySqlDbType.TinyText).Value = insert[4];
                            sda.InsertCommand.Parameters.Add(par6, MySqlDbType.TinyText).Value = insert[5];
                            sda.InsertCommand.Parameters.Add(par7, MySqlDbType.TinyText).Value = insert[6];
                            sda.InsertCommand.Parameters.Add(par8, MySqlDbType.TinyText).Value = insert[7];
                            sda.InsertCommand.Parameters.Add(par9, MySqlDbType.TinyText).Value = insert[8];
                            sda.InsertCommand.Parameters.Add(par10, MySqlDbType.TinyText).Value = insert[9];
                            result = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return result;
        }

        /// <summary>
        /// This is use for get data from DB with no 15 string parameter list
        /// </summary>
        /// <param name="procname">Pass Sql ProcName</param>
        /// <param name="par1">Pass parameter name</param>
        /// <param name="par2">Pass parameter name</param>
        /// <param name="par3">Pass parameter name</param>
        /// <param name="par4">Pass parameter name</param>
        /// <param name="par5">Pass parameter name</param>
        /// <param name="par6">Pass parameter name</param>
        /// <param name="par7">Pass parameter name</param>
        /// <param name="par8">Pass parameter name</param>
        /// <param name="par9">Pass parameter name</param>
        /// <param name="par10">Pass parameter name</param>
        /// <param name="par11">Pass parameter name</param>
        /// <param name="par12">Pass parameter name</param>
        /// <param name="par13">Pass parameter name</param>
        /// <param name="par14">Pass parameter name</param>
        /// <param name="par15">Pass parameter name</param>
        /// <param name="values">List Of club Values</param>
        /// <returns>Data insertion Status if return 1 Data Insert Successfully otherwise Fail</returns>
        public int InsertMasterrecord(string procname, string par1, string par2, string par3, string par4, string par5, string par6, string par7, string par8, string par9, string par10, string par11, string par12, string par13, string par14, string par15, string values, string OP = "")
        {
            var insert = values.Split('_');
            int result = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procname;
                            sda.InsertCommand.Parameters.Add(par1, MySqlDbType.Int32).Value = insert[0];
                            sda.InsertCommand.Parameters.Add(par2, MySqlDbType.TinyText).Value = insert[1];
                            sda.InsertCommand.Parameters.Add(par3, MySqlDbType.Int32).Value = insert[2];
                            sda.InsertCommand.Parameters.Add(par4, MySqlDbType.TinyText).Value = insert[3];
                            sda.InsertCommand.Parameters.Add(par5, MySqlDbType.TinyText).Value = insert[4];
                            sda.InsertCommand.Parameters.Add(par6, MySqlDbType.TinyText).Value = insert[5];
                            sda.InsertCommand.Parameters.Add(par7, MySqlDbType.TinyText).Value = insert[6];
                            sda.InsertCommand.Parameters.Add(par8, MySqlDbType.TinyText).Value = insert[7];
                            sda.InsertCommand.Parameters.Add(par9, MySqlDbType.DateTime).Value = Convert.ToDateTime(insert[8]);
                            sda.InsertCommand.Parameters.Add(par10, MySqlDbType.DateTime).Value = Convert.ToDateTime(insert[9]);
                            sda.InsertCommand.Parameters.Add(par11, MySqlDbType.TinyText).Value = insert[10];
                            sda.InsertCommand.Parameters.Add(par12, MySqlDbType.TinyText).Value = insert[11];
                            sda.InsertCommand.Parameters.Add(par13, MySqlDbType.TinyText).Value = insert[12];
                            sda.InsertCommand.Parameters.Add(par14, MySqlDbType.VarChar).Value = insert[13];
                            sda.InsertCommand.Parameters.Add(par15, MySqlDbType.VarChar).Value = insert[14];
                            result = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return result;
        }

        /// <summary>
        /// This is use for get data from DB with no 13 string parameter list
        /// </summary>
        /// <param name="procname">Pass Sql ProcName</param>
        /// <param name="par1">Pass parameter name</param>
        /// <param name="par2">Pass parameter name</param>
        /// <param name="par3">Pass parameter name</param>
        /// <param name="par4">Pass parameter name</param>
        /// <param name="par5">Pass parameter name</param>
        /// <param name="par6">Pass parameter name</param>
        /// <param name="par7">Pass parameter name</param>
        /// <param name="par8">Pass parameter name</param>
        /// <param name="par9">Pass parameter name</param>
        /// <param name="par10">Pass parameter name</param>
        /// <param name="par11">Pass parameter name</param>
        /// <param name="par12">Pass parameter name</param>
        /// <param name="par13">Pass parameter name</param>        
        /// <param name="values">List Of club Values</param>
        /// <returns>Data insertion Status if return 1 Data Insert Successfully otherwise Fail</returns>
        public int InsertMasterrecord(string procname, string par1, string par2, string par3, string par4, string par5, string par6, string par7, string par8, string par9, string par10, string par11, string par12, string par13, string values)
        {
            var insert = values.Split('_');
            int result = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procname;
                            sda.InsertCommand.Parameters.Add(par1, MySqlDbType.VarChar).Value = insert[0];
                            sda.InsertCommand.Parameters.Add(par2, MySqlDbType.Int32).Value = int.Parse(insert[1]);
                            sda.InsertCommand.Parameters.Add(par3, MySqlDbType.VarChar).Value = insert[2];
                            sda.InsertCommand.Parameters.Add(par4, MySqlDbType.TinyText).Value = insert[3];
                            sda.InsertCommand.Parameters.Add(par5, MySqlDbType.TinyText).Value = insert[4];
                            sda.InsertCommand.Parameters.Add(par6, MySqlDbType.DateTime).Value = Convert.ToDateTime(insert[5].ToString());
                            sda.InsertCommand.Parameters.Add(par7, MySqlDbType.DateTime).Value = Convert.ToDateTime(insert[6].ToString());
                            sda.InsertCommand.Parameters.Add(par8, MySqlDbType.VarChar).Value = insert[7];
                            sda.InsertCommand.Parameters.Add(par9, MySqlDbType.VarChar).Value = insert[8];
                            sda.InsertCommand.Parameters.Add(par10, MySqlDbType.VarChar).Value = insert[9];
                            sda.InsertCommand.Parameters.Add(par11, MySqlDbType.VarChar).Value = insert[10];
                            sda.InsertCommand.Parameters.Add(par12, MySqlDbType.TinyText).Value = insert[11];
                            sda.InsertCommand.Parameters.Add(par13, MySqlDbType.TinyText).Value = insert[12];
                            result = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return result;
        }

        /// <summary>
        /// This is use for get data from DB with no 15 string parameter list
        /// </summary>
        /// <param name="procname">Pass Sql ProcName</param>
        /// <param name="par1">Pass parameter name</param>
        /// <param name="par2">Pass parameter name</param>
        /// <param name="par3">Pass parameter name</param>
        /// <param name="par4">Pass parameter name</param>
        /// <param name="par5">Pass parameter name</param>
        /// <param name="par6">Pass parameter name</param>
        /// <param name="par7">Pass parameter name</param>
        /// <param name="par8">Pass parameter name</param>
        /// <param name="par9">Pass parameter name</param>
        /// <param name="par10">Pass parameter name</param>
        /// <param name="par11">Pass parameter name</param>
        /// <param name="par12">Pass parameter name</param>
        /// <param name="par13">Pass parameter name</param>
        /// <param name="par14">Pass parameter name</param>
        /// <param name="par15">Pass parameter name</param>
        /// <param name="values">List Of club Values</param>
        /// <returns>Data insertion Status if return 1 Data Insert Successfully otherwise Fail</returns>
        public int InsertMasterrecord(string procname, string par1, string par2, string par3, string par4, string par5, string par6, string par7, string par8, string par9, string par10, string par11, string par12, string par13, string par14, string par15, string values)
        {
            var insert = values.Split('~');
            int result = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = procname;
                            sda.UpdateCommand.Parameters.Add(par1, MySqlDbType.TinyText).Value = insert[0];
                            sda.UpdateCommand.Parameters.Add(par2, MySqlDbType.TinyText).Value = insert[1];
                            sda.UpdateCommand.Parameters.Add(par3, MySqlDbType.TinyText).Value = insert[2];
                            sda.UpdateCommand.Parameters.Add(par4, MySqlDbType.TinyText).Value = insert[3];
                            sda.UpdateCommand.Parameters.Add(par5, MySqlDbType.TinyText).Value = insert[4];
                            sda.UpdateCommand.Parameters.Add(par6, MySqlDbType.TinyText).Value = insert[5];
                            sda.UpdateCommand.Parameters.Add(par7, MySqlDbType.TinyText).Value = insert[6];
                            sda.UpdateCommand.Parameters.Add(par8, MySqlDbType.TinyText).Value = insert[7];
                            sda.UpdateCommand.Parameters.Add(par9, MySqlDbType.TinyText).Value = insert[8];
                            sda.UpdateCommand.Parameters.Add(par10, MySqlDbType.TinyText).Value = insert[9];
                            sda.UpdateCommand.Parameters.Add(par11, MySqlDbType.TinyText).Value = insert[10];
                            sda.UpdateCommand.Parameters.Add(par12, MySqlDbType.TinyText).Value = insert[11];
                            sda.UpdateCommand.Parameters.Add(par13, MySqlDbType.Int32).Value = Convert.ToInt32(insert[13]);
                            sda.UpdateCommand.Parameters.Add(par14, MySqlDbType.TinyText).Value = insert[12];
                            sda.UpdateCommand.Parameters.Add(par15, MySqlDbType.TinyText).Value = insert[14];
                            result = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return result;
        }
        /// <summary>
        /// This is use for insert data into sql Db using Eight Sql parameter
        /// </summary>
        /// <param name="procname">Pass Sql ProcName</param>
        /// <param name="par1">Pass parameter name</param>
        /// <param name="par2">Pass parameter name</param>
        /// <param name="par3">Pass parameter name</param>
        /// <param name="par4">Pass parameter name</param>
        /// <param name="par5">Pass parameter name</param>
        /// <param name="par6">Pass parameter name</param>
        /// <param name="par7">Pass parameter name</param>
        /// <param name="par8">Pass parameter name</param>
        /// <param name="values">Pass Club value into Single Variable</param>
        /// <returns><Data insertion Status if return 1 Data Insert Successfully otherwise Fail/returns>
        public int insertMasteObj(string procname, string par1, string par2, string par3, string par4, string par5, string par6, string par7, string par8, string values)
        {
            var insert = values.Split('_');
            int result = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procname;
                            sda.InsertCommand.Parameters.Add(par1, MySqlDbType.TinyText).Value = insert[0];
                            sda.InsertCommand.Parameters.Add(par2, MySqlDbType.TinyText).Value = insert[1];
                            sda.InsertCommand.Parameters.Add(par3, MySqlDbType.TinyText).Value = insert[2];
                            sda.InsertCommand.Parameters.Add(par4, MySqlDbType.TinyText).Value = insert[3];
                            sda.InsertCommand.Parameters.Add(par5, MySqlDbType.TinyText).Value = insert[4];
                            sda.InsertCommand.Parameters.Add(par6, MySqlDbType.TinyText).Value = insert[5];
                            sda.InsertCommand.Parameters.Add(par7, MySqlDbType.TinyText).Value = insert[6];
                            sda.InsertCommand.Parameters.Add(par8, MySqlDbType.TinyText).Value = insert[7];
                            result = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return result;
        }
        public int InsertNearMissGenInfo(string procname, string par1, string par2, string par3, string par4, string par5, string par6, string par7, string par8, string par9, string par10, string par11, string par12, string par13, string par14, string values)
        {
            var insert = values.Split('_');
            int result = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procname;
                            sda.InsertCommand.Parameters.Add(par1, MySqlDbType.TinyText).Value = insert[0];
                            sda.InsertCommand.Parameters.Add(par2, MySqlDbType.TinyText).Value = insert[1];
                            sda.InsertCommand.Parameters.Add(par3, MySqlDbType.TinyText).Value = insert[2];
                            sda.InsertCommand.Parameters.Add(par4, MySqlDbType.TinyText).Value = insert[3];
                            sda.InsertCommand.Parameters.Add(par5, MySqlDbType.TinyText).Value = insert[4];
                            sda.InsertCommand.Parameters.Add(par6, MySqlDbType.TinyText).Value = insert[5];
                            sda.InsertCommand.Parameters.Add(par7, MySqlDbType.TinyText).Value = insert[6];
                            sda.InsertCommand.Parameters.Add(par8, MySqlDbType.TinyText).Value = insert[7];
                            sda.InsertCommand.Parameters.Add(par9, MySqlDbType.TinyText).Value = insert[8];
                            sda.InsertCommand.Parameters.Add(par10, MySqlDbType.TinyText).Value = insert[9];
                            sda.InsertCommand.Parameters.Add(par11, MySqlDbType.TinyText).Value = insert[10];
                            sda.InsertCommand.Parameters.Add(par12, MySqlDbType.TinyText).Value = insert[11];
                            sda.InsertCommand.Parameters.Add(par13, MySqlDbType.Int32).Value = Convert.ToInt32(insert[12]);
                            sda.InsertCommand.Parameters.Add(par14, MySqlDbType.TinyText).Value = insert[13];

                            result = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return result;
        }
        public int insertMasteObj(string procname, string par1, string par2, string par3, string par4, string par5, string par6, string par7, string par8, string par9, string values)
        {
            var insert = values.Split('_');
            int result = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procname;
                            sda.InsertCommand.Parameters.Add(par1, MySqlDbType.TinyText).Value = insert[0];
                            sda.InsertCommand.Parameters.Add(par2, MySqlDbType.TinyText).Value = insert[1];
                            sda.InsertCommand.Parameters.Add(par3, MySqlDbType.TinyText).Value = insert[2];
                            sda.InsertCommand.Parameters.Add(par4, MySqlDbType.TinyText).Value = insert[3];
                            sda.InsertCommand.Parameters.Add(par5, MySqlDbType.TinyText).Value = insert[4];
                            sda.InsertCommand.Parameters.Add(par6, MySqlDbType.TinyText).Value = insert[5];
                            sda.InsertCommand.Parameters.Add(par7, MySqlDbType.TinyText).Value = insert[6];
                            sda.InsertCommand.Parameters.Add(par8, MySqlDbType.TinyText).Value = insert[7];
                            sda.InsertCommand.Parameters.Add(par9, MySqlDbType.TinyText).Value = insert[8];

                            result = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return result;
        }
        public int InsertPlaningInfo(string procname, string par1, string par2, string par3, string par4, string par5, string par6, string par7, string par8, string par9, string par10, string par11, string par12, string par13, string values)
        {
            var insert = values.Split('_');
            int result = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procname;
                            sda.InsertCommand.Parameters.Add(par1, MySqlDbType.TinyText).Value = insert[0];
                            sda.InsertCommand.Parameters.Add(par2, MySqlDbType.TinyText).Value = insert[1];
                            sda.InsertCommand.Parameters.Add(par3, MySqlDbType.TinyText).Value = insert[2];
                            sda.InsertCommand.Parameters.Add(par4, MySqlDbType.TinyText).Value = insert[3];
                            sda.InsertCommand.Parameters.Add(par5, MySqlDbType.DateTime).Value = Convert.ToDateTime(insert[4]);
                            sda.InsertCommand.Parameters.Add(par6, MySqlDbType.DateTime).Value = Convert.ToDateTime(insert[5]);
                            sda.InsertCommand.Parameters.Add(par7, MySqlDbType.DateTime).Value = Convert.ToDateTime(insert[6]);
                            sda.InsertCommand.Parameters.Add(par8, MySqlDbType.TinyText).Value = insert[7];
                            sda.InsertCommand.Parameters.Add(par9, MySqlDbType.TinyText).Value = insert[8];
                            sda.InsertCommand.Parameters.Add(par10, MySqlDbType.TinyText).Value = insert[9];
                            sda.InsertCommand.Parameters.Add(par11, MySqlDbType.TinyText).Value = insert[10];
                            sda.InsertCommand.Parameters.Add(par12, MySqlDbType.TinyText).Value = insert[11];
                            sda.InsertCommand.Parameters.Add(par13, MySqlDbType.TinyText).Value = insert[12];
                            result = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return result;
        }
        public int InsertPlaningInfo(string procname, string par1, string par2, string par3, string par4, string par5, string par6, string par7, string par8, string par9, string par10, string values)
        {
            var insert = values.Split('_');
            int result = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = procname;
                            sda.UpdateCommand.Parameters.Add(par1, MySqlDbType.VarChar).Value = insert[0];
                            sda.UpdateCommand.Parameters.Add(par2, MySqlDbType.VarChar).Value = insert[1];
                            sda.UpdateCommand.Parameters.Add(par3, MySqlDbType.VarChar).Value = insert[2];
                            sda.UpdateCommand.Parameters.Add(par4, MySqlDbType.VarChar).Value = insert[3];
                            sda.UpdateCommand.Parameters.Add(par5, MySqlDbType.VarChar).Value = insert[4];
                            sda.UpdateCommand.Parameters.Add(par6, MySqlDbType.VarChar).Value = insert[5];
                            sda.UpdateCommand.Parameters.Add(par7, MySqlDbType.VarChar).Value = insert[6];
                            sda.UpdateCommand.Parameters.Add(par8, MySqlDbType.VarChar).Value = insert[7];
                            sda.UpdateCommand.Parameters.Add(par9, MySqlDbType.VarChar).Value = insert[8];
                            sda.UpdateCommand.Parameters.Add(par10, MySqlDbType.DateTime).Value = Convert.ToDateTime(insert[9]);
                            result = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return result;
        }
        public int InsertPlaningInfo(string procname, string par1, string par2, string par3, string par4, string par5, string par6, string par7, string par8, string par9, string par10, string par11, string par12, string par13, string par14, string par15, string values)
        {
            var insert = values.Split('_');
            int result = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procname;
                            sda.InsertCommand.Parameters.Add(par1, MySqlDbType.TinyText).Value = insert[0];
                            sda.InsertCommand.Parameters.Add(par2, MySqlDbType.TinyText).Value = insert[1];
                            sda.InsertCommand.Parameters.Add(par3, MySqlDbType.TinyText).Value = insert[2];
                            sda.InsertCommand.Parameters.Add(par4, MySqlDbType.TinyText).Value = insert[3];
                            sda.InsertCommand.Parameters.Add(par5, MySqlDbType.TinyText).Value = insert[4];
                            sda.InsertCommand.Parameters.Add(par6, MySqlDbType.TinyText).Value = insert[5];
                            sda.InsertCommand.Parameters.Add(par7, MySqlDbType.TinyText).Value = insert[6];
                            sda.InsertCommand.Parameters.Add(par8, MySqlDbType.TinyText).Value = insert[7];
                            sda.InsertCommand.Parameters.Add(par9, MySqlDbType.TinyText).Value = insert[9];
                            sda.InsertCommand.Parameters.Add(par10, MySqlDbType.TinyText).Value = insert[10];
                            sda.InsertCommand.Parameters.Add(par11, MySqlDbType.TinyText).Value = insert[8];
                            sda.InsertCommand.Parameters.Add(par12, MySqlDbType.TinyText).Value = insert[11];
                            sda.InsertCommand.Parameters.Add(par13, MySqlDbType.TinyText).Value = insert[12];
                            sda.InsertCommand.Parameters.Add(par14, MySqlDbType.TinyText).Value = insert[13];
                            sda.InsertCommand.Parameters.Add(par15, MySqlDbType.TinyText).Value = insert[14];
                            result = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return result;
        }
        public int InsertNearMissGenInfo(string procname, string par1, string par2, string par3, string par4, string par5, string par6, string par7, string par8, string par9, string par10, string values)
        {
            var insert = values.Split('_');
            int result = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procname;
                            sda.InsertCommand.Parameters.Add(par1, MySqlDbType.TinyText).Value = insert[0];
                            sda.InsertCommand.Parameters.Add(par2, MySqlDbType.TinyText).Value = insert[1];
                            sda.InsertCommand.Parameters.Add(par3, MySqlDbType.TinyText).Value = insert[2];
                            sda.InsertCommand.Parameters.Add(par4, MySqlDbType.TinyText).Value = insert[3];
                            sda.InsertCommand.Parameters.Add(par5, MySqlDbType.TinyText).Value = insert[4];
                            sda.InsertCommand.Parameters.Add(par6, MySqlDbType.TinyText).Value = insert[5];
                            sda.InsertCommand.Parameters.Add(par7, MySqlDbType.TinyText).Value = insert[6];
                            sda.InsertCommand.Parameters.Add(par8, MySqlDbType.TinyText).Value = insert[7];
                            sda.InsertCommand.Parameters.Add(par9, MySqlDbType.TinyText).Value = insert[8];
                            sda.InsertCommand.Parameters.Add(par10, MySqlDbType.TinyText).Value = insert[9];
                            result = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return result;
        }
        public int InsertNearMissGenInfo(string procname, string par1, string par2, string par3, string par4, string par5, string par6, string par7, string par8, string par9, string par10, string par11, string par12, string values)
        {
            var insert = values.Split('_');
            int result = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procname;
                            sda.InsertCommand.Parameters.Add(par1, MySqlDbType.TinyText).Value = insert[0];
                            sda.InsertCommand.Parameters.Add(par2, MySqlDbType.TinyText).Value = insert[1];
                            sda.InsertCommand.Parameters.Add(par3, MySqlDbType.TinyText).Value = insert[2];
                            sda.InsertCommand.Parameters.Add(par4, MySqlDbType.TinyText).Value = insert[3];
                            sda.InsertCommand.Parameters.Add(par5, MySqlDbType.TinyText).Value = insert[4];
                            sda.InsertCommand.Parameters.Add(par6, MySqlDbType.TinyText).Value = insert[5];
                            sda.InsertCommand.Parameters.Add(par7, MySqlDbType.TinyText).Value = insert[6];
                            sda.InsertCommand.Parameters.Add(par8, MySqlDbType.TinyText).Value = insert[7];
                            sda.InsertCommand.Parameters.Add(par9, MySqlDbType.TinyText).Value = insert[8];
                            sda.InsertCommand.Parameters.Add(par10, MySqlDbType.TinyText).Value = insert[9];
                            sda.InsertCommand.Parameters.Add(par11, MySqlDbType.TinyText).Value = insert[10];
                            sda.InsertCommand.Parameters.Add(par12, MySqlDbType.DateTime).Value = insert[11];
                            result = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return result;
        }
        /// <summary>
        /// This is use for insertion All Connector data using multiple fields list values
        /// </summary>
        /// <param name="procName">Pass ProcName</param>
        /// <param name="FieldsValue">List Of Fields value into Single Variable</param>
        /// <param name="frmName">Pass name of Calling Form Name</param>
        /// <returns></returns>
        public int InsertRecord(string procName, string FieldsValue, string frmName)
        {
            var value = FieldsValue.Split('_');
            int result = 0;
            try
            {
                if (frmName == "Tentive_Price")
                {
                    using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                    {
                        cnn.Open();
                        using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                        {
                            using (MySqlCommand cmd = new MySqlCommand())
                            {
                                sda.InsertCommand = cmd;
                                sda.InsertCommand.Connection = cnn;
                                sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                                sda.InsertCommand.CommandText = procName;
                                sda.InsertCommand.Parameters.Add("p_make", MySqlDbType.VarChar).Value = value[0];
                                sda.InsertCommand.Parameters.Add("p_NewTechno", MySqlDbType.VarChar).Value = value[1];
                                sda.InsertCommand.Parameters.Add("p_Price", MySqlDbType.Decimal).Value = Convert.ToDecimal(value[2]);
                                sda.InsertCommand.Parameters.Add("p_notes", MySqlDbType.TinyText).Value = value[3];
                                sda.InsertCommand.Parameters.Add("p_SysGenName", MySqlDbType.TinyText).Value = value[4];
                                sda.InsertCommand.Parameters.Add("p_machinename", MySqlDbType.TinyText).Value = value[5];
                                sda.InsertCommand.Parameters.Add("p_machineTag", MySqlDbType.TinyText).Value = value[6];
                                sda.InsertCommand.Parameters.Add("p_username", MySqlDbType.TinyText).Value = value[7];
                                sda.InsertCommand.Parameters.Add("p_userid", MySqlDbType.TinyText).Value = value[8];
                                result = sda.InsertCommand.ExecuteNonQuery();
                                cmd.Dispose();
                            }
                            sda.Dispose();
                        }
                        cnn.Dispose();
                    }
                }
                else if (frmName == "Input_Property")
                {
                    using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                    {
                        cnn.Open();
                        using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                        {
                            using (MySqlCommand cmd = new MySqlCommand())
                            {
                                sda.InsertCommand = cmd;
                                sda.InsertCommand.Connection = cnn;
                                sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                                sda.InsertCommand.CommandText = procName;
                                sda.InsertCommand.Parameters.Add("p_macros", MySqlDbType.VarChar).Value = value[0];
                                sda.InsertCommand.Parameters.Add("p_Sc", MySqlDbType.VarChar).Value = value[1];
                                sda.InsertCommand.Parameters.Add("p_p_prcchk", MySqlDbType.VarChar).Value = value[2];
                                sda.InsertCommand.Parameters.Add("p_SysGenName", MySqlDbType.TinyText).Value = value[3];
                                sda.InsertCommand.Parameters.Add("p_MName", MySqlDbType.TinyText).Value = value[4];
                                result = sda.InsertCommand.ExecuteNonQuery();
                                cmd.Dispose();
                            }
                            sda.Dispose();
                        }
                        cnn.Dispose();
                    }
                }
                else if (frmName == "OutPut_Property")
                {
                    using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                    {
                        cnn.Open();
                        using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                        {
                            using (MySqlCommand cmd = new MySqlCommand())
                            {
                                sda.InsertCommand = cmd;
                                sda.InsertCommand.Connection = cnn;
                                sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                                sda.InsertCommand.CommandText = procName;
                                sda.InsertCommand.Parameters.Add("p_macros", MySqlDbType.VarChar).Value = value[0];
                                sda.InsertCommand.Parameters.Add("p_Sc", MySqlDbType.VarChar).Value = value[1];
                                sda.InsertCommand.Parameters.Add("p_p_prcchk", MySqlDbType.VarChar).Value = value[2];
                                sda.InsertCommand.Parameters.Add("p_SysGenName", MySqlDbType.TinyText).Value = value[3];
                                sda.InsertCommand.Parameters.Add("p_MName", MySqlDbType.TinyText).Value = value[4];
                                result = sda.InsertCommand.ExecuteNonQuery();
                                cmd.Dispose();
                            }
                            sda.Dispose();
                        }
                        cnn.Dispose();
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return result;
        }
        /// <summary>
        /// This is use for Insertion data into database uisng With  Sql Parameter
        /// </summary>
        /// <param name="procName"> Pass name Of ProcName</param>
        /// <param name="Value">Pass Club values</param>
        /// <returns>Data insertion Status if return 1 Data Insert Successfully otherwise Fail</returns>
        public int InsertRecordKeyComTab(string procName, string Value)
        {
            var values = Value.Split('~');
            int rsult = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procName;
                            sda.InsertCommand.Parameters.Add("p_Machinename", MySqlDbType.TinyText).Value = values[0];
                            sda.InsertCommand.Parameters.Add("p_machinetag", MySqlDbType.VarChar).Value = values[1];
                            sda.InsertCommand.Parameters.Add("p_frmConn", MySqlDbType.VarChar).Value = values[2];
                            sda.InsertCommand.Parameters.Add("p_linlocation", MySqlDbType.TinyText).Value = values[3];
                            sda.InsertCommand.Parameters.Add("p_linetype", MySqlDbType.TinyText).Value = values[4];
                            sda.InsertCommand.Parameters.Add("p_MCordinaye", MySqlDbType.TinyText).Value = values[5];
                            sda.InsertCommand.Parameters.Add("p_empCode", MySqlDbType.TinyText).Value = values[6];
                            rsult = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return rsult;
        }
        /// <summary>
        /// This is use for insertion data into database using one sql parameter
        /// </summary>
        /// <param name="procname">Pass Sql ProcName</param>
        /// <param name="value">pass Paramter Value</param>
        /// <param name="parms1">Pass Input parameter Name</param>
        /// <param name="parms2">Pass Output Parameter Name</param>
        /// <param name="s">Get Value from Db into Outpur Parameter</param>
        public void InsertMasterKeycom(string procname, string value, string parms1, string parms2, out string s)
        {

            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procname;
                            sda.InsertCommand.Parameters.Add(parms1, MySqlDbType.VarChar).Value = value;//p_keyName/p_returnValue
                            sda.InsertCommand.Parameters.Add(parms2, MySqlDbType.VarChar, 50);
                            sda.InsertCommand.Parameters[parms2].Direction = ParameterDirection.Output;
                            sda.InsertCommand.ExecuteNonQuery();
                            s = sda.InsertCommand.Parameters[parms2].Value.ToString();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
        public void selectMasterDeptKeycom(string procname, string value, string parms1, string parms2, out string s)
        {

            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = procname;
                            sda.SelectCommand.Parameters.Add(parms1, MySqlDbType.VarChar).Value = value;//p_keyName/p_returnValue
                            sda.SelectCommand.Parameters.Add(parms2, MySqlDbType.VarChar, 50);
                            sda.SelectCommand.Parameters[parms2].Direction = ParameterDirection.Output;
                            sda.SelectCommand.ExecuteNonQuery();
                            s = sda.SelectCommand.Parameters[parms2].Value.ToString();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }


        }
        /// <summary>
        /// This is use for insertion data into database using one sql parameter
        /// </summary>
        /// <param name="procname">Pass Sql ProcName</param>
        /// <param name="value">pass Paramter Value</param>
        /// <param name="parms1">Pass Input parameter Name</param>
        /// <param name="parms2">Pass Output Parameter Name</param>
        /// <param name="s">Get Value from Db into Outpur Parameter</param>
        public void InsertMasterKeycom(string procname, string value, string parms1, string parms2, out int s)
        {

            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procname;
                            sda.InsertCommand.Parameters.Add(parms1, MySqlDbType.VarChar).Value = value;//p_keyName/p_returnValue                       
                            sda.InsertCommand.Parameters[parms2].Direction = ParameterDirection.Output;
                            sda.InsertCommand.ExecuteNonQuery();
                            s = Convert.ToInt32(sda.InsertCommand.Parameters[parms2].Value);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }


        }

        public void selectMasterKeycom(string procname, string value, string parms1, string parms2, out int s)
        {

            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = procname;
                            sda.SelectCommand.Parameters.Add(parms1, MySqlDbType.VarChar).Value = value;//p_keyName/p_returnValue
                            sda.SelectCommand.Parameters.Add(parms2, MySqlDbType.VarChar, 50);
                            sda.SelectCommand.Parameters[parms2].Direction = ParameterDirection.Output;
                            sda.SelectCommand.ExecuteNonQuery();
                            s = Convert.ToInt32(sda.SelectCommand.Parameters[parms2].Value);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }


        }
        /// <summary>
        /// This is use for insertion Data into DataBase using Three parameter
        /// </summary>
        /// <param name="procname">Pass Sql ProcName</param>
        /// <param name="parms1">Pass First parameter name</param>
        /// <param name="parms2">Pass Secound parameter name</param>
        /// <param name="value">Pass First parameter Value</param>
        /// <param name="value2">Pass Secound parameter Value</param>
        /// <param name="parms3">Pass Third Output parameter Name</param>
        /// <param name="s"> Get OutPut Parameter Value from Sql</param>
        public void InsertMasterKeycom(string procname, string parms1, string parms2, string value, string value2, string parms3, out int s)
        {

            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procname;
                            sda.InsertCommand.Parameters.Add(parms1, MySqlDbType.VarChar).Value = value;//p_keyName/p_returnValue
                            sda.InsertCommand.Parameters.Add(parms2, MySqlDbType.VarChar).Value = value2;
                            sda.InsertCommand.Parameters.Add(parms3, MySqlDbType.Int32, 50);
                            sda.InsertCommand.Parameters[parms3].Direction = ParameterDirection.Output;
                            sda.InsertCommand.ExecuteNonQuery();
                            s = Convert.ToInt32(sda.InsertCommand.Parameters[parms3].Value);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
        /// <summary>
        /// this is use for insertion record into database using with two parameter
        /// </summary>
        /// <param name="procname">Pass Sql ProcName</param>
        /// <param name="parms1">Pass parameter name</param>
        /// <param name="parms2">Pass parameter name</param>
        /// <param name="value">Pass Parameter Value</param>
        /// <param name="value2">Pass Parameter Value</param>
        /// <param name="parms3">Pass parameter name</param>
        /// <param name="s"></param>
        public void InsertMasterKeycom(string procname, string parms1, string parms2, string value, string value2, string parms3, out string s)
        {

            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procname;
                            sda.InsertCommand.Parameters.Add(parms1, MySqlDbType.VarChar).Value = value;//p_keyName/p_returnValue
                            sda.InsertCommand.Parameters.Add(parms2, MySqlDbType.VarChar).Value = value2;
                            sda.InsertCommand.Parameters.Add(parms3, MySqlDbType.VarChar, 500);
                            sda.InsertCommand.Parameters[parms3].Direction = ParameterDirection.Output;
                            sda.InsertCommand.ExecuteNonQuery();
                            s = sda.InsertCommand.Parameters[parms3].Value.ToString();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        #region User Module Data Access Process Method List
        public int spRegister(string username, int UserID, string ProjectName, double PhoneNumber,string password, string email, int RoleID, int DeptID, string question, string Ans, string sts, string Geolocation,string EmpCode,ref string Result)
        {
            int Count = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.InsertCommand = cmd;
                        sda.InsertCommand.Connection = cnn;
                        sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                        sda.InsertCommand.CommandText = "Sp_RegistorUser";
                        sda.InsertCommand.Parameters.Add("p_UserName", MySqlDbType.VarChar).Value = username;
                        sda.InsertCommand.Parameters.Add("p_userID", MySqlDbType.Int32).Value = UserID;
                        sda.InsertCommand.Parameters.Add("p_Password", MySqlDbType.TinyText).Value = password;
                        sda.InsertCommand.Parameters.Add("p_Email", MySqlDbType.TinyText, 50).Value = email;
                        sda.InsertCommand.Parameters.Add("p_RoleId", MySqlDbType.Int32).Value = RoleID;
                        sda.InsertCommand.Parameters.Add("p_DeptID", MySqlDbType.Int32).Value = DeptID;
                        sda.InsertCommand.Parameters.Add("p_Question", MySqlDbType.VarChar).Value = question;
                        sda.InsertCommand.Parameters.Add("p_Answer", MySqlDbType.VarChar, 50).Value = Ans;
                        sda.InsertCommand.Parameters.Add("p_ProjectName", MySqlDbType.VarChar).Value = ProjectName;
                        sda.InsertCommand.Parameters.Add("p_PhoneNumber", MySqlDbType.Int64).Value = PhoneNumber;
                        sda.InsertCommand.Parameters.Add("p_Geolocation", MySqlDbType.VarChar).Value = Geolocation;                     
                        if (string.IsNullOrEmpty(sts))
                        {
                            sda.InsertCommand.Parameters.Add("p_staus", MySqlDbType.VarChar).Value = "";
                            if(string.IsNullOrEmpty(EmpCode))
                            {
                                sda.InsertCommand.Parameters.Add("p_EmpCode", MySqlDbType.VarChar).Value = string.Concat("Emp", UserID);
                            }
                            else
                            {
                                sda.InsertCommand.Parameters.Add("p_EmpCode", MySqlDbType.VarChar).Value = EmpCode;
                            }                            
                        }
                        else
                        {
                            sda.InsertCommand.Parameters.Add("p_staus", MySqlDbType.VarChar).Value = sts;
                            sda.InsertCommand.Parameters.Add("p_EmpCode", MySqlDbType.VarChar).Value = string.Concat("Emp",UserID);
                        }
                        sda.InsertCommand.Parameters.Add("p_Result", MySqlDbType.VarChar, 500);
                        sda.InsertCommand.Parameters["p_Result"].Direction = ParameterDirection.Output;
                        Count = sda.InsertCommand.ExecuteNonQuery();
                        Result = sda.InsertCommand.Parameters["p_Result"].Value.ToString();
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
                return Count;
            }
        }
        public int SP_AuthenticationLogin(string email, string password, ref string ProjectName, ref string DeptName, ref string Result, ref string Role, ref string userName, ref int UserID,ref string GeoLocation,ref string EmpCode)
        {
            int Data = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "Sp_Authentication";
                            sda.SelectCommand.Parameters.Add("p_Email", MySqlDbType.TinyText).Value = email;
                            sda.SelectCommand.Parameters.Add("p_Password", MySqlDbType.TinyText).Value = password;
                            sda.SelectCommand.Parameters.Add("p_Result", MySqlDbType.VarChar, 100);
                            sda.SelectCommand.Parameters.Add("p_ProjectName", MySqlDbType.TinyText, 100);
                            sda.SelectCommand.Parameters.Add("p_GeoLocation", MySqlDbType.TinyText, 100);
                            sda.SelectCommand.Parameters.Add("p_EmpCode", MySqlDbType.TinyText, 100);
                            sda.SelectCommand.Parameters.Add("p_DeptName", MySqlDbType.TinyText, 100);
                            sda.SelectCommand.Parameters.Add("p_Role", MySqlDbType.VarChar, 100);
                            sda.SelectCommand.Parameters.Add("p_userName", MySqlDbType.VarChar, 100);
                            sda.SelectCommand.Parameters.Add("p_UserID", MySqlDbType.Int32);
                            sda.SelectCommand.Parameters["p_ProjectName"].Direction = ParameterDirection.Output;
                            sda.SelectCommand.Parameters["p_GeoLocation"].Direction = ParameterDirection.Output;
                            sda.SelectCommand.Parameters["p_EmpCode"].Direction = ParameterDirection.Output;
                            sda.SelectCommand.Parameters["p_DeptName"].Direction = ParameterDirection.Output;
                            sda.SelectCommand.Parameters["p_Result"].Direction = ParameterDirection.Output;
                            sda.SelectCommand.Parameters["p_Role"].Direction = ParameterDirection.Output;
                            sda.SelectCommand.Parameters["p_userName"].Direction = ParameterDirection.Output;
                            sda.SelectCommand.Parameters["p_UserID"].Direction = ParameterDirection.Output;
                            Data = sda.SelectCommand.ExecuteNonQuery();
                            Result = sda.SelectCommand.Parameters["p_Result"].Value.ToString();
                            ProjectName = sda.SelectCommand.Parameters["p_ProjectName"].Value.ToString();
                            GeoLocation = sda.SelectCommand.Parameters["p_GeoLocation"].Value.ToString();
                            DeptName = sda.SelectCommand.Parameters["p_DeptName"].Value.ToString();
                            Role = sda.SelectCommand.Parameters["p_Role"].Value.ToString();
                            userName = sda.SelectCommand.Parameters["p_userName"].Value.ToString();
                            UserID = int.Parse(sda.SelectCommand.Parameters["p_UserID"].Value.ToString());
                            EmpCode= sda.SelectCommand.Parameters["p_EmpCode"].Value.ToString();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return Data;
        }
        public int spCheckEmail(string EmailID, string Action, ref string Result, ref string question, string ans, string ConfirmPWD)
        {
            int Data = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.SelectCommand = cmd;
                        sda.SelectCommand.Connection = cnn;
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = "SP_CheckEmail";
                        sda.SelectCommand.Parameters.Add("p_Email", MySqlDbType.TinyText).Value = EmailID;
                        sda.SelectCommand.Parameters.Add("p_Action", MySqlDbType.VarChar).Value = Action;
                        sda.SelectCommand.Parameters.Add("p_Result", MySqlDbType.VarChar, 100);
                        sda.SelectCommand.Parameters.Add("p_QuestionOut", MySqlDbType.VarChar, 100);
                        sda.SelectCommand.Parameters.Add("p_AnswerIn", MySqlDbType.TinyText).Value = ans;
                        sda.SelectCommand.Parameters.Add("p_ChangePassword", MySqlDbType.TinyText).Value = ConfirmPWD;
                        sda.SelectCommand.Parameters["p_Result"].Direction = ParameterDirection.Output;
                        sda.SelectCommand.Parameters["p_QuestionOut"].Direction = ParameterDirection.Output;
                        Data = sda.SelectCommand.ExecuteNonQuery();
                        Result = sda.SelectCommand.Parameters["p_Result"].Value.ToString();
                        question = sda.SelectCommand.Parameters["p_QuestionOut"].Value.ToString();
                    }
                }
            }
            return Data;
        }
        public int spChangePassword(string Email, string currentPassword, string NewPassword, string Confirmpassword, ref string Result)
        {
            int Data = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.UpdateCommand = cmd;
                        sda.UpdateCommand.Connection = cnn;
                        sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                        sda.UpdateCommand.CommandText = "SP_ChangePassword";
                        sda.UpdateCommand.Parameters.Add("p_Email", MySqlDbType.TinyText).Value = Email;
                        sda.UpdateCommand.Parameters.Add("p_CurrentPassword", MySqlDbType.VarChar).Value = currentPassword;
                        sda.UpdateCommand.Parameters.Add("p_Result", MySqlDbType.VarChar, 200);
                        sda.UpdateCommand.Parameters.Add("p_NewPassword", MySqlDbType.TinyText).Value = NewPassword;
                        sda.UpdateCommand.Parameters.Add("p_ConfNewPassword", MySqlDbType.TinyText).Value = Confirmpassword;
                        sda.UpdateCommand.Parameters["p_Result"].Direction = ParameterDirection.Output;
                        Data = sda.UpdateCommand.ExecuteNonQuery();
                        Result = sda.UpdateCommand.Parameters["p_Result"].Value.ToString();
                    }
                }
            }
            return Data;
        }
        public int spReadUsers(int ID, ref string userName, ref string email, ref string role, ref string isActivated, ref string isLocked)
        {
            int Data = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.SelectCommand = cmd;
                        sda.SelectCommand.Connection = cnn;
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = "SP_ReadUsers";
                        sda.SelectCommand.Parameters.Add("p_Id", MySqlDbType.Int32).Value = ID;
                        sda.SelectCommand.Parameters.Add("p_UserName", MySqlDbType.VarChar, 100);
                        sda.SelectCommand.Parameters.Add("p_Email", MySqlDbType.TinyText, 100);
                        sda.SelectCommand.Parameters.Add("p_Role", MySqlDbType.Int32, 20);
                        sda.SelectCommand.Parameters.Add("p_isActivated", MySqlDbType.TinyText, 20);
                        sda.SelectCommand.Parameters.Add("p_isLocked", MySqlDbType.TinyText, 20);
                        sda.SelectCommand.Parameters["p_UserName"].Direction = ParameterDirection.Output;
                        sda.SelectCommand.Parameters["p_Email"].Direction = ParameterDirection.Output;
                        sda.SelectCommand.Parameters["p_Role"].Direction = ParameterDirection.Output;
                        sda.SelectCommand.Parameters["p_isActivated"].Direction = ParameterDirection.Output;
                        sda.SelectCommand.Parameters["p_isLocked"].Direction = ParameterDirection.Output;
                        Data = sda.SelectCommand.ExecuteNonQuery();
                        userName = sda.SelectCommand.Parameters["p_UserName"].Value.ToString();
                        email = sda.SelectCommand.Parameters["p_Email"].Value.ToString();
                        role = sda.SelectCommand.Parameters["p_Role"].Value.ToString();
                        isActivated = sda.SelectCommand.Parameters["p_isActivated"].Value.ToString();
                        isLocked = sda.SelectCommand.Parameters["p_isLocked"].Value.ToString();
                    }
                }
            }
            return Data;
        }
        public int spManageUsers(int ID, int role, bool isActive, bool islocked, ref string result)
        {
            int Data = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.UpdateCommand = cmd;
                        sda.UpdateCommand.Connection = cnn;
                        sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                        sda.UpdateCommand.CommandText = "SP_ManageUsers";
                        sda.UpdateCommand.Parameters.Add("p_Id", MySqlDbType.Int32).Value = ID;
                        sda.UpdateCommand.Parameters.Add("p_Role", MySqlDbType.Int32, 20).Value = role;
                        sda.UpdateCommand.Parameters.Add("p_isActive", MySqlDbType.Bit).Value = isActive;
                        sda.UpdateCommand.Parameters.Add("p_islocked", MySqlDbType.Bit).Value = islocked;
                        sda.UpdateCommand.Parameters.Add("p_Result", MySqlDbType.TinyText, 50);
                        sda.UpdateCommand.Parameters["p_Result"].Direction = ParameterDirection.Output;
                        Data = sda.UpdateCommand.ExecuteNonQuery();
                        result = sda.UpdateCommand.Parameters["p_Result"].Value.ToString();
                    }
                }
            }
            return Data;
        }
        public void GetMaxID(string ProcName, string outprams, ref int MaxValue)
        {
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.SelectCommand = cmd;
                        sda.SelectCommand.Connection = cnn;
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = ProcName;
                        sda.SelectCommand.Parameters.Add(outprams, MySqlDbType.Int32);
                        sda.SelectCommand.Parameters[outprams].Direction = ParameterDirection.Output;
                        sda.SelectCommand.ExecuteNonQuery();
                        MaxValue = Convert.ToInt32(sda.SelectCommand.Parameters[outprams].Value);
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
        }
        public void GetMaxID(string ProcName, string outprams, int Value , ref int MaxValue)
        {
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.SelectCommand = cmd;
                        sda.SelectCommand.Connection = cnn;
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = ProcName;
                        sda.SelectCommand.Parameters.Add("p_code", MySqlDbType.Int32).Value = Value;
                        sda.SelectCommand.Parameters.Add(outprams, MySqlDbType.Int32);
                        sda.SelectCommand.Parameters[outprams].Direction = ParameterDirection.Output;
                        sda.SelectCommand.ExecuteNonQuery();
                        MaxValue = Convert.ToInt32(sda.SelectCommand.Parameters[outprams].Value);
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
        }
        public void GetMaxID(string ProcName,int Code, string outprams, string Roleid,ref Guid UserGuid,ref int RoleID)
        {
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.SelectCommand = cmd;
                        sda.SelectCommand.Connection = cnn;
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = ProcName;
                        sda.SelectCommand.Parameters.Add("p_code", MySqlDbType.Int32).Value = Code;
                        sda.SelectCommand.Parameters.Add(outprams, MySqlDbType.Guid);
                        sda.SelectCommand.Parameters[outprams].Direction = ParameterDirection.Output;
                        sda.SelectCommand.Parameters.Add(Roleid, MySqlDbType.Int32);
                        sda.SelectCommand.Parameters[Roleid].Direction = ParameterDirection.Output;
                        sda.SelectCommand.ExecuteNonQuery();
                        UserGuid = Guid.Parse(sda.SelectCommand.Parameters[outprams].Value.ToString());
                        RoleID = Convert.ToInt32(sda.SelectCommand.Parameters[Roleid].Value.ToString());
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
        }
        #endregion
        public DataTable GetDataKey(string procName)
        {
            DataTable dt = null;
            try
            {

                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {

                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        dt = new DataTable();
                        Thread.Sleep(500);
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetDataKey(string procName, string param1, string parm2 = "", string parm3 = "")
        {
            DataTable dt = null;
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("select * from SafetyChkListTBL where SrNo='Sr1'", cnn))
                    {
                        //sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        //sda.SelectCommand.CommandText = procName;
                        //sda.SelectCommand.Parameters.Add("p_SystemGenMachine", MySqlDbType.TinyText).Value =param1;
                        //sda.SelectCommand.Parameters.Add("p_tagNo", MySqlDbType.TinyText).Value = parm2;
                        //sda.SelectCommand.Parameters.Add("p_machineName", MySqlDbType.TinyText).Value = parm3;
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (MySqlException Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetDataKey(string procName, string param1, int param2, string parm3, string parm4)
        {
            DataTable dt = null;
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(param1, MySqlDbType.Int32).Value = param2;
                        sda.SelectCommand.Parameters.Add(parm3, MySqlDbType.TinyText).Value = parm4;
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (MySqlException Ex)
            {
                throw new Exception(Ex.Message);
                // return dt;
            }
            return dt;
        }
        public DataTable GetDataKey(string procName, string param1, int param2)
        {
            DataTable dt = null;
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(param1, MySqlDbType.Int32).Value = param2;
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (MySqlException Ex)
            {
                throw new Exception(Ex.Message);
                // return dt;
            }
            return dt;
        }
        public DataTable GetDataKey(string procName, string Param1, string Param2, int param1, int param2)
        {
            DataTable dt = null;
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(Param1, MySqlDbType.Int32).Value = param1;
                        sda.SelectCommand.Parameters.Add(Param2, MySqlDbType.Int32).Value = param2;
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (MySqlException Ex)
            {
                throw new Exception(Ex.Message);
                // return dt;
            }
            return dt;
        }
        public DataTable GetDataKey(string procName, string Param1, string Param2, string param1, int param2)
        {
            DataTable dt = null;
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(Param1, MySqlDbType.VarChar).Value = param1;
                        sda.SelectCommand.Parameters.Add(Param2, MySqlDbType.Int32).Value = param2;
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (MySqlException Ex)
            {
                throw new Exception(Ex.Message);
                // return dt;
            }
            return dt;
        }
        public DataTable GetDataKey2pams(string procName, string param1, string param2, string val1, string val2)
        {
            DataTable dt = null;
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(param1, MySqlDbType.TinyText).Value = val1;
                        sda.SelectCommand.Parameters.Add(param2, MySqlDbType.TinyText).Value = val2;
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetDataKey(string procName, string param1, string param2, string parm3, string value1, string value2, int value3)
        {
            DataTable dt = null;
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(param1, MySqlDbType.VarChar).Value = value1;
                        sda.SelectCommand.Parameters.Add(param2, MySqlDbType.VarChar).Value = value2;
                        sda.SelectCommand.Parameters.Add(parm3, MySqlDbType.Int32).Value = value3;
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetDataKey(string procName, string param1, string param2, string parm3, string parm4, string value1, string value2, string value3, int value4)
        {
            DataTable dt = null;
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(param1, MySqlDbType.TinyText).Value = value1;
                        sda.SelectCommand.Parameters.Add(param2, MySqlDbType.TinyText).Value = value2;
                        sda.SelectCommand.Parameters.Add(parm3, MySqlDbType.TinyText).Value = value3;
                        sda.SelectCommand.Parameters.Add(parm4, MySqlDbType.Int32).Value = value4;
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetDataKey(string procName, string param1, string param2, string parm3, string value1, string value2, string value3)
        {
            DataTable dt = null;
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(param1, MySqlDbType.TinyText).Value = value1;
                        sda.SelectCommand.Parameters.Add(param2, MySqlDbType.TinyText).Value = value2;
                        sda.SelectCommand.Parameters.Add(parm3, MySqlDbType.TinyText).Value = value3;
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetDataKey(string procName, string param1, string param2, string parm3, string parm4, string parm5, string value1, string value2, string value3, string val4, string val5)
        {
            DataTable dt = null;
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(param1, MySqlDbType.TinyText).Value = value1;
                        sda.SelectCommand.Parameters.Add(param2, MySqlDbType.TinyText).Value = value2;
                        sda.SelectCommand.Parameters.Add(parm3, MySqlDbType.TinyText).Value = value3;
                        sda.SelectCommand.Parameters.Add(parm4, MySqlDbType.TinyText).Value = val4;
                        sda.SelectCommand.Parameters.Add(parm5, MySqlDbType.TinyText).Value = val5;
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetDataKey(string procName, string param1, string param2, string parm3, string parm4, string parm5, string parm6, string value1, string value2, string value3, string val4, int val5, string val6)
        {
            DataTable dt = null;
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(param1, MySqlDbType.TinyText).Value = value1.Trim();
                        sda.SelectCommand.Parameters.Add(param2, MySqlDbType.TinyText).Value = value2.Trim();
                        sda.SelectCommand.Parameters.Add(parm3, MySqlDbType.TinyText).Value = value3.Trim();
                        sda.SelectCommand.Parameters.Add(parm4, MySqlDbType.TinyText).Value = val4.Trim();
                        sda.SelectCommand.Parameters.Add(parm5, MySqlDbType.Int32).Value = val5;
                        sda.SelectCommand.Parameters.Add(parm6, MySqlDbType.TinyText).Value = val6.Trim();
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetDataKey(string procName, string param1, string param2, string parm3, string parm4, string parm5, string parm6, string value1, string value2, string value3, string val4, string val5, string val6)
        {
            DataTable dt = null;
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(param1, MySqlDbType.TinyText).Value = value1.Trim();
                        sda.SelectCommand.Parameters.Add(param2, MySqlDbType.TinyText).Value = value2.Trim();
                        sda.SelectCommand.Parameters.Add(parm3, MySqlDbType.TinyText).Value = value3.Trim();
                        sda.SelectCommand.Parameters.Add(parm4, MySqlDbType.TinyText).Value = val4.Trim();
                        sda.SelectCommand.Parameters.Add(parm5, MySqlDbType.TinyText).Value = val5;
                        sda.SelectCommand.Parameters.Add(parm6, MySqlDbType.TinyText).Value = val6.Trim();
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetDataKey(string procName, string param1, string param2, string parm3, string parm4, string parm5, string parm6,string parm7, string value1, string value2, string value3, string val4, string val5, string val6,string val7)
        {
            DataTable dt = null;
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(param1, MySqlDbType.TinyText).Value = value1.Trim();
                        sda.SelectCommand.Parameters.Add(param2, MySqlDbType.TinyText).Value = value2.Trim();
                        sda.SelectCommand.Parameters.Add(parm3, MySqlDbType.TinyText).Value = value3.Trim();
                        sda.SelectCommand.Parameters.Add(parm4, MySqlDbType.TinyText).Value = val4.Trim();
                        sda.SelectCommand.Parameters.Add(parm5, MySqlDbType.TinyText).Value = val5;
                        sda.SelectCommand.Parameters.Add(parm6, MySqlDbType.TinyText).Value = val6.Trim();
                        sda.SelectCommand.Parameters.Add(parm7, MySqlDbType.TinyText).Value = val7.Trim();
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetDataKey(string procName, string param1, string param2, string parm3, string parm4, string parm5, string parm6, string Value)
        {
            DataTable dt = null;
            var val = Value.Split('_');
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(param1, MySqlDbType.TinyText).Value = val[0];
                        sda.SelectCommand.Parameters.Add(param2, MySqlDbType.TinyText).Value = val[1];
                        sda.SelectCommand.Parameters.Add(parm3, MySqlDbType.TinyText).Value = val[2];
                        sda.SelectCommand.Parameters.Add(parm4, MySqlDbType.TinyText).Value = val[3];
                        sda.SelectCommand.Parameters.Add(parm5, MySqlDbType.TinyText).Value = val[4];
                        sda.SelectCommand.Parameters.Add(parm6, MySqlDbType.Int32).Value = Convert.ToInt32(val[5]);
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetDataKey(string procName, string param1, string param2, string parm3, string parm4, string parm5, string parm6, string parm7, string Value)
        {
            DataTable dt = null;
            var val = Value.Split('~');
            //var val = Value.Split('_');
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(param1, MySqlDbType.TinyText).Value = val[0];
                        sda.SelectCommand.Parameters.Add(param2, MySqlDbType.TinyText).Value = val[1];
                        sda.SelectCommand.Parameters.Add(parm3, MySqlDbType.TinyText).Value = val[2];
                        sda.SelectCommand.Parameters.Add(parm4, MySqlDbType.TinyText).Value = val[3];
                        sda.SelectCommand.Parameters.Add(parm5, MySqlDbType.TinyText).Value = val[4];
                        sda.SelectCommand.Parameters.Add(parm6, MySqlDbType.Int32).Value = Convert.ToInt32(val[5]);
                        sda.SelectCommand.Parameters.Add(parm7, MySqlDbType.TinyText).Value = val[6];
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetDataKey(string procName, string param1, string value1, string parm3, string value2)
        {
            DataTable dt = null;
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(param1, MySqlDbType.TinyText).Value = value1;
                        sda.SelectCommand.Parameters.Add(parm3, MySqlDbType.TinyText).Value = value2;
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetDataKey(string procName, string param1, string param2, string parm3, string param4, string Value)
        {
            DataTable dt = null;
            var val = Value.Split('_');
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(param1, MySqlDbType.VarChar).Value = val[0];
                        sda.SelectCommand.Parameters.Add(param2, MySqlDbType.TinyText).Value = val[1];
                        sda.SelectCommand.Parameters.Add(parm3, MySqlDbType.VarChar).Value = val[2];
                        sda.SelectCommand.Parameters.Add(param4, MySqlDbType.TinyText).Value = val[3];
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        
        public DataTable GetDataKey(string procName, string param1, string param2, string parm3, string param4, string param5DateType, string Value, int optionprms = 0)
        {
            DataTable dt = null;
            var val = Value.Split('_');
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(param1, MySqlDbType.VarChar).Value = val[0];
                        sda.SelectCommand.Parameters.Add(param2, MySqlDbType.TinyText).Value = val[1];
                        sda.SelectCommand.Parameters.Add(parm3, MySqlDbType.VarChar).Value = val[2];
                        sda.SelectCommand.Parameters.Add(param4, MySqlDbType.TinyText).Value = val[3];
                        sda.SelectCommand.Parameters.Add(param5DateType, MySqlDbType.Date).Value = val[4];
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable Logdata(string procName, string param1, string param2, string parm3, string param4, string Value)
        {
            DataTable dt = null;
            var val = Value.Split('~');
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(param1, MySqlDbType.VarChar).Value = val[0];
                        sda.SelectCommand.Parameters.Add(param2, MySqlDbType.TinyText).Value = val[1];
                        sda.SelectCommand.Parameters.Add(parm3, MySqlDbType.VarChar).Value = val[2];
                        sda.SelectCommand.Parameters.Add(param4, MySqlDbType.TinyText).Value = val[3];
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable LogdataOld(string procName, string param1, string param2, string parm3, string param4, string param5, string param6, string param7, string Value)
        {
            DataTable dt = null;
            var val = Value.Split('~');
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(param1, MySqlDbType.VarChar).Value = val[0];
                        sda.SelectCommand.Parameters.Add(param2, MySqlDbType.TinyText).Value = val[1];
                        sda.SelectCommand.Parameters.Add(parm3, MySqlDbType.VarChar).Value = val[2];
                        sda.SelectCommand.Parameters.Add(param4, MySqlDbType.TinyText).Value = val[3];
                        sda.SelectCommand.Parameters.Add(param4, MySqlDbType.TinyText).Value = val[4];
                        sda.SelectCommand.Parameters.Add(param4, MySqlDbType.TinyText).Value = val[5];
                        sda.SelectCommand.Parameters.Add(param4, MySqlDbType.TinyText).Value = val[6];
                        sda.SelectCommand.Parameters.Add(param4, MySqlDbType.TinyText).Value = val[7];
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public DataTable Logdata(string procName, string param1, string param2, string parm3, string param4, string param5, string param6, string param7, string Value)
        {
            DataTable dt = null;
            var val = Value.Split('~');
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(param1, MySqlDbType.VarChar).Value = val[0];
                        sda.SelectCommand.Parameters.Add(param2, MySqlDbType.TinyText).Value = val[1];
                        sda.SelectCommand.Parameters.Add(parm3, MySqlDbType.VarChar).Value = val[2];
                        sda.SelectCommand.Parameters.Add(param4, MySqlDbType.TinyText).Value = val[3];
                        //sda.SelectCommand.Parameters.Add(param4, MySqlDbType.TinyText).Value = val[4];
                        //sda.SelectCommand.Parameters.Add(param4, MySqlDbType.TinyText).Value = val[5];
                        //sda.SelectCommand.Parameters.Add(param4, MySqlDbType.TinyText).Value = val[6];
                        //sda.SelectCommand.Parameters.Add(param4, MySqlDbType.TinyText).Value = val[7];
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }


        public DataTable FetchAuditReport(string procName, string param1, string param2, string parm3, string Val1, string val2, string val3)
        {
            DataTable dt = null;
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(param1, MySqlDbType.VarChar).Value = Val1;
                        sda.SelectCommand.Parameters.Add(param2, MySqlDbType.TinyText).Value = val2;
                        sda.SelectCommand.Parameters.Add(parm3, MySqlDbType.TinyText).Value = val3;
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetDataKey(string procName, string param1, string parm2)
        {
            DataTable dt = null;
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(param1, MySqlDbType.TinyText).Value = parm2;
                        //sda.SelectCommand.Parameters.Add("p_machineName", MySqlDbType.TinyText).Value = param3;
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public DataTable GetDataCAPA(string PocName, string param, string pramvalue, string pram1, string pramvalue1)
        {
            DataTable dt = null;
            try
            {
                // p_"Data Source=tcp:plant360.database.windows.net; Initial Catalog=Plant360DB; Integrated Security=False;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultipleActiveResultSets=False; User ID=admin0017201911; Password=20190711p_plant360;                "
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = PocName;
                        sda.SelectCommand.Parameters.Add(param, MySqlDbType.TinyText).Value = pramvalue;
                        sda.SelectCommand.Parameters.Add(pram1, MySqlDbType.TinyText).Value = pramvalue1;
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetDataCAPA(string PocName, string param, string pramvalue, string pram1, string pramvalue1, string par2, string value)
        {
            DataTable dt = null;
            try
            {
                // p_"Data Source=tcp:plant360.database.windows.net; Initial Catalog=Plant360DB; Integrated Security=False;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultipleActiveResultSets=False; User ID=admin0017201911; Password=20190711p_plant360;                "
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = PocName;
                        sda.SelectCommand.Parameters.Add(param, MySqlDbType.TinyText).Value = pramvalue;
                        sda.SelectCommand.Parameters.Add(pram1, MySqlDbType.TinyText).Value = pramvalue1;
                        sda.SelectCommand.Parameters.Add(par2, MySqlDbType.TinyText).Value = value;
                        dt = new DataTable();
                        sda.Fill(dt);
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public DataTable TrackerLoadquery(string usery)
        {
            DataTable dt = null;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter(usery, cnn))
                {
                    sda.SelectCommand.CommandType = CommandType.Text;
                    string usery1 = usery;
                    sda.SelectCommand.CommandText = usery1;
                    dt = new DataTable();
                    sda.Fill(dt);
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return dt;
        }
        public int InsertSafetyListDetails(string procName, string value, byte[] image)
        {
            int result = 0;
            var details = value.Split('_');
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = procName;
                            sda.InsertCommand.Parameters.Add("p_Mcordinate", MySqlDbType.TinyText).Value = details[0];
                            sda.InsertCommand.Parameters.Add("p_srno", MySqlDbType.TinyText).Value = details[1];
                            sda.InsertCommand.Parameters.Add("p_Aspect", MySqlDbType.VarChar).Value = details[2];
                            sda.InsertCommand.Parameters.Add("p_QueryElmt", MySqlDbType.VarChar).Value = details[3];
                            sda.InsertCommand.Parameters.Add("p_Responce", MySqlDbType.VarChar).Value = details[4];
                            sda.InsertCommand.Parameters.Add("p_Deviation", MySqlDbType.VarChar).Value = details[5];
                            sda.InsertCommand.Parameters.Add("p_Areaowner", MySqlDbType.VarChar).Value = details[6];
                            sda.InsertCommand.Parameters.Add("p_Freeqncy", MySqlDbType.VarChar).Value = details[7];
                            sda.InsertCommand.Parameters.Add("p_Image", MySqlDbType.Blob).Value = image;
                            sda.InsertCommand.Parameters.Add("p_empCode", MySqlDbType.TinyText).Value = details[8];
                            sda.InsertCommand.Parameters.Add("p_Status", MySqlDbType.TinyText).Value = details[9];
                            result = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return result;
        }
        public int InsertFreeZplan(string vlaue, string Proc)
        {
            int rslt = 0;
            var _update = vlaue.Split('~');
            try
            {

                DateTime dt = Convert.ToDateTime(_update[8]);
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = Proc;
                            sda.InsertCommand.Parameters.Add("p_Priority", MySqlDbType.VarChar).Value = _update[0];
                            sda.InsertCommand.Parameters.Add("p_MachineTagNo", MySqlDbType.TinyText).Value = _update[1];
                            sda.InsertCommand.Parameters.Add("p_MachineName", MySqlDbType.TinyText).Value = _update[2];
                            sda.InsertCommand.Parameters.Add("p_AdditonalManpower", MySqlDbType.VarChar).Value = _update[3];
                            sda.InsertCommand.Parameters.Add("p_MaintenanceType", MySqlDbType.VarChar).Value = _update[4];
                            sda.InsertCommand.Parameters.Add("p_MaintenacePrms", MySqlDbType.VarChar).Value = _update[5];
                            sda.InsertCommand.Parameters.Add("p_AcitvityDetails", MySqlDbType.VarChar).Value = _update[6];
                            sda.InsertCommand.Parameters.Add("p_MeterReading", MySqlDbType.VarChar).Value = _update[7];
                            sda.InsertCommand.Parameters.Add("p_Setdate", MySqlDbType.DateTime).Value = Convert.ToDateTime(_update[8]);
                            sda.InsertCommand.Parameters.Add("p_Team", MySqlDbType.VarChar).Value = _update[9];
                            sda.InsertCommand.Parameters.Add("p_Units", MySqlDbType.TinyText).Value = _update[10];
                            sda.InsertCommand.Parameters.Add("p_userId", MySqlDbType.Int32).Value = Convert.ToInt32(_update[11]);
                            sda.InsertCommand.Parameters.Add("p_username", MySqlDbType.TinyText).Value = _update[12];
                            sda.InsertCommand.Parameters.Add("p_empcode", MySqlDbType.TinyText).Value = _update[13];
                            sda.InsertCommand.Parameters.Add("p_frquncy", MySqlDbType.TinyText).Value = _update[14];
                            sda.InsertCommand.Parameters.Add("p_shtrequ", MySqlDbType.TinyText).Value = _update[15];
                            sda.InsertCommand.Parameters.Add("p_recource", MySqlDbType.TinyText).Value = _update[16];
                            sda.InsertCommand.Parameters.Add("p_frststus", MySqlDbType.TinyText).Value = _update[17];
                            sda.InsertCommand.Parameters.Add("p_Mshedule", MySqlDbType.TinyText).Value = _update[18];
                            rslt = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return rslt;


        }
        public int UpdateFreezPlan(string Poc, string Value)
        {
            int result = 0;
            var value = Value.Split('~');
            string dt = Convert.ToDateTime(value[3]).ToString("yyyy-MM-dd hh:ss");
            DateTime f = Convert.ToDateTime(dt);
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.UpdateCommand = cmd;
                        sda.UpdateCommand.Connection = cnn;
                        sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                        sda.UpdateCommand.CommandText = Poc;
                        sda.UpdateCommand.Parameters.Add("p_machinetag", MySqlDbType.TinyText).Value = value[0];
                        sda.UpdateCommand.Parameters.Add("p_machinename", MySqlDbType.TinyText).Value = value[1];
                        sda.UpdateCommand.Parameters.Add("p_activity", MySqlDbType.TinyText).Value = value[2];
                        sda.UpdateCommand.Parameters.Add("p_closerdate", MySqlDbType.DateTime).Value = f;
                        sda.UpdateCommand.Parameters.Add("p_userId", MySqlDbType.Int32).Value = value[4];
                        sda.UpdateCommand.Parameters.Add("p_username", MySqlDbType.TinyText).Value = value[5];
                        sda.UpdateCommand.Parameters.Add("p_empcode", MySqlDbType.TinyText).Value = value[6];
                        sda.UpdateCommand.Parameters.Add("p_stus", MySqlDbType.TinyText).Value = value[7];
                        sda.UpdateCommand.Parameters.Add("p_Mshedule", MySqlDbType.TinyText).Value = value[8];
                        cmd.Dispose();
                    }
                    result = sda.UpdateCommand.ExecuteNonQuery();
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return result;
        }
        public int InsertSafetyMaster(string ProcName, string value)
        {
            int rslt = 0;
            var Data = value.Split('_');
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = ProcName;
                            sda.InsertCommand.Parameters.Add("p_sysGenMachineName", MySqlDbType.TinyText).Value = Data[0];
                            sda.InsertCommand.Parameters.Add("p_TagNo", MySqlDbType.TinyText).Value = Data[1];
                            sda.InsertCommand.Parameters.Add("p_CrtclSafetyDevice", MySqlDbType.TinyText).Value = Data[2];
                            sda.InsertCommand.Parameters.Add("p_SpecificPPE", MySqlDbType.TinyText).Value = Data[3];
                            rslt = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return rslt;
        }
        public int SaveMaintenenceData(string procName)
        {
            int rslt = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.InsertCommand = cmd;
                        sda.InsertCommand.Connection = cnn;
                        sda.InsertCommand.CommandType = CommandType.Text;
                        sda.InsertCommand.CommandText = procName;
                        rslt = sda.InsertCommand.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return rslt;
        }
        public int SaveMaintenenceData(string procName, string update = "hh")
        {
            if (string.IsNullOrEmpty(update))
            {
                throw new ArgumentException("message", nameof(update));
            }

            int rslt = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.UpdateCommand = cmd;
                        sda.UpdateCommand.Connection = cnn;
                        sda.UpdateCommand.CommandType = CommandType.Text;
                        sda.UpdateCommand.CommandText = procName;
                        rslt = sda.UpdateCommand.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return rslt;
        }
        public int SaveMainTenenceData(string ProcName, string para, DataTable dt, string Action = "")
        {
            int rslt = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.InsertCommand = cmd;
                        sda.InsertCommand.Connection = cnn;
                        sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                        sda.InsertCommand.CommandText = ProcName;
                        if (!string.IsNullOrEmpty(Action))
                            sda.InsertCommand.Parameters.AddWithValue("p_recevivevalue", Action);

                        sda.InsertCommand.Parameters.AddWithValue(para, dt);
                        rslt = sda.InsertCommand.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return rslt;

        }
        public int InsertNearMissData(string ProcName, String Value)
        {
            int rslt = 0;
            var Data = Value.Split('~');
            //var Data = Value.Split('_');
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = ProcName;
                            sda.InsertCommand.Parameters.Add("p_machineTag", MySqlDbType.VarChar).Value = Data[0];
                            sda.InsertCommand.Parameters.Add("p_IsApplicable", MySqlDbType.VarChar).Value = Data[1];
                            sda.InsertCommand.Parameters.Add("p_evtDateTime", MySqlDbType.DateTime).Value = Convert.ToDateTime(Data[2]);
                            sda.InsertCommand.Parameters.Add("p_evntrprttime", MySqlDbType.DateTime).Value = Convert.ToDateTime(Data[3]);
                            sda.InsertCommand.Parameters.Add("p_machineName", MySqlDbType.TinyText).Value = Data[4];
                            sda.InsertCommand.Parameters.Add("p_location", MySqlDbType.TinyText).Value = Data[5];
                            sda.InsertCommand.Parameters.Add("p_owner", MySqlDbType.TinyText).Value = Data[6];
                            sda.InsertCommand.Parameters.Add("p_vendor", MySqlDbType.TinyText).Value = Data[7];
                            sda.InsertCommand.Parameters.Add("p_sysGenNo", MySqlDbType.TinyText).Value = Data[8];
                            sda.InsertCommand.Parameters.Add("p_MCordinate", MySqlDbType.TinyText).Value = Data[9];
                            sda.InsertCommand.Parameters.Add("p_userName", MySqlDbType.TinyText).Value = Data[10];
                            sda.InsertCommand.Parameters.Add("p_userId", MySqlDbType.Int32).Value = Convert.ToInt32(Data[11]);
                            sda.InsertCommand.Parameters.Add("p_empCode", MySqlDbType.TinyText).Value = Data[12];
                            rslt = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();


                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return rslt;
        }
        public int RemoveEntry(string ProcName, string pram, string value)
        {
            int rsu = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.DeleteCommand = cmd;
                        sda.DeleteCommand.Connection = cnn;
                        sda.DeleteCommand.CommandType = CommandType.StoredProcedure;
                        sda.DeleteCommand.CommandText = ProcName;
                        sda.DeleteCommand.Parameters.Add(pram, MySqlDbType.TinyText).Value = value;
                        rsu = sda.DeleteCommand.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    sda.Dispose();

                }
                cnn.Dispose();
            }
            return rsu;
        }
        public int RemoveEntry(string ProcName, string pram, string value, string Actiontype, string Actypvalue)
        {
            int rsu = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.DeleteCommand = cmd;
                        sda.DeleteCommand.Connection = cnn;
                        sda.DeleteCommand.CommandType = CommandType.StoredProcedure;
                        sda.DeleteCommand.CommandText = ProcName;
                        sda.DeleteCommand.Parameters.Add(pram, MySqlDbType.TinyText).Value = value;
                        sda.DeleteCommand.Parameters.Add(Actiontype, MySqlDbType.VarChar).Value = Actypvalue;
                        rsu = sda.DeleteCommand.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return rsu;
        }
        public int RemoveEntry(string ProcName, string pram, string parm2, string parm3, string val, string val2, string ff = "")
        {
            int rsu = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.DeleteCommand = cmd;
                        sda.DeleteCommand.Connection = cnn;
                        sda.DeleteCommand.CommandType = CommandType.StoredProcedure;
                        sda.DeleteCommand.CommandText = ProcName;
                        sda.DeleteCommand.Parameters.Add(pram, MySqlDbType.TinyText).Value = val;
                        sda.DeleteCommand.Parameters.Add(parm2, MySqlDbType.TinyText).Value = val2;
                        //sda.DeleteCommand.Parameters.Add(parm3, MySqlDbType.Int32).Value = Convert.ToInt32(val3);
                        rsu = sda.DeleteCommand.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return rsu;
        }
        public int RemoveEntry(string ProcName, string pram, string parm2, string parm3, string val, string val2, string val3, string Optional = "")
        {
            int rsu = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.DeleteCommand = cmd;
                        sda.DeleteCommand.Connection = cnn;
                        sda.DeleteCommand.CommandType = CommandType.StoredProcedure;
                        sda.DeleteCommand.CommandText = ProcName;
                        sda.DeleteCommand.Parameters.Add(pram, MySqlDbType.TinyText).Value = val;
                        sda.DeleteCommand.Parameters.Add(parm2, MySqlDbType.TinyText).Value = val2;
                        sda.DeleteCommand.Parameters.Add(parm3, MySqlDbType.TinyText).Value = val3;
                        rsu = sda.DeleteCommand.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return rsu;
        }
        public int RemoveEntry(string ProcName, string pram, string parm2, string parm3, string parm4, string val, string val2, string val3, string val4)
        {
            int rsu = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.DeleteCommand = cmd;
                        sda.DeleteCommand.Connection = cnn;
                        sda.DeleteCommand.CommandType = CommandType.StoredProcedure;
                        sda.DeleteCommand.CommandText = ProcName;
                        sda.DeleteCommand.Parameters.Add(pram, MySqlDbType.TinyText).Value = val;
                        sda.DeleteCommand.Parameters.Add(parm2, MySqlDbType.VarChar).Value = val2;
                        sda.DeleteCommand.Parameters.Add(parm3, MySqlDbType.Int32).Value = Convert.ToInt32(val3);
                        sda.DeleteCommand.Parameters.Add(parm4, MySqlDbType.TinyText).Value = val4;
                        rsu = sda.DeleteCommand.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return rsu;
        }
        #region Insertion and Fetch Audit Sheet Data
        public int AuditCalendarInsert(string procname, string ActionName, string parvalues)
        {
            int result = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.InsertCommand = cmd;
                        sda.InsertCommand.Connection = cnn;
                        sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                        sda.InsertCommand.CommandText = procname;
                        if (ActionName == "Internal")
                        {
                            var values = parvalues.Split('_');
                            sda.InsertCommand.Parameters.Add("p_SrNo", MySqlDbType.TinyText).Value = values[0];
                            sda.InsertCommand.Parameters.Add("p_AuditCode", MySqlDbType.TinyText).Value = values[1];
                            sda.InsertCommand.Parameters.Add("p_NameofAudit", MySqlDbType.TinyText).Value = values[2];
                            sda.InsertCommand.Parameters.Add("p_TypeofAudit", MySqlDbType.TinyText).Value = values[3];
                            sda.InsertCommand.Parameters.Add("p_ProcessName", MySqlDbType.TinyText).Value = values[4];
                            sda.InsertCommand.Parameters.Add("p_Frequency", MySqlDbType.TinyText).Value = values[5];
                            sda.InsertCommand.Parameters.Add("p_Lastdateofaudit", MySqlDbType.DateTime).Value = Convert.ToDateTime(values[6]);
                            sda.InsertCommand.Parameters.Add("p_Nextdateofaudit", MySqlDbType.DateTime).Value = Convert.ToDateTime(values[7]);
                            sda.InsertCommand.Parameters.Add("p_Department", MySqlDbType.VarChar).Value = values[8];
                            sda.InsertCommand.Parameters.Add("p_Individual", MySqlDbType.VarChar).Value = values[9];
                            sda.InsertCommand.Parameters.Add("p_Auditowner", MySqlDbType.TinyText).Value = values[10];
                            sda.InsertCommand.Parameters.Add("p_Reviewedby", MySqlDbType.TinyText).Value = values[11];
                            sda.InsertCommand.Parameters.Add("p_Approvedby", MySqlDbType.TinyText).Value = values[12];

                        }
                        else
                        {
                            var values = parvalues.Split('_');
                            sda.InsertCommand.Parameters.Add("p_SrNo", MySqlDbType.TinyText).Value = values[0];
                            sda.InsertCommand.Parameters.Add("p_NameofAudit", MySqlDbType.TinyText).Value = values[1];
                            sda.InsertCommand.Parameters.Add("p_TypeofAudit", MySqlDbType.TinyText).Value = values[2];
                            sda.InsertCommand.Parameters.Add("p_ProcessName", MySqlDbType.TinyText).Value = values[3];
                            sda.InsertCommand.Parameters.Add("p_From_date", MySqlDbType.DateTime).Value = Convert.ToDateTime(values[4]);
                            sda.InsertCommand.Parameters.Add("p_To_date", MySqlDbType.DateTime).Value = Convert.ToDateTime(values[5]);
                            sda.InsertCommand.Parameters.Add("p_Third_Party_Name", MySqlDbType.TinyText).Value = values[6];
                            sda.InsertCommand.Parameters.Add("p_Department", MySqlDbType.TinyText).Value = values[7];
                            sda.InsertCommand.Parameters.Add("p_Individual", MySqlDbType.TinyText).Value = values[8];
                            sda.InsertCommand.Parameters.Add("p_Audit_owner", MySqlDbType.TinyText).Value = values[9];
                            sda.InsertCommand.Parameters.Add("p_Remark", MySqlDbType.TinyText).Value = values[10];
                        }
                        result = sda.InsertCommand.ExecuteNonQuery();

                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return result;
        }

        #endregion
        #endregion

        #region RMPCL Method List
        public int InsertRMPCLMNT(string MntCode, DateTime MNTDate, int MNTOP, int Status, string machinetag, string MNTOTHS, int MNTPRTY, string MNTExactLocation, int MNTTime, string MNTArea, string MNTReportedBy, string MNTDescrption, string MNTComments, string MNTAssignTo, ref string Result)
        {
            int Count = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.InsertCommand = cmd;
                        sda.InsertCommand.Connection = cnn;
                        sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                        sda.InsertCommand.CommandText = "SP_InsertMaintenanceRMPCL";
                        sda.InsertCommand.Parameters.Add("p_MNTCode", MySqlDbType.TinyText).Value = MntCode;
                        sda.InsertCommand.Parameters.Add("p_MNTDate", MySqlDbType.DateTime).Value = MNTDate;
                        sda.InsertCommand.Parameters.Add("p_MNTOP", MySqlDbType.Int32).Value = MNTOP;
                        sda.InsertCommand.Parameters.Add("p_mNTSTS", MySqlDbType.Int32).Value = Status;
                        sda.InsertCommand.Parameters.Add("p_MNTTag", MySqlDbType.TinyText).Value = machinetag;
                        sda.InsertCommand.Parameters.Add("p_MNTOTHS", MySqlDbType.TinyText).Value = MNTOTHS;
                        sda.InsertCommand.Parameters.Add("p_MNTPRTY", MySqlDbType.Int32).Value = MNTPRTY;
                        sda.InsertCommand.Parameters.Add("p_MNTExactLocation", MySqlDbType.TinyText, 50).Value = MNTExactLocation;
                        sda.InsertCommand.Parameters.Add("p_MNTTime", MySqlDbType.Int32).Value = MNTTime;
                        sda.InsertCommand.Parameters.Add("p_MNTArea", MySqlDbType.TinyText).Value = MNTArea;
                        sda.InsertCommand.Parameters.Add("p_MNTReportedBy", MySqlDbType.TinyText).Value = MNTReportedBy;
                        sda.InsertCommand.Parameters.Add("p_MNTDescrption", MySqlDbType.TinyText).Value = MNTDescrption;
                        sda.InsertCommand.Parameters.Add("p_MNTComments", MySqlDbType.TinyText).Value = MNTComments;
                        sda.InsertCommand.Parameters.Add("p_MNTAssignTo", MySqlDbType.TinyText).Value = MNTAssignTo;
                        sda.InsertCommand.Parameters.Add("p_Result", MySqlDbType.VarChar, 500);
                        sda.InsertCommand.Parameters["p_Result"].Direction = ParameterDirection.Output;
                        Count = sda.InsertCommand.ExecuteNonQuery();
                        Result = sda.InsertCommand.Parameters["p_Result"].Value.ToString();
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
                return Count;
            }
        }
        public int InsertRMPCLMNT(string MntCode, DateTime MNTDate, int MNTOP, int Status, string machinetag, string MNTOTHS, int MNTPRTY, string MNTExactLocation, string MNTArea, string MNTReportedBy, int IsMaintenanceRequired, ref string Result)
        {
            int Count = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.InsertCommand = cmd;
                        sda.InsertCommand.Connection = cnn;
                        sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                        sda.InsertCommand.CommandText = "SP_InsertMaintenanceBRKRMPCL";
                        sda.InsertCommand.Parameters.Add("p_BRKCode", MySqlDbType.TinyText).Value = MntCode;
                        sda.InsertCommand.Parameters.Add("p_BRKDate", MySqlDbType.DateTime).Value = MNTDate;
                        sda.InsertCommand.Parameters.Add("p_BRKOP", MySqlDbType.Int32).Value = MNTOP;
                        sda.InsertCommand.Parameters.Add("p_BRKSTS", MySqlDbType.Int32).Value = Status;
                        sda.InsertCommand.Parameters.Add("p_BRKTag", MySqlDbType.TinyText).Value = machinetag;
                        sda.InsertCommand.Parameters.Add("p_BRKOTHS", MySqlDbType.TinyText).Value = MNTOTHS;
                        sda.InsertCommand.Parameters.Add("p_BRKPRTY", MySqlDbType.Int32).Value = MNTPRTY;
                        sda.InsertCommand.Parameters.Add("p_BRKExactLocation", MySqlDbType.TinyText, 50).Value = MNTExactLocation;
                        sda.InsertCommand.Parameters.Add("p_BRKArea", MySqlDbType.TinyText).Value = MNTArea;
                        sda.InsertCommand.Parameters.Add("p_BRKReportedBy", MySqlDbType.TinyText).Value = MNTReportedBy;
                        sda.InsertCommand.Parameters.Add("p_IsMaintenanceRequired", MySqlDbType.Int32).Value = IsMaintenanceRequired;
                        sda.InsertCommand.Parameters.Add("p_Result", MySqlDbType.VarChar, 500);
                        sda.InsertCommand.Parameters["p_Result"].Direction = ParameterDirection.Output;
                        Count = sda.InsertCommand.ExecuteNonQuery();
                        Result = sda.InsertCommand.Parameters["p_Result"].Value.ToString();
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
                return Count;
            }
        }
        public int UpdateRMPCLBreakDownRecord(string MntCode, int staus, string remark)
        {
            int rslt = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.UpdateCommand = cmd;
                        sda.UpdateCommand.Connection = cnn;
                        sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                        sda.UpdateCommand.CommandText = "SP_UpdateMaintenaceBRK";
                        sda.UpdateCommand.Parameters.Add("p_BRKCode", MySqlDbType.TinyText).Value = MntCode;
                        sda.UpdateCommand.Parameters.Add("p_comments", MySqlDbType.TinyText).Value = remark;
                        sda.UpdateCommand.Parameters.Add("p_sts", MySqlDbType.Int32).Value = staus;
                        rslt = sda.UpdateCommand.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return rslt;
        }
        public int UpdateRMPCLRemarkRecord(string MntCode, int staus, string remark)
        {
            int rslt = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.UpdateCommand = cmd;
                        sda.UpdateCommand.Connection = cnn;
                        sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                        sda.UpdateCommand.CommandText = "UpdateRMPCLRemarkRecord";
                        sda.UpdateCommand.Parameters.Add("p_MNTCode", MySqlDbType.TinyText).Value = MntCode;
                        sda.UpdateCommand.Parameters.Add("p_remark", MySqlDbType.TinyText).Value = remark;
                        sda.UpdateCommand.Parameters.Add("p_sts", MySqlDbType.Int32).Value = staus;
                        rslt = sda.UpdateCommand.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return rslt;
        }
        public int UpdateRMPCLRecord(string MntCode, int staus)
        {
            int rslt = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.UpdateCommand = cmd;
                        sda.UpdateCommand.Connection = cnn;
                        sda.UpdateCommand.CommandType = CommandType.Text;
                        sda.UpdateCommand.CommandText = "UpdateRMPCLRecord";
                        sda.UpdateCommand.Parameters.Add("p_MNTCode", MySqlDbType.TinyText).Value = MntCode;
                        sda.UpdateCommand.Parameters.Add("p_sts", MySqlDbType.Int32).Value = staus;
                        rslt = sda.UpdateCommand.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return rslt;
        }
        public int UpdateMaintenaceRMPCLRecord(string MntCode, int MNTTime, int staus, string AssignTo, ref string Result)
        {
            int rslt = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.UpdateCommand = cmd;
                        sda.UpdateCommand.Connection = cnn;
                        sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                        sda.UpdateCommand.CommandText = "SP_UpDateRMPCLMaintenace";
                        sda.UpdateCommand.Parameters.Add("p_MNTCode", MySqlDbType.TinyText).Value = MntCode;
                        sda.UpdateCommand.Parameters.Add("p_sts", MySqlDbType.Int32).Value = staus;
                        sda.UpdateCommand.Parameters.Add("p_MNTTime", MySqlDbType.Int32).Value = MNTTime;
                        sda.UpdateCommand.Parameters.Add("p_MNTAssignTo", MySqlDbType.TinyText).Value = AssignTo;
                        sda.UpdateCommand.Parameters.Add("p_Result", MySqlDbType.VarChar, 500);
                        sda.UpdateCommand.Parameters["p_Result"].Direction = ParameterDirection.Output;
                        rslt = sda.UpdateCommand.ExecuteNonQuery();
                        Result = sda.UpdateCommand.Parameters["p_Result"].Value.ToString();
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return rslt;
        }
        public int InsertRMPClOHC(int SrNo, string empcode, string empname, DateTime DOB, int Gender, long Aadharno, DateTime DOJ, string Department, string EmpType, string Company, DateTime CheckUpDate, int HealthStatus, byte[] Photo, string Remark, byte[] report, string Reportname, int Sts)
        {
            int Count = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        if (Sts == 0)
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_InsertOHCData";

                            sda.InsertCommand.Parameters.Add("p_SrNo", MySqlDbType.Int32).Value = SrNo;
                            sda.InsertCommand.Parameters.Add("p_empCode", MySqlDbType.TinyText).Value = empcode;
                            sda.InsertCommand.Parameters.Add("p_empName", MySqlDbType.TinyText).Value = empname;
                            sda.InsertCommand.Parameters.Add("p_DOB", MySqlDbType.DateTime).Value = DOB;
                            sda.InsertCommand.Parameters.Add("p_Gender", MySqlDbType.Int32).Value = Gender;
                            sda.InsertCommand.Parameters.Add("p_AadharNumber", MySqlDbType.Int64).Value = Aadharno;
                            sda.InsertCommand.Parameters.Add("p_DOJ", MySqlDbType.DateTime).Value = DOJ;
                            sda.InsertCommand.Parameters.Add("p_Department", MySqlDbType.VarChar, 50).Value = Department;
                            sda.InsertCommand.Parameters.Add("p_EmploymentType", MySqlDbType.VarChar, 50).Value = EmpType;
                            sda.InsertCommand.Parameters.Add("p_Company", MySqlDbType.VarChar, 50).Value = Company;
                            sda.InsertCommand.Parameters.Add("p_CheckUpDate", MySqlDbType.DateTime).Value = CheckUpDate;
                            sda.InsertCommand.Parameters.Add("p_HealthStatus", MySqlDbType.Int32).Value = HealthStatus;
                            sda.InsertCommand.Parameters.Add("p_Photo", MySqlDbType.VarBinary).Value = Photo;
                            sda.InsertCommand.Parameters.Add("p_Remark", MySqlDbType.TinyText).Value = Remark;
                            sda.InsertCommand.Parameters.Add("p_report", MySqlDbType.Blob).Value = report;
                            sda.InsertCommand.Parameters.Add("p_Reportname", MySqlDbType.TinyText).Value = Reportname;
                            sda.InsertCommand.Parameters.Add("p_CallingSTS", MySqlDbType.Int32).Value = Sts;
                            Count = sda.InsertCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "SP_InsertOHCData";
                            sda.UpdateCommand.Parameters.Add("p_SrNo", MySqlDbType.Int32).Value = SrNo;
                            sda.UpdateCommand.Parameters.Add("p_empCode", MySqlDbType.TinyText).Value = empcode;
                            sda.UpdateCommand.Parameters.Add("p_empName", MySqlDbType.TinyText).Value = empname;
                            sda.UpdateCommand.Parameters.Add("p_DOB", MySqlDbType.DateTime).Value = DOB;
                            sda.UpdateCommand.Parameters.Add("p_Gender", MySqlDbType.Int32).Value = Gender;
                            sda.UpdateCommand.Parameters.Add("p_AadharNumber", MySqlDbType.Int64).Value = Aadharno;
                            sda.UpdateCommand.Parameters.Add("p_DOJ", MySqlDbType.DateTime).Value = DOJ;
                            sda.UpdateCommand.Parameters.Add("p_Department", MySqlDbType.VarChar, 50).Value = Department;
                            sda.UpdateCommand.Parameters.Add("p_EmploymentType", MySqlDbType.VarChar, 50).Value = EmpType;
                            sda.UpdateCommand.Parameters.Add("p_Company", MySqlDbType.VarChar, 50).Value = Company;
                            sda.UpdateCommand.Parameters.Add("p_CheckUpDate", MySqlDbType.DateTime).Value = CheckUpDate;
                            sda.UpdateCommand.Parameters.Add("p_HealthStatus", MySqlDbType.Int32).Value = HealthStatus;
                            sda.UpdateCommand.Parameters.Add("p_Photo", MySqlDbType.VarBinary).Value = Photo;
                            sda.UpdateCommand.Parameters.Add("p_Remark", MySqlDbType.TinyText).Value = Remark;
                            sda.UpdateCommand.Parameters.Add("p_report", MySqlDbType.Blob).Value = report;
                            sda.UpdateCommand.Parameters.Add("p_Reportname", MySqlDbType.TinyText).Value = Reportname;
                            sda.UpdateCommand.Parameters.Add("p_CallingSTS", MySqlDbType.Int32).Value = Sts;
                            Count = sda.UpdateCommand.ExecuteNonQuery();
                        }
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
                return Count;
            }
        }
        public int DeleteEmployeeOHC(long Aadharno, string empcode)
        {
            int rslt = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.DeleteCommand = cmd;
                        sda.DeleteCommand.Connection = cnn;
                        sda.DeleteCommand.CommandType = CommandType.StoredProcedure;
                        sda.DeleteCommand.CommandText = "SP_DeleteEmployeeOHC";
                        sda.DeleteCommand.Parameters.Add("p_empCode", MySqlDbType.TinyText).Value = empcode;
                        sda.DeleteCommand.Parameters.Add("p_AadharNumber", MySqlDbType.TinyText).Value = Aadharno;
                        rslt = sda.DeleteCommand.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return rslt;
        }
        public void GetUniqueSrNo(string procName, string param1, string Value, ref int UniqueID)
        {
            int id = 0;
            try
            {
                //p_"Data Source=172.16.1.139\SQLEXPRESS; Initial Catalog=plant360DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = procName;
                        sda.SelectCommand.Parameters.Add(param1, MySqlDbType.TinyText).Value = Value;
                        sda.SelectCommand.Parameters.Add("p_RSLT", MySqlDbType.Int32);
                        sda.SelectCommand.Parameters["p_RSLT"].Direction = ParameterDirection.Output;
                        sda.SelectCommand.ExecuteNonQuery();
                        UniqueID = Convert.ToInt32(sda.SelectCommand.Parameters["p_RSLT"].Value.ToString());
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        public DataTable GetOHCRecordByYear(string EmpCode,Double AadharNo,DateTime CheckUpDate)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "sp_GetOHCRecordByYear";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_EmpCode", EmpCode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_AadharNo", AadharNo));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_CheckUpDate", CheckUpDate));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        #endregion

        ///////////Arvind Sharma All DLL Method List/////////////

        #region Arvind All Method List for DML,DDL and DCL
        /// <summary>
        /// Date-04-06-2021
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()// Change By RP According To New User Module
        {
            List<User> userlist = new List<User>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "GetAllUsers";
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                var UserModel = new User
                                {
                                    UserId = Convert.ToInt32(rdr.GetValue(rdr.GetOrdinal("UserID"))),
                                    UserName = rdr.GetValue(rdr.GetOrdinal("UserName")).ToString(),                                   
                                    contact = rdr.GetValue(rdr.GetOrdinal("PhoneNumber")).ToString(),                                  
                                    email = rdr.GetValue(rdr.GetOrdinal("Email")).ToString()                                   
                                    //  Appid = rdr.GetString(7),
                                    //  userTypeId = rdr.GetString(8)
                                };
                                userlist.Add(UserModel);
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return userlist;            
        }
        public int AddUploadedMachineDocs(string MachineTagNo, string filename, string fileExtension, string Area, string remarks, DateTime uploadedDate, int mode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddMachineUploadedDocs";                           
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_MachineTagNo", MachineTagNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_filename", filename));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_fileExtension", fileExtension));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Area", Area));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_remarks", remarks));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_uploadedDate", uploadedDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            count = cmd.ExecuteNonQuery();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
            return count;
        }
        public DataTable GetJSADataBothControls(string TypeOfWork)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_TypeOfWork", TypeOfWork));
                            sda.SelectCommand.CommandText = "SP_GetJSADataBothControls";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public int AddSafetyJSANoControl(string SrNo, string Area, string Activity, string TypOfWrk, string HazrdDscp, string Consequnce, string LikeHood, int Severity, int RiskRating, string DecribeCtrl, string TypeOfctrl, string EmpCode, string Mcordinate)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddJSAInptMstNoCtrlTBL";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_SrNo", SrNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Area", Area));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Activity", Activity));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_TypOfWrk", TypOfWrk));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_HazrdDscp", HazrdDscp));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Consequnce", Consequnce));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_LikeHood", LikeHood));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Severity", Severity));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RiskRating", RiskRating));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DecribeCtrl", DecribeCtrl));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_TypeOfctrl", TypeOfctrl));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_EmpCode", EmpCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Mcordinate", Mcordinate));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int AddJSAInptMstNewCtrlTBL(string ConSqunce, string Likehood, int Severity, int RiskRating, string Acceptblty, string EmpCode, string Mcordinate)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddJSAInptMstNewCtrlTBL";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ConSqunce", ConSqunce));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Likehood", Likehood));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Severity", Severity));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RiskRating", RiskRating));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Acceptblty", Acceptblty));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_EmpCode", EmpCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Mcordinate", Mcordinate));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public List<UserType> getUserTypeById(string userid, string AppId)
        {
            List<UserType> utype = new List<UserType>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "GetUserTypeByUserId";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_userid", userid));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_AppId", AppId));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                var UserModel = new UserType
                                {
                                    UTypeId = rdr.GetString(0)
                                };
                                utype.Add(UserModel);
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return utype;
        }
        public List<ComplianceMaster> GetComplianceName()
        {
            List<ComplianceMaster> complianceMaster = new List<ComplianceMaster>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetComplianceName";
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                var complianceModel = new ComplianceMaster
                                {
                                    complianceId = rdr.GetInt32(0),
                                    ComplianceName = rdr.GetString(1),
                                    ComplianceCode = rdr.GetString(2)
                                };
                                complianceMaster.Add(complianceModel);
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return complianceMaster;
        }
        public List<User> GetUserById(string UserId, string AppId, string userTypeId)
        {
            List<User> userlist = new List<User>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "GetUserDetailsById";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_UserId", UserId));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_AppId", AppId));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_userTypeId", userTypeId));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                var UserModel = new User
                                {
                                    // UserId = rdr.GetString(1),
                                    UserName = rdr.GetString(2),
                                    DOB = rdr.GetDateTime(3),
                                    contact = rdr.GetString(4),
                                    alternateContact = rdr.GetString(5),
                                    email = rdr.GetString(6),
                                    address = rdr.GetString(7),
                                    //   Appid = rdr.GetString(11),
                                    //   userTypeId = rdr.GetString(9),
                                    sex = rdr.GetString(10),
                                    isActive = rdr.GetBoolean(12)
                                };
                                userlist.Add(UserModel);
                            }
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return userlist;
        }
        public string ChangePwd(string UserId, string UPwd, string AppId, string oldpwd, int isActive)
        {
            string message = string.Empty;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "UpdateUserPassword";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UserId", UserId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UPwd", UPwd));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_oldpwd", oldpwd));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_AppId", AppId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_isActive", isActive));
                            sda.InsertCommand.Parameters.Add("p_ERROR", MySqlDbType.VarChar, 500);
                            sda.InsertCommand.Parameters["p_ERROR"].Direction = ParameterDirection.Output;
                            sda.InsertCommand.ExecuteNonQuery();
                            message = (string)cmd.Parameters["p_ERROR"].Value;
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return message;
        }
        public int AddGenericCAPARpt(int eventReportingDetailId, DateTime CapaRptDate, string machineTag, string Area, string Observation, string criticality, string ImmediateCause, string RootCause, string CorrectiveAction, string PreventiveAction)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddGenericCAPARpt";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_eventReportingDetailId", eventReportingDetailId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CapaRptDate", CapaRptDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_machineTag", machineTag));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Area", Area));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Observation", Observation));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_criticality", criticality));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ImmediateCause", ImmediateCause));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RootCause", RootCause));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CorrectiveAction", CorrectiveAction));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_PreventiveAction", PreventiveAction));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return count;
        }
        public int AddUserActivityHeaderc(string UserId, string uploadedDate, string fileName, string Frequency, string ValidFrom, string ValidTo)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddUserActivityMaster";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UserId", UserId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_uploadedDate", uploadedDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_fileName", fileName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Frequency", Frequency));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ValidFrom", ValidFrom));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ValidTo", ValidTo));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return count;
        }
        public int AddTabInsertedParam(string tabName, int ParameterId)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddTabInsertedParam";
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_tabName", tabName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ParameterId", ParameterId));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return count;

        }
        public int AddOEEProductionLineDetails(string productionLine, string shift, string category, decimal productionCapacity, decimal unitTime)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddOEEProductionLine";
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_productionLine", productionLine));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_shift", shift));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_category", category));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_productionCapacity", productionCapacity));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_unitTime", unitTime));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return count;
        }
        public int UPDOEEProductionLine(string productionLine, string shift, string category, decimal productionCapacity, decimal unitTime, int LineId)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "SP_UPDOEEProductionLine";
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_productionLine", productionLine));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_shift", shift));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_category", category));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_productionCapacity", productionCapacity));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_unitTime", unitTime));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_LineId", LineId));
                            count = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return count;
        }
        public int AddDepartmentHead(int DeptId, int emp_id, int GeoTeam_Id, string DataTag)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddDepartmentHead";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DeptId", DeptId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_emp_id", emp_id));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_GeoTeam_Id", GeoTeam_Id));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DataTag", DataTag));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return count;
        }
        public string GetUserEmail(string UserId)
        {
            string emailId = "";
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetUserEmail";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_UserId", UserId));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            rdr.Read();
                            {
                                emailId = rdr["Email"].ToString();

                            }
                            rdr.Close();

                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return emailId;
        }
        public int AddShiftProductionMaster(string Type_Of_OEE, string Shift, string LineName, DateTime ProductionDateTime)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddShiftProductionMaster";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Type_Of_OEE", Type_Of_OEE));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Shift", Shift));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_LineName", LineName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ProductionDateTime", ProductionDateTime));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return count;
           
        }
        public string GetEmployeeNameByEmpiId(int emp_id)
        {
            string emailId = "";
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEmployeeNameByEmpId";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_emp_id", emp_id));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            rdr.Read();
                            {
                                emailId = rdr["emp_name"].ToString();

                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return emailId;
        }


        public int GetLoginUserRole(int UserID)
        {
            int roleId = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetLoggedUserRole";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_UserID", UserID));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            rdr.Read();
                            {
                                roleId =Convert.ToInt32( rdr["RoleID"]);
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return roleId;
        }

        public int GetInHousePermitValidity(string permitCode)
        {
            int permit = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetINHousePermitValidity";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_permitCode", permitCode));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            if (rdr.HasRows)
                            {
                                rdr.Read();
                                {
                                    permit = Convert.ToInt32(rdr["ValidPermit"]);
                                }
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return permit;
        }

        
        public DataTable CountCompliedData(int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_CountCompliedData";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return dt;
        }
        public DataTable GetComplianceStakeHolderWise(int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetComplianceStakeHolderWise";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return dt;
        }
        public DataTable GetMachineCategory(int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMachineCategory";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return dt;
        }
        public DataTable SearchComplianceDetails(string SearchPattern)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetComplianceOnFilter";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_SearchPattern", SearchPattern));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return dt;
        }
        public string ForgotPwd(string UserId, string UPwd, string AppId, int isActive)
        {
            string message = string.Empty;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "ForgotPassword";
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_UserId", UserId));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_UPwd", UPwd));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_AppId", AppId));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_isActive", isActive));
                            sda.SelectCommand.Parameters.Add("p_ERROR", MySqlDbType.VarChar, 500);
                            sda.SelectCommand.Parameters["p_ERROR"].Direction = ParameterDirection.Output;
                            sda.SelectCommand.ExecuteNonQuery();
                            message = (string)sda.SelectCommand.Parameters["p_ERROR"].Value;
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }      
            return message;
        }
        public int IsUserActive(string UserId, string AppId)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "IsUserActive";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_UserId", UserId));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_AppId", AppId));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            rdr.Read();
                            count = Convert.ToInt32(rdr["countactive"]);
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int GetLocationId(string locationName)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetLocationId";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_locationName", locationName));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            rdr.Read();
                            count = Convert.ToInt32(rdr["LocationId"]);
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }      

        public int SearchMachineTag(string machineTag)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_SearchMachineTag";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_machineTag", machineTag));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            rdr.Read();
                            count = Convert.ToInt32(rdr["countMax"]);
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;            
        }

        public int GetWindowSId(string WinDName)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "GetWindowSId";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_WinDName", WinDName));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            rdr.Read();
                            count = Convert.ToInt32(rdr["WMasterId"]);
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        ////////All Call////////////////////
        public string GetUserEmpCode(int UserId)
        {
            string empCode = string.Empty;
            try
            {                             
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetUserEmpCode";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_UserId", UserId));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            rdr.Read();
                            empCode = rdr["empCode"].ToString();
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return empCode;
        }

        public int GetOperationId(string operationName)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "GetOperationId";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_OperationName", operationName));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            rdr.Read();
                            count = Convert.ToInt32(rdr["OperationDetId"]);
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;            
        }
        public string AddUserType(string UTypeId, string UType)
        {
            string message = string.Empty;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "AddUserType";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_UTypeId", UTypeId));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_UType", UType));
                            int count = cmd.ExecuteNonQuery();
                             message = (string)cmd.Parameters["p_ERROR"].Value;
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return message;
        }

        public int AddComplianceTaggedUser(int complianceDetId, string taskCode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddComplianceTaggedUser";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_complianceDetId", complianceDetId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_taskCode", taskCode));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }


        public string AddNewUnitParameterWise(string oldval, string newval, string paramname, int param_id)
        {
            string message = string.Empty;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "AddNewUnitParameterWise";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_oldval", oldval));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_newval", newval));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_paramname", paramname));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_param_id", param_id));
                            sda.InsertCommand.Parameters.Add("p_output", MySqlDbType.VarChar, 500);
                            sda.InsertCommand.Parameters["p_output"].Direction = ParameterDirection.Output;
                            sda.InsertCommand.ExecuteNonQuery();
                            message = (string)cmd.Parameters["p_output"].Value;
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return message;
        }       
        public int addEquipmentName(string equipname)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "sp_addEquipmentName";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_equipname", equipname));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return count;
        }

        public int AddMachineParamMapping(int param_id, int sub_Layer_id, int layer_id)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "AddMachineParamMapping";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_param_id", param_id));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_sub_Layer_id", sub_Layer_id));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_layer_id", layer_id));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return count;
        }

        public int AddEmploymentHistory(string Value, int mode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "AddEmploymentHistory";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_value", Value));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return count;
        }


        public int AddHealthEnvironment(string supplement_chemicals, string clean_chemicals, string clean_materials, string emission, string discharge, string waste_generation, string MachineTagNo, int healthinvId, int mode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "AddHealthEnvironment";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_supplement_chemicals", supplement_chemicals));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_clean_chemicals", clean_chemicals));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_clean_materials", clean_materials));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_emission", emission));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_discharge", discharge));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_waste_generation", waste_generation));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_MachineTagNo", MachineTagNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_health_EnvId", healthinvId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return count;
        }       

        public List<UserType> GetUserType()
        {
            List<UserType> utype = new List<UserType>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "GetUsertype";                            
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                var UserModel = new UserType
                                {
                                    UTypeId = rdr.GetString(0),
                                    UType = rdr.GetString(1)
                                };
                                utype.Add(UserModel);
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return utype;           
        }
        public List<string> GetVendorName()
        {
            List<string> vendorName = new List<string>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetVendorName";
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                vendorName.Add(rdr["vendorname"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return vendorName;
        }

        public List<string> GetMasterVendorCode()
        {
            List<string> vendorName = new List<string>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMasterVendorCode";
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                vendorName.Add(rdr["vendorCode"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return vendorName;
        }

        public List<string> GetReportService()
        {
            List<string> reportName = new List<string>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetReportService";
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                reportName.Add(rdr["reportName"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }          
            return reportName;
        }
        public List<string> GetMachineFunctionalocation()
        {
            List<string> location = new List<string>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMachineFunctionalocation";
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                location.Add(rdr["NameOfArea"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return location;           
        }

        public List<string> GetDepartmentWiseEmployee(int deptid)
        {
            List<string> empDept = new List<string>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetDepartmentWiseEmployee";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_DeptId", deptid));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                empDept.Add(rdr["emp_name"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return empDept;            
        }

        public DataTable GetLineShifts()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetLineShifts";                            
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
            return dt;
        }

        public DataTable GetDragDroppedMachinesList()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetDrag&DroppedMachinesList";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;           
        }
        public List<LayerType> GetLayerType()
        {
            List<LayerType> layrtype = new List<LayerType>();
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.SelectCommand = cmd;
                        sda.SelectCommand.Connection = cnn;
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = "GetTableLayer";                        
                        MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                        while (rdr.Read())
                        {
                            var layertype = new LayerType
                            {
                                layer_id = rdr.GetInt32(0),
                                layer_name = rdr.GetString(1),
                                layer_type = rdr.GetString(2)
                            };
                            layrtype.Add(layertype);
                        }
                        rdr.Close();
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }           
            return layrtype;
        }
        public string GetUserId(string UserId)
        {
            string message = string.Empty;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "GetUserId";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_UserId", UserId));
                            sda.SelectCommand.Parameters.Add("p_ERROR", MySqlDbType.VarChar, 500);
                            sda.SelectCommand.Parameters["p_ERROR"].Direction = ParameterDirection.Output;
                            int count = cmd.ExecuteNonQuery();
                            message = (string)cmd.Parameters["p_ERROR"].Value;
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }         
            return message;
        }
        public int GetUserID(string proc, string empname, ref int result)
        {
            int Data = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.SelectCommand = cmd;
                        sda.SelectCommand.Connection = cnn;
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = proc;
                        sda.SelectCommand.Parameters.Add("p_empName", MySqlDbType.VarChar, 50).Value = empname;
                        sda.SelectCommand.Parameters.Add("p_UserID", MySqlDbType.Int32);
                        sda.SelectCommand.Parameters["p_UserID"].Direction = ParameterDirection.Output;
                        Data = sda.SelectCommand.ExecuteNonQuery();
                        result = int.Parse(sda.SelectCommand.Parameters["p_UserID"].Value.ToString());
                    }
                }
            }
            return Data;
        }
        public int CountAuditOnMachine(string machineTag)
        {
            int totAudit = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_CountAuditonMachine";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_machineTag", machineTag));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                totAudit = Convert.ToInt32(rdr["TotalAudits"]);
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return totAudit;
        }
        public string GetVendorCodeonName(string vendorName)
        {
            string status = string.Empty;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetVendorCodeOnName";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_vendorName", vendorName));
                           MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();                           
                            while (rdr.Read())
                            {
                                status = rdr["vendorCode"].ToString();
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
            return status;

        }
        public string GetVendorContact(string vendorCode)
        {
            string status = string.Empty;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetVendorContact";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_vendorCode", vendorCode));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                status = rdr["vContact"].ToString();
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return status;            
        }
        public string GetUsereEmail(string email)
        {
            string message = string.Empty;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "GetUserEmail";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_email", email));
                            sda.SelectCommand.Parameters.Add("p_ERROR", MySqlDbType.VarChar, 500);
                            sda.SelectCommand.Parameters["p_ERROR"].Direction = ParameterDirection.Output;
                            int count = cmd.ExecuteNonQuery();
                             message = (string)cmd.Parameters["p_ERROR"].Value;
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return message;           
        }
        public string GetMachineStatus(string MachineTagNo, string Status, int mode)
        {
            string status = string.Empty;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "SP_UpdateMachineStatus";
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_MachineTagNo", MachineTagNo));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_Status", Status));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            MySqlDataReader rdr = sda.UpdateCommand.ExecuteReader();                           
                            while (rdr.Read())
                            {
                                status = rdr["Status"].ToString();
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }          
            return status;
        }                              
        public DataSet GetMachineParameters(string equipmentName)
        {
            DataSet dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "GetMachineParameters";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_equipment_name", equipmentName));
                            dt = new DataSet();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return dt;
        }

        public List<string> CheckTableParameter()
        {
            List<string> datalist = new List<string>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "CheckTableParameter";
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                datalist.Add(rdr["COLUMN_NAME"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return datalist;                       
        }
        public List<string> GetProductionLineName(int mode)
        {
            List<string> datalist = new List<string>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetProductionLineName";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            string getval = "";
                            if (mode == 1)
                            {
                                getval = "shift";
                            }
                            else
                            {
                                getval = "linename";
                            }
                            while (rdr.Read())
                            {
                                datalist.Add(rdr[getval].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return datalist;            
        }
        public List<string> CheckSeconaryTable(string secondtable, string primaryTable)
        {
            List<string> datalist = new List<string>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "CheckSeconaryTable";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_secondtable", secondtable));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_primaryTable", primaryTable));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();                            
                            while (rdr.Read())
                            {
                                datalist.Add(rdr["COLUMN_NAME"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return datalist;            
        }

        public string GetMachineName(int parameterId)
        {
            string machineName = string.Empty;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "GetEquipmentName";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_parameterId", parameterId));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            if (rdr.HasRows)
                            {
                                rdr.Read();
                                {
                                    machineName = rdr["equipment_name"].ToString();
                                }
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();

                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
          
            return machineName;
        }      
        public List<EmployeeDetail> GetEmployeeId()
        {
            List<EmployeeDetail> empDetails = new List<EmployeeDetail>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEmployeeCode";
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                var empModel = new EmployeeDetail
                                {
                                    emp_id = rdr.GetInt32(0),
                                    emp_code = rdr.GetString(1),
                                    emp_name = rdr.GetString(2)
                                };
                                empDetails.Add(empModel);
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return empDetails;
        }       
        public int GetEmployeeIdfromName(string empName)
        {
            int empid = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEmployeeIdfromName";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_empName", empName));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                empid = Convert.ToInt32(rdr["emp_id"]);
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return empid;
        }
        public List<ServiceName> GetReportServiceNameType()
        {
            List<ServiceName> serviceName = new List<ServiceName>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetReportServiceNameType";
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                var servicename = new ServiceName
                                {
                                    reportName = rdr.GetString(0),
                                    serviceType = rdr.GetString(1)

                                };
                                serviceName.Add(servicename);
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return serviceName;
        }       
        public DataTable GetGeoLocationForEmployee(string empname)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEmployeeLocation";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_emp_name", empname));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }         
            return dt;          
        }
        public DataTable GetAllComplianceName()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetComplianceName";                            
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
            return dt;
            // return message;
        }
        public DataTable GetMachineConnectionInfo(string machineTag)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMachineConnectionInfo";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_machineTag", machineTag));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }         
            return dt;
            // return message;
        }



        public DataTable GetComplianceAgainstStatus(string currentStatus, string ComplianceId,DateTime dateFrom, DateTime toDate)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetComplianceAgainstStatus";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_currentStatus", currentStatus));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_ComplianceId", ComplianceId));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_dateFrom", dateFrom));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_toDate", toDate));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public DataTable GetMachineAreaDetails(string machinename)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMachineAreaDetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_machinename", machinename));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
            return dt;
        }

        public DataTable GetEmployeeList(int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEmployeeDetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return dt;            
        }
        public int AddApplicablePramaster(int paramId)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "sp_addApplicableParameterMaster";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_param_id", paramId));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;            
        }

        public int CountStandardColumns(string tableName, string tableSchema, string tableCatalog)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_CountStandardColumns";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_tableName", tableName));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_tableSchema", tableSchema));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_tableCatalog", tableCatalog));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                count = Convert.ToInt32(rdr["cntcol"].ToString());
                            }
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;           
        }
        public int CountTaskCode(string taskCode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_CountTaskCode";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_taskCode", taskCode));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                count = Convert.ToInt32(rdr["taskCode"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;           
        }
        public int AddRFQMaster(string Quot_date, string RFQ_code)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddRfqMaster";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Quot_date", Quot_date));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RFQ_code", RFQ_code));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return count;
        }

        public int AddRQApprovedById(string RFQCode, string RFQ_CheckedBy, string RFQ_ApprovedBy, string RFQ_VendorcheckedBy, string RFQ_VendorApprovedBy, string RFQ_RaisedBy, string RFQ_OwnedBy)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddRFQApprovalID";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RFQCode", RFQCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RFQ_CheckedBy", RFQ_CheckedBy));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RFQ_ApprovedBy", RFQ_ApprovedBy));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RFQ_VendorcheckedBy", RFQ_VendorcheckedBy));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RFQ_VendorApprovedBy", RFQ_VendorApprovedBy));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RFQ_RaisedBy", RFQ_RaisedBy));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RFQ_OwnedBy", RFQ_OwnedBy));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;           
        }
        public int AddRFQFinalization(string vendorCode, string RFQCode, string FinalDate)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddRFQFinalization";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_vendorCode", vendorCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RFQCode", RFQCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_FinalDate", FinalDate));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;            
        }

        public int UpdateSafetyTask(string taskCode, string taskType, string taskDescription, string taskReference, string taskRefereDocPath, string taskDeadline, string taskSeekPartner)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "SP_UpdateSafetyTask";
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_taskCode", taskCode));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_taskType", taskType));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_taskDescription", taskDescription));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_taskReference", taskReference));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_taskRefereDocPath", taskRefereDocPath));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_taskDeadline", taskDeadline));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_taskSeekPartner", taskSeekPartner));
                            count = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;           
        }
        public int UpdateUserNotification(string taskCode, string status, string empCode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "SP_UpdateSafetyTask";                          
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_taskCode", taskCode));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_status", status));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_empCode", empCode));
                            count = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;            
        }

        public int UpdateTaskToPending(string empCode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "SP_UpdTaskStatustoPending";
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_empCode", empCode));
                            count = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public int AddTaskSafetyTagEvent(string taskCode, string empCode, string tagDate, string tagUpdDate, string taskStatus, string taskCategory, int mode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddTaskSafetyTagEvent";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_taskCode", taskCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_empCode", empCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_tagDate", tagDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_tagUpdDate", tagUpdDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_taskStatus", taskStatus));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_taskCategory", taskCategory));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public int AddActionTask(string taskCode, string actionName, string dateOfClosure, string priority, string Constraints, string Description, string tentDateofStart, string empcode, string targetDateOfClosure, string acceptWithReason, string ClosingReason, string ClosingDescription, string TaskStatus, string AssignedTo, int mode, string taskCategory, string UploadedPath)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddSafetyTaskAction";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_taskCode", taskCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_actionName", actionName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_dateOfClosure", dateOfClosure));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_priority", priority));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Constraints", Constraints));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Description", Description));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_tentDateofStart", tentDateofStart));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_empcode", empcode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_targetDateOfClosure", targetDateOfClosure));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_acceptWithReason", acceptWithReason));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ClosingReason", ClosingReason));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ClosingDescription", ClosingDescription));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_TaskStatus", TaskStatus));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_AssignedTo", AssignedTo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_taskCategory", taskCategory));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UploadedPath", UploadedPath));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int GetVendorCode(string vcode, int mode)
        {
            int newID = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.SelectCommand = cmd;
                        sda.SelectCommand.Connection = cnn;
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = "SP_GetVendorCode";
                        sda.SelectCommand.Parameters.Add(new MySqlParameter("p_vcode", vcode));
                        sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                        MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                        while (rdr.Read())
                        {
                            newID = Convert.ToInt32(rdr["vcode"]);
                        }
                        rdr.Close();
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return newID;
            // return message;

        }
        public DataTable GetUserActivityHeader(string UserId)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetUserActivityHeader";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_UserId", UserId));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return dt;
        }
      
        public int AddComplianceDetails(int complianceId, int statutory, int NonStatutory, int CorporateFirm, string RegulationBreif, string Standard, string ReleaseDate, string currentStatus, string DocName,
string corporateLatestDate, string lastpermitDate, string nextpermitUpdate, string frequency, int ownerDept, int owner1, int owner2, string ScannedCopy, string oldPermit, string notices)
        {
            int newID = 0;
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddCompianceData";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_complianceId", complianceId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_statutory", statutory));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_NonStatutory", NonStatutory));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CorporateFirm", CorporateFirm));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RegulationBreif", RegulationBreif));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Standard", Standard));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ReleaseDate", ReleaseDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_currentStatus", currentStatus));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocName", DocName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_corporateLatestDate", corporateLatestDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_lastpermitDate", lastpermitDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_nextpermitUpdate", nextpermitUpdate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_frequency", frequency));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ownerDept", ownerDept));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_owner1", owner1));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_owner2", owner2));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ScannedCopy", ScannedCopy));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_oldPermit", oldPermit));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_notices", notices));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int GetComplianceID(string complianceName)
        {
            int newID = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetComplianceId";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_complianceName", complianceName));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                newID = Convert.ToInt32(rdr["complianceId"].ToString());
                            }
                            rdr.Close();
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return newID;
        }

        // Note- the Procedure return object is changed from Uid to UserId as now the reference is chnaged from userdetails to usercredentials.//
        public int GetUserIDByName(string userName)
        {
            int newID = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetUserIDByName";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_userName", userName));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                newID = Convert.ToInt32(rdr["UserID"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return newID;           

        }
        public string GetMAchineTagfromName(string machineName)
        {
            string newID = string.Empty;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMachineNamefromTag";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_machineName", machineName));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                newID = rdr["MachineTagNo"].ToString();
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return newID;
        }
        public int TotalMachinesOnCAD(int mode, string status)
        {
            int newID = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMachineLineStatus";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_status", status));
                           
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                newID = Convert.ToInt32(rdr["TotalMachines"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return newID;
        }
        public int TotalMachinesinOperaion(int mode, string status)
        {
            int newID = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMachineLineStatus";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_status", status));

                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                newID = Convert.ToInt32(rdr["TotalLineStat"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return newID;

        }
        public int AddMachineInterLockData(DataTable dt)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_addMachineInterLock";
                            sda.InsertCommand.Parameters.AddWithValue("p_datatable", dt);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;           
        }
        public int AddRawMaterials(string MaterialName, decimal Qty, string Unit, string Location, decimal Price)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddRawMaterial";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_MaterialName", MaterialName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Qty", Qty));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Unit", Unit));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Location", Location));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Price", Price));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int ADDNewServiceConnection(string serviceCode, string serviceName)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddNewServiceConn";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_serviceCode", serviceCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_serviceName", serviceName));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int AddGenericUnit(string UnitName)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddGenericUnitNew";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UnitName", UnitName));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;           
        }
        public int AddUserActivityHeaderc(int activityLogId, string UserId, int DeptId, DateTime activitydate)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddUserActivityDetails";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_activityLogId", activityLogId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UserId", UserId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DeptId", DeptId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_activitydate", activitydate));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int AddHazardSpecialRequirement(string area, string activity, string typeOfWork, string description, int HIRANoControl, string TypeOfControl, string consequence, string describeControls, string likelihood, string severity, int ownerId, string riskRating, string PPERequired, int HIRAWithNewControl)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddPermitSpecialRequirement";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_area", area));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_activity", activity));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_typeOfWork", typeOfWork));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_description", description));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_HIRANoControl", HIRANoControl));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_TypeOfControl", TypeOfControl));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_consequence", consequence));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_describeControls", describeControls));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_likelihood", likelihood));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_severity", severity));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ownerId", ownerId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_riskRating", riskRating));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_PPERequired", PPERequired));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_HIRAWithNewControl", HIRAWithNewControl));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int AddPTWBasicDetailsWithWorkLocation(string permitCode, string RequestedTime, int RequestedBy, string durationFrom, string durationTo,
            string areaName, string MachineTagNo, int AreaApproverId, string description,string WorkType, string capability, string permitType, 
            string ptwBasicstatus, int IsIsolationRequired,int IsIsolationComplete,string Comments)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddPTWBasicDetails";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_permitCode", permitCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RequestedTime", RequestedTime));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RequestedBy", RequestedBy));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_durationFrom", durationFrom));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_durationTo", durationTo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_areaName", areaName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_MachineTagNo", MachineTagNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_AreaApproverId", AreaApproverId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_description", description));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_WorkType", WorkType));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_capability", capability));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_permitType", permitType));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_status", ptwBasicstatus));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_IsIsolationRequired", IsIsolationRequired));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_IsIsolationComplete", IsIsolationRequired));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Comments", Comments));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public int AddPTWBasicDetailsWithWorkLocation(string permitCode, string RequestedTime, int RequestedBy, string durationFrom, string durationTo,
            string fromHrs, string fromMinuts, string toHrs, string toMinuts, string areaName, string MachineTagNo, int AreaApproverId, string description,
            string WorkType, string capability,string Vendor ,string permitType, string ptwBasicstatus, int IsIsolationRequired, int IsIsolationComplete,
            int IsSaved,string Comments)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddPTWBasicDetailsExt";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_permitCode", permitCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RequestedTime", RequestedTime));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RequestedBy", RequestedBy));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_durationFrom", durationFrom));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_durationTo", durationTo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Fromhrs", fromHrs));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_FromMinuts", fromMinuts));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ToHrs", toHrs));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ToMinuts", toMinuts));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_areaName", areaName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_MachineTagNo", MachineTagNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_AreaApproverId", AreaApproverId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_description", description));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_WorkType", WorkType));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_capability", capability));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Vendor", Vendor));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_permitType", permitType));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_status", ptwBasicstatus));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_IsIsolationRequired", IsIsolationRequired));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_IsIsolationComplete", IsIsolationRequired));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_IsSaved", IsSaved));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Comments", Comments));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public int AddPTWStatus(int mode, string permitCode, string status)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddPermitStatus";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_permitCode", permitCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_status", status));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }        
        public int AddPTWClosure(string PermitCode, DateTime ClosureDate, string ClosedBy, string FinalStatus)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddPTWClosure";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_PermitCode", PermitCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ClosureDate", ClosureDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ClosedBy", ClosedBy));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_FinalStatus", FinalStatus));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public DataTable GetPermitByStatusName(string status, string dateFrom, string dateTo, int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetPermitByStatus";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_status", status));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_dateFrom", dateFrom));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_dateTo", dateTo));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return dt;
        }
        public DataTable getPTWBasicInfo()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetPermitBasicInfo";                            
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return dt;
        }        
        public int GetTotalPermit(string permitCode)
        {
            int newID = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.SelectCommand = cmd;
                        sda.SelectCommand.Connection = cnn;
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = "SP_GetTotalPermit";
                        sda.SelectCommand.Parameters.Add(new MySqlParameter("p_permitCode", permitCode));
                        MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            rdr.Read();
                            {
                                newID = Convert.ToInt32(rdr["TotalPermit"]);
                            }
                        }
                        rdr.Close();
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return newID;
        }
        public int DropInventoryData(string p_machinetagno)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.DeleteCommand = cmd;
                            sda.DeleteCommand.Connection = cnn;
                            sda.DeleteCommand.CommandType = CommandType.StoredProcedure;
                            sda.DeleteCommand.CommandText = "SP_DropInventoryData";
                            sda.DeleteCommand.Parameters.Add(new MySqlParameter("p_machinetagno", p_machinetagno));
                            count = sda.DeleteCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int DropEnvironmentData(string MachineTagNo)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.DeleteCommand = cmd;
                            sda.DeleteCommand.Connection = cnn;
                            sda.DeleteCommand.CommandType = CommandType.StoredProcedure;
                            sda.DeleteCommand.CommandText = "SP_DeleteEnvironmentData";
                            sda.DeleteCommand.Parameters.Add(new MySqlParameter("p_machinetagno", MachineTagNo));
                            count = sda.DeleteCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int DropEmployeeDetails(string userInput, int mode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.DeleteCommand = cmd;
                            sda.DeleteCommand.Connection = cnn;
                            sda.DeleteCommand.CommandType = CommandType.StoredProcedure;
                            sda.DeleteCommand.CommandText = "SP_DeleteEmployeeDetails";
                            sda.DeleteCommand.Parameters.Add(new MySqlParameter("p_userInput", userInput));
                            sda.DeleteCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            count = sda.DeleteCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;        
        }
        public int DropOEEProductionLine(int LineID)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.DeleteCommand = cmd;
                            sda.DeleteCommand.Connection = cnn;
                            sda.DeleteCommand.CommandType = CommandType.StoredProcedure;
                            sda.DeleteCommand.CommandText = "SP_DropOEEProductionLine";
                            sda.DeleteCommand.Parameters.Add(new MySqlParameter("p_LineID", LineID));
                            count = sda.DeleteCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int AddHazardSpecialRequirement( string area, string activity, string typeOfWork, string description, int HIRANoControl, string TypeOfControl, string consequence, string describeControls, string likelihood, string severity, int ownerId, string riskRating, string PPERequired, int HIRAWithNewControl, string permitcode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddPermitSpecialRequirement";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_area", area));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_activity", activity));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_typeOfWork", typeOfWork));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_description", description));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_HIRANoControl", HIRANoControl));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_TypeOfControl", TypeOfControl));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_consequence", consequence));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_describeControls", describeControls));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_likelihood", likelihood));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_severity", severity));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ownerId", ownerId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_riskRating", riskRating));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_PPERequired", PPERequired));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_HIRAWithNewControl", HIRAWithNewControl));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_permitcode", permitcode));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int DropComplianceMaster(int complianceId)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.DeleteCommand = cmd;
                            sda.DeleteCommand.Connection = cnn;
                            sda.DeleteCommand.CommandType = CommandType.StoredProcedure;
                            sda.DeleteCommand.CommandText = "SP_DropComplianceMaster";
                            sda.DeleteCommand.Parameters.Add(new MySqlParameter("p_complianceId", complianceId));
                            count = sda.DeleteCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int AddPermitOtherHazard(int permitId,string electricalHazard, string fireHazard, string fallFromHeight, string crushing, string vibration, string ambientemprature, string noise, string radiations, string vapours, string dust, string safetyGuideline)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddPTWOtherHazard";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_permitId", permitId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_electricalHazard", electricalHazard));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_fireHazard", fireHazard));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_fallFromHeight", fallFromHeight));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_crushing", crushing));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_vibration", vibration));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ambientemprature", ambientemprature));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_noise", noise));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_radiations", radiations));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_vapours", vapours));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_dust", dust));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_safetyGuideline", safetyGuideline));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;            
        }
        public int AddPermitOtherHazard(string electricalHazard, string fireHazard, string fallFromHeight, string crushing, string vibration, string ambientemprature, string noise, string radiations, string vapours, string dust, string safetyGuideline, string permitcode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddPTWOtherHazard";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_electricalHazard", electricalHazard));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_fireHazard", fireHazard));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_fallFromHeight", fallFromHeight));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_crushing", crushing));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_vibration", vibration));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ambientemprature", ambientemprature));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_noise", noise));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_radiations", radiations));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_vapours", vapours));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_dust", dust));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_safetyGuideline", safetyGuideline));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_permitcode", permitcode));

                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int AddVendorRFQOutSourced(string permitCode, string vendorCode, string RFQCode, string vendorContact, string teamCapability, string equipmentsUsed, string VendEmpName)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddVendorRFQOutSourced";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_permitCode", permitCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_vendorCode", vendorCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RFQCode", RFQCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_vendorContact", vendorContact));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_teamCapability", teamCapability));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_equipmentsUsed", equipmentsUsed));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_VendEmpName", VendEmpName));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int AddFinalVendorResponse(DateTime loggedTime, string VendorCode, string JobOrderNo, string POdescription,
          string ScheduleorDuration, string AuditFrom, string AuditTo, string TeamCapability, string PreRequisite, string EquipmentUsed,
          string EscalationMatrix, string Milestone1, string Milestone2, string Milestone3)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddVendorFinalResponse";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_loggedTime", loggedTime));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_VendorCode", VendorCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_JobOrderNo", JobOrderNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_POdescription", POdescription));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ScheduleorDuration", ScheduleorDuration));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_AuditFrom", AuditFrom));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_AuditTo", AuditTo));                         
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_TeamCapability", TeamCapability));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_PreRequisite", PreRequisite));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_EquipmentUsed", EquipmentUsed));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_EscalationMatrix", EscalationMatrix));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Milestone1", Milestone1));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Milestone2", Milestone2));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Milestone3", Milestone3));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;         
        }
        public int AddPTWIsolationDetails(string permitCode, DateTime isolationDate, string location, string equipName, string connectorType, int isolationCompleted, string LockNo, string personName, string contactNo, string Status,byte[] Snapshot)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddPTWIsolationDetails";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_permitCode", permitCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_isolationDate", isolationDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_location", location));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_equipName", equipName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_connectorType", connectorType));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_isolationCompleted", isolationCompleted));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_LockNo", LockNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_personName", personName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_contactNo", contactNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Status", Status));
                            if(Snapshot==null)
                                sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Snapshot", System.Data.SqlTypes.SqlBinary.Null));
                            else
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Snapshot", Snapshot));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        //public int AddPTWIsolationDetails(string permitCode, DateTime isolationDate, string location, string equipName, string connectorType, int isolationCompleted, string LockNo, string personName, string contactNo, string Status)
        //{
        //    int count = 0;
        //    try
        //    {
        //        using (MySqlConnection cnn = new MySqlConnection(GetConnection))
        //        {
        //            cnn.Open();
        //            using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
        //            {
        //                using (MySqlCommand cmd = new MySqlCommand())
        //                {
        //                    sda.InsertCommand = cmd;
        //                    sda.InsertCommand.Connection = cnn;
        //                    sda.InsertCommand.CommandType = CommandType.StoredProcedure;
        //                    sda.InsertCommand.CommandText = "SP_AddPTWIsolationDetails";
        //                    sda.InsertCommand.Parameters.Add(new MySqlParameter("p_permitCode", permitCode));
        //                    sda.InsertCommand.Parameters.Add(new MySqlParameter("p_isolationDate", isolationDate));
        //                    sda.InsertCommand.Parameters.Add(new MySqlParameter("p_location", location));
        //                    sda.InsertCommand.Parameters.Add(new MySqlParameter("p_equipName", equipName));
        //                    sda.InsertCommand.Parameters.Add(new MySqlParameter("p_connectorType", connectorType));
        //                    sda.InsertCommand.Parameters.Add(new MySqlParameter("p_isolationCompleted", isolationCompleted));
        //                    sda.InsertCommand.Parameters.Add(new MySqlParameter("p_LockNo", LockNo));
        //                    sda.InsertCommand.Parameters.Add(new MySqlParameter("p_personName", personName));
        //                    sda.InsertCommand.Parameters.Add(new MySqlParameter("p_contactNo", contactNo));
        //                    sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Status", Status));
        //                    count = sda.InsertCommand.ExecuteNonQuery();
        //                    cmd.Dispose();
        //                }
        //                sda.Dispose();
        //            }
        //            cnn.Dispose();
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw new Exception(Ex.Message);
        //    }
        //    return count;
        //}


        public int AddOEENonProductionDetails(int LineId, decimal MealBreak, decimal Education, decimal PreventiveMaintenance, decimal BreakDown_Repair, decimal ToolChange, decimal LackOfResource,
          decimal SetUpTime, decimal Cleaning, decimal WaitingForApproval, decimal Adjustments, string OEEDate)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddOEENonProductionDetails";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_LineId", LineId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_MealBreak", MealBreak));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Education", Education));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_PreventiveMaintenance", PreventiveMaintenance));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_BreakDown_Repair", BreakDown_Repair));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ToolChange", ToolChange));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_LackOfResource", LackOfResource));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_SetUpTime", SetUpTime));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Cleaning", Cleaning));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_WaitingForApproval", WaitingForApproval));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Adjustments", Adjustments));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_OEEDate", OEEDate));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int AddPermitTypemaster(string permitName, string description, int mode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddPermitTypemaster";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_permitName", permitName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_description", description));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;           
        }
        public int AddUserNotification(string Description, string Source, string empCode, string taskCode, DateTime AssignedDate, int Status)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddUsernotification";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Description", Description));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Source", Source));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_empCode", empCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_taskCode", taskCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_AssignedDate", AssignedDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Status", Status));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;         
        }
        public int AddNewHazardRequierment(string requirement, string description, int permitId)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddNewHazardRequirement";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_requirement", requirement));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_description", description));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_permitId", permitId));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;

        }
        public int AddNewHazardRequierment(string requirement, string description, string permitcode, string MoniterNeed, string Lelmeasure)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddNewHazardRequirement";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_requirement", requirement));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_description", description));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_permitcode", permitcode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_MoniterNeed", MoniterNeed));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Lelmeasure", Lelmeasure));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;

        }
        public int DeletePTW(string p_PermitCode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.DeleteCommand = cmd;
                            sda.DeleteCommand.Connection = cnn;
                            sda.DeleteCommand.CommandType = CommandType.StoredProcedure;
                            sda.DeleteCommand.CommandText = "SP_DeletePTW";
                            sda.DeleteCommand.Parameters.Add(new MySqlParameter("p_PermitCode", p_PermitCode));
                            count = sda.DeleteCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int AddVendorMaster(DataTable dt)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddVendorMaster";                           
                            sda.InsertCommand.Parameters.AddWithValue("p_datatable", dt);                           
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;           
        }
        public int AddVendorMaster(string VendorName, string VendorCode, string Contact, string ContactPeson, string EmailId, DateTime CreatedDate, string Address)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddVendor";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_VendorName", VendorName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_VendorCode", VendorCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Contact", Contact));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ContactPerson", ContactPeson));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_EmailId", EmailId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CreatedDate", CreatedDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Address", Address));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int AddDailyProductionDetails(DataTable dt)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddDailyProduction";
                            sda.InsertCommand.Parameters.AddWithValue("p_datatable", dt);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;          
        }
        public int AddWeeklyProductionDetails(DataTable dt)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddWeeklyProduction";
                            sda.InsertCommand.Parameters.AddWithValue("p_datatable", dt);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;        
        }
        public int AddLineConfiguration(int LineId, string ConnectedMachines)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddLineConfiguration";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_LineId", LineId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ConnectedMachines", ConnectedMachines));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int AddMonthlyProductionDetails(DataTable dt)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddMonthlyProduction";
                            sda.InsertCommand.Parameters.AddWithValue("p_datatable", dt);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;           
        }
        public int AddRFQuotation(DataTable dt)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddRFQuotation";
                            sda.InsertCommand.Parameters.AddWithValue("p_datatable", dt);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int AddMachineHazopData(DataTable dt)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_addMachineHazop";
                            sda.InsertCommand.Parameters.AddWithValue("p_datatable", dt);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int AddComplianceExcelData(DataTable dt)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddComplianceExcelData";
                            sda.InsertCommand.Parameters.AddWithValue("p_datatable", dt);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        //getTabParameterData
        public int GetMachineOREquipmentName(string machineTagNo)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_GetMachineOREquipmentName";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_machineTagNo", machineTagNo));                          
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int GetOEEProductionLineId(string productionLine, string shift, string category)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetOEEProductionLineID";
                            sda.SelectCommand.Parameters.AddWithValue("p_productionLine", productionLine);
                            sda.SelectCommand.Parameters.AddWithValue("p_shift", shift);
                            sda.SelectCommand.Parameters.AddWithValue("p_category", category);
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            count=Convert.ToInt32(rdr["LineId"].ToString());
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public List<string> GetAreaApprover(string areaname)
        {
            List<string> areaapprover = new List<string>();            
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetAreaApprover";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_nameofarea", areaname));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                areaapprover.Add(rdr["AreaOwner"].ToString());                                
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return areaapprover;           
        }
        public string GetMachineLocation(string MachineTagNo)
        {
            string areaapprover = string.Empty;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMachineLocation";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_MachineTagNo", MachineTagNo));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                areaapprover = rdr["Machinelocation"].ToString();
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return areaapprover;
        }             
        public int AddSafetyTask(string taskCode, string taskType, string taskDescription, string taskReference, string taskRefereDocPath, DateTime taskDeadline, string AssignedTo, string AssignedBy)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddSafetyTask";
                            sda.InsertCommand.Parameters.AddWithValue("p_taskCode", taskCode);
                            sda.InsertCommand.Parameters.AddWithValue("p_taskType", taskType);
                            sda.InsertCommand.Parameters.AddWithValue("p_taskDescription", taskDescription);
                            sda.InsertCommand.Parameters.AddWithValue("p_taskReference", taskReference);
                            sda.InsertCommand.Parameters.AddWithValue("p_taskRefereDocPath", taskRefereDocPath);
                            sda.InsertCommand.Parameters.AddWithValue("p_taskDeadline", taskDeadline);
                            sda.InsertCommand.Parameters.AddWithValue("p_AssignedTo", AssignedTo);
                            sda.InsertCommand.Parameters.AddWithValue("p_AssignedBy", AssignedBy);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
       
        
        public int AddOEEEEShiftWiseProduction(DataTable dt)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_Add_OEE_EE_ShiftWiseProduction";
                            sda.InsertCommand.Parameters.AddWithValue("p_datatable", dt);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int addApplicableParameter(DataTable dt, int parameterId)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "addApplicableParameter";
                            sda.InsertCommand.Parameters.AddWithValue("p_datatable", dt);
                            sda.InsertCommand.Parameters.AddWithValue("p_param_id", parameterId);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;                        
        }
        public int AddEventReporting(string eventReportingDate, string eventLocation, string empCode, string ImgPath, string MachineTagNo, string remarks, string description, int eventrerportid, int mode, string actionableCategory, string riskCategory)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddEventReporting";
                            sda.InsertCommand.Parameters.AddWithValue("p_eventReportingDate", eventReportingDate);
                            sda.InsertCommand.Parameters.AddWithValue("p_eventLocation", eventLocation);
                            sda.InsertCommand.Parameters.AddWithValue("p_empCode", empCode);
                            sda.InsertCommand.Parameters.AddWithValue("p_ImgPath", ImgPath);
                            sda.InsertCommand.Parameters.AddWithValue("p_MachineTagNo", MachineTagNo);
                            sda.InsertCommand.Parameters.AddWithValue("p_remarks", remarks);
                            sda.InsertCommand.Parameters.AddWithValue("p_description", description);
                            sda.InsertCommand.Parameters.AddWithValue("p_eventreportingId", eventrerportid);
                            sda.InsertCommand.Parameters.AddWithValue("p_mode", mode);
                            sda.InsertCommand.Parameters.AddWithValue("p_actionableCategory", actionableCategory);
                            sda.InsertCommand.Parameters.AddWithValue("p_riskCategory", riskCategory);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int UpdVendorMaster(string vendorCode, string vendorName, string vAddress, string vContact, string vEmailId, string vContactPerson, string vDesignation, string vHeadOffice, string vCategory, string vAddCategory, int mode)
        {
            int count = 0;
            try
            {                
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "SP_UpdVendorMaster";
                            sda.UpdateCommand.Parameters.AddWithValue("p_vendorCode", vendorCode);
                            sda.UpdateCommand.Parameters.AddWithValue("p_vendorName", vendorName);
                            sda.UpdateCommand.Parameters.AddWithValue("p_vAddress", vAddress);
                            sda.UpdateCommand.Parameters.AddWithValue("p_vContact", vContact);
                            sda.UpdateCommand.Parameters.AddWithValue("p_vEmailId", vEmailId);
                            sda.UpdateCommand.Parameters.AddWithValue("p_vContactPeson", vContactPerson);
                            sda.UpdateCommand.Parameters.AddWithValue("p_vDesignation", vDesignation);
                            sda.UpdateCommand.Parameters.AddWithValue("p_vHeadOffice", vHeadOffice);
                            sda.UpdateCommand.Parameters.AddWithValue("p_vCategory", vCategory);
                            sda.UpdateCommand.Parameters.AddWithValue("p_vAddCategory", vAddCategory);
                            sda.UpdateCommand.Parameters.AddWithValue("p_mode", mode);
                            count = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public int AddEventReportingDetails(string eventBrief, string event_responsibility, string event_EHS_Responsibility, string vendorName, int eventReportingId, int mode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddEventReportingDetails";
                            sda.InsertCommand.Parameters.AddWithValue("p_eventBrief", eventBrief);
                            sda.InsertCommand.Parameters.AddWithValue("p_event_responsibility", event_responsibility);
                            sda.InsertCommand.Parameters.AddWithValue("p_event_EHS_Responsibility", event_EHS_Responsibility);
                            sda.InsertCommand.Parameters.AddWithValue("p_vendorName", vendorName);
                            sda.InsertCommand.Parameters.AddWithValue("p_eventReportingId", eventReportingId);
                            sda.InsertCommand.Parameters.AddWithValue("p_mode", mode);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;          
        }
        public int AddReportFormat(string reportName, string serviceType, string category)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddReportFormat";
                            sda.InsertCommand.Parameters.AddWithValue("p_reportName", reportName);
                            sda.InsertCommand.Parameters.AddWithValue("p_serviceType", serviceType);
                            sda.InsertCommand.Parameters.AddWithValue("p_category", category);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int AddReportFormatDetails(string machineName, string areaName, string observationType, string recommendationType, string riskCategory)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddReportFormatDetails";
                            sda.InsertCommand.Parameters.AddWithValue("p_machineName", machineName);
                            sda.InsertCommand.Parameters.AddWithValue("p_areaName", areaName);
                            sda.InsertCommand.Parameters.AddWithValue("p_observationType", observationType);
                            sda.InsertCommand.Parameters.AddWithValue("p_recommendationType", recommendationType);
                            sda.InsertCommand.Parameters.AddWithValue("p_riskCategory", riskCategory);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;            
        }
        public int UpdateLineStatus(string LineName, int OEE_EE_ID, string Status, string remarks)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "SP_UpdateLineStatus";
                            sda.UpdateCommand.Parameters.AddWithValue("p_LineName", LineName);
                            sda.UpdateCommand.Parameters.AddWithValue("p_OEE_EE_ID", OEE_EE_ID);
                            sda.UpdateCommand.Parameters.AddWithValue("p_Status", Status);
                            sda.UpdateCommand.Parameters.AddWithValue("p_remarks", remarks);
                            count = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public DataTable GetInventorTaggedData(int autoInventId)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetInventaggedData";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_autoInventId", autoInventId));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }        
        public int AddLogServiceMaster(string ServiceName, string ServiceType, string ValidFrom, string ValidTo, string Category, string EmployeeCode, string UplFile, string Frequency, string machineTag, string machineName, string AssignedBy, string AssignedDate)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddLogServiceMaster";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ServiceName", ServiceName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ServiceType", ServiceType));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ValidFrom", ValidFrom));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ValidTo", ValidTo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Category", Category));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_EmployeeCode", EmployeeCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UplFile", UplFile));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Frequency", Frequency));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_machineTag", machineTag));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_machineName", machineName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_AssignedBy", AssignedBy));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_AssignedDate", AssignedDate));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        /// <summary>
        ///  Updating comments on PTWBasicInfo table 
        /// </summary>
        /// <param name="permitCode"></param>
        /// <param name="Comments"></param>
        /// <returns></returns>
        public int UpdatePTWBasicDetails(string permitCode, string Comments)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "SP_UpdatePTWBasicDetails";
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_permitCode", permitCode));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_comments", Comments));
                            count = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public DataTable SP_GetPendingTasks(string AssignedTo, string TodayDate)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetPendingTasks";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_AssignedTo", AssignedTo));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_TodayDate", TodayDate));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetMachineNameTagging()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMachineNameTagging";
                            //sda.SelectCommand.Parameters.Add(new MySqlParameter("p_machineName", machineName));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetLogServiceMasterData(int mode, string machineTag, int ServiceId)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetLogServiceMasterData";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_machineTag", machineTag));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_ServiceId", ServiceId));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public int AddInventoryTaggedMachine(int AutoId, string machineTagno)
        {
            int newID = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddInventoryTaggedMachine";
                            sda.InsertCommand.Parameters.AddWithValue("p_autoInventId", AutoId);
                            sda.InsertCommand.Parameters.AddWithValue("p_machineTagNo", machineTagno);
                            newID = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return newID;
        }
        public DataTable GetEmployeeMasterData()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEmployeeFilterData";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public int UpdateInventoryQty(string machine_tag_no, double stockInHand)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "SP_UpdateInventoryQty";
                            sda.UpdateCommand.Parameters.AddWithValue("p_machine_tag_no", machine_tag_no);
                            sda.UpdateCommand.Parameters.AddWithValue("p_stockInHand", stockInHand);
                            count = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int UpdateInventory(DataTable dt)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "UpdateInventory";
                            sda.UpdateCommand.Parameters.AddWithValue("p_datatable", dt);
                            count = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int AddNewColumn(string colName)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddNewColumns";
                            sda.InsertCommand.Parameters.AddWithValue("p_columnName", colName);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int AddReportDetails(string MySqlCommandInsert)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.Text;
                            sda.InsertCommand.CommandText = MySqlCommandInsert;                           
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int UpdateApplicableParameter(DataTable dt)
        {

            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "UpdateApplicableParameter";
                            sda.UpdateCommand.Parameters.AddWithValue("p_datatable", dt);                          
                            count = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int AddEmployeeDetails(DataTable dt)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_addEmployeeDetails";
                            sda.InsertCommand.Parameters.AddWithValue("p_datatable", dt);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public DataSet GetMachineLayer()
        {
            DataSet dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "GetMachineLayer";                           
                            dt = new DataSet();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }        
        public DataTable GetDepartmentDetailsDataTable(int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEmployeeDetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
            return dt;
        }
        public DataTable GetAllPTWData(string permitCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetPTWAllData";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_permitCode", permitCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
            return dt;
        }

        public DataTable GetEmploymentDetailsDataTable(int mode)
        { 
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEmployeeDetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }          
            //dataGridView1.DataSource = dt;
            return dt;
        }
        public DataTable GetGeoLocationDetailsDataTable(int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEmployeeDetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable getOEEProductionLine()
        {

            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetOEEProdcutionLine";                         
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;           
        }
        public List<Department_Master> GetDepartmentDetails(int mode)
        {
            List<Department_Master> deptMaster = new List<Department_Master>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEmployeeDetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                var deptData = new Department_Master
                                {
                                    DeptId = rdr.GetInt32(0),
                                    Dept_Name = rdr.GetString(1)
                                };
                                deptMaster.Add(deptData);
                            }
                            rdr.Close();
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }          
            return deptMaster;
        }
        public List<Employment_Type> GetEmploymentDetails(int mode)
        {
            List<Employment_Type> employType = new List<Employment_Type>();            
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEmployeeDetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                var EmployData = new Employment_Type
                                {
                                    emplmentTypeId = rdr.GetInt32(0),
                                    employ_Type = rdr.GetString(1)
                                };
                                employType.Add(EmployData);
                                // return layrtype;
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }          
            return employType;
        }
        public DataTable GetEmployeeCode()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEmployeeCode";                           
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetDepartmentList(int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEmployeeDetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return dt;
        }
        public DataTable GetOEELineProductionDetails(int LineId)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetOEELineProductionDetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_LineId", LineId));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetReportFormatOtherDetails(string reportName)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "sp_GetReportFormatOtherDetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_reportName", reportName));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return dt;
        }
        public DataTable GetRFQDetails(string RFQ_code, int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetRFQDetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_RFQ_code", RFQ_code));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;            
        }
        public DataTable GetRFQOrderDetails(string RFQ_Code, string rfqStDate, string rfqEndate, int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetRFQOrderDetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_RFQ_Code", RFQ_Code));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_rfqStDate", rfqStDate));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_rfqEndate", rfqEndate));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;            
        }
        public DataTable GetVendors(string RFQCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetVendors";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_RFQCode", RFQCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetFinalisedVendorList()
        {

            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetFinalisedVendorList";                           
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }          
            return dt;
        }
        public DataTable GetUserKPIData()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetUserKPIData";                           
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public DataTable GetRFQCode()
        {

            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetRFQCode";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;

        }
        public DataTable GetTaskDetailsTaskWise(string taskCode)
        { 
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetSafetyDetailsTaskWise";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_taskCode", taskCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;           
        }
        public DataTable GetUserOpenTask(string status, string empCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetUserOpenTask";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_status", status));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_empCode", empCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;          
        }
        public DataTable GetSearchData(string tasktype)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_SearchSafetyTaskDetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_paranmName", tasktype));                           
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;                        
        }

        public DataTable GetTaskStatusWise(string loginid, string status)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetTaskStatusWise";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_loginid", loginid));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_status", status));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;            
        }

        public DataTable GetEventReport()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEventReport";                            
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetCAPATaskStatus()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetCAPATaskStatus";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;           
        }
        public DataTable GetEventReportCapaStatus()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEventReportCapaStatus";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;          

        }

        public DataTable GetReportedEventsUserWise(string loginid)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetReportedEventsForUser";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_userid", loginid));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;           
        }

        public DataTable GetEventReportingDetails(int eventReportingId, int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEventReportingDetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_eventReportingId", eventReportingId));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return dt;
        }

        public DataTable GetReportFormatColumns(string reportName, int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetReportFormatColumns";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_reportName", reportName));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;           
        }
        public DataTable GetMachineTagNo_Name(string machineName, string machineType, string location, string status)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMachineLocationWiseData";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_machineName", machineName));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_machineType", machineType));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_location", location));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_status", status));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;            
        }

        public DataTable GetStandardBuyOutOption()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetStandardBuyOption";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
            return dt;
        }

        public DataTable GetReportWithParameter(string reportName, string serviceType, string category)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetReportWithParameters";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_reportName", reportName));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_serviceType", serviceType));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_category", category));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return dt;
        }

        public DataTable GetMachineUploadedDocs(string MachineTagNo, string filename, string fileExtension, string Area, string remarks, DateTime uploadedDate, int mode)
        {

            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_AddMachineUploadedDocs";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_MachineTagNo", MachineTagNo));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_filename", filename));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_fileExtension", fileExtension));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_Area", Area));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_remarks", remarks));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_uploadedDate", uploadedDate));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;            
        }
        public List<GeoTeam_Master> GetGeoLocationDetails(int mode)
        {
            List<GeoTeam_Master> geoLocation = new List<GeoTeam_Master>();
            int newID = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEmployeeDetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                var LocationData = new GeoTeam_Master
                                {
                                    GeoTeamId = rdr.GetInt32(0),
                                    GeoTeam_Name = rdr.GetString(1)
                                };
                                geoLocation.Add(LocationData);
                                // return layrtype;
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return geoLocation;
        }

        public List<Safety> GetSafetModelData(string AssignedTo)
        {
            List<Safety> safetyList = new List<Safety>();
            int newID = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetTaskModelData";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_AssignedTo", AssignedTo));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                var safetyData = new Safety
                                {
                                    taskCode = rdr.GetString(0),
                                    taskType = rdr.GetString(1),
                                    taskdeadline = rdr.GetString(2),
                                    AssignedTo = rdr.GetString(3),
                                    AssignedBy = rdr.GetString(4),
                                    actionName = rdr.GetString(5),
                                    targetDateOfClosure = rdr.GetString(6)
                                };
                                safetyList.Add(safetyData);
                                // return layrtype;
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
            return safetyList;
        }
        public DataTable GetEmployeeName(string empname)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEmployeeName";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_empname", empname));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetComplianceAgainstName(int complianceId)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetComplianceAgainstName";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_complianceId", complianceId));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return dt;
        }
        public DataTable GetEmployeeName()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEmployeeNameNoParam";                            
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return dt;
        }
        public DataTable GetUploadedDocsMachineWise(string MachineTagNo, string FilePath1, string FilePath2, string FilePath3, string equipment_name, int mode)
        {

            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_AddMachineUploadedDocs";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_MachineTagNo", MachineTagNo));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_FilePath1", FilePath1));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_FilePath2", FilePath2));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_FilePath3", FilePath3));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_equipment_name", equipment_name));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
            return dt;
        }
        public DataTable GetOEEProductionLine()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetOEEProductionLineData";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;            
        }

        public DataTable GetMachineInterlockTagNo(int mode, string MachineTagNo)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMachineInterlockData";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_MachineTagNo", MachineTagNo));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;           
        }
        public DataTable getTabParameterData(string header_name, int param_id)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "getTabParameterData";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_header_name", header_name));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_param_id", param_id));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
            return dt;
        }
        public DataTable GetAuditReportonMachineTag(string machineTag, string auditType)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetAuditReportonMachineTag";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_machineTag", machineTag));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_auditType", auditType));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
            return dt;
        }
        public DataTable getIncidentReport(DateTime dateFrom, DateTime dateTo)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetIncidentReport";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_dateFrom", dateFrom));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_dateTo", dateTo));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;            
        }
        public DataTable getFileU1Data(string FileName, string AreaName, string Category)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetFileU1Data";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_FileName", FileName));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_AreaName", AreaName));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_Category", Category));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return dt;
        }
        public DataTable GetApplicableParameters(string header_name, int param_id)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_getApplicableParameters";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_header_name", header_name));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_param_id", param_id));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;          
        }
        public DataTable GetSafetyTask(int mode, string taskcode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetSafetyTask";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_taskcode", taskcode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public int UpdateTaggedStatus(string taskStatus, string taskCode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "SP_updateTaskTaggedStatus";
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_taskStatus", taskStatus));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_taskCode", taskCode));
                            count = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;           
        }
        public int UpdateMachineStatus(string MachineTagNo, string Status, int mode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "SP_UpdateMachineStatus";
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_MachineTagNo", MachineTagNo));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_Status", Status));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            count = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }               
        public int UpdateEmployeeDetails(string userInput, int id, int mode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "SP_UpdateEmployeeDetails";
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_userInput", userInput));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_id", id));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            count = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;           
        }
        public int UpdateDepartHead(int deptId, int empId, int mode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "SP_UpdateDepartHead";
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_deptId", deptId));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_empId", empId));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            count = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int UpdateTaskClosedstatus(string empcode, string taskcode, string status, string tentdateofstart)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "SP_UpdateDepartHead";
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_empcode", empcode));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_taskcode", taskcode));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_status", status));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_tentdateofstart", tentdateofstart));
                            count = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public DataTable GetTaskList(string empCode, string taskStatus, string taskCategory)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetTaskEventList";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_empCode", empCode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_taskStatus", taskStatus));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_taskCategory", taskCategory));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetOpenTaskList(string empCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMyOpenTasks";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_empCode", empCode));                          
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;           
        }
        public DataTable GetIsolatedMachines(string permitCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetIsolatedMachine";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_permitCode", permitCode));                           
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetAllIsolatedMachines(string permitCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetAllIsolatedMachine";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_permitCode", permitCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetVendorList(int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetVendorList";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;           
        }
        public DataTable getInventoryData()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "sp_GetInventoryData";                           
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;           
        }
        public DataTable GetCompliedAgainstDept()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetCompliedAgainstDept";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetTaskMaster()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetTaskMaster";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;           
        }
        public DataTable GetTaskMaster(string empCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetTaskMaster";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_empCode", empCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetNonCompliedAgainstDept()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetNonCompliedAgainstDept";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetFunctionalMachineList()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetFunctionalMachineList";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetTabInsertedParam(int ParameterId)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetTabInsertedParam";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_ParameterId", ParameterId));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetEventCAPADetails(string empCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEventCAPADetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_empCode", empCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable getProductionDetails(string startDate, string endDate, string type, string productionLine, string shift)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetProductionData";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_startdDate", startDate));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_endDate", endDate));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_Type", type));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_productionLine", productionLine));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_shift", shift));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;           
        }
        public DataTable getHealthEnvironmentData(string MachineTagNo, int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "sp_getHealthEnvironmentData";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_machinetagno", MachineTagNo));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;           
        }
        public DataTable GetStandardUsedMasterData(int standard_id, int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "GetStandardUsedMasterData";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_standard_id", standard_id));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;       
        }
        public DataTable GetMachineDetailsOrTag()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "Sp_GetMachineMaster";                           
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetMachineParameterName()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMachineParameterName";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public List<string> getEmployementHistory(int mode)
        {
            List<string> employlist = new List<string>();
            int newID = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_getEmployementHistory";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                employlist.Add(rdr[""].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return employlist;
        }
        public List<string> GetVendorQuotedRFQ(string rfqCode, int mode)
        {
            List<string> rfqList = new List<string>();
            int newID = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetVendorQuotedRFQ";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_rfqCode", rfqCode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                rfqList.Add(rdr["RFQ_Code"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }          
            return rfqList;
        }
        public List<string> GetMachineName()
        {
            List<string> MachineName = new List<string>();           
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMachineName";                          
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                MachineName.Add(rdr["MachineName"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
            return MachineName;
        }
        public List<string> GetMachineTag()
        {
            List<string> machineList = new List<string>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMachineDetailsORTag";
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                machineList.Add(rdr["machinetagno"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return machineList;
        }
        public List<string> GetMachineConcatData()
        {
            List<string> machineList = new List<string>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMachineConcatData";
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                machineList.Add(rdr["machinetagno"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
            return machineList;
        }

        public List<string> GetAllMachineName()
        {
            List<string> machineList = new List<string>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMachineName";
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                machineList.Add(rdr["MachineName"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return machineList;
        }
        public List<string> GetUserDeptWise(int deptId)
        {
            List<string> empList = new List<string>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetUserDeptWise";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_deptId", deptId));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                empList.Add(rdr["emp_name"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return empList;
        }
        public List<string> GetInventoryDataByName(string itemName)
        {
            List<string> inventList = new List<string>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetInventoryDetailsByName";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_itemName", itemName));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            rdr.Read();
                            inventList.Add(rdr["stock_in_hand"].ToString());
                            inventList.Add(rdr["minimum_stock_trigger_lvl"].ToString());
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return inventList;           
        }
        public string GetUserNameByID(string userId, int areaId)
        {
            string uname = string.Empty;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetUserNameByID";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_userId", userId));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_areaId", areaId));
                           MySqlDataReader rdr = cmd.ExecuteReader();
                            rdr.Read();                            
                            if (rdr.HasRows == true)
                            {
                                uname = rdr["emp_name"].ToString();
                            }
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return uname;
        }

        public int GetOEELineID(string productionLine)
        {
            int newID = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetOEELineID";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_productionLine", productionLine));                           
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                newID = Convert.ToInt32(rdr["LineId"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return newID;           
        }
        public int GetMachineAreCount(string machineName)
        {
            int newID = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMachineAreaCount";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_machinename", machineName));                            
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                newID = Convert.ToInt32(rdr["CountId"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return newID;
        }

        public int CheckVendorFinalResponse(string vendorCode, string rfqCode)
        {
            int newID = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_CheckVendorFinalResponse";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_vendorCode", vendorCode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_rfqCode", rfqCode));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                newID = Convert.ToInt32(rdr["CountId"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return newID;
        }

        public List<string> GetemployeeNameByID(string userId)
        {
            List<string> uname = new List<string>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEmployeeByID";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_userId", userId));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            if (rdr.HasRows == true)
                            {
                                while (rdr.Read())
                                {
                                    uname.Add(rdr["emp_name"].ToString());
                                    uname.Add(rdr["emp_code"].ToString());
                                }
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
            return uname;
        }

        public DataTable getInvetoryByMachineTagNo(string mach_tag_no)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "getInvetoryByMachineTagNo";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_machine_tag_no", mach_tag_no));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;           
        }
        public DataTable GetVendorQuotedRFQDT(string rfqCode, int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetVendorQuotedRFQ";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_rfqCode", rfqCode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;            
        }
        public List<GetMachineHeader> GetMchineHeader()
        {
            List<GetMachineHeader> headerlist = new List<GetMachineHeader>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "GetMachineHeader";
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                var machinehead = new GetMachineHeader
                                {
                                    header_id = rdr.GetInt32(0),
                                    header_name = rdr.GetString(1)

                                };
                                headerlist.Add(machinehead);
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }          
            return headerlist;
        }
        public List<OEEProductionLine> GetOEEProductionLineData()
        {
            List<OEEProductionLine> OEEProductionLine = new List<OEEProductionLine>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetOEEProductionLineData";
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                var oeeproduct = new OEEProductionLine
                                {
                                    LineId = rdr.GetInt32(0),
                                    productionLine = rdr.GetString(1),
                                    shift = rdr.GetString(2),
                                    category = rdr.GetString(3),
                                    productionCapacity = rdr.GetDecimal(4),
                                    unitTime = rdr.GetDecimal(5)
                                };
                                OEEProductionLine.Add(oeeproduct);
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }         
            return OEEProductionLine;
        }
        public List<GetParameter> GetParameterColumns()
        {
            List<GetParameter> paramlist = new List<GetParameter>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMachineDetailsORTag";
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                var columndet = new GetParameter
                                {
                                    header_id = rdr.GetInt32(1),
                                    parameter_id = rdr.GetInt32(0)
                                };
                                paramlist.Add(columndet);
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return paramlist;           
        }
        public int GetMaxParameterId(string machineName)
        {
            int newID = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "GetMaxParameterId";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_machineName", machineName));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                newID = Convert.ToInt32(rdr["mcnt"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return newID;          
        }
        public List<string> GetUserCreatedAction(string UserId)
        {
            List<string> machineList = new List<string>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetUserCreatedAction";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_UserId", UserId));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                machineList.Add(rdr["empcode"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return machineList;
        }

        public List<string> GetPTWPermitCode()
        {
            List<string> machineList = new List<string>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetPTWPermitCode";
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                machineList.Add(rdr["permitCode"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return machineList;           
        }


        public DataSet GetOperationName()
        {
            DataSet dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "GetOperationName";
                            dt = new DataSet();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public int AddUserNew(string UserId, string UserName, string UPwd, DateTime DOB, string contact, int alternateContact, string email, string address, string userTypeId, string sex, string AppId, int isActive, string empCode, int mode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "AddNewUser";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UserId", UserId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UserName", UserName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UPwd", UPwd));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DOB", DOB));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_contact", contact));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_alternateContact", alternateContact));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_email", email));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_address", address));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_userTypeId", userTypeId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_sex", sex));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_AppId", AppId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_isActive", isActive));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_empCode", empCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public int AddIncidentReport(string employeeName, string employeeCode, int locationId, string locationName, string eventDescription, string correctiveAction, string imageUploaded, DateTime eventDate)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddIncidentReport";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_employeeName", employeeName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_employeeCode", employeeCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_locationId", locationId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_locationName", locationName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_eventDescription", eventDescription));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_correctiveAction", correctiveAction));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_imageUploaded", imageUploaded));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_eventDate", eventDate));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public int AddBreakDownData(decimal MealBreak, decimal EducationBreak, decimal PreventiveMaintenance, decimal BreakDown, decimal ToolChange, decimal SetUpTime,
            decimal Cleaning, decimal WaitingForApproval, decimal LackOfResource, decimal Adjustments, int OEE_EE_ID)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddBreakDownData";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_MealBreak", MealBreak));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_EducationBreak", EducationBreak));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_PreventiveMaintenance", PreventiveMaintenance));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_BreakDown", BreakDown));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ToolChange", ToolChange));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_SetUpTime", SetUpTime));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Cleaning", Cleaning));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_WaitingForApproval", WaitingForApproval));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_LackOfResource", LackOfResource));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Adjustments", Adjustments));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_OEE_EE_ID", OEE_EE_ID));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }


        public int AddVendorQuotationDetails(int QuoteId, string RFQ_Code, string vendorCode, string TeamCapability, string Schedule, string Payment_Terms,
          string ScopeofWork, string Deviation, string Upload_DeviationPath, string ResponseDocument, string Commercials, string remarks, DateTime postedDate)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddVendorQuotationDetails";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_QuoteId", QuoteId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RFQ_Code", RFQ_Code));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_vendorCode", vendorCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_TeamCapability", TeamCapability));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Schedule", Schedule));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Payment_Terms", Payment_Terms));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ScopeofWork", ScopeofWork));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Deviation", Deviation));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Upload_DeviationPath", Upload_DeviationPath));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ResponseDocument", ResponseDocument));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Commercials", Commercials));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_remarks", remarks));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_postedDate", postedDate));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;

        }
        public int AddMachinelayer(int layer_id, string sub_Layer_type, int mode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "AddMachineLayer";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_layer_id", layer_id));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_sub_Layer_type", sub_Layer_type));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public int UpdateEventReporting(string description, string area, string machineName, string uplPhoto, string occurenceDate, string actionableCategory, string eventBreif, string eventResposibility, string ehsResponsibility, string vendorName, string riskCategory, int eventReportingId)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "SP_UpdateEventReporting";
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_description", description));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_area", area));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_machineName", machineName));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_uplPhoto", uplPhoto));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_occurenceDate", occurenceDate));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_actionableCategory", actionableCategory));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_eventBreif", eventBreif));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_eventResposibility", eventResposibility));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_ehsResponsibility", ehsResponsibility));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_vendorName", vendorName));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_riskCategory", riskCategory));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_eventReportingId", eventReportingId));
                            count = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int UpdateComplianceDetails(int complianceId, int complianceDetId, int statutory, int NonStatutory, int corporateFirm, string RegulationBreif, string Standard, string ReleaseDate,
          string currentStatus, string DocName, string corporateLatestDate, string lastpermitDate, string nextpermitUpdate, string frequency, int ownerDept, int owner1, int owner2,
          string ScannedCopy, string oldPermit, string notices)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "SP_UpdateComplianceDetails";
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_complianceId", complianceId));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_complianceDetId", complianceDetId));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_statutory", statutory));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_NonStatutory", NonStatutory));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_corporateFirm", corporateFirm));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_RegulationBreif", RegulationBreif));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_Standard", Standard));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_ReleaseDate", ReleaseDate));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_currentStatus", currentStatus));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_DocName", DocName));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_corporateLatestDate", corporateLatestDate));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_lastpermitDate", lastpermitDate));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_nextpermitUpdate", nextpermitUpdate));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_frequency", frequency));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_ownerDept", ownerDept));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_owner1", owner1));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_owner2", owner2));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_ScannedCopy", ScannedCopy));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_oldPermit", oldPermit));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_notices", notices));
                            count = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;          
        }
        
        public int AssignUserPermission(string AppId, int WMasterId, string UTypeId, int OperationDetId, int permissionid, int mode)
        {
            int newID = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "AssignUserPermission";
                           sda.SelectCommand.Parameters.Add(new MySqlParameter("p_AppId", AppId));
                           sda.SelectCommand.Parameters.Add(new MySqlParameter("p_WMasterId", WMasterId));
                           sda.SelectCommand.Parameters.Add(new MySqlParameter("p_UTypeId", UTypeId));
                           sda.SelectCommand.Parameters.Add(new MySqlParameter("p_OperationDetId", OperationDetId));
                           sda.SelectCommand.Parameters.Add(new MySqlParameter("p_permissionid", permissionid));
                           sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                           sda.SelectCommand.Parameters.Add("p_ERROR", MySqlDbType.VarChar, 500);
                            sda.SelectCommand.Parameters["p_ERROR"].Direction = ParameterDirection.Output;
                            newID = sda.SelectCommand.ExecuteNonQuery();
                            string message = (string)cmd.Parameters["p_ERROR"].Value;                            
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return newID;
        }

        public DataSet GetUserPermission(string AppId, string UTypeId)
        {
            DataSet dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "GetPermissionUserType";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_AppId", AppId));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_UTypeId", UTypeId));
                            dt = new DataSet();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }      
        public int AddReportFormatMaster(string sql)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.Text;
                            sda.InsertCommand.CommandText = sql;                            
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }                                 
        public DataTable GetComplianceData()
        {


            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetComplianceData";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
            return dt;
        }

        public DataTable GetVendorFinalResponseRFQWise(string rfqCode)
        {


            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetVendorFinalDataRFQWise";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_rfqCode", rfqCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public DataTable GetEventCAPADetail(string empCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEventCAPADetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_empCode", empCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetInHousePTWonPermitCode(string permitCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetInHousePTWonPermitCode";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_permitCode", permitCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetPermitTypemaster(string permitName, string description, int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_AddPermitTypemaster";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_permitName", permitName));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_description", description));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public DataTable GetPermitDetails(string permitCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetPermitDetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_permitCode", permitCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return dt;
        }

        public DataTable GetPTWCapabilityData(string permitCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetPTWCapabilityData";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_permitCode", permitCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable FetchRemoteConnection(string SourceMachine, string SourceCordinates)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_FetchRemoteConnection";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_SourceMachine", SourceMachine));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_SourceCordinates", SourceCordinates));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;

        }
        public DataTable GetStakeHolderData()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetPTWCapabilityData";                           
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;           
        }
        public DataTable GetUserNotification(DateTime AssignedDate, string empCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetUserNotification";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_AssignedDate", AssignedDate));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_empCode", empCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetEmployeeData(string empCode)
        {


            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEmployeeData";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_empCode", empCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;           
        }
        public DataTable getInevntoryTempData()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetTempInventory";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetLineOEEData()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetLineOEEData";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetPermitStatuco(int emp_id, int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetPermitStatus";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_emp_id", emp_id));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
      
     public DataTable GetPermitDataPeriodic(int emp_id, int mode, DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = null; 
            try { using (MySqlConnection cnn = new MySqlConnection(GetConnection)) 
                { cnn.Open(); using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn)) 
                    { using (MySqlCommand cmd = new MySqlCommand()) 
                        { sda.SelectCommand = cmd; sda.SelectCommand.Connection = cnn; 
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetPermitStatusPeriodic"; 
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_emp_id", emp_id));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_FromDate", FromDate));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_ToDate", ToDate));
                            dt = new DataTable();
                            sda.Fill(dt); cmd.Dispose();
                        } sda.Dispose(); 
                    } cnn.Dispose(); } 
            } 
            catch (Exception Ex)
            { 
                throw new Exception(Ex.Message);
            
            } 
            return dt; 
        }


        public DataTable GetDepartmentHeadAll()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetDepartmentHeadAll";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public DataTable GetDepartmentHead(int dept_Id)
        {


            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetDepartmentHead";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_dept_Id", dept_Id));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetOpenTask_ReportingManager(string empCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetOpenTask_ReportingManager";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_empCode", empCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public DataTable GetPermitStatus()
        {


            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetPermitStatusNoEmp";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable getNearMissData(string EventType, string EventDate, string EventReportTime, int mode, string month, string year)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetNearMissDataParameterWise";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_EventType", EventType));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_EventDate", EventDate));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_EventReportTime", EventReportTime));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_month", month));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_year", year));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }          
            return dt;
        }
        public DataTable GetOEEDetailsonId(int OEEID)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetOEEDetailsonId";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_OEEID", OEEID));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return dt;
        }
        public List<string> GetVendorRFQFinalised(string vendorName)
        {
            List<string> machineList = new List<string>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetRFQFinalisedVendorWise";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_vendorName", vendorName));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                machineList.Add(rdr["MachineName"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return machineList;                       
        }

        public string GetAreaApproverEmailId(int areaapproverId)
        {
            string emailid = "";
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetAreaApproverEmailId";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_AreaApproverId", areaapproverId));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            if (rdr.HasRows == true)
                            {
                                emailid = rdr["emailId"].ToString();
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
            return emailid;
        }
        public string GetMachineTagfromCoOrdinate(string machineName, string cadLocation)
        {
            string roomname = "";
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMachinetagfromCoordinate";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_machineName", machineName));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_cadLocation", cadLocation));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            if (rdr.HasRows == true)
                            {
                                roomname = rdr["emailId"].ToString();
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return roomname;
        }
        public string GetMachineRoolLocation(string machineName, string cadLocation)
        {
            string roomname = "";
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMachineRoolLocation";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_machineName", machineName));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_cadLocation", cadLocation));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            if (rdr.HasRows == true)
                            {
                                roomname = rdr["emailId"].ToString();
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return roomname;
        }
        public string GetMaxPTWCodeInsertionCheck(string ProcName, string outprams, ref int MaxValue)
        {
            string emailid = "";
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMaxPermitCode";                        
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            if (rdr.HasRows == true)
                            {
                                rdr.Read();
                                emailid = rdr["maxPermit"].ToString();
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
            return emailid;

        }
        public string GetEmployeeUserID(string empName)
        {
            string emailid = "";
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEmployeeUserID";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_empName", empName));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            if (rdr.HasRows == true)
                            {
                                rdr.Read();
                                emailid = rdr["emp_id"].ToString();
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }           
            return emailid;
        }
        public DataTable getInventoryAllData()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetInventoryAllData";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public int CountMachineType(string machineName, string machiinetneType, string machinesubType)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_CountMachinesWithType";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_machineName", machineName));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_machineType", machiinetneType));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_machinesubType", machinesubType));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                count = Convert.ToInt32(rdr["RetCount"]);
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int addInventory(DataTable dt)
        {
            int newID = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "addInventory";
                            sda.InsertCommand.Parameters.AddWithValue("p_datatable", dt);
                            newID = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return newID;
        }
        public string GetSecurityInchargeEmailId()
        {
            string emailid = "";
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetSecurityEnchargeEmail";
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            if (rdr.HasRows == true)
                            {
                                emailid = rdr["emailId"].ToString();
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return emailid;
        }
        public List<string> GetEmployeeTeam(string empName)
        {
            List<string> emplName = new List<string>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEmployeeTeam";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_empName", empName));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            while (rdr.Read())
                            {
                                emplName.Add(rdr["EmpName"].ToString());
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
            return emplName;
        }

        public int AddFinalVendorResponse(System.Data.DataTable dt0)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddVendorFinalResponse";
                            sda.InsertCommand.Parameters.AddWithValue("p_datatable", dt0);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;           
        }
        public DataTable GetParameterRFQData(string parameterId, string headerName)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetParameterRFQData";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_parameterId", parameterId));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_headerName", headerName));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
            return dt;
        }
        public DataTable GetPTWLocationonPermitCode(string permitCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetPTWLocationonPermitCode";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_permitCode", permitCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetTodaysTask(string todaysDate, string AssignedTo)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetTodaysTask";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_todaysDate", todaysDate));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_AssignedTo", AssignedTo));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetTodaysTask(string todaysDate, string nextDate, string AssignedTo)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetTodaysTask";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_todaysDate", todaysDate));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_nextDate", nextDate));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_AssignedTo", AssignedTo));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetMachineAreaMaster()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "Sp_FetchAreamMaster";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;           
        }
        public DataTable GetMahineTagFromPTW()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "Sp_GetMahineTagFromPTW";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;           
        }
        public DataTable GetMachineConnection(string MLocation)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMachineConnection";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_MLocation", MLocation));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;           
        }
        public DataTable GetUpcomingTasks(string todaysDate, string AssignedTo)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetUpcomingTasks";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_todaysDate", todaysDate));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_AssignedTo", AssignedTo));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;            
        }

        public DataTable GetUpcomingNewTasks(string todaysDate, string AssignedTo)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetupcoimgNewTasks";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_todaysDate", todaysDate));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_AssignedTo", AssignedTo));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }            
            return dt;
        }

        public DataTable SP_GetPendingTasks(string AssignedTo)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetPendingTasks";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_AssignedTo", AssignedTo));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public int AddParameterRFQ(string ParameterId, string ParameterName, string MinimumValue, string MaximumValue, string OperatingValue, string RFQ, string NotAvailable, string NotApplicable, string headerName, int mode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddParameterRFQ";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ParameterName", ParameterName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_MinimumValue", MinimumValue));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_MaximumValue", MaximumValue));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_OperatingValue", OperatingValue));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RFQ", RFQ));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_NotAvailable", NotAvailable));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_NotApplicable", NotApplicable));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_headerName", headerName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int AddInHousePermit(DataTable dt)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddInHousePermit";
                            sda.InsertCommand.Parameters.AddWithValue("p_datatable", dt);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;            
        }

        public int altertablestandard(string tablename,string columnname)
        {
            int checkstatus = 0;
            try
            {
                string sqlsc = "ALTER TABLE " + tablename + " " + "ADD" + "";
                string sql = sqlsc + " " + columnname + " " + " varchar(max) ";
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.Text;
                            sda.SelectCommand.CommandText = sql;
                             checkstatus = sda.SelectCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }         
            return checkstatus;
        }
        public int UpdatePTWIsolationDetails(string permitCode, string equipName, DateTime removalDate, int isolationCompleted)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_UpdatePTWIsolationDetails";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_permitCode", permitCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_equipName", equipName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_removalDate", removalDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_isolationCompleted", isolationCompleted));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }



        #region Milan  RMPCL Method List
        public DataTable GetAllProcurement()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetAllProcurement";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public int AddProcurement(string DocumentNo, DateTime DocDate, string BillNo, DateTime PurchaseDate, string Vendor, string VendorCode,int Status)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddProcurement";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocumentNo", DocumentNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocDate", DocDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_BillNo", BillNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_PurchaseDate", PurchaseDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Vendor", Vendor));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_VendorCode", VendorCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Status", Status));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public int AddUOM(string UOMCode, string UOMName, DateTime CreatedDate)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddUOM";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UOMCode", UOMCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UOMName", UOMName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CreatedDate", CreatedDate));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public DataTable GetUOM()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;

                            sda.SelectCommand.CommandText = "SP_GetUOM";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public int DeleteUOM(string UnitCode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_DeleteUOM";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UnitCode", UnitCode));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int AddItemMaster(string ItemCode, string ItemName, string Unit, string UnitCode, string Category, string CatCode, string Make, string Model, Double Threshold, DateTime CreatedDate)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddItemMaster";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ItemCode", ItemCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ItemName", ItemName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Unit", Unit));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UnitCode", UnitCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Category", Category));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CategoryCode", CatCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Make", Make));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Model", Model));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Threshold", Threshold));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CreatedDate", CreatedDate));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int AddCategoryMaster(string CategoryName, string CategoryCode, string Parent, string ParentCode, DateTime CreatedDate)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddCategoryMaster";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CategoryName", CategoryName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CategoryCode", CategoryCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Parent", Parent));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ParentCode", ParentCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CreatedDate", CreatedDate));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public DataTable GetCategory()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetAllCategory";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetSubCategory(string ParentCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetSubCategory";
                            dt = new DataTable();
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_ParentCode", ParentCode));
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public DataTable GetItemMaster()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetItemMasterExt";// "SP_GetItemMaster";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public DataTable GetVendorMaster()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetVendorMaster";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public int AddItemOpeningDetail(string DocumentNo, DateTime DocumentDate, string Vendor, string BillNo, string Item, string ItemCode, double OpeningQty, string BatchNo, string UnitCode,double UnitCost, double TotalCost)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddItemOpeningDetail";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocumentNo", DocumentNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocumentDate", DocumentDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Vendor", Vendor));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_BillNo", BillNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Item", Item));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ItemCode", ItemCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_OpeningQty", OpeningQty));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_BatchNo", BatchNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UnitCode", UnitCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UnitCost", UnitCost));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_TotalCost", TotalCost));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }


        public int AddConsumption(string DocumentNo, DateTime DocumentDate, string ReferenceNo, string ConsumptionType, string Remarks,int Status)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddConsumption";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocumentNo", DocumentNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocumentDate", DocumentDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ReferenceNo", ReferenceNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ConsumptionType", ConsumptionType));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Remarks", Remarks));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Status", Status));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public DataTable GetAllConsumption()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetAllConsumption";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public int IsConsumptionExit(string DocumentNo, out int iCount)
        {
            int rslt = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.SelectCommand = cmd;
                        sda.SelectCommand.Connection = cnn;
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = "sp_IsConsumptionExists";
                        sda.SelectCommand.Parameters.Add("p_DocumentNo", MySqlDbType.TinyText).Value = DocumentNo;
                        sda.SelectCommand.Parameters.Add("p_iCount", MySqlDbType.Int32);
                        sda.SelectCommand.Parameters["p_iCount"].Direction = ParameterDirection.Output;
                        sda.SelectCommand.ExecuteReader();
                        iCount =Convert.ToInt32(sda.SelectCommand.Parameters["p_iCount"].Value);
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return iCount;
        }

        public DataTable GetTotalStockx()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetTotalStockExt";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetTotalStock()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            // sda.SelectCommand.CommandText = "SP_GetTotalStock";
                            sda.SelectCommand.CommandText = "SP_GetTotalStockwithOpening";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetSingleItemStock(string ItemCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            //sda.SelectCommand.CommandText = "SP_GetSingleItemStock";
                            sda.SelectCommand.CommandText = "SP_GetSingleItemStockWithOpening";
                            dt = new DataTable();
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_ItemCode", ItemCode));
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public int AddReturn(string DocumentNo, DateTime DocumentDate, string ReferenceNo, string ConsumptionType, string Remarks,int Status)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddReturn";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocumentNo", DocumentNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocumentDate", DocumentDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ReferenceNo", ReferenceNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ConsumptionType", ConsumptionType));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Remarks", Remarks));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Status", Status));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public DataTable GetAllReturn()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetAllReturn";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public int AddProcureItemDetail(string DocumentNo, string Item, string ItemCode, string UnitCode, string BatchNo, double ProcureQty, double UnitCost, double TotalCost)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddProcureItemDetail";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocumentNo", DocumentNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Item", Item));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ItemCode", ItemCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UnitCode", UnitCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ProcureQty", ProcureQty));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_BatchNo", BatchNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UnitCost", UnitCost));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_TotalCost", TotalCost));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public DataTable GetProcureItemDetail(string DocumentNo)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetProcureItemDetail";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_DocumentNo", DocumentNo));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetAllProcureItemDetail()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetAllProcureItemDetail";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetProcureBatchDetail(string ItemCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetProcureBatchDetail";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_ItemCode", ItemCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public int AddConsumpItemDetail(string DocumentNo, string ReferenceNo, string Item, string ItemCode, string BatchNo, string Unit, string UnitCode, double ConsumedQty, double UnitCost, double TotalCost)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddConsumpItemDetail";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocumentNo", DocumentNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ReferenceNo", ReferenceNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_BatchNo", BatchNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Item", Item));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ItemCode", ItemCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Unit", Unit));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UnitCode", UnitCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ConsumedQty", ConsumedQty));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UnitCost", UnitCost));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_TotalCost", TotalCost));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public DataTable GetConsumedItemDetail(string DocumentNo, string ReferenceNo)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetConsumedItemDetail";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_DocumentNo", DocumentNo));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_ReferenceNo", ReferenceNo));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetConsumedItemDetailwithRefNo(string ReferenceNo)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetConsumedItemDetailwithRefNo";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_ReferenceNo", ReferenceNo));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetAllConsumedItemDetail()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetAllConsumedItemDetail";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetAllConsumedItemDetailWithReturn(string DocumentNo,string ReferenceNo)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetAllConsumedItemDetailWithReturn";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_DocumentNo", DocumentNo));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_ReferenceNo", ReferenceNo));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public int AddReturnItemDetail(string DocumentNo, string ReferenceNo, string Item, string ItemCode, string BatchNo, string Unit, string UnitCode, double ReturnQty, double UnitCost, double TotalCost)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddReturnItemDetail";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocumentNo", DocumentNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ReferenceNo", ReferenceNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_BatchNo", BatchNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Item", Item));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ItemCode", ItemCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Unit", Unit));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UnitCode", UnitCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ReturnQty", ReturnQty));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UnitCost", UnitCost));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_TotalCost", TotalCost));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public DataTable GetReturnItemDetail(string DocumentNo, string ReferenceNo)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetReturnItemDetail";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_DocumentNo", DocumentNo));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_ReferenceNo", ReferenceNo));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public int IsReturnExit(string DocumentNo, out int iCount)
        {
            int rslt = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.SelectCommand = cmd;
                        sda.SelectCommand.Connection = cnn;
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = "sp_IsReturnExists";
                        sda.SelectCommand.Parameters.Add("p_DocumentNo", MySqlDbType.TinyText).Value = DocumentNo;
                        sda.SelectCommand.Parameters.Add("p_iCount", MySqlDbType.Int32);
                        sda.SelectCommand.Parameters["p_iCount"].Direction = ParameterDirection.Output;
                        sda.SelectCommand.ExecuteReader();
                        iCount = Convert.ToInt32(sda.SelectCommand.Parameters["p_iCount"].Value);
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return iCount;
        }

        public DataTable GetThresholdProcureDetail()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetThresholdProcureDetail";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetPivotThresholdProcureDetail()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetPivotThresholdProcureDetail";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public int AddVendor(string VendorName, string VendorCode, string Contact,string ContactPerson,string EmailId, DateTime CreatedDate, string Address)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddVendor";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_VendorName", VendorName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_VendorCode", VendorCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Contact", Contact));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ContactPerson", ContactPerson));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_EmailId", EmailId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CreatedDate", CreatedDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Address", Address));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public int AddAdditionalHazard(string PermitCode,string Hazard, string Remarks, DateTime CreatedDate)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddAdditionalHazard";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_PermitCode", PermitCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Hazard", Hazard));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Remarks", Remarks));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CreatedDate", CreatedDate));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int DeleteAdditionalHazard(int AddHazId)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_DeleteAdditionalHazard";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_AddHazId", AddHazId));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public DataTable GetAdditionalHazDetail(string permitCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetAdditionalHazDetail";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_PermitCode", permitCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public int AddPPERequired(DataTable dt)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddPPERequired";
                            sda.InsertCommand.Parameters.AddWithValue("p_data", dt);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public DataTable GetPPERequired(string PermitCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetPPERequired";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_PermitCode", PermitCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public int DeleteProcurement(string DocumentNo)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_DeleteProcurement";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocumentNo", DocumentNo));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int DeleteProcureDetail(string DocumentNo,string ItemCode,string BatchNo)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_DeleteProcureDetail";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocumentNo", DocumentNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ItemCode", ItemCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_BatchNo", BatchNo));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

    
        public int DropDailyGridTempTbl_RMPCL(string ProdCode, string PlantName)
            {
                int count = 0;
                try
                {
                    using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                    {
                        cnn.Open();
                        using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                        {
                            using (MySqlCommand cmd = new MySqlCommand())
                            {
                                sda.InsertCommand = cmd;
                                sda.InsertCommand.Connection = cnn;
                                sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                                sda.InsertCommand.CommandText = "SP_DropDailyTempTbl";
                                sda.InsertCommand.Parameters.AddWithValue("p_ProdCode", ProdCode);
                                sda.InsertCommand.Parameters.AddWithValue("p_PlantName", PlantName);
                                count = sda.InsertCommand.ExecuteNonQuery();
                                cmd.Dispose();
                            }
                            sda.Dispose();
                        }
                        cnn.Dispose();
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(Ex.Message);
                }
                return count;
            }


        public int DeleteConsumption(string DocumentNo)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_DeleteConsumption";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocumentNo", DocumentNo));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int DeleteConsumpDetail(string DocumentNo, string ItemCode, string BatchNo)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_DeleteConsumpDetail";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocumentNo", DocumentNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ItemCode", ItemCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_BatchNo", BatchNo));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int DeleteReturn(string DocumentNo)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_DeleteReturn";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocumentNo", DocumentNo));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int DeleteReturnDetail(string DocumentNo, string ItemCode, string BatchNo)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_DeleteReturnDetail";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocumentNo", DocumentNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ItemCode", ItemCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_BatchNo", BatchNo));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public int DeleteItemMaster(string ItemCode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_DeleteItemMaster";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ItemCode", ItemCode));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public DataTable CheckItemOnTran(string ItemCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_CheckItemOnTran";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_ItemCode", ItemCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public int AddUAUC(DataTable dt)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddUAUC";
                            sda.InsertCommand.Parameters.AddWithValue("p_data", dt);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public int UpdateUAUC(string ObservationNo, string SafetyUser,string SafetyUserCode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "SP_UpdateUAUC";
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_ObservationNo", ObservationNo));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_SafetyUser", SafetyUser));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_SafetyUserCode", SafetyUserCode));
                            count = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }
        public int UpdateCloseMaintBreakDown(string BreakDownCode, string ClosedBy, string ClosedByCode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                            sda.UpdateCommand.CommandText = "SP_UpdateCloseMaintBreakDown";
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_BreakDownCode", BreakDownCode));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_ClosedBy", ClosedBy));
                            sda.UpdateCommand.Parameters.Add(new MySqlParameter("p_ClosedByCode", ClosedByCode));
                            count = sda.UpdateCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public DataTable GetUAUC()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetAllUAUC";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public DataTable GetCreatedUAUC(string userCode )
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_userCode", userCode));
                            sda.SelectCommand.CommandText = "SP_GetCreatedUAUC";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public DataTable GetAssignedUAUC(string assignedToCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetAssignedUAUC";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_AssignedToCode", assignedToCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public int AddOperationUnit(string OperationUnitCode, string OperationUnitName, DateTime CreatedDate)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddOperationUnit";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_OperationUnitCode", OperationUnitCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_OperationUnitName", OperationUnitName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CreatedDate", CreatedDate));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public DataTable GetOperationUnit()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetOperationUnit";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetArea()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetArea";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public int AddAreaMaster(string AreaName, string AreaCode,  DateTime CreatedDate)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddAreaMaster";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_AreaCode", AreaCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_AreaName", AreaName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CreatedDate", CreatedDate));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public int AddMailConfig(string Host, string Port, string MailFrom, string MailPassword, bool MailSSL)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddMailConfig";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Host", Host));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Port", Port));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_MailFrom", MailFrom));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_MailPassword", MailPassword));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_MailSSL", MailSSL));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public int AddGeneralConfig(string dashboardUrl)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddGeneralConfig";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DashboardUrl", dashboardUrl));
                             count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }


        public DataTable GetMailConfig()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetMailConfig";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public DataTable GetGeneralConfig()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetGeneralConfig";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public double GetBillWiseConsumedItemQty(string ReferenceNo, string Itemcode, string BatchNo,out double Result )
        {
            double retQty = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.SelectCommand = cmd;
                        sda.SelectCommand.Connection = cnn;
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.CommandText = "SP_GetBillWiseConsumedItemQty";
                        sda.SelectCommand.Parameters.Add("p_ReferenceNo", MySqlDbType.TinyText).Value = ReferenceNo;
                        sda.SelectCommand.Parameters.Add("p_Itemcode", MySqlDbType.TinyText).Value = Itemcode;
                        sda.SelectCommand.Parameters.Add("p_BatchNo", MySqlDbType.TinyText).Value = BatchNo;
                        sda.SelectCommand.Parameters.Add("p_Result", MySqlDbType.Float).Value = retQty;
                        sda.SelectCommand.Parameters["p_Result"].Direction = ParameterDirection.Output;
                        // sda.SelectCommand.ExecuteReader();
                        sda.SelectCommand.ExecuteNonQuery();
                        Result = Convert.ToDouble(sda.SelectCommand.Parameters["p_Result"].Value);//.ToString());
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return Result;
        }

        #endregion

        #region "RMPCL Method CAlls Arvind"
        //public int AddIncidentReport_RMPCL(string ReportNo, DateTime ReportDate, DateTime ReportTime, string EmployeeType, string Shift, string IncidentType,
        //    DateTime IncidentDate,string IncHours,String IncMinuts,DateTime IncidentTime, string IncidentLocation, string ExactLocation, string Description, 
        //    string CorrectiveAction,string ObservedBy, string PersonInjured, int DepartmentId, string PersonAge, string MachineTag, byte[] IncidentImage,
        //    string IncidentStatus, string OperationUnit, string is_localSaved, string is_Assigned, string AssignedToGM,
        // DateTime ClosureDate, int mode)
             public int AddIncidentReport_RMPCL(string ReportNo, DateTime ReportDate, DateTime ReportTime, string EmployeeType, string Shift, string IncidentType,
            DateTime IncidentDate, string IncHours, String IncMinuts, DateTime IncidentTime, string IncidentLocation, string ExactLocation, string Description,
            string CorrectiveAction, string ObservedBy, string DocumentedBy, string ReportedBy, string PersonInjured, int DepartmentId, string PersonAge, string MachineTag, byte[] IncidentImage,
            string IncidentStatus, string OperationUnit, string is_localSaved, string is_Assigned, string AssignedToGM,
         DateTime ClosureDate, int mode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddIncidentReport";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ReportNo", ReportNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ReportDate", ReportDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ReportTime", ReportTime));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_EmployeeType", EmployeeType));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Shift", Shift));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_IncidentType", IncidentType));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_IncidentDate", IncidentDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_IncHours", IncHours));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_IncMinuts", IncMinuts));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_IncidentTime", IncidentTime));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_IncidentLocation", IncidentLocation));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ExactLocation", ExactLocation));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Description", Description));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CorrectiveAction", CorrectiveAction));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ObservedBy", ObservedBy));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocumentedBy", DocumentedBy));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ReportedBy", ReportedBy));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_PersonInjured", PersonInjured));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DepartmentId", DepartmentId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_PersonAge", PersonAge));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_MachineTag", MachineTag));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_IncidentImage", IncidentImage));

                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_IncidentStatus", IncidentStatus));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_OperationUnit", OperationUnit));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_is_localSaved", is_localSaved));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_is_Assigned", is_Assigned));

                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_AssignedToGM", AssignedToGM));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ClosureDate", ClosureDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return count;
        }
       
public int AddDailyProductionTmpTbl_RMPCL(string DProdCode, string PlantName, string ProdName, string ProdCode, decimal OpeningStock, decimal DailyTarget, decimal ActualProd,
decimal ProdDispatched, decimal ClosingStock, string EmpCode, int RoleId, DateTime CreatedDate, DateTime DateFilledFor, DateTime UpdateDate, string ActualProdUnit, string PrdoDispatchedUnit, int mode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddDailyProductionTmpTbl_RMPCL";
                            sda.InsertCommand.Parameters.AddWithValue("p_DProdCode", DProdCode);
                            sda.InsertCommand.Parameters.AddWithValue("p_PlantName", PlantName);
                            sda.InsertCommand.Parameters.AddWithValue("p_ProdName", ProdName);
                            sda.InsertCommand.Parameters.AddWithValue("p_ProdCode", ProdCode);
                            sda.InsertCommand.Parameters.AddWithValue("p_OpeningStock", OpeningStock);
                            sda.InsertCommand.Parameters.AddWithValue("p_DailyTarget", DailyTarget);
                            sda.InsertCommand.Parameters.AddWithValue("p_ActualProd", ActualProd);
                            sda.InsertCommand.Parameters.AddWithValue("p_ProdDispatched", ProdDispatched);
                            sda.InsertCommand.Parameters.AddWithValue("p_ClosingStock", ClosingStock);
                            //sda.InsertCommand.Parameters.AddWithValue("p_CreatedDate", CreatedDate);
                            sda.InsertCommand.Parameters.AddWithValue("p_EmpCode", EmpCode);
                            sda.InsertCommand.Parameters.AddWithValue("p_RoleId", RoleId);
                            sda.InsertCommand.Parameters.AddWithValue("p_CreatedDate", CreatedDate);
                            sda.InsertCommand.Parameters.AddWithValue("p_DateFilledFor", DateFilledFor);
                            sda.InsertCommand.Parameters.AddWithValue("p_UpdateDate", UpdateDate);
                            sda.InsertCommand.Parameters.AddWithValue("p_ActualProdUnit", ActualProdUnit);
                            sda.InsertCommand.Parameters.AddWithValue("p_PrdoDispatchedUnit", PrdoDispatchedUnit);
                            sda.InsertCommand.Parameters.AddWithValue("p_mode", mode);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        //        public DataTable GetDailyProductionTempTbl_RMPCL(string DProdCode, string PlantName, string ProdName, string ProdCode, decimal OpeningStock, decimal DailyTarget, decimal ActualProd,
        //decimal ProdDispatched, decimal ClosingStock, string EmpCode, int RoleId, DateTime CreatedDate, DateTime DateFilledFor, DateTime UpdateDate, string ActualProdUnit, string PrdoDispatchedUnit, int mode)
        //        {
        //            DataTable dt = null;
        //            try
        //            {
        //                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
        //                {
        //                    cnn.Open();
        //                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
        //                    {
        //                        using (MySqlCommand cmd = new MySqlCommand())
        //                        {
        //                            sda.SelectCommand = cmd;
        //                            sda.SelectCommand.Connection = cnn;
        //                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
        //                            sda.SelectCommand.CommandText = "SP_AddDailyProductionTmpTbl_RMPCL";
        //                            sda.SelectCommand.Parameters.AddWithValue("p_DProdCode", DProdCode);
        //                            sda.SelectCommand.Parameters.AddWithValue("p_PlantName", PlantName);
        //                            sda.SelectCommand.Parameters.AddWithValue("p_ProdName", ProdName);
        //                            sda.SelectCommand.Parameters.AddWithValue("p_ProdCode", ProdCode);
        //                            sda.SelectCommand.Parameters.AddWithValue("p_OpeningStock", OpeningStock);
        //                            sda.SelectCommand.Parameters.AddWithValue("p_DailyTarget", DailyTarget);
        //                            sda.SelectCommand.Parameters.AddWithValue("p_ActualProd", ActualProd);
        //                            sda.SelectCommand.Parameters.AddWithValue("p_ProdDispatched", ProdDispatched);
        //                            sda.SelectCommand.Parameters.AddWithValue("p_ClosingStock", ClosingStock);
        //                            //sda.InsertCommand.Parameters.AddWithValue("p_CreatedDate", CreatedDate);
        //                            sda.SelectCommand.Parameters.AddWithValue("p_EmpCode", EmpCode);
        //                            sda.SelectCommand.Parameters.AddWithValue("p_RoleId", RoleId);
        //                            sda.SelectCommand.Parameters.AddWithValue("p_CreatedDate", CreatedDate);
        //                            sda.SelectCommand.Parameters.AddWithValue("p_DateFilledFor", DateFilledFor);
        //                            sda.SelectCommand.Parameters.AddWithValue("p_UpdateDate", UpdateDate);
        //                            sda.SelectCommand.Parameters.AddWithValue("p_ActualProdUnit", ActualProdUnit);
        //                            sda.SelectCommand.Parameters.AddWithValue("p_PrdoDispatchedUnit", PrdoDispatchedUnit);
        //                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
        //                            dt = new DataTable();
        //                            sda.Fill(dt);
        //                            cmd.Dispose();
        //                        }
        //                        sda.Dispose();
        //                    }
        //                    cnn.Dispose();
        //                }
        //            }
        //            catch (Exception Ex)
        //            {
        //                throw new Exception(Ex.Message);
        //            }
        //            return dt;
        //        }

        public DataTable GetIncidentBetweenDates_RMPCL(DateTime ReportDateFrom, DateTime ReportDateTo, string EmployeType, string Status, string empCode, int isAdminRole)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetIncidentBetweenDates";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_ReportDateFrom", ReportDateFrom));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_ReportDateTo", ReportDateTo));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_EmployeType", EmployeType));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_Status", Status));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_empCode", empCode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_isAdminRole", isAdminRole));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetDailyProductionTempTbl_RMPCL(string DProdCode, string PlantName, string ProdName, string ProdCode, decimal OpeningStock, decimal DailyTarget, decimal ActualProd,
 decimal ProdDispatched, decimal ClosingStock, string EmpCode, int RoleId, DateTime CreatedDate, DateTime DateFilledFor, DateTime UpdateDate, string ActualProdUnit, string PrdoDispatchedUnit, int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_AddDailyProductionTmpTbl_RMPCL";
                            sda.SelectCommand.Parameters.AddWithValue("p_DProdCode", DProdCode);
                            sda.SelectCommand.Parameters.AddWithValue("p_PlantName", PlantName);
                            sda.SelectCommand.Parameters.AddWithValue("p_ProdName", ProdName);
                            sda.SelectCommand.Parameters.AddWithValue("p_ProdCode", ProdCode);
                            sda.SelectCommand.Parameters.AddWithValue("p_OpeningStock", OpeningStock);
                            sda.SelectCommand.Parameters.AddWithValue("p_DailyTarget", DailyTarget);
                            sda.SelectCommand.Parameters.AddWithValue("p_ActualProd", ActualProd);
                            sda.SelectCommand.Parameters.AddWithValue("p_ProdDispatched", ProdDispatched);
                            sda.SelectCommand.Parameters.AddWithValue("p_ClosingStock", ClosingStock);
                            //sda.InsertCommand.Parameters.AddWithValue("p_CreatedDate", CreatedDate);
                            sda.SelectCommand.Parameters.AddWithValue("p_EmpCode", EmpCode);
                            sda.SelectCommand.Parameters.AddWithValue("p_RoleId", RoleId);
                            sda.SelectCommand.Parameters.AddWithValue("p_CreatedDate", CreatedDate);
                            sda.SelectCommand.Parameters.AddWithValue("p_DateFilledFor", DateFilledFor);
                            sda.SelectCommand.Parameters.AddWithValue("p_UpdateDate", UpdateDate);
                            sda.SelectCommand.Parameters.AddWithValue("p_ActualProdUnit", ActualProdUnit);
                            sda.SelectCommand.Parameters.AddWithValue("p_PrdoDispatchedUnit", PrdoDispatchedUnit);
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

    public int DropDailyTempTbl_RMPCL(DateTime DateFilledFrom, string PlantName)
            {
                int count = 0;
                try
                {
                    using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                    {
                        cnn.Open();
                        using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                        {
                            using (MySqlCommand cmd = new MySqlCommand())
                            {
                                sda.InsertCommand = cmd;
                                sda.InsertCommand.Connection = cnn;
                                sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                                sda.InsertCommand.CommandText = "SP_DropDailyTempTblData";
                                sda.InsertCommand.Parameters.AddWithValue("p_DateFilledFrom", DateFilledFrom);
                                sda.InsertCommand.Parameters.AddWithValue("p_PlantName", PlantName);
                                count = sda.InsertCommand.ExecuteNonQuery();
                                cmd.Dispose();
                            }
                            sda.Dispose();
                        }
                        cnn.Dispose();
                    }
                }
                catch (Exception Ex)
                {
                    throw new Exception(Ex.Message);
                }
                return count;
            }

        public DataTable GetDailyProductionDetails_RMPCL(string DProdCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetDailyProductionDetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_DProdCode", DProdCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

            public DataTable GetDailyProductionData_RMPCL(DateTime datetime)
                {
                    DataTable dt = null;
                    try
                    {
                        using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                        {
                            cnn.Open();
                            using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                            {
                                using (MySqlCommand cmd = new MySqlCommand())
                                {
                                    sda.SelectCommand = cmd;
                                    sda.SelectCommand.Connection = cnn;
                                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                                    sda.SelectCommand.CommandText = "SP_GetDailyprodData";
                                    sda.SelectCommand.Parameters.Add(new MySqlParameter("p_datetime", datetime));
                                    dt = new DataTable();
                                    sda.Fill(dt);
                                    cmd.Dispose();
                                }
                                sda.Dispose();
                            }
                            cnn.Dispose();
                        }
                    }
                    catch (Exception Ex)
                    {
                        throw new Exception(Ex.Message);
                    }
                    return dt;
                }

        public DataTable GetShiftData(string shiftName, DateTime entryDate, DateTime entryDate1, int mode, Guid IncId)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetShiftData";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_shiftName", shiftName));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_entryDate", entryDate));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_entryDate1", entryDate1));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_IncId", IncId));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }


        public int DropDailyProductionData_RMPCL(string DProdCode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_DropDailyProductionData";
                            sda.InsertCommand.Parameters.AddWithValue("p_DProdCode", DProdCode);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public int AddUAUCNearMissRequestor_RMPCL(string ObservationNo, DateTime ObservationDate, string OperationUnit, string SpecificLocation,
        string DocumentedBy, string Area,
        string MachineTag, string Observation, string NearMissStatus, string DocumentStatus, string ActOrCondition,
        string ObservedBy, string Recommendation, string ImgPath, string AssignedTo, string Remarks, int is_Admin, string is_GMCode,
        string AssigneeImgPath, string ObserverImgPath, DateTime AssignedDate, DateTime GM_Approval_RejectionDate, DateTime Reqester_FinalApproval_RejectionDate, bool is_AdminClosed, string RequestStage)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddUAUCNearMissData";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ObservationNo", ObservationNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ObservationDate", ObservationDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_OperationUnit", OperationUnit));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_SpecificLocation", SpecificLocation));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocumentedBy", DocumentedBy));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Area", Area));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_MachineTag", MachineTag));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Observation", Observation));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_NearMissStatus", NearMissStatus));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocumentStatus", DocumentStatus));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ActOrCondition", ActOrCondition));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ObservedBy", ObservedBy));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Recommendation", Recommendation));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ImgPath", ImgPath));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_AssignedTo", AssignedTo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Remarks", Remarks));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_is_Admin", is_Admin));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_is_GMCode", is_GMCode));

                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_AssigneeImgPath", AssigneeImgPath));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ObserverImgPath", ObserverImgPath));

                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_AssignedDate", AssignedDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_GM_Approval_RejectionDate", GM_Approval_RejectionDate));

                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Reqester_FinalApproval_RejectionDate", Reqester_FinalApproval_RejectionDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_is_AdminClosed", is_AdminClosed));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RequestStage", RequestStage));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return count;
        }

        public DataTable GetIncidentReport_RMPCL(string empCode, string IncidentStatus, int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetIncidentLocalReport";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_empCode", empCode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_incidentStatus", IncidentStatus));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public DataTable GetUserName_RMPCL()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "GetAllUsers";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetUserDetails_RMPCL(int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetUserDetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public DataTable GetEmployeeType_RMPCL(int mode, string EmpType, int TypeId)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetEmployeeType";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_EmpType", EmpType));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_TypeId", TypeId));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetNearMissReport_UAUC_RMPCL(string UAUCStatus, int is_Admin, string GMCode, int mode)
        {
            DataTable dt = null;
            try
            {

                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetNearMissUAUC";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_UAUCStatus", UAUCStatus));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_isAdmin", is_Admin));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_GMCode", GMCode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));

                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public int UpdateIncidentReport_RMPCL(string ReportNo, string IncidentStatus, DateTime ClosureDate, string AdminRemarks)
        {
            int result = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.UpdateCommand = cmd;
                        sda.UpdateCommand.Connection = cnn;
                        sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                        sda.UpdateCommand.CommandText = "SP_UpdateIncidentReport";
                        sda.UpdateCommand.Parameters.Add("p_ReportNo", MySqlDbType.TinyText).Value = ReportNo;
                        sda.UpdateCommand.Parameters.Add("p_IncidentStatus", MySqlDbType.TinyText).Value = IncidentStatus;
                        sda.UpdateCommand.Parameters.Add("p_ClosureDate", MySqlDbType.DateTime).Value = ClosureDate;
                        sda.UpdateCommand.Parameters.Add("p_AdminRemarks", MySqlDbType.TinyText).Value = AdminRemarks;
                        cmd.Dispose();
                    }
                    result = sda.UpdateCommand.ExecuteNonQuery();
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return result;
        }

        public int AddEmployeeType_RMPCL(int mode, string EmpType, int TypeId)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_GetEmployeeType";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_EmpType", EmpType));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_TypeId", TypeId));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return count;
        }
        public int UpdateUAUCNearMissData_RMPCL(string ObservationNo, DateTime ObservationDate, string OperationUnit, string SpecificLocation,
     string DocumentedBy, string Area,
     string MachineTag, string Observation, string NearMissStatus, string DocumentStatus, string ActOrCondition,
     string ObservedBy, string Recommendation, string ImgPath, string AssignedTo, string Remarks, int is_Admin, string is_GMCode,
     string AssigneeImgPath, string ObserverImgPath, DateTime AssignedDate, DateTime GM_Approval_RejectionDate, DateTime Reqester_FinalApproval_RejectionDate, bool is_AdminClosed, string RequestStage, int mode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_UpdateUAUCNearMissData";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ObservationNo", ObservationNo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ObservationDate", ObservationDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_OperationUnit", OperationUnit));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_SpecificLocation", SpecificLocation));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocumentedBy", DocumentedBy));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Area", Area));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_MachineTag", MachineTag));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Observation", Observation));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_NearMissStatus", NearMissStatus));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DocumentStatus", DocumentStatus));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ActOrCondition", ActOrCondition));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ObservedBy", ObservedBy));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Recommendation", Recommendation));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ImgPath", ImgPath));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_AssignedTo", AssignedTo));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Remarks", Remarks));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_is_Admin", is_Admin));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_is_GMCode", is_GMCode));

                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_AssigneeImgPath", AssigneeImgPath));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ObserverImgPath", ObserverImgPath));

                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_AssignedDate", AssignedDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_GM_Approval_RejectionDate", GM_Approval_RejectionDate));

                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Reqester_FinalApproval_RejectionDate", Reqester_FinalApproval_RejectionDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_is_AdminClosed", is_AdminClosed));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RequestStage", RequestStage));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return count;
        }

        public List<string> GetProductClosingStock_RMPCL(string ProdCode)
        {
            List<string> itemList = new List<string>();
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetProductOpenStock";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_ProdCode", ProdCode));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            if (rdr.HasRows == true)
                            {
                                rdr.Read();
                                itemList.Add(rdr.GetDecimal(0).ToString());
                                itemList.Add(rdr.GetDecimal(1).ToString());
                                itemList.Add(rdr.GetString(2));
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return itemList;
        }

        public string GetAdminEmployeeCode_RMPCL()
        {
            string emailid = "";
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetAdminEmployeeCode";
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            if (rdr.HasRows == true)
                            {
                                rdr.Read();
                                emailid = rdr.GetString(0);
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return emailid;
        }


        public string GetObservationNo_RMPCL()
        {
            string emailid = "";
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetObservationNo";
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            if (rdr.HasRows == true)
                            {
                                rdr.Read();
                                emailid = rdr["ObservNo"].ToString();
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return emailid;
        }


        public string GetIncidentReportNo_RMPCL(string SP_Name)
        {
            string emailid = "";
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {

                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = SP_Name;
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            if (rdr.HasRows == true)
                            {
                                rdr.Read();
                                emailid = rdr["ReportNo"].ToString();
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return emailid;
        }

        public int AddProductionCalendar_RMPCL(string MonthName, int CalendarYear, string WorkingDays, int IsFirstEntry)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddProductionCalendar";
                            sda.InsertCommand.Parameters.AddWithValue("p_MonthName", MonthName);
                            sda.InsertCommand.Parameters.AddWithValue("p_CalendarYear", CalendarYear);
                            sda.InsertCommand.Parameters.AddWithValue("p_WorkingDays", WorkingDays);
                            sda.InsertCommand.Parameters.AddWithValue("p_IsFirstEntry", IsFirstEntry);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public int UpdateProductionCalendar_RMPCL(string WorkingDays, int MonthId)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_UpdateProductionCalendar";
                            sda.InsertCommand.Parameters.AddWithValue("p_WorkingDays", WorkingDays);
                            sda.InsertCommand.Parameters.AddWithValue("p_MonthId", MonthId);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public DataTable GetProductionCalendar_RMPCL(string MonthName, int CalendarYear, string WorkingDays, int IsFirstEntry)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetProductionCalendar";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_MonthName", MonthName));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_CalendarYear", CalendarYear));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_WorkingDays", WorkingDays));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_IsFirstEntry", IsFirstEntry));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public int MapAdminRole_RMPCL(string empCode)
        {
            int RoleId = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_MapAdminRoles";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_empCode", empCode));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            if (rdr.HasRows == true)
                            {
                                rdr.Read();
                                RoleId = Convert.ToInt32(rdr[0]);
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return RoleId;
        }


        public int AddShiftChecks_RMPCL(string ShiftName, DateTime EntryDate, int GranulationDrum, int DryerDrum, int CoolerDrum, int GearthGear, int FeedingBelt01GB, int BoronBeltGB, int RMBeltGB, int RMElevatorGearBox,
            int GranulationDrumGB, int DryerDrumGB, int DCBeltGB, int CoolerDrumGB, int CMBeltGB, int CMElevatorGB, int RecycleBeltGB, int ProductionBeltGB, int PackingBeltGB,
            int FeedingBelt01GBSSp, int ZNBeltGB, int ZNElevatorGB, int BottomScrewConveyor, int GRElevatorGearBox, int TopScrewConveyor, int MixerGearBox, int DanGearBox,
            int DozzerGearBox, int DanChain, int FloatingShaft, int CouplingNut, int Rope, int Miscallaneous, int FeedingBelt01GBPssp, int FeedingBelt02GBPssp, int ScreberFan,
            int BallMillIDFan, int Mounting, int HDPEFlang, int HDPEPipe, int ServicePmp78, int ServicePmp98, int VerticalPmp03, int VerticalPmp04, int SilicaPmp)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddShiftChecks";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ShiftName", ShiftName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_EntryDate", EntryDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_GranulationDrum", GranulationDrum));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DryerDrum", DryerDrum));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CoolerDrum", CoolerDrum));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_GearthGear", GearthGear));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_FeedingBelt01GB", FeedingBelt01GB));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_BoronBeltGB", BoronBeltGB));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RMBeltGB", RMBeltGB));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RMElevatorGearBox", RMElevatorGearBox));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_GranulationDrumGB", GranulationDrumGB));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DryerDrumGB", DryerDrumGB));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DCBeltGB", DCBeltGB));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CoolerDrumGB", CoolerDrumGB));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CMBeltGB", CMBeltGB));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CMElevatorGB", CMElevatorGB));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RecycleBeltGB", RecycleBeltGB));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ProductionBeltGB", ProductionBeltGB));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_PackingBeltGB", PackingBeltGB));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_FeedingBelt01GBSSp", FeedingBelt01GBSSp));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ZNBeltGB", ZNBeltGB));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ZNElevatorGB", ZNElevatorGB));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_BottomScrewConveyor", BottomScrewConveyor));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_GRElevatorGearBox", GRElevatorGearBox));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_TopScrewConveyor", TopScrewConveyor));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_MixerGearBox", MixerGearBox));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DanGearBox", DanGearBox));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DozzerGearBox", DozzerGearBox));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DanChain", DanChain));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_FloatingShaft", FloatingShaft));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CouplingNut", CouplingNut));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Rope", Rope));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Miscallaneous", Miscallaneous));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_FeedingBelt01GBPssp", FeedingBelt01GBPssp));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_FeedingBelt02GBPssp", FeedingBelt02GBPssp));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ScreberFan", ScreberFan));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_BallMillIDFan", BallMillIDFan));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_Mounting", Mounting));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_HDPEFlang", HDPEFlang));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_HDPEPipe", HDPEPipe));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ServicePmp78", ServicePmp78));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ServicePmp98", ServicePmp98));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_VerticalPmp03", VerticalPmp03));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_VerticalPmp04", VerticalPmp04));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_SilicaPmp", SilicaPmp));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);

            }
            return count;
        }

        public int AddProductMaster(string PlantName, string ProdCode, string ProdName, DateTime DateAdded, string UniqCode, string CreatedBy, int RoleId, int mode, int IsActive, DateTime DeactivatedFrom, DateTime DeactivatedTo)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddProductMaster";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_PlantName", PlantName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ProdCode", ProdCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ProdName", ProdName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DateAdded", DateAdded));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_UniqCode", UniqCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CreatedBy", CreatedBy));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_RoleId", RoleId));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_IsActive", IsActive));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DeactivatedFrom", DeactivatedFrom));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DeactivatedTo", DeactivatedTo));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public DataTable GetProductCode_RMPCL()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetProductCode";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetProductMaster_RMPCL(string PlantName, string ProdCode, string ProdName, DateTime DateAdded, string UniqCode, string CreatedBy, int RoleId, int mode, int IsActive, DateTime DeactivatedFrom, DateTime DeactivatedTo)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_AddProductMaster";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_PlantName", PlantName));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_ProdCode", ProdCode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_ProdName", ProdName));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_DateAdded", DateAdded));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_UniqCode", UniqCode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_CreatedBy", CreatedBy));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_RoleId", RoleId));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_IsActive", IsActive));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_DeactivatedFrom", DeactivatedFrom));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_DeactivatedTo", DeactivatedTo));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public int AddUnitMaster_RMPCL(string UnitName, int mode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddUnitMaster";
                            sda.InsertCommand.Parameters.AddWithValue("p_UnitName", UnitName);
                            sda.InsertCommand.Parameters.AddWithValue("p_mode", mode);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }


        public DataTable GetUnitMaster_RMPCL(string UnitName, int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_AddUnitMaster";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_UnitName", UnitName));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public DataTable GetDailyProductionDataLineWise_RMPCL(string LineName, DateTime DateFor, int TargetMonth, int targetYear)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetDailyProductionLineData";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_LineName", LineName));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_DateFor", DateFor));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_TargetMonth", TargetMonth));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_targetYear", targetYear));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public DataTable GetConsumptionDetails_RMPCL(string PlantName, DateTime DateFillfrom, DateTime DateFilledTo)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetConsumptionDetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_PlantName", PlantName));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_DateFilledFrom", DateFillfrom));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_DateFilledTo", DateFilledTo));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }


        public DataTable GetDailyProdConsumption_RMPCL(string PlantName, DateTime DateFilledFor)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetDailyProdConsumption";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_PlantName", PlantName));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_DateFilledFor", DateFilledFor));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public int AddMonthlyProductionTarget(int NoWorkDays, string DaysWorked, string PlantName, decimal MonthlyTarget, decimal DailyTarget, decimal ClosingStock,
            string MonthlyTargetUnit, string DailyTargetUnit, string ClosingStockUnit, DateTime CreatedDate, string CreatedBy, int RoleId,
            string TargetCode, string TargetMonth, int TargetYear, string ProdCode, int mode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddMonthlyProductionTarget";
                            sda.InsertCommand.Parameters.AddWithValue("p_NoWorkDays", NoWorkDays);
                            sda.InsertCommand.Parameters.AddWithValue("p_DaysWorked", DaysWorked);
                            sda.InsertCommand.Parameters.AddWithValue("p_PlantName", PlantName);
                            sda.InsertCommand.Parameters.AddWithValue("p_MonthlyTarget", MonthlyTarget);
                            sda.InsertCommand.Parameters.AddWithValue("p_DailyTarget", DailyTarget);
                            sda.InsertCommand.Parameters.AddWithValue("p_ClosingStock", ClosingStock);
                            sda.InsertCommand.Parameters.AddWithValue("p_MonthlyTargetUnit", MonthlyTargetUnit);
                            sda.InsertCommand.Parameters.AddWithValue("p_DailyTargetUnit", DailyTargetUnit);
                            sda.InsertCommand.Parameters.AddWithValue("p_ClosingStockUnit", ClosingStockUnit);
                            sda.InsertCommand.Parameters.AddWithValue("p_CreatedDate", CreatedDate);
                            sda.InsertCommand.Parameters.AddWithValue("p_CreatedBy", CreatedBy);
                            sda.InsertCommand.Parameters.AddWithValue("p_RoleId", RoleId);
                            sda.InsertCommand.Parameters.AddWithValue("p_TargetCode", TargetCode);
                            sda.InsertCommand.Parameters.AddWithValue("p_TargetMonth", TargetMonth);
                            sda.InsertCommand.Parameters.AddWithValue("p_TargetYear", TargetYear);
                            sda.InsertCommand.Parameters.AddWithValue("p_ProdCode", ProdCode);
                            sda.InsertCommand.Parameters.AddWithValue("p_mode", mode);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }


        public DataTable GetMonthlyProductionTarget_RMPCL(int NoWorkDays, string DaysWorked, string PlantName, decimal MonthlyTarget, decimal DailyTarget,

          decimal ClosingStock, string MonthlyTargetUnit, string DailyTargetUnit, string ClosingStockUnit, DateTime CreatedDate, string TargetCode, int RoleId, string CreatedBy, string TargetMonth, int TargetYear, string ProdCode, int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_AddMonthlyProductionTarget";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_NoWorkDays", NoWorkDays));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_DaysWorked", DaysWorked));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_PlantName", PlantName));

                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_MonthlyTarget", MonthlyTarget));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_DailyTarget", DailyTarget));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_ClosingStock", ClosingStock));

                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_MonthlyTargetUnit", MonthlyTargetUnit));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_DailyTargetUnit", DailyTargetUnit));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_ClosingStockUnit", ClosingStockUnit));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_CreatedDate", CreatedDate));

                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_TargetCode", TargetCode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_RoleId", RoleId));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_CreatedBy", CreatedBy));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_TargetMonth", TargetMonth));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_TargetYear", TargetYear));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_ProdCode", ProdCode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public int AddDailyProduction_RMPCL(string DProdCode, string PlantName, string ProdName, string ProdCode, decimal OpeningStock, decimal DailyTarget, decimal ActualProd,
            decimal ProdDispatched, decimal ClosingStock, string EmpCode, int RoleId, DateTime CreatedDate, DateTime DateFilledFor, DateTime UpdateDate, string ActualProdUnit, string PrdoDispatchedUnit, int mode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddDailyProductionDetails_RMPCL";
                            sda.InsertCommand.Parameters.AddWithValue("p_DProdCode", DProdCode);
                            sda.InsertCommand.Parameters.AddWithValue("p_PlantName", PlantName);
                            sda.InsertCommand.Parameters.AddWithValue("p_ProdName", ProdName);
                            sda.InsertCommand.Parameters.AddWithValue("p_ProdCode", ProdCode);
                            sda.InsertCommand.Parameters.AddWithValue("p_OpeningStock", OpeningStock);
                            sda.InsertCommand.Parameters.AddWithValue("p_DailyTarget", DailyTarget);
                            sda.InsertCommand.Parameters.AddWithValue("p_ActualProd", ActualProd);
                            sda.InsertCommand.Parameters.AddWithValue("p_ProdDispatched", ProdDispatched);
                            sda.InsertCommand.Parameters.AddWithValue("p_ClosingStock", ClosingStock);
                            //sda.InsertCommand.Parameters.AddWithValue("p_CreatedDate", CreatedDate);
                            sda.InsertCommand.Parameters.AddWithValue("p_EmpCode", EmpCode);
                            sda.InsertCommand.Parameters.AddWithValue("p_RoleId", RoleId);
                            sda.InsertCommand.Parameters.AddWithValue("p_CreatedDate", CreatedDate);
                            sda.InsertCommand.Parameters.AddWithValue("p_DateFilledFor", DateFilledFor);
                            sda.InsertCommand.Parameters.AddWithValue("p_UpdateDate", UpdateDate);
                            sda.InsertCommand.Parameters.AddWithValue("p_ActualProdUnit", ActualProdUnit);
                            sda.InsertCommand.Parameters.AddWithValue("p_PrdoDispatchedUnit", PrdoDispatchedUnit);
                            sda.InsertCommand.Parameters.AddWithValue("p_mode", mode);
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }

        public int AddDailyConsumption(string DProdCode, string DConsumCode, string PlantName, decimal ElectricityConsumed, string ElectricityUnit,
           decimal ElectricityRate, decimal CoalConsumed, string CoalUnit, decimal CoalRate, decimal TotalProduction, string TotalUnit,
           decimal PowerTrip, string PowerTripUnit, decimal MaintenanceTime, string MaintenanceTimeUnit, decimal TotalRunningTime, string TotalRunningTimeUnit,
           DateTime CreatedDate, int mode)
        {
            int count = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.InsertCommand = cmd;
                            sda.InsertCommand.Connection = cnn;
                            sda.InsertCommand.CommandType = CommandType.StoredProcedure;
                            sda.InsertCommand.CommandText = "SP_AddDailyConsumption";
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DProdCode", DProdCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_DConsumCode", DConsumCode));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_PlantName", PlantName));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ElectricityConsumed", ElectricityConsumed));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ElectricityUnit", ElectricityUnit));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_ElectricityRate", ElectricityRate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CoalConsumed", CoalConsumed));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CoalUnit", CoalUnit));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CoalRate", CoalRate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_TotalProduction", TotalProduction));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_TotalUnit", TotalUnit));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_PowerTrip", PowerTrip));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_PowerTripUnit", PowerTripUnit));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_MaintenanceTime", MaintenanceTime));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_MaintenanceTimeUnit", MaintenanceTimeUnit));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_TotalRunningTime", TotalRunningTime));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_TotalRunningTimeUnit", TotalRunningTimeUnit));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_CreatedDate", CreatedDate));
                            sda.InsertCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            count = sda.InsertCommand.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return count;
        }



        public DataTable GetDailyConsumption_RMPCL(string DProdCode, int mode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetDailyConsumption";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_DProdCode", DProdCode));
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_mode", mode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public string GetRequestStage(string ObservationNo)
        {
            string emailid = "";
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetRequestStage";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_ObservationNo", ObservationNo));
                            MySqlDataReader rdr = sda.SelectCommand.ExecuteReader();
                            if (rdr.HasRows == true)
                            {
                                rdr.Read();
                                emailid = rdr["RequestStage"].ToString();
                            }
                            rdr.Close();
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return emailid;
        }
        public DataTable GetDailyProductionDetails(string DProdCode)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetDailyProductionDetails";
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_DProdCode", DProdCode));
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }


        public DataTable GetFtpConnection_RMPCL()
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetFTPConnection";
                            dt = new DataTable();
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        #endregion "Arvind Code RMPCL"

        #region "Rajendra Code RMPCL"
        public int UpdateMaintenaceRMPCLReturnINVRecord(string MntCode, string DocNo, string BatchNo, int Qty, double UnitCost, double TotalCost, ref string Result)
        {
            int rslt = 0;
            using (MySqlConnection cnn = new MySqlConnection(GetConnection))
            {
                cnn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        sda.UpdateCommand = cmd;
                        sda.UpdateCommand.Connection = cnn;
                        sda.UpdateCommand.CommandType = CommandType.StoredProcedure;
                        sda.UpdateCommand.CommandText = "SP_ReturnInventoryUpdate";
                        sda.UpdateCommand.Parameters.Add("p_MNTCode", MySqlDbType.TinyText).Value = MntCode;
                        sda.UpdateCommand.Parameters.Add("p_DocNo", MySqlDbType.TinyText).Value = DocNo;
                        sda.UpdateCommand.Parameters.Add("p_batchNo", MySqlDbType.TinyText).Value = BatchNo;
                        sda.UpdateCommand.Parameters.Add("p_Qty", MySqlDbType.Int32).Value = Qty;
                        sda.UpdateCommand.Parameters.Add("p_UnitCost", MySqlDbType.Float).Value = UnitCost;
                        sda.UpdateCommand.Parameters.Add("p_TotalCost", MySqlDbType.Float).Value = TotalCost;
                        sda.UpdateCommand.Parameters.Add("p_Result", MySqlDbType.VarChar, 500);
                        sda.UpdateCommand.Parameters["p_Result"].Direction = ParameterDirection.Output;
                        rslt = sda.UpdateCommand.ExecuteNonQuery();
                        Result = sda.UpdateCommand.Parameters["p_Result"].Value.ToString();
                        cmd.Dispose();
                    }
                    sda.Dispose();
                }
                cnn.Dispose();
            }
            return rslt;
        }
        #endregion

        #region "General Methods"


        public DataTable GetJSAInputNoControl(string Mcordinate)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "SP_GetJSAInputNoControl";
                            dt = new DataTable();
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_Mcordinate", Mcordinate));
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public DataTable GetJSAInputNewControl(string Mcordinate)
        {
            DataTable dt = null;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.SelectCommand = cmd;
                            sda.SelectCommand.Connection = cnn;
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.CommandText = "Sp_GetJSAInputNewControl";
                            dt = new DataTable();
                            sda.SelectCommand.Parameters.Add(new MySqlParameter("p_Mcordinate", Mcordinate));
                            sda.Fill(dt);
                            cmd.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Dispose();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }

        public int INUpdateUsery(string Query)
        {
            int Status = 0;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(GetConnection))
                {
                    cnn.Open();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("", cnn))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            sda.UpdateCommand = cmd;
                            sda.UpdateCommand.Connection = cnn;
                            sda.UpdateCommand.CommandType = CommandType.Text;
                            sda.UpdateCommand.CommandText = Query;
                            // sda.UpdateCommand.Parameters.AddWithValue("p_AuditCode", AuditCode);
                            Status = sda.UpdateCommand.ExecuteNonQuery();
                            sda.UpdateCommand.Dispose();
                        }
                        sda.Dispose();
                    }
                    cnn.Close();
                }
            }
            catch (MySqlException Ex)
            {
                throw new Exception(Ex.Message);
            }
            return Status;
        }

        #endregion
        #endregion





        /// Today Commit 09-09-2021

    }
}
