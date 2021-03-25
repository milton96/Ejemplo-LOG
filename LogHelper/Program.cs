using LogHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int a = Int32.Parse("asd");
            }
            catch (Exception ex)
            {
                Log.Add(Log.ERROR, "String parse to Int32", ex.Message);
            }

            if (6 != 7)
            {
                Log.Add(Log.WARNING, "Comparar valores", "Los valores son diferentes.");
            }

            Log.Add(Log.INFO, "Main", "Pruebas finalizadas.");

            Log.Print("24-03-2021.txt");
            Console.ReadKey();
        }
    }
}
