namespace CSVFileProcessor.Services.Contracts
{
    using System.Collections.Generic;
    public interface IReader
    {
        public string Directory { get; }

        public string FileName { get; }

        public ICollection<string[]> Read();

    }
}
