using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class FileHelper
    {
        public string EntryFilePath { get; set; }
        public string SolutionFilePath { get; set; }
        public string StatsFilePath { get; set; }

        public FileHelper(string entryFilePath)
        {
            EntryFilePath = entryFilePath;
        }

        public void ReadFromFile()
        {

        }
    }
}
