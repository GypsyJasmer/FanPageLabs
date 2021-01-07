using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRockFanPage.Models
{
    public class QuizVM
    {
        //User andswers and correct answers for the questions. 
        public string UserAnswer1 { get; set; }

        public string RightOrWrong1 { get; set; }

        public string UserAnswer2 { get; set; }

        public string RightOrWrong2 { get; set; }

        public string UserAnswer3 { get; set; }

        public string RightOrWrong3 { get; set; }

        //checks each answer to see if it's correct
        //Return "Right" or "Wrong"
        public void CheckAnswers()
        {
            RightOrWrong1 = UserAnswer1 == "1972" ? "Right" : "Wrong";
            RightOrWrong2 = UserAnswer2 == "Scorpion King" ? "Right" : "Wrong";
            RightOrWrong3 = UserAnswer3 == "Madison Square Garden" ? "Right" : "Wrong";
        }


    }
}
