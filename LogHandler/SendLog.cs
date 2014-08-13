using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace LogHandler
{
    public static class SendLog
    {
        public static void SendToVizzit(string file, string customerId)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.vizzit.se/" + customerId + "/" + file);
            request.UseBinary = true;
            request.KeepAlive = true;
            request.Method = WebRequestMethods.Ftp.UploadFile;

            request.Credentials = new NetworkCredential("upload", "upload");

            byte[] fileContents = File.ReadAllBytes(file);
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            response.Close();
        }
    }
}
