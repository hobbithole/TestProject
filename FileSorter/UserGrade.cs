using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSorter
{
    public class UserGrade
    {
        public string Firstname  {get;set;}
        public string Lastname  {get; set;}
        public uint Score       { get; set; }

        public static UserGrade Parse(string userGradeString)
        {
            var userGradeArray = userGradeString.Split(",".ToArray());
            //exit if the record does not have three entries 
            if (userGradeArray.Length != 3)
                return null;
            //check the grade is integer
            uint score = 0;
            if (!uint.TryParse(userGradeArray[2], out score))
                return null;
            return new UserGrade()
            {
                Firstname = userGradeArray[0],
                Lastname = userGradeArray[1],
                Score    = score
            };

        }

        public override string ToString()
        {
            StringBuilder userGradeString = new StringBuilder();
            userGradeString.AppendFormat("{0},{1},{2}", Firstname, Lastname, Score);
            return userGradeString.ToString();
        }
    }
}
