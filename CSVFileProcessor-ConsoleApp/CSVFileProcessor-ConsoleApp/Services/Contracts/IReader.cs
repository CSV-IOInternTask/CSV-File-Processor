using System.Collections.Generic;

namespace CSVFileProcessor_ConsoleApp.Services.Contracts
{
    
    public interface IReader
    {
        public string Directory { get; }

        public string FileName { get; }

        public ICollection<string[]> Read();

    }
}
