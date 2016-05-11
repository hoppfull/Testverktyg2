using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Model;
using Testverktyg.Repository;
using Testverktyg.Controllers;

namespace StudentApp.Controllers
{
    public static class StudentController
    {
        public static int CalculateScore(IList<Question> userAnswers, IList<Question> correctAnswers)
        {
            int score = 0;

            for (int i = 0; i < correctAnswers.Count; i++)
            {
                bool allCorrect = true;

                if (correctAnswers[i].QuestionType != QuestionType.Open)
                {
                    for (int j = 0; j < correctAnswers[i].Answers.Count; j++)
                    {
                        if (userAnswers[i].Answers[j].CheckedOrRanked != correctAnswers[i].Answers[j].CheckedOrRanked)
                        {
                            allCorrect = false;
                        }
                    }
                }
                else //if question is open
                {
                    if (correctAnswers[i].Answers[0].Text.ToLower() != userAnswers[i].Answers[0].Text.ToLower())
                    {
                        allCorrect = false;
                    }
                }

                if (allCorrect == true) score += correctAnswers[i].Score;

            }
            return score;
        }
    }
}
