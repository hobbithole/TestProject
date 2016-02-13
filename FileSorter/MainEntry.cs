using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ScoreFileSorter
{
    class MainEntry
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
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

            var fileSorter = new ScoreSorter(filename);
            if (!fileSorter.ReadInput())
            {
                ShowOperationErrorMessage();
            }

            if (!fileSorter.WriteOutputFile())
            {
                ShowOperationErrorMessage();
            }
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
        static void ShowOperationErrorMessage()
        {
            string errorMessage = "The operation failed. Please check your input file format and check again.\n" +
                                  "User score line should be in the format of lastname, firstname, score";
            Console.WriteLine(errorMessage);
        }


    }
}
