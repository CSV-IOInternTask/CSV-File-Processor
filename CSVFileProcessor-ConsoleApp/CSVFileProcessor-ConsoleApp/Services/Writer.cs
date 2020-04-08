using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using CSVFileProcessor_ConsoleApp.Services.Contracts;

namespace CSVFileProcessor_ConsoleApp.Services
{
    /// <summary>
    /// Writes the input data to the assigned directory;
    /// </summary>
    public class Writer : IWriter
    {
        #region Fields
        /// <value>The default count of files to be split.</value>
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
        /// <summary>
        /// Writes the input data into separate files Synchronosly.
        /// </summary>
        /// <param name="data">Data to be written.</param>
        /// <param name="path">The path to the directory.</param>
        /// <param name="fileName">The new name of file to be written.</param>
        public void WriteDataSynchronosly(ICollection<string> data, string path, string fileName)
        {
            int counter = 1;
            string fullPath = path + @"\" + fileName + "_{0}.csv";

            var splitData = this.SplitData(data.ToList());

            foreach (var arr in splitData)
            {
                using (var writer = new StreamWriter(string.Format(fullPath, counter++)))
                {
                    foreach (var line in arr)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
        /// <summary>
        /// Writes the input data into separate files Asynchronosly.
        /// </summary>
        /// <param name="data">Data to be written.</param>
        /// <param name="path">The path to the directory.</param>
        /// <param name="fileName">The new name of file to be written.</param>
        public async Task WriteDataAsync(ICollection<string> data, string path, string fileName)
        {
            var tasks = new List<Task>();

            int counter = 1;
            string fullPath = path + @"\" + fileName + "_{0}.csv";

            var splitData = this.SplitData(data.ToList());

            foreach (var arr in splitData)
            {
                tasks.Add(GetTaskWriter(arr, string.Format(fullPath, counter++)));
            }

            await Task.WhenAll(tasks);
        }
        /// <summary>
        /// Generates a Task for an idividual file to be writen at the given location.
        /// </summary>
        /// <param name="arr">Data to be written.</param>
        /// <param name="path">The path to the directory.</param>
        private async Task GetTaskWriter(string[] arr, string path)
        {
            using (var writer = new StreamWriter(path))
            {
                foreach (var item in arr)
                {
                    await writer.WriteLineAsync(item);
                }
            }
        }

        /// <summary>
        /// Splits the data into an even portions to be written to a new files.
        /// </summary>
        /// <param name="data">The data to be split.</param>
        /// <returns></returns>
        private ICollection<string[]> SplitData(List<string> data)
        {
            var result = new List<string[]>();
            int fileCount = data.Count / fileSplitter;

            for (int i = 1; i <= fileSplitter; i++)
            {
                if (i == fileSplitter)
                {
                    result.Add(data.ToArray());
                }
                else
                {
                    result.Add(data.Take(fileCount).ToArray());
                    data.RemoveRange(0, fileCount);
                }
            }

            return result;
        }

        #endregion
    }
}
