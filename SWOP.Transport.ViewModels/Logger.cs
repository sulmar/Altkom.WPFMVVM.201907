using System;
using System.Collections.Generic;
using System.Text;

namespace SWOP.Transport.ViewModels
{
    public class Logger
    {
        public delegate void Log(string message);

        public Log Write;


        //public void WriteTxt(string message)
        //{
        //    Console.WriteLine($"text file {message}");
        //}

        //public void WriteDb(string message)
        //{
        //    Console.WriteLine($"db {message}");
        //}
    }
}
