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
        //public static bool f(TestForm testForm) {
        //    var qs = Repository<Question>.Instance.GetAll()
        //        .Where(x => x.TestDefinitionId == testForm.TestDefinitionId);

        //    int score = 0;

        //    foreach (Question q in qs) {
        //        AnsweredQuestion answeredQuestion = Repository<AnsweredQuestion>.Instance.GetAll()
        //            .First(aq => aq.QuestionId == q.Id && aq.TestFormId == testForm.Id);

        //        Answer[] userAnswers = Repository<Answer>.Instance.GetAll()
        //            .Where(answer => answer.AnswerQuestionId == answeredQuestion.Id).ToArray();

        //        Answer[] rightAnswers = Repository<Answer>.Instance.GetAll()
        //            .Where(answer => answer.QuestionId == q.Id).ToArray();
                
        //        for (int i = 0; i < userAnswers.Length; i++) {
        //            if (userAnswers[i].CheckedOrRanked == rightAnswers[i].CheckedOrRanked && userAnswers[i].Text == rightAnswers[i].Text) {
        //                score += q.Score;
        //                break;
        //            }
        //        }
        //    }

        //    if (score > 0) {
        //        testForm.Score = score;
        //        Repository<TestForm>.Instance.Update(testForm);
        //        return true;
        //    }
        //    return false;
        //}

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
                userAnswers.AddRange(Repository<Answer>.Instance.GetAll().Where(x => x.AnswerQuestionId == item.Id));
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
