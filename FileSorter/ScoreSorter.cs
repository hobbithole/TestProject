using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileSorter
{
    public class ScoreSorter
    {
        private string _filename;
        List<UserScore> userGrades = new List<UserScore>();
        public ScoreSorter()
        {

        }
        public ScoreSorter(string filename)
        {
            _filename = filename;
        }

        public bool ReadInput()
        {
            try
            {
                using (var reader = new System.IO.StreamReader(_filename))
                {
                    ReadInput(reader);
                }
                
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool WriteOutputFile()
        {
            try
            {
                using (var writer = new StreamWriter(GetOutputfilename(_filename)))
                {
                    WriteOutputFile(writer);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void ReadInput(TextReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var userScore = UserScore.Parse(line);
                if (userScore != null)
                    userGrades.Add(userScore);
            }
        }
        public void WriteOutputFile(TextWriter writer)
        {
            List<UserScore> sortedList;
            sortedList = (from ug in userGrades orderby ug.Score descending , ug.Lastname , ug.Firstname  select ug).ToList();
            foreach (var userGrade in sortedList)
            {
                writer.WriteLine(userGrade.ToString());
            }
        }
        
       public string GetOutputfilename(string filename)
       {
           var pathName = Path.GetDirectoryName(filename);
           
           if (String.IsNullOrEmpty(pathName))
           {
               return Path.GetFileNameWithoutExtension(filename) + "-graded.txt";
           }

           return pathName + "\\" + Path.GetFileNameWithoutExtension(filename) + "-graded.txt";
       }

    }
}
