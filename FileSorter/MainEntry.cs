using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSorter
{
    class MainEntry
    {
        static void Main(string[] args)
        {
           var inputFileName = args[0];
           var fileSorter = new FileSorter(inputFileName);
           fileSorter.ReadInput();
           fileSorter.WriteOutputFile();
        }
        
        
    }
}
