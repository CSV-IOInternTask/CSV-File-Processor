using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CSVFileProcessor.Services.Contracts
{
    interface IReader
    {
        public string Directory { get; }

        public ICollection<string[]> Read();



    }
}
