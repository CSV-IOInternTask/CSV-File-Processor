using System;
using System.Collections.Generic;
using System.Linq;

using CSVFileProcessor_ConsoleApp.Models;
using CSVFileProcessor_ConsoleApp.Services.Contracts;

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
            

            IReader reader = new Reader();
            IWriter writer = new Writer();
            CommandInterpreter commandInterperter = new CommandInterpreter();

            while (Command[0].ToLower() != "end")
            {
                this.Command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                commandInterperter.Interpet(Command[0], Command[1], reader, writer);
            }
        }

        public void ShowConsoleUI()
        {
            Console.WriteLine("-------UI------");
            Console.WriteLine("---Commands: SetFilePath {FilePath} // SetFileName {FileName} // FilesCount {FileCountNumber}");
        }
    }
}
