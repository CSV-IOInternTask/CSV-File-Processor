using System;
using System.Collections.Generic;
using System.Linq;
using CSVFileProcessor_ConsoleApp.Core.Contracts;
using CSVFileProcessor_ConsoleApp.Models;
using CSVFileProcessor_ConsoleApp.Services;
using CSVFileProcessor_ConsoleApp.Services.Contracts;

namespace CSVFileProcessor_ConsoleApp.Core
{
    public class Engine : IEngine
    {

        public Engine()
        {
        }

        public void Run()
        {
            Console.WriteLine("Read directory: ");
            string readDirectory = Console.ReadLine();

            Console.WriteLine("Directory to write: ");
            string writeDirectory = Console.ReadLine();

            Console.WriteLine("File name to write: ");
            string fileNameToWrite = Console.ReadLine();

            IReader reader = new Reader(readDirectory);
            IWriter writer = new Writer();

            writer.WriteDataSynchronosly(reader.Read(), writeDirectory, fileNameToWrite);


            
        }
    }
}
