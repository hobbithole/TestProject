using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScoreFileSorter
{
    /// <summary>
    ///  UserScore class
    /// </summary>
    public class UserScore
    {
        public string Firstname {get;set;}
        public string Lastname  {get; set;}
        public uint   Score     { get; set; }

        /// <summary>
        ///  create a userScore instance from string 
        /// format: lastname, firstname, score
        /// </summary>
        /// <param name="userScoreString"></param>
        /// <returns>UserScore instance or null if the input string does not conform to the specified format</returns>
        public static UserScore Parse(string userScoreString)
        {
            var userGradeArray = userScoreString.Split(",".ToArray());
            //exit if the record does not have three entries 
            if (userGradeArray.Length != 3)
                return null;
            //check the grade is integer
            uint score;
            if (!uint.TryParse(userGradeArray[2], out score))
                return null;
            return new UserScore()
            {
                Lastname = userGradeArray[0].Trim(),
                Firstname  = userGradeArray[1].Trim(),
                Score    = score
            };
        }
        /// <summary>
        /// 
        /// overrite ToString function
        /// </summary>
        /// <returns>UserScore string. Format: lastname, firstname, score</returns>
        public override string ToString()
        {
            StringBuilder userGradeString = new StringBuilder();
            userGradeString.AppendFormat("{0}, {1}, {2}", Lastname, Firstname, Score);
            return userGradeString.ToString();
        }
    }
}
