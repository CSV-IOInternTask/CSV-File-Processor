using System;
using System.IO;
using System.Collections.Generic;
using CSVFileProcessor_ConsoleApp.Services.Contracts;
using System.IO.Enumeration;

namespace CSVFileProcessor_ConsoleApp.Services
{
    /// <summary>
    /// Reads data from a file 
    /// </summary>
    public class Reader : IReader
    {
        private string directory;
        private string fileName;
        private string fullDirectoryFileName;

        public Reader()
        {

        }

        public Reader(string fullDirectoryFileName)
        {
            this.fullDirectoryFileName = fullDirectoryFileName;
        }

        /// <summary>
        /// Reads data from a file and returns ICollection<string> for every line
        /// </summary>
        /// <returns>ICollection<string></returns>
        public ICollection<string> Read()
        {
            var data = new List<string>();
            string line = string.Empty;

            if (fullDirectoryFileName == null)
            {
                fullDirectoryFileName = directory + fileName;
            }

            using (StreamReader str = new StreamReader(fullDirectoryFileName))
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

