using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LogHandler
{
    public static class GetLog
    {
        public static void CopyLog(string logPath, string fileName, string destFileName)        
        {           
            File.Copy(Path.Combine(logPath, fileName), Path.Combine(System.IO.Directory.GetCurrentDirectory(), destFileName));
        }
    }
}
