using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LogHandler
{
    public class RunVizzitJob
    {
        string fileName;
        string zipFile;

        public RunVizzitJob(string logPath, string customerId, List<string> dateArray)
        {
            foreach(string date in dateArray)
            {
                fileName = SetFileName(date);
                string destFileName = fileName.Remove(0, 2);

                GetLog.CopyLog(logPath, fileName, destFileName);
                zipFile = ZipLog.ZipLogfile(destFileName);
                SendLog.SendToVizzit(zipFile, customerId);
                CleanUp(destFileName);
            }
        }

        private void CleanUp(string destFileName)
        {
            File.Delete(zipFile);
            File.Delete(destFileName);
        }
        
        private string SetFileName(string date)
        {
            return "u_ex" + date +".log";
        }
    }
}
