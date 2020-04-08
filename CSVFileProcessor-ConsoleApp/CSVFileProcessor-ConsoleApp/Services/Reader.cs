using System;
using System.IO;
using System.Collections.Generic;
using CSVFileProcessor_ConsoleApp.Services.Contracts;
using System.IO.Enumeration;

namespace CSVFileProcessor_ConsoleApp.Models
{
    /// <summary>
    /// Reads data from a file 
    /// </summary>
    public class Reader : IReader
    {
        private string directory;
        private string fileName;
        private string fullDirectoryFileName;

        public Reader(string fullDirectoryFileName)
        {
            this.fullDirectoryFileName = fullDirectoryFileName;
        }

        public Reader(string directory, string fileName)
        {
            this.directory = directory;
            this.fileName = fileName;
        }

        /// <summary>
        /// Reads data from a file and returns ICollection<String[]> for every line
        /// </summary>
        /// <returns>ICollection<String[]></returns>
        public ICollection<string> Read(string fullDirectoryFileName = null)
        {
            var data = new List<string>();
            string line = string.Empty;

            string path = fullDirectoryFileName;

            if (path == null)
            {
                path = directory + fileName;
            }

            using (StreamReader str = new StreamReader(path))
            {

                while ((line = str.ReadLine()) != null)
                {
                    data.Add(line);
                }
            }

            return data;
        }

    }
}

