using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LogHandler
{
    public static class ZipLog
    {
        public static string ZipLogfile(string fileName)
        {
            DateTime thisDate = DateTime.Now;
            string zipFile = fileName.Remove(fileName.Length - 4) + ".zip";

            using (ZipFile zip = new ZipFile())
            {
                zip.AddFile(fileName, "");
                zip.Save(zipFile);
            }

            return zipFile;
        }
    }
}
