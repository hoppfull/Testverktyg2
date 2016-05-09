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
            TestDefinition testdef = testForm.TestDefinition;

            //compare answers with rigth answer
            foreach (var item in testForm.AnsweredQuestions)
            {

            }

            GradeType grade = Controller.CalcGrade(testForm);

            //Save to databas
            return false;
        }
    }
}
