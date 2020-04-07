using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileProcessor.Services.Contracts
{
    public interface IWriter
    {
        void WriteDataSynchronosly(ICollection<string> data, string path, string fileName);

        Task WriteDataAsync(ICollection<string[]> data, string path, string fileName);
    }
}
