﻿using System;
using System.Data.SqlClient;
using System.IO;

namespace NorthWNDSuppliersV2
{
    public static class Logger
    {
        public static string errorLogPath;
        
        public static void ExceptionMessage(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(ex.Message);
            Console.WriteLine();
            Console.WriteLine(ex.StackTrace);

            Console.ResetColor();
        }

        public static void SqlExceptionLog(SqlException sqlEx)
        {
            ExceptionLog(sqlEx, sqlEx.Server);
        }

        public static void ExceptionLog(Exception ex, string server)
        {
            StreamWriter sw = new StreamWriter(errorLogPath, true);

            sw.WriteLine("*****************************");
            sw.WriteLine();
            sw.WriteLine();
            sw.WriteLine("{0:MMMM dd, yyyy, hh:mm tt}", DateTime.Now);
            sw.WriteLine();
            sw.WriteLine(ex.Message);
            sw.WriteLine();

            if (server != string.Empty)
            {
                sw.WriteLine(server);
                sw.WriteLine();
            }

            sw.WriteLine(ex.StackTrace);

            sw.WriteLine();
            sw.WriteLine("*****************************");

            sw.Close();
            sw.Dispose();
        }
    }
}
