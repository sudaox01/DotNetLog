using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DotNetLog
{
    public class Logger
    {
        // Config, Configure your options here. This will support embedded app XML if used as a DLL soon, This is planned but this project is currently still in the works
        // and needs a lot of bug fixing, features, etc. It is nowhere near complete yet.

        private static bool LogLib_FileLog = false; // False - Don't log to file, true - Log to file
        private static string LogLib_FileName = "log.log"; // File to log to
        public static void setLogFile(string filename)
        {
            /// <summary>
            /// Set file that log is stored in for file logging
            /// </summary>
            LogLib_FileName = filename;
        }
        public static void setFileLogStatus(bool toggle)
        {
            /// <summary>
            /// Toggle logging to file
            /// </summary>
            LogLib_FileLog = toggle;
        }
        private static void doLog(int logType, string logMsg, string className)
        {
            /// <summary>
            /// Manually add a line to the log
            /// </summary>
            // 0 - Info, 1 - Debug, 2 - Error, 3 - Warning
            string logLabel = "";
            // Error Log
            // Set Log Info
            switch (logType)
            {
                case 0:
                    // Info, colour default
                    logLabel = "INFO";
                    break;
                case 1:
                    // Debug, same as info
                    logLabel = "DEBUG";
                    break;
                case 2:
                    // Error, This is where we add some red to the mix
                    logLabel = "ERROR";
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 3:
                    // Warning, we add a tiny bit of yellow! :3
                    logLabel = "WARN";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 4:
                    logLabel = "CRITICAL";
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            DateTime dt = DateTime.Now;
            string timeVal = dt.ToLongDateString() + " " + dt.ToLongTimeString();
            string tFormat = "[" + logLabel + "] " + "(" + timeVal + ") " + className + ": " + logMsg;
            Console.WriteLine(tFormat);
            Console.ResetColor();
            if (LogLib_FileLog)
            {
                // Log to File
                // Get contents of old file if exists
                string cSpec = "";
                if (File.Exists(LogLib_FileName))
                {
                    cSpec = File.ReadAllText(LogLib_FileName);
                }
                cSpec = tFormat + "\r\n" + cSpec;
                File.WriteAllText(LogLib_FileName, cSpec);
            }
        }
        // These are just stub functions to redirect to doLog easily
        public static void Info(string logMsg, string className = "")
        {
            /// <summary>
            /// Logs an info line to the log
            /// </summary>
            doLog(0, logMsg, className);
        }
        public static void Debug(string logMsg, string className = "")
        {
            /// <summary>
            /// Logs a debug line to the log
            /// </summary>
            doLog(1, logMsg, className);
        }
        public static void Error(string logMsg, string className = "")
        {
            /// <summary>
            /// Logs a error line to the log
            /// </summary>
            doLog(2, logMsg, className);
        }
        public static void Warn(string logMsg, string className = "")
        {
            /// <summary>
            /// Logs a warning line to the log
            /// </summary>
            doLog(3, logMsg, className);
        }
        public static void Critical(string logMsg, string className = "")
        {
            /// <summary>
            /// Logs a critical error line to the log
            /// </summary>
            doLog(4, logMsg, className);
        }
    }
}
