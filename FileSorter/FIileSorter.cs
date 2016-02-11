using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileSorter
{
    public class FileSorter
    {
        private string _filename;
        List<UserGrade> userGrades = new List<UserGrade>();
        public FileSorter(string filename)
        {
            _filename = filename;
        }
        public bool ReadInput()
        {
            string line;
            StreamReader file = new System.IO.StreamReader(_filename);
            while ((line = file.ReadLine()) != null)
            {
                var userGrade = UserGrade.Parse(line);
                if (userGrade != null)
                    userGrades.Add(userGrade);
            }

            file.Close();
            return true;
        }

        
        public bool WriteOutputFile()
        {
            List<UserGrade> sortedList;
            sortedList = (from ug in userGrades orderby ug.Score, ug.Lastname, ug.Firstname select ug).ToList();
            using (System.IO.StreamWriter file =
            new StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt"))
            {
                foreach (var userGrade in sortedList)
                {
                    file.WriteLine(userGrade.ToString());
                }
            }
            return true;
        }
        

    }
}
