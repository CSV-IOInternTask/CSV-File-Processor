using System.Threading.Tasks;
using System.Collections.Generic;

namespace CSVFileProcessor_ConsoleApp.Services.Contracts
{
    public interface IWriter
    {
        void WriteDataSynchronosly(ICollection<string> data, string path, string fileName);

        Task WriteDataAsync(ICollection<string[]> data, string path, string fileName);
    }
}
