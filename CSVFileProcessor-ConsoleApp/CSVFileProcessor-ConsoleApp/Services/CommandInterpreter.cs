using System.Collections.Generic;
using System.Linq;

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

        public void Interpet(string command)
        {
            if (this.knownCommands.Any(x => x.ToLower() == command.ToLower()))
            {
                switch (command)
                {
                    case "SetFilePath":
                        
                    default:
                        return;

                }
            }
        }
    }
}
