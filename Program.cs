using FTPApp3.Models;
using FTPApp3.Models.Students;
using System;
using Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FTPApp3.Models.Constants;
using FTPApp3.Models.Utilities.FTP;

namespace FTPApp3
{
    class Program
    {
        public static string directory { get; private set; }
        public static object errors { get; private set; }

        static void Main(string[] args)
        {

            //Question 1 retrieve a list of directories from FTP & Output to Console
            string imagesOutputFolder = @"C: \Users\Sophie N. Kellman\FTPApp3\Content";
            List<string> errors = new List<string>();
            List<Student> students = new List<Student>();
            List<string> directories = FTP.GetDirectory(Constants.FTP.BaseUrl);

            foreach (var directory in directories)
            {
                Console.WriteLine(directory);

                Student student = new Student();

                student.FromDirectory(directory);



                //Question 2 Search for a file named info.csv to report on whether my file exists
                if (FTP.FileExists(Constants.FTP.BaseUrl + "/" + "200471222 Sophie Kellman" + "/info.csv"))

                //Does the file exist?
                {
                    Console.WriteLine("    info.csv exists");

                    //Questions 3 and 4 also in Student class to capture and retrieve student info programmatically
                    var fileBytes = FTP.DownloadFileBytes(FTP.BaseUrl + "/" + directory + "/info.csv");
                    string infoCsvData = Encoding.UTF8.GetString(fileBytes, 0, fileBytes.Length);

                    string[] lines = infoCsvData.Split("r\n", StringSplitOptions.RemoveEmptyEntries);

                }
                else
                {
                    errors.Add(directory + "- info.csv does not exist");
                    Console.WriteLine("    info.csv does not exist");
                }

                //Question 2b Search for a file named myimage.jpg to report on data

                bool exists = FTP.FileExists(Constants.FTP.BaseUrl + $"/" + "200471222 Sophie Kellman" + "/myimage.jpg");

                //Does the file exist?
                if (exists == true)
                {
                    Console.WriteLine("myimage.jpg exists");

                    string downloadFileResult = FTP.DownloadFile(Constants.FTP.BaseUrl + $"/{directory}/myimage.jpg", imagesOutputFolder + "\\" + directory + ".jpg");
                    Console.WriteLine(downloadFileResult);
                }

                else
                {
                    errors.Add(directory + "- myimage.jpg does not exist");
                    Console.WriteLine("   myimage.jpg does not exist");
                }
                students.Add(student);
                //Question 2c Search for a file named info.html to report on data


                if (FTP.FileExists(Constants.FTP.BaseUrl + $"/{directory}/info.html"))
                {
                    Console.WriteLine("info.html exists");
                }
                else
                {
                    errors.Add(directory + "- info.html does not exist");
                    Console.WriteLine("   info.html does not exist");
                }
            }

                if (errors.Count > 0)
            {
                    Console.WriteLine("Found errors");
            foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
            }

                if (students.Count > 0)
            {
                Console.WriteLine("Found students");
            foreach (var student in students)
                {
                Console.WriteLine(students);
                }
            }

                if (students.Count > 0)
            {
                Console.WriteLine("Found {students.Count} students");
                foreach (var student in students.OrderBy(x => x.LastName))
                {
                Console.WriteLine(student);
                }
            }
                //CONTAINS
            foreach (Student student in students)
            {
                char LastName = default;
                bool cont = directory.Contains(LastName);
                {
                    Console.WriteLine("Directory contains student.");

                }
            }
            {
             foreach (var directory in directories)
            {
                Console.WriteLine(directory);

                Student student = new Student();
               // Creating and initializing new string 
                string myRecord = "200471222 Sophie Kellman";

                student.FromDirectory(directory).Find(myRecord, element => element.StartsWith("200471222", StringComparison.Ordinal)); ;
                    Console.WriteLine("Directory contains Sophie Kellman");
                }
            }


            //{
            //StartsWith
            //if (students.StartsWith.FirstName("S"))
            //{
            //}
            //Console.WriteLine(student);
            //}

            //}
            //}
            {
                foreach (var directory in directories)
                {
                    //Average Age for Question 5.1.e
                    List<int> studage = new List<int> { };

                    double average = studage.Average();

                    Console.WriteLine("The average age is {0}.", average);
                }
            }
            foreach (var student in students)
            {
            List<int> maxAge = new List<int> { };
                              
                    Console.WriteLine("The maximum age is {0}.");
            }

                    
        
            //Download files
            string remoteDownloadFilePath = "/StudentId FirstName LastName/info.csv";
            //Path to a valid folder and the new file to be saved
            string localDownloadFileDestination = @"C:\Users\Sophie N. Kellman\FTPApp3\Content\info2.csv";
            Console.WriteLine(FTP.DownloadFile(Constants.FTP.BaseUrl + remoteDownloadFilePath, localDownloadFileDestination));
        }
    }
}
      