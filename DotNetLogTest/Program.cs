using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetLog;

namespace DotNetLogTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pruebas de DotNetLog
            Logger.Error("Error", "Program");
            Logger.Critical("Critical", "Program");
            Logger.Warn("Warning", "Program");
            Logger.Info("Information", "Program");
            Logger.Info("Debug", "Program");
            Logger.setFileLogStatus(true);
            Console.WriteLine();
            Logger.Error("Error R2", "Program");
            Logger.Critical("Critical R2", "Program");
            Logger.Warn("Warning R2", "Program");
            Logger.Info("Information R2", "Program");
            Logger.Info("Debug R2", "Program");
            Console.WriteLine();
            Logger.setLogFile("test.log");
            Logger.Error("Error R3", "Program");
            Logger.Critical("Critical R3", "Program");
            Logger.Warn("Warning R3", "Program");
            Logger.Info("Information R3", "Program");
            Logger.Info("Debug R3", "Program");
            Console.ReadLine();
        }
    }
}
