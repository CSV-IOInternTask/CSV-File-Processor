using CSVFileProcessor.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;

namespace CSVFileProcessor.Models
{
    /// <summary>
    /// Reads data from a file 
    /// </summary>
    public class Reader : IReader
    {
        public string Directory { get; set; }

        public string FileName { get; set; }

        private ICollection<string[]> Data { get; set; }

        public Reader()
        {
            Data = new List<string[]>();
        }

        public Reader(string directory, string fileName)
            :this()
        {
            this.Directory = directory;
            this.FileName = fileName;
        }

        /// <summary>
        /// Reads data from a file and returns ICollection<String[]> for every line
        /// </summary>
        /// <returns>ICollection<String[]></returns>
        public ICollection<string[]> Read()
        {
            string line = string.Empty;

            using (StreamReader str = new StreamReader(this.Directory + this.FileName))
            {

                while ((line = str.ReadLine()) != null)
                {
                    Data.Add(line.Split(new char[] { '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries));
                }
            }
            return Data;
        }

    }
}

