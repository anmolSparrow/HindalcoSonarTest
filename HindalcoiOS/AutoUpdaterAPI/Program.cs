using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using WinSCP;
//using DevExpress.XtraEditors;
using System.Windows;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace AutoUpdaterAPI
{
    class Program
    {
        #region "Global Variables"
        string AppSource = string.Empty;
        string AppCopysource = string.Empty;
        string AppDefaultPath = string.Empty;
        string SessionProto = string.Empty;
        string SessionUser = string.Empty;
        string SessionHost = string.Empty;
        string SessionDecryptPwd = string.Empty;
        DirectoryInfo copyFrm;
        DirectoryInfo copytoDir;
        public const string AppConfig = "ApplicationConfig";
        List<string> AllowedFiles = new List<string>();
        public static string applicationManifestPrimary = string.Empty;
        public static string applicationManifestSecondory = string.Empty;
        string[] ApplicationArr = new string[] { };
        public string AppName = string.Empty;
        bool isUpdating = false;
        string urlCompose = string.Empty;
        RemoteFileInfo latest = null;
        string[] App = new string[] { };
        #endregion
        static void Main(string[] args)
        {
            Console.WriteLine("Starting the Download process.");
            Console.SetWindowSize(100, 40);
            Program ps = new Program();
          //  System.Diagnostics.Debugger.Launch();
            ps.ReadINIData();
            ps.AddListObjects(ps.AppName);
            ps.CompareVersionHistory();
            if (ps.isUpdating == true)
            {
                ps.DownloadFtpDirectory(ps.urlCompose);
            }
            else
            {
                Console.WriteLine("Application is upto date.");
            }
            System.Threading.Thread.Sleep(1000);
        }   
        private void AddListObjects(string AppName)
        {
            try
            {               
                AllowedFiles.Add(AppName+".application Manifest");
                AllowedFiles.Add(AppName);
                AllowedFiles.Add(AppName+".application");
                AllowedFiles.Add(AppName+".exe.manifest");
                AllowedFiles.Add(AppName+".exe.config");
                AllowedFiles.Add(AppName+".pdb");
                AllowedFiles.Add("SparrowRMS.dll");
                AllowedFiles.Add("AppSetting.ini");
            }
            catch (Exception Ex)
            {
                WriteToFile(Ex.Message);
            }
        }
        public void WriteToFile(string Message)
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
        void CompareVersionHistory()
        {
            try
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("Performing version checks...");
                System.Threading.Thread.Sleep(20);
                
                Console.WriteLine("Hang on this may take some time to download.");
                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Ftp,
                    HostName = SessionHost,
                    UserName = Decrypt(SessionUser),
                    Password = Decrypt(SessionDecryptPwd),
                    PortNumber = 21
                };
                using (Session session = new Session())
                {
                    Console.WriteLine("Looking for files to download...");
                    session.Open(sessionOptions);
                    //// Download files
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;
                    //   RemoteDirectoryInfo directory = session.ListDirectory("/Application Files/RMPCLApp_1_0_0_0");
                    RemoteDirectoryInfo directory = session.ListDirectory("/Application Files/"); // Base FTP Folder
                    App = AppName.Split('.');  // Application split exe part
                   
                    latest = directory.Files
                    .Where(file => file.IsDirectory).Where(file=>file.Name.Contains(App[0]))
                    .OrderByDescending(file => file.LastWriteTime)
                    .FirstOrDefault();  // gets the most recent folder to look for the related files based on the application that is making the request

                    string AppFullPath = latest.FullName + @"\" + AppName;
                    bool rds = session.FileExists(AppFullPath);
                    if (rds == true)
                    {
                        RemoteDirectoryInfo LatestDir = session.ListDirectory(latest.FullName);
                        isUpdating = true;
                        ApplicationUpdating(session, LatestDir, latest);
                    }
                    else
                    {
                        isUpdating = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                WriteToFile(Ex.Message);
            }
        }

        void ApplicationUpdating(Session RemoteSession,RemoteDirectoryInfo directory,RemoteFileInfo latestDir)
        {
            try
            {
                int versionNewMinor = 0;
                int versionOldMinor = 0;
                int versionNewMajor = 0;
                int versionOldMajor = 0;
                string NewManifestLocation = applicationManifestPrimary;
                string OldManifestLocation = applicationManifestSecondory;
                string RmpclPath = AppDefaultPath + @"\" + AppName;
                string AutoUpdPath = AppDefaultPath + @"\" + "AutoUpdater" + @"\";
                foreach (RemoteFileInfo fileInfo in directory.Files)
                {
                    string extension = Path.GetExtension(fileInfo.Name);
                    if (string.Compare(extension, ".exe", true) == 0)
                    {
                        if (fileInfo.Name == AppName)
                        {
                            if (!Directory.Exists(AppDefaultPath + "Manifest"))
                            {
                                Directory.CreateDirectory(AppDefaultPath + "Manifest");
                                Directory.CreateDirectory(AppDefaultPath + "AutoUpdater");
                                Directory.CreateDirectory(AppDefaultPath + "Manifest" + @"\" + @"NewManifest");
                            }
                            if (!Directory.Exists(AppDefaultPath + "Manifest"))
                            {
                                Directory.CreateDirectory(AppDefaultPath + "Manifest" + @"\" + @"OldManifest");
                            }
                            RemoteSession.GetFiles(fileInfo.FullName, NewManifestLocation, false).Check();
                            string fnae = fileInfo.Name;
                            string Loadfrm = NewManifestLocation + fnae;
                            var versionInfo = FileVersionInfo.GetVersionInfo(Loadfrm);

                            if (File.Exists(OldManifestLocation + @"\" + AppName))
                            {
                                File.Delete(OldManifestLocation + @"\" + AppName);
                            }
                            File.Copy(RmpclPath, OldManifestLocation + @"\" + AppName);
                            string LoadPrimaryAssembly = OldManifestLocation + @"\" + AppName;
                            var versionLoad = FileVersionInfo.GetVersionInfo(LoadPrimaryAssembly);
                            versionNewMinor = versionInfo.FilePrivatePart;
                            versionOldMinor = versionLoad.FilePrivatePart;
                            versionNewMajor = versionInfo.FileMajorPart;
                            versionOldMajor = versionLoad.FileMajorPart;
                        }
                    }
                }
                if ((versionOldMinor < versionNewMinor) || (versionOldMajor < versionNewMajor))
                {
                    isUpdating = true;
                    NetworkCredential credentials = new NetworkCredential(SessionUser, SessionDecryptPwd);
                    urlCompose = "ftp://103.53.41.202//RMPCL_Updates/Application Files/"+ latestDir;
                }
                else
                {
                    isUpdating = false;
                }
            }
            catch (Exception Ex)
            {
                WriteToFile(Ex.Message);
            }
        }
        void DownloadFtpDirectory(string url)
        {
            try
            {
                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Ftp,
                    HostName = SessionHost,
                    UserName = Decrypt(SessionUser),
                    Password = Decrypt(SessionDecryptPwd),
                    PortNumber = 21
                };
                using (Session session = new Session())
                {
                    // Connect
                    session.Open(sessionOptions);
                    //// Download files
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;
                    RemoteDirectoryInfo directory = session.ListDirectory("/Application Files/"+ latest);
                    Console.WriteLine("Copying files to local directory...");
                    System.Threading.Thread.Sleep(20);
                    foreach (RemoteFileInfo fileInfo in directory.Files)
                    {
                        string extension = Path.GetExtension(fileInfo.Name);
                        for(int i=0;i<AllowedFiles.Count;i++)
                        {
                            if(fileInfo.Name==AllowedFiles[i].ToString())
                            {
                                session.GetFileToDirectory(fileInfo.FullName, AppCopysource, false, transferOptions);
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                WriteToFile(Ex.Message);
            }
            finally
            {
                //Console.Write(Environment.NewLine);
                Process[] procs = Process.GetProcessesByName(App.ToString());
                foreach (Process proc in procs)
                    proc.Kill();
                DirectoryInfo copyFrm =new DirectoryInfo(AppCopysource);
                DirectoryInfo copytoDir = new DirectoryInfo(AppDefaultPath);
                foreach (FileInfo file in copytoDir.GetFiles())
                {
                    //GC.Collect();
                    //GC.WaitForPendingFinalizers();
                    //System.Threading.Thread.Sleep(20);
                    //for (int  x = 0; x < AllowedFiles.Count; x++)
                    //{
                    //    if (file.Name == AllowedFiles[x])
                    //      // GC.WaitForPendingFinalizers();
                    //    //   File.Copy(file.Name, applicationManifestSecondory + @"\" + file.Name);
                    //       file.Delete();
                    //}
                    for (int x = 0; x < AllowedFiles.Count; x++)
                    {
                        if (File.Exists(Path.Combine(copytoDir.FullName, AllowedFiles[x])))
                        {
                            // If file found, delete it    
                            Process[] procs1 = Process.GetProcessesByName(App[0]);
                            foreach (Process proc in procs1)
                                proc.Kill();
                            if (procs1 != null && procs1.Length > 0)
                            {
                                procs1[0].WaitForExit(5);
                            }
                            else
                            {// GC.Collect();
                                //GC.WaitForPendingFinalizers();
                                File.Delete(Path.Combine(copytoDir.FullName, AllowedFiles[x]));
                            }
                        }
                    }
                }
                Console.WriteLine("Downloading...");
                System.Threading.Thread.Sleep(20);
                Console.WriteLine("Download Complete.");
                Console.WriteLine("Deleting Temporary files...");
                DirectoryInfo manifest1 = new DirectoryInfo(applicationManifestPrimary);
                DirectoryInfo manifest2 = new DirectoryInfo(applicationManifestSecondory);
                foreach (FileInfo DeleteFiles1 in manifest1.GetFiles())
                {
                    DeleteFiles1.Delete();
                }
                foreach (FileInfo DeleteFiles2 in manifest2.GetFiles())
                {
                    DeleteFiles2.Delete();
                }
                CopyFolder(copyFrm, copytoDir);
            }
        }

        void CopyFolder(DirectoryInfo source, DirectoryInfo target)
        {
            string nameofFile = string.Empty;
            DirectoryInfo dirFrm = target;
            try
            {
                foreach (DirectoryInfo dir in source.GetDirectories())
                    CopyFolder(dir, target.CreateSubdirectory(dir.Name));
                foreach (FileInfo file in source.GetFiles())
                    file.CopyTo((Path.Combine(target.FullName, file.Name)));
                FileInfo[] files = dirFrm.GetFiles().OrderBy(p => p.CreationTime).ToArray();
                foreach (FileInfo file in source.GetFiles())
                {
                   Console.WriteLine("Downloading files:" + " " + file.Name);
                  //  Console.WriteLine(Environment.NewLine);
                }
                foreach (FileInfo avlfile in source.GetFiles())
                    avlfile.Delete();
                string AppTostart = AppDefaultPath + @"\" + AppName;
                System.Diagnostics.Process.Start(AppTostart);
                string ProcName = System.AppDomain.CurrentDomain.FriendlyName;
                Process[] procs = Process.GetProcessesByName(ProcName);
                System.Threading.Thread.Sleep(800);
                Console.WriteLine("Stopping Service" + " " + App[0]);
                System.Threading.Thread.Sleep(800);
                Console.WriteLine("Stopping Service" + " " + "AutoUpdater");
                System.Threading.Thread.Sleep(800);
                Console.WriteLine("Starting Service" + " " + App[0]);
                System.Threading.Thread.Sleep(800);
                Process[] AutoProcs = Process.GetProcessesByName("AutoUpdater");
                foreach (Process proc in procs)
                    proc.Kill();
            }
            catch (Exception Ex)
            {
                WriteToFile(Ex.Message);
            }
        }
        public void ReadINIData()
        {
            try
            {
                //   string text = System.IO.Path.GetFullPath("DownloaderSetting.txt");
                string text = AppDomain.CurrentDomain.BaseDirectory + "DownloaderSetting.txt";
                if (File.Exists(text))
                {
                   
                }
                else
                {
                    File.Create(text);
                }
                var content = System.IO.File.ReadAllText(text);
                string[] appResource = new string[] { };
                appResource = content.Split(Environment.NewLine);
                AppCopysource = appResource[1].ToString();
                AppSource = appResource[0].ToString();
                AppDefaultPath = appResource[2].ToString();
                SessionProto = appResource[3].ToString();
                SessionHost = appResource[4].ToString();
                SessionUser = appResource[5].ToString();
                SessionDecryptPwd = appResource[6].ToString();
                applicationManifestPrimary = appResource[8].ToString();
                applicationManifestSecondory = appResource[9].ToString();
              //ApplicationArr = AppDefaultPath.Split(@"\");
                AppName = appResource[10];
            }
            catch (Exception Ex)
            {
                WriteToFile(Ex.Message);
            }
        }
        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "abc123";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}

