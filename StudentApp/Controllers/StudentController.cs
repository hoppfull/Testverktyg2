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

        public static bool TestFormCalculateScore(TestForm testForm)
        {

            var td = Repository<TestDefinition>.Instance.Get(testForm.TestDefinitionId);
            var questions = Repository<Question>.Instance.GetAll().Where(x => x.TestDefinitionId == td.Id).ToList();
            var answerquestions = Repository<AnsweredQuestion>.Instance.GetAll().Where(x => x.TestFormId == testForm.Id);
            var rightAnswers = new List<Answer>();
            var userAnswers = new List<Answer>();
            int userScore = 0;

            foreach (var item in questions)
            {
              rightAnswers.AddRange(Repository<Answer>.Instance.GetAll().Where(x => x.QuestionId == item.Id));
                
            }
            foreach (var item in answerquestions)
            {
                //userAnswers.AddRange(Repository<Answer>.Instance.GetAll().Where(x => x.AnswerQuestionId == item.Id));
            }

            for (int i = 0; i < questions.Count-1; i++)
            {

                if (questions[i].QuestionType == QuestionType.Single)
                {
                    var correct = true;
                    var currentRightAnswers = rightAnswers.Where(x => x.QuestionId == questions[i].Id).ToList();
                    var currentUserAnswers = userAnswers.Where(x => x.QuestionId == questions[i].Id).ToList();
                    for (int j = 0; j < currentRightAnswers.Count-1; j++)
                    {
                        if (currentRightAnswers[j].CheckedOrRanked != currentUserAnswers[j].CheckedOrRanked)
                        {
                            correct = false;
                            break;
                        }
                
                    }
                    if (correct == true)
                    {
                    userScore += questions[i].Score;
                    }
                }
                if (questions[i].QuestionType == QuestionType.Multi)
                {
                    var correct = true;
                    var currentRightAnswers = rightAnswers.Where(x => x.QuestionId == questions[i].Id).ToList();
                    var currentUserAnswers = userAnswers.Where(x => x.QuestionId == questions[i].Id).ToList();
                    for (int j = 0; j < currentRightAnswers.Count - 1; j++)
                    {
                        if (currentRightAnswers[j].CheckedOrRanked != currentUserAnswers[j].CheckedOrRanked)
                        {
                            correct = false;
                            break;
                        }

                    }
                    if (correct == true)
                    {
                        userScore += questions[i].Score;
                    }
                }
                if (questions[i].QuestionType == QuestionType.Ranked)
                {
                    var correct = true;
                    var currentRightAnswers = rightAnswers.Where(x => x.QuestionId == questions[i].Id).ToList();
                    var currentUserAnswers = userAnswers.Where(x => x.QuestionId == questions[i].Id).ToList();
                    for (int j = 0; j < currentRightAnswers.Count - 1; j++)
                    {
                        if (currentRightAnswers[j].CheckedOrRanked != currentUserAnswers[j].CheckedOrRanked)
                        {
                            correct = false;
                            break;
                        }

                    }
                    if (correct == true)
                    {
                        userScore += questions[i].Score;
                    }
                }
                if (questions[i].QuestionType == QuestionType.Open)
                {
                    var correct = true;
                    var currentRightAnswers = rightAnswers.Where(x => x.QuestionId == questions[i].Id).ToList();
                    var currentUserAnswers = userAnswers.Where(x => x.QuestionId == questions[i].Id).ToList();
                    for (int j = 0; j < currentRightAnswers.Count - 1; j++)
                    {
                        if (currentRightAnswers[j].CheckedOrRanked != currentUserAnswers[j].CheckedOrRanked)
                        {
                            correct = false;
                            break;
                        }

                    }
                    if (correct == true)
                    {
                        userScore += questions[i].Score;
                    }
                }
            }

            GradeType grade = Controller.CalcGrade(testForm);

            //Save to databas
            return false;
        }
    }
}
