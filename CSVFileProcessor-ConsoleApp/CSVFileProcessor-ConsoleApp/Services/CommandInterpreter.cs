using System.Linq;
using System.Collections.Generic;
using CSVFileProcessor_ConsoleApp.Models;

namespace CSVFileProcessor_ConsoleApp.Services
{
    public class CommandInterpreter
    {
        private readonly List<string> knownCommands;
        public CommandInterpreter()
        {
            knownCommands = new List<string>()
            {
                "SetFilePath",
                "SetFileName",
                "FilesCount",

            };
        }

        public void Interpet(string command, string commandParameter, Reader reader, Writer writer)
        {
            if (this.knownCommands.Any(x => x.ToLower() == command.ToLower()))
            {
                switch (command)
                {
                    case "SetFilePath":
                            reader.Directory = commandParameter;
                    default:
                        return;

                }
            }
        }
    }
}
