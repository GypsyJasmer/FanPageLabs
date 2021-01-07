using System;
using TheRockFanPage.Models;
using Xunit;

namespace Tests
{
    public class FanClubTest
    {
        [Fact]
        //Test when user gives correct answers
        public void RightAnswerTest()
        {
            //Arrange
            var quiz = new QuizVM()
            {
                UserAnswer1 = "1972",
                UserAnswer2 = "Scorpion King",
                UserAnswer3 = "Madison Square Garden"
            };

            //Act
            quiz.CheckAnswers();

            //Assert
            Assert.True("Right" == quiz.RightOrWrong1 && "Right" == quiz.RightOrWrong2 && "Right" == quiz.RightOrWrong3);
        }

        [Fact]
        //Test when user gives wrong answers 
        public void WrongAnswerTest()
        {
            //Arrange
            var quiz = new QuizVM()
            {
                UserAnswer1 = "1970",
                UserAnswer2 = "The Rundown",
                UserAnswer3 = "Staples Center "
            };

            //Act
            quiz.CheckAnswers();

            //Assert
            Assert.True("Wrong" == quiz.RightOrWrong1 && "Wrong" == quiz.RightOrWrong2 && "Wrong" == quiz.RightOrWrong3);
        }
    }
}
