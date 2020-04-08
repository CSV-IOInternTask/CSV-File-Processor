using CSVFileProcessor.Models;
using CSVFileProcessor.Services;
using CSVFileProcessor.Services.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSVFileProcessor_ConsoleApp.Services
{
    public class Engine
    {
        private List<string> Command;

        public Engine()
        {
            this.Command = new List<string>();
        }

        public void Run()
        {
            this.ShowConsoleUI();
            this.Command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            IReader reader = new Reader();
            IWriter writer = new Writer();
            CommandInterpreter commandInterperter = new CommandInterpreter();

            while (Command[0].ToLower() != "end")
            {
                commandInterperter.Interpet(Command[0]);
            }
        }

        public void ShowConsoleUI()
        {
            Console.WriteLine("-------UI------");
            Console.WriteLine("---Commands: SetFilePath {FilePath} // SetFileName {FileName} // FilesCount {FileCountNumber}");
        }
    }
}
