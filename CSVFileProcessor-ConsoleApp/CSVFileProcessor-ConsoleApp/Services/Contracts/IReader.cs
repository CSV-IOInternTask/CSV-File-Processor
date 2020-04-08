using System.Collections.Generic;

namespace CSVFileProcessor_ConsoleApp.Services.Contracts
{
    
    public interface IReader
    {
        public ICollection<string> Read();

    }
}
