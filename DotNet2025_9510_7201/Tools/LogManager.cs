using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Tools
{
    public class LogManager
    {
        static string LogDirPath = "Log";
        static int day = DateTime.Now.Day;
        static int month = DateTime.Now.Month;
        static int year = DateTime.Now.Year;


        //החזרת ניתוב
        public static string PathFile()
        {
            return $@"{PathDir()}/{day}";
        }
        public static string PathDir()
        {
            return $@"{LogDirPath}/{year}/{month}";
        }



        //יצירת קובץ
        private static void CreateLogFile()
        {
            DirectoryInfo logDir = Directory.CreateDirectory(LogDirPath);
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            //בדיקה האם קיימת תיקיה לשנה הנוכחית
            if (!Directory.Exists($@"{logDir.FullName}\{year}"))
            {
                //יוצרים תת תיקיה עבור השנה
                logDir.CreateSubdirectory(year.ToString());
            }

            //בדיקה האם קיימת תיקיה לחודש הנוכחי
            if (!Directory.Exists($@"{logDir.FullName}\{year}\{month}"))
            {
                //יוצרים תת תיקיה עבור השנה
                logDir.CreateSubdirectory($@"{year}\{month}");
            }
            if (!File.Exists($@"{logDir.FullName}\{year}\{month}\{day}.txt"))
            {
                File.Create($@"{logDir.FullName}\{year}\{month}\{day}.txt").Close();
            }
        }


        //כותבת לקובץ וקוראת לפונקצית יצירת קובץ
        public static void WriteToLog(string message)
        {
            CreateLogFile();
            DirectoryInfo logDir = Directory.CreateDirectory(LogDirPath);
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            string filePath = $@"{logDir}\{year}\{month}\{day}.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(message);
            }
        }

        //כתיבה לפי תבנית בהתחלה 7
        public static void WriteStart(string projectName,string methodName, string message = null)
        {
            WriteToLog($"{DateTime.Now}\t{projectName}.{methodName}\t{message}");
        }
        public static void WriteEnd(string projectName, string methodName, string message = null)
        {
            WriteToLog($"{DateTime.Now}\t{projectName}.{methodName}\t{message}");
        }

        // ניקוי תיקיית לוג 8
        public static void DeletFiles()
        {
            DirectoryInfo mainLogDir=new DirectoryInfo(LogDirPath); 
            DateTime m = DateTime.Now.AddMonths(-2);
            foreach(DirectoryInfo dir in mainLogDir.GetDirectories())
            {
                if(dir.CreationTime < m)
                    dir.Delete(true);
            }
        }

    }
}
