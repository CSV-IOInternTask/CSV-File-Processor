using CSVFileProcessor.Models;
using CSVFileProcessor.Services;
using CSVFileProcessor.Services.Contracts;
using System;

namespace CSVFileProcessor_ConsoleApp.Services
{
    public class Engine
    {
        private string Command = string.Empty;

        public void Run()
        {
            this.Command = Console.ReadLine();

            IReader reader = new Reader();
            IWriter writer = new Writer();
            CommandInterpreter commandInterperter = new CommandInterpreter();

            while(Command != "End")
            {
                commandInterperter.Interpet(Command);
            }
        }
    }
}
