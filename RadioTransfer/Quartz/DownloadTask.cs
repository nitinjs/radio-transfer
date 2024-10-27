using FluentFTP;
using Quartz;
using ScraperApp;
using SQLiteSample.Persistence;
using SQLjobScheduler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Thornton.Data;
using WinSCP;

namespace Thornton.Scheduler.Quartz
{
    public class DownloadTask : IJob
    {
        readonly static Uri SomeBaseUri = new Uri("http://canbeanything");

        static string GetFileNameFromUrl(string url)
        {
            Uri uri;
            if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
                uri = new Uri(SomeBaseUri, url);

            return Path.GetFileName(uri.LocalPath);
        }

        static string GetFileExtensionFromUrl(string url)
        {
            Uri uri;
            if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
                uri = new Uri(SomeBaseUri, url);

            return Path.GetExtension(uri.LocalPath);
        }

        public string BuildFileNameFromMacro(string fileNameWithMacro)
        {
            string FileName = fileNameWithMacro.Substring(0, fileNameWithMacro.LastIndexOf("."));// GetFileNameFromUrl(fileNameWithMacro);
            string extension = GetFileExtensionFromUrl(fileNameWithMacro);

            var macro = string.Empty;
            var macroExpression = string.Empty;

            var dt = DateTime.Now;

            //get text between the tags
            Regex regex = new Regex("[{]{1}[-]*[^{-]+[}]{1}");
            var v = regex.Match(FileName);
            string s = v.Groups[0].ToString();
            string[] splitted = s.Replace("{", "").Replace("}", "").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (splitted.Count() > 1)
            {
                int count = Convert.ToInt32(splitted[0]);
                dt = DateTime.Now.AddDays(count);
            }

            if (splitted.Length == 1)
                return fileNameWithMacro.Replace("{0:}", "");

            if (splitted.Length == 0)
                return fileNameWithMacro;

            foreach (var tag in splitted[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string expression = tag.Replace("\"", "");
                macro += dt.ToString(expression) + " ";
            }

            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                macro = macro.Replace(c, '-');
            }
            macro = macro.Replace(',', ' ');

            macro = macro.Trim();

            //refresh text of macro output
            if (fileNameWithMacro.StartsWith("{") == false)
            {
                return (FileName.Substring(0, FileName.IndexOf(" {")) + " " + macro).Trim() + extension;
            }
            else
            {
                return (macro + " " + FileName.Substring(FileName.IndexOf("} ") + 2, FileName.Length - FileName.IndexOf("} ") - 2).Trim()) + extension;
            }
        }

