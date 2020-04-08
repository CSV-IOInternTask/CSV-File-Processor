using CSVFileProcessor.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSVFileProcessor.Models
{
    public class Reader : IReader
    {
        public string Directory { get; set; }

        public Reader()
        {

        }

        public Reader(string directory)
        {
            this.Directory = directory;
        }

        public ICollection<string[]> Read()
        {
            List<string[]> data = new List<string[]>();
            string line = string.Empty;

            using (StreamReader str = new StreamReader(this.Directory))
            {

                while ((line = str.ReadLine()) != null)
                {
                    data.Add(line.Split(new char[] { '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries));
                }
            }
            return data;
        }
    }
}
