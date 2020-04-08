using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CSVFileProcessor_ConsoleApp.Core.Contracts;
using CSVFileProcessor_ConsoleApp.Models;
using CSVFileProcessor_ConsoleApp.Services;
using CSVFileProcessor_ConsoleApp.Services.Contracts;

namespace CSVFileProcessor_ConsoleApp.Core
{
    /// <summary>
    /// The IO main class. Main logic is called here.
    /// </summary>
    public class Engine : IEngine
    {

        public Engine()
        {
        }

        public void Run()
        {
            IReader reader;
            IWriter writer;

            Console.WriteLine("Read directory with file name and file format: ");
            string readDirectory = Console.ReadLine();

            Console.WriteLine("Directory to write in: ");
            string writeDirectory = Console.ReadLine();

            Console.WriteLine("new File names to be written: ");
            string fileNameToWrite = Console.ReadLine();

            Console.WriteLine("To how many files would you like the data to be split.");
            Console.WriteLine("The default is set to 10.");
            string filesCount = Console.ReadLine();

            if (int.TryParse(filesCount, out int x))
            {
                reader = new Reader(readDirectory);
                writer = new Writer(x);
            }
            else
            {
                reader = new Reader(readDirectory);
                writer = new Writer();
            }

            var stopwatch = new Stopwatch();
            Console.WriteLine("Timer has started.");
            stopwatch.Start();

            writer.WriteDataSynchronosly(reader.Read(), writeDirectory, fileNameToWrite);

            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
        }
    }
}
