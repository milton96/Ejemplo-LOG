using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogHelper.Models
{
    public class Log
    {
        public const string ERROR = "ERROR";
        public const string WARNING = "WARNING";
        public const string INFO = "INFO";
        private const string _BASE_PATH = @"LOGS/";

        public static void Add(string type, string method, string msg)
        {
            try
            {
                DateTime now = DateTime.Now;
                string date = now.ToString("dd/MM/yyyy HH:mm:ss zzz");
                string filename = String.Format("{0}.txt", now.ToString("dd-MM-yyyy"));
                string file = String.Format("{0}{1}", _BASE_PATH, filename);

                if (!Directory.Exists(_BASE_PATH)) Directory.CreateDirectory(_BASE_PATH);
                
                FileInfo fileInfo = new FileInfo(file);
                if (!fileInfo.Exists) fileInfo.Create();

                using (StreamWriter log = File.AppendText(file))
                {
                    string data = String.Format("[{0}] - {1} - {2} => {3}", type, date, method, msg);
                    log.WriteLine(data);
                    log.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Print(string filename)
        {
            try
            {
                string file = String.Format("{0}{1}", _BASE_PATH, filename);
                FileInfo f = new FileInfo(file);
                if (!f.Exists) throw new Exception(String.Format("No existe el archivo: {0}", filename));

                Console.ForegroundColor = ConsoleColor.White;
                using (StreamReader r = new StreamReader(file))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                    r.Close();
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
    }
}
