using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Model;
using Testverktyg.Repository;

namespace StudentApp.Controller
{
    public static class StudentController
    {

        public static bool TestFormCalculateScore(TestForm testForm)
        {
            TestDefinition testdef = testForm.TestDefinition;

            //compare answers with rigth answer
            foreach (var item in testForm.AnsweredQuestions)
            {

            }

            GradeType grade = Testverktyg.Controller.Controller.CalcGrade(testForm);

            //Save to databas
            return false;
        }
    }
}
