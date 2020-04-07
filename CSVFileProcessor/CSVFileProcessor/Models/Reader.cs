using CSVFileProcessor.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSVFileProcessor.Models
{
    class Reader : IReader
    {
        public string Directory { get; set; }

        public Reader(string directory)
        {
            this.Directory = directory;
        }

        public ICollection<string> Read(string directory)
        {
            using (StreamReader str = new StreamReader(directory))
            {
                List<string> data = new List<string>();
                string line = string.Empty;

                while((line = str.ReadLine()) != null)
                {
                    data.Add(line.Split(new char[] { '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToString());
                }
                ;
                return data;
            }
        }
    }
}
