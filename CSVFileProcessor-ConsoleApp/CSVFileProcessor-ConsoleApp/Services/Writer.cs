using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using CSVFileProcessor.Services.Contracts;

namespace CSVFileProcessor.Services
{
    public class Writer : IWriter
    {
        #region Fields

        private const int DefaultFileSpliter = 10;

        private int fileSplitter;

        #endregion

        #region Initialization

        public Writer()
        {
            this.fileSplitter = DefaultFileSpliter;
        }

        public Writer(int fileSpliter)
        {
            this.fileSplitter = fileSpliter;
        }

        #endregion

        #region Funcionality

        public void WriteDataSynchronosly(ICollection<string> data, string path, string fileName)
        {
            int counter = 1;
            string fullPath = path + fileName + $"_{counter++}";

            var splitData = this.SplitData(data.ToList());

            foreach (var arr in data)
            {
                using (var writer = new StreamWriter(fullPath))
                {
                    foreach (var line in arr)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }

        public Task WriteDataAsync(ICollection<string[]> data, string path, string fileName)
        {
            throw new NotImplementedException();
        }

        private ICollection<string[]> SplitData(List<string> data)
        {
            var result = new List<string[]>();
            int fileCount = data.Count / DefaultFileSpliter;

            for (int i = 1; i <= DefaultFileSpliter; i++)
            {
                switch (i)
                {
                    case DefaultFileSpliter:
                        result.Add(data.ToArray());
                        break;
                    default:
                        result.Add(data.Take(fileCount).ToArray());
                        data.RemoveRange(0, fileCount);
                        break;
                }
            }

            return result;
        }

        #endregion
    }
}
