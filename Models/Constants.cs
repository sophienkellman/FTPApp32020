using System;
using System.Collections.Generic;
using System.Text;

namespace FTPApp3.Models
{
    public class Constants
    {

        public class FTP
        {
            public const string UserName = @"bdat100119f\bdat1001";
            public const string Password = "bdat1001";

            public const string BaseUrl = "ftp://waws-prod-dm1-127.ftp.azurewebsites.windows.net/bdat1001-10983";

            public const int OperationPauseTime = 10000;

            public static bool FileExists(string v1);
           
            public static List<string> GetDirectory(string baseUrl);
       
            public static string DownloadFile(string v1, string v2);
            
        
        public class Credentials
        {
            public const string UserName = "<yourusername>";
            public const string Password = "<yourpassword>";
        }

        public class Urls
        {
            public const string BaseUrl = "https://webapibasicsstudenttracker.azurewebsites.net/api/students";

            public static readonly string BaseUrlApi = $"{BaseUrl}/api";

            public const string GetStudentsUnsecure = "/students";
            public const string GetStudentsSecure = "/securestudents";

            public const string PostToken = "/Tokens";

        }

    }
}