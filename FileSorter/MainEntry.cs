using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileSorter
{
    class MainEntry
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                ShowUsage();
                return;
            }
           string filename = args[0];
           if (!File.Exists(filename))
           {
               ShowErrorMessage();
               return;
           }
           var inputFileName = args[0];
           var fileSorter = new ScoreSorter(inputFileName);
           fileSorter.ReadInput();
           fileSorter.WriteOutputFile();
        }
        
        static void ShowUsage()
        {
            string instruction = "Missing input file name\n Usage: FileSorter inputfilename";
            Console.WriteLine(instruction);
        }
        static void ShowErrorMessage()
        {
            string errorMessage = "Failed to open the input file\n Usage: FileSorter inputfilename";
            Console.WriteLine(errorMessage);
        }

        
    }
}