        public void Execute(IJobExecutionContext context)
        {
            var dataMap = context.JobDetail.JobDataMap;
            var id = Convert.ToInt32(dataMap["id"]);
            using (ThorntonContext db = new ThorntonContext())
            {
                var schedule = db.SQLschedules.Where(x => x.SQLscheduleId == id).First();
                if (schedule.IsProcessing == false && schedule.enabled)
                {
                    TaskExecutionLog log = new TaskExecutionLog();
                    log.ExecutedDateTime = DateTime.Now;
                    log.SQLscheduleId = id;
                    log.Description = "Task execution started";
                    db.TaskExecutionLogs.Add(log);
                    db.SaveChanges();

                    schedule.IsProcessing = true;
                    db.Entry<SQLschedule>(schedule).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    try
                    {
                        switch (schedule.TaskTypeId)
                        {
                            case TaskTypes.FTP:
                                {
                                    //New code
                                    try
                                    {
                                        // Setup session options
                                        SessionOptions sessionOptions = new SessionOptions
                                        {
                                            Protocol = (schedule.FTP_Protocol == 1 ? Protocol.Sftp : Protocol.Ftp),
                                            HostName = schedule.FTP_Host
                                        };



                                        if (schedule.FTP_LogonType == 1)
                                        {
                                            sessionOptions.UserName = schedule.FTP_UserName;
                                            sessionOptions.Password = schedule.FTP_Password;

                                            //sessionOptions.SshHostKeyFingerprint = "ssh-rsa 2048 xx:xx:xx:xx:xx:xx:xx:xx..."
                                        }

                                        if (sessionOptions.Protocol == Protocol.Sftp || sessionOptions.Protocol == Protocol.Scp)
                                        {
                                            sessionOptions.GiveUpSecurityAndAcceptAnySshHostKey = true;
                                            sessionOptions.GiveUpSecurityAndAcceptAnyTlsHostCertificate = true;
                                        }

                                        sessionOptions.FtpMode = schedule.FTP_IsPassive ? FtpMode.Passive : FtpMode.Active;

                                        using (Session session = new Session())
                                        {
                                            string outputFilePath = schedule.OutputPath;

                                            // Connect
                                            session.Open(sessionOptions);

                                            TaskExecutionLog log3 = new TaskExecutionLog();
                                            log3.ExecutedDateTime = DateTime.Now;
                                            log3.SQLscheduleId = id;
                                            log3.Description = "Connected to FTP server";
                                            db.TaskExecutionLogs.Add(log3);
                                            db.SaveChanges();

                                            // Download files
                                            TransferOptions transferOptions = new TransferOptions();
                                            transferOptions.TransferMode = TransferMode.Binary;

                                            transferOptions.PreserveTimestamp = true;

                                            TransferOperationResult transferResult;
                                            if (schedule.FTP_SyncSubdirectories)
                                            {
                                                //session.GetFiles(schedule.FTP_Path + ("/*"), schedule.OutputPath, false, transferOptions);
                                                var result = session.SynchronizeDirectories(SynchronizationMode.Local, schedule.OutputPath, schedule.FTP_Path, false, true, SynchronizationCriteria.Time, transferOptions);
                                                result.Check();

                                                // Print results
                                                //foreach (TransferEventArgs transfer in result.Transfers)
                                                //{
                                                //    Console.WriteLine("Download of {0} succeeded", outputFilePath);
                                                //}
                                            }
                                            else
                                            {
                                                string outputFile = schedule.OutputPath + "\\" + BuildFileNameFromMacro(schedule.OutputFileName);
                                                transferResult =
                                                session.GetFiles(schedule.FTP_Path + (""), outputFile, false, transferOptions);

                                                // Throw on any error
                                                transferResult.Check();


                                            // Print results
                                            foreach (TransferEventArgs transfer in transferResult.Transfers)
                                            {
                                                Console.WriteLine("Download of {0} succeeded", outputFilePath);
                                            }
                                            }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        //File.WriteAllText(outputPath + System.Guid.NewGuid().ToString() + "-Error.txt", ex.Message);
                                        TaskExecutionLog logError = new TaskExecutionLog();
                                        logError.ExecutedDateTime = DateTime.Now;
                                        logError.SQLscheduleId = id;
                                        logError.Description = e.Message;
                                        db.TaskExecutionLogs.Add(logError);
                                        db.SaveChanges();
                                    }
                                }
                                #region OLD Code
                                /*string outputPath = schedule.OutputPath + "\\";
                                try
                                {
                                    // create an FTP client
                                    FtpClient client = new FtpClient(schedule.FTP_Host);
                                    client.Port = schedule.FTP_Port;

                                    if (schedule.FTP_LogonType == 1)
                                    {
                                        // if you don't specify login credentials, we use the "anonymous" user account
                                        client.Credentials = new NetworkCredential(schedule.FTP_UserName, schedule.FTP_Password);
                                    }
                                    client.Connect();

                                    TaskExecutionLog log3 = new TaskExecutionLog();
                                    log3.ExecutedDateTime = DateTime.Now;
                                    log3.SQLscheduleId = id;
                                    log3.Description = "Connected to FTP server";
                                    db.TaskExecutionLogs.Add(log3);
                                    db.SaveChanges();

                                    // get a list of files and directories in the "/htdocs" folder
                                    foreach (FtpListItem item in schedule.FTP_SyncSubdirectories ? client.GetListing(schedule.FTP_Path, FtpListOption.Recursive) : client.GetListing(schedule.FTP_Path))
                                    {
                                        // if this is a file
                                        if (item.Type == FtpFileSystemObjectType.File)
                                        {
                                            string fileName = item.Name;
                                            string outputFilePath = outputPath + fileName;
                                            // get the file size
                                            long size = client.GetFileSize(item.FullName);
                                            if (schedule.RenameOldFile)
                                            {
                                                if (File.Exists(outputFilePath))
                                                {
                                                    FileInfo fileInfo = new FileInfo(outputFilePath);
                                                    string dateTimeAppend = fileInfo.CreationTime.ToString("(ddMMMyyyy HH-mm-ss)");
                                                    string newName = schedule.OutputPath + "\\" + outputFilePath.Insert(outputFilePath.LastIndexOf("."), dateTimeAppend);
                                                    fileInfo.MoveTo(newName);
                                                }

                                                // download the file
                                                client.DownloadFile(outputFilePath, item.FullName);

                                                TaskExecutionLog log4 = new TaskExecutionLog();
                                                log4.ExecutedDateTime = DateTime.Now;
                                                log4.SQLscheduleId = id;
                                                log4.Description = "Downloaded file '" + item.FullName + "' to '" + outputFilePath + "'";
                                                db.TaskExecutionLogs.Add(log4);
                                                db.SaveChanges();
                                            }
                                            else
                                            {
                                                if (File.Exists(outputFilePath))
                                                {
                                                    long length = new System.IO.FileInfo(outputFilePath).Length;
                                                    if (length != size)
                                                    {
                                                        // download the file again
                                                        client.DownloadFile(outputFilePath, item.FullName);

                                                        TaskExecutionLog log4 = new TaskExecutionLog();
                                                        log4.ExecutedDateTime = DateTime.Now;
                                                        log4.SQLscheduleId = id;
                                                        log4.Description = "Downloaded file '" + item.FullName + "' to '" + outputFilePath + "'";
                                                        db.TaskExecutionLogs.Add(log4);
                                                        db.SaveChanges();
                                                    }
                                                }
                                                else
                                                {
                                                    // download the file
                                                    client.DownloadFile(outputFilePath, item.FullName);

                                                    TaskExecutionLog log4 = new TaskExecutionLog();
                                                    log4.ExecutedDateTime = DateTime.Now;
                                                    log4.SQLscheduleId = id;
                                                    log4.Description = "Downloaded file '" + item.FullName + "' to '" + outputFilePath + "'";
                                                    db.TaskExecutionLogs.Add(log4);
                                                    db.SaveChanges();
                                                }
                                            }
                                        }
                                    }

                                    client.Disconnect();
                                }
                                catch (Exception ex)
                                {
                                    //File.WriteAllText(outputPath + System.Guid.NewGuid().ToString() + "-Error.txt", ex.Message);
                                    TaskExecutionLog logError = new TaskExecutionLog();
                                    logError.ExecutedDateTime = DateTime.Now;
                                    logError.SQLscheduleId = id;
                                    logError.Description = ex.Message;
                                    db.TaskExecutionLogs.Add(logError);
                                    db.SaveChanges();
                                }
                                */
                                #endregion
                                break;
                            case TaskTypes.RSS:
                            case TaskTypes.HTTP:
                                {
                                    string outputFile = "";
                                    if (!string.IsNullOrWhiteSpace(schedule.OutputFileName))//override file name
                                    {
                                        outputFile = schedule.OutputPath + "\\" + BuildFileNameFromMacro(schedule.OutputFileName);

                                        //if (File.Exists(outputFile))//rename old file if file of same name exists
                                        //{
                                        //    FileInfo fileInfo = new FileInfo(outputFile);
                                        //    //string dateTimeAppend = fileInfo.CreationTime.ToString("(ddMMMyyyy HH-mm-ss)");
                                        //    //string outputFileName = schedule.OutputFileName;
                                        //    string newName = schedule.OutputPath + "\\" + BuildFileNameFromMacro(schedule.OutputFileName);
                                        //    fileInfo.MoveTo(newName);
                                        //}
                                    }
                                    else
                                    {
                                        outputFile = schedule.OutputPath + "\\" + BuildFileNameFromMacro(schedule.Path);

                                        //if (File.Exists(outputFile))//rename old file if file of same name exists
                                        //{
                                        //    FileInfo fileInfo = new FileInfo(outputFile);
                                        //    //string dateTimeAppend = fileInfo.CreationTime.ToString("(ddMMMyyyy HH-mm-ss)");
                                        //    //string outputFileName = GetFileNameFromUrl(schedule.Path);
                                        //    string newName = schedule.OutputPath + "\\" + BuildFileNameFromMacro(schedule.OutputFileName);
                                        //    fileInfo.MoveTo(newName);
                                        //}
                                    }

                                    try
                                    {
                                        var client = new ScraperWebClient();
                                        if (!string.IsNullOrWhiteSpace(schedule.Path))
                                        {
                                            client.DownloadFile(schedule.Path, outputFile);

                                            TaskExecutionLog log4 = new TaskExecutionLog();
                                            log4.ExecutedDateTime = DateTime.Now;
                                            log4.SQLscheduleId = id;
                                            log4.Description = "Downloaded file '" + schedule.Path + "' to '" + outputFile + "'";
                                            db.TaskExecutionLogs.Add(log4);
                                            db.SaveChanges();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        //File.WriteAllText(outputFile + "-Error.txt", ex.Message);
                                        TaskExecutionLog logError = new TaskExecutionLog();
                                        logError.ExecutedDateTime = DateTime.Now;
                                        logError.SQLscheduleId = id;
                                        logError.Description = ex.Message;
                                        db.TaskExecutionLogs.Add(logError);
                                        db.SaveChanges();
                                    }
                                }
                                break;
                            case TaskTypes.GoogleDrive:
                                {
                                    string outputFile = schedule.OutputPath + "\\" + BuildFileNameFromMacro(schedule.OutputFileName);
                                    try
                                    {
                                        if (!File.Exists(outputFile) && !string.IsNullOrWhiteSpace(schedule.Path))
                                        {
                                            GDriveDownloader.DownloadFileFromURLToPath(schedule.Path, outputFile);

                                            TaskExecutionLog log4 = new TaskExecutionLog();
                                            log4.ExecutedDateTime = DateTime.Now;
                                            log4.SQLscheduleId = id;
                                            log4.Description = "Downloaded google drive file '" + schedule.Path + "' to '" + outputFile + "'";
                                            db.TaskExecutionLogs.Add(log4);
                                            db.SaveChanges();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        //File.WriteAllText(outputFile + "-Error.txt", ex.Message);
                                        TaskExecutionLog logError = new TaskExecutionLog();
                                        logError.ExecutedDateTime = DateTime.Now;
                                        logError.SQLscheduleId = id;
                                        logError.Description = ex.Message;
                                        db.TaskExecutionLogs.Add(logError);
                                        db.SaveChanges();
                                    }
                                }
                                break;
                            case TaskTypes.Dropbox:
                                {
                                    string outputFile = schedule.OutputPath + "\\" + BuildFileNameFromMacro(schedule.OutputFileName);
                                    try
                                    {
                                        if (!File.Exists(outputFile) && !string.IsNullOrWhiteSpace(schedule.Path))
                                        {
                                            var client = new ScraperWebClient();

                                            //https://www.dropbox.com/s/a1b2c3d4ef5gh6/example.docx?dl=1
                                            string dropboxUrl = schedule.Path;
                                            var uriBuilder = new UriBuilder(dropboxUrl);
                                            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                                            if (query.AllKeys.Contains("dl"))
                                            {
                                                query["dl"] = "1";
                                            }
                                            else
                                            {
                                                query.Add("dl", "1");
                                            }
                                            uriBuilder.Query = query.ToString();
                                            dropboxUrl = uriBuilder.ToString();

                                            client.DownloadFile(dropboxUrl, outputFile);

                                            TaskExecutionLog log4 = new TaskExecutionLog();
                                            log4.ExecutedDateTime = DateTime.Now;
                                            log4.SQLscheduleId = id;
                                            log4.Description = "Downloaded dropbox file '" + dropboxUrl + "' to '" + outputFile + "'";
                                            db.TaskExecutionLogs.Add(log4);
                                            db.SaveChanges();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        //File.WriteAllText(outputFile + "-Error.txt", ex.Message);
                                        TaskExecutionLog logError = new TaskExecutionLog();
                                        logError.ExecutedDateTime = DateTime.Now;
                                        logError.SQLscheduleId = id;
                                        logError.Description = ex.Message;
                                        db.TaskExecutionLogs.Add(logError);
                                        db.SaveChanges();
                                    }
                                }
                                break;
                            case TaskTypes.NetworkFolder:
                                {
                                    string outputFile = schedule.OutputPath + "\\" + BuildFileNameFromMacro(schedule.OutputFileName);
                                    File.Copy(schedule.Path, outputFile, true);

                                    TaskExecutionLog log4 = new TaskExecutionLog();
                                    log4.ExecutedDateTime = DateTime.Now;
                                    log4.SQLscheduleId = id;
                                    log4.Description = "Downloaded network file '" + schedule.Path + "' to '" + outputFile + "'";
                                    db.TaskExecutionLogs.Add(log4);
                                    db.SaveChanges();
                                }
                                break;
                        }
                    }
                    catch (Exception ex5)
                    {
                        TaskExecutionLog log5 = new TaskExecutionLog();
                        log5.ExecutedDateTime = DateTime.Now;
                        log5.SQLscheduleId = id;
                        log5.Description = ex5.Message;
                        db.TaskExecutionLogs.Add(log5);
                    }

                    schedule.IsProcessing = false;
                    db.Entry<SQLschedule>(schedule).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    TaskExecutionLog log2 = new TaskExecutionLog();
                    log2.ExecutedDateTime = DateTime.Now;
                    log2.SQLscheduleId = id;
                    log2.Description = "Task execution finished";
                    db.TaskExecutionLogs.Add(log2);
                    db.SaveChanges();
                }
            }
        }
    }
}
