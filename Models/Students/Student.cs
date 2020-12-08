using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace FTPApp3.Models.Students
{
    public class Student
    {
        public string StudentID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StudentCode { get; set; }

        private string _DateofBirthString;
        public string DateofBirthString
        {
            get { 
                return _DateofBirthString; 
            }
            set 
            { 
                _DateofBirthString = value;

                DateTime datetime;
                if (DateTime.TryParse(_DateofBirthString, out datetime) == true) 
                {
                    DateOfBirth = datetime;
                }
            
            }
        }             
        
         
        public DateTime DateOfBirth { get; set; }

        private string _imageData;
     
        public string ImageData
        {
            get { return _imageData; }
            set { 
                _imageData = value;
                Image = FTPApp3.Models.Utilities.Converter.Base64ToImage(_imageData);
        }
    }


        public Image Image { get; set; }

        public void FromDirectory(string directory)
        {
            string[] directoryPart = directory.Split(" ", StringSplitOptions.None);

            StudentCode = directoryPart[0];
            FirstName = directoryPart[1];
            LastName = directoryPart[2];
        }
        public override string ToString()
        {
            return $"{StudentCode} - {LastName}, {FirstName}";
        }

        public void FromCsv(string csvDataLine)
        {
            string[] csvDataLineProps = csvDataLine.Split("\r\n ", StringSplitOptions.None);

            StudentCode = csvDataLineProps[0];
            FirstName = csvDataLineProps[1];
            LastName = csvDataLineProps[2];
            DateofBirthString = csvDataLineProps[3];
            ImageData = csvDataLineProps[4];
        }
        public virtual int age
        {
            get
            {
                DateTime Now = DateTime.Now;
                int Years = new DateTime(DateTime.Now.Subtract(DateOfBirth).Ticks).Year - 1;
                DateTime PastYearDate = DateOfBirth.AddYears(Years);
                int Months = 0;
                for (int i = 1; i <= 12; i++)
                {
                    if (PastYearDate.AddMonths(i) == Now)
                    {
                        Months = i;
                        break;
                    }
                    else if (PastYearDate.AddMonths(i) >= Now)
                    {
                        Months = i - 1;
                        break;
                    }
                }
                int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
                int Hours = Now.Subtract(PastYearDate).Hours;
                int Minutes = Now.Subtract(PastYearDate).Minutes;
                int Seconds = Now.Subtract(PastYearDate).Seconds;
                return Years;
            }
        }


    }
}
