using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ScoreFileSorter
{

    /// <summary>
    ///  This class performs the function of sorting scores
    /// </summary>
    public class ScoreSorter
    {
        private string _filename;
        private List<UserScore> _userScores = new List<UserScore>();
        public ScoreSorter()
        {

        }
        /// <summary>
        ///  constructor takes input file name
        /// </summary>
        public ScoreSorter(string filename)
        {
            _filename = filename;
        }

        /// <summary>
        ///  Read input stream content into internal list
        /// </summary>
        /// <returns>boolean indicating the succcess or failure of the operation</returns>
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
        /// <summary>
        ///  Write sorted scores to output stream
        /// </summary>
        /// <returns>boolean indicating the succcess or failure of the operation</returns>
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
        /// <summary>
        ///  Read input stream content into internal list
        /// </summary>
        /// <param name="reader">TextReader input</param>
        /// <returns>boolean indicating the succcess or failure of the operation</returns>
        public void ReadInput(TextReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var userScore = UserScore.Parse(line);
                if (userScore != null)
                    _userScores.Add(userScore);
            }
        }
        /// <summary>
        ///  Write sorted scores to output stream
        /// </summary>
        /// <param name="writer">textwriter output</param>
        /// <returns>boolean indicating the succcess or failure of the operation</returns>
        public void WriteOutputFile(TextWriter writer)
        {
            var sortedList = (from ug in _userScores orderby ug.Score descending , ug.Lastname , ug.Firstname  select ug).ToList();
            foreach (var userGrade in sortedList)
            {
                writer.WriteLine(userGrade.ToString());
            }
        }

        /// <summary>
        ///  Get output filename as specified by the spec; sample.txt -> sample-graded.txt
        /// </summary>
        /// <param name="filename">input file name</param>
        /// <returns>output file name</returns>      
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
