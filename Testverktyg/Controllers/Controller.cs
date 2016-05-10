using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using Testverktyg.Context;
using Testverktyg.Model;
using Testverktyg.Repository;

namespace Testverktyg.Controllers
{
    static public class Controller
    {
        public static bool CreateTest(string name, Subject subject,int teacherId )
        {
            if (IsTestDefinitionNameValid(name))
            {
                var testdefinition = new TestDefinition { Title = name, Subject = subject, TestDefinitionState = TestDefinitionState.Created, Paragraph = "" };
                Repository<TestDefinition>.Instance.Add(testdefinition);
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool IsTestDefinitionNameValid(string name)
        {
            IList<TestDefinition> tds = Repository<TestDefinition>.Instance.GetAll();
            return !(tds.Any(x => x.Title == name) || String.IsNullOrWhiteSpace(name));
        }



        public static bool DeleteTestDefinition(TestDefinition testDefinition)
        {

            if (testDefinition.TestDefinitionState == TestDefinitionState.Validated)
            {
                testDefinition.IsNotRemoved = false;
                return true;
            }
            else
            {
                Repository.Repository<TestDefinition>.Instance.Delete(testDefinition);
                return true;
            }

        }

        public static bool SendTestDefinitionForValidation(TestDefinition testDefinition)
        {
            testDefinition.TestDefinitionState = TestDefinitionState.Sent;
            return true;
        }

        public static bool UpdateTestDefinition(TestDefinition testDefinition)
        {
            Repository.Repository<TestDefinition>.Instance.Update(testDefinition);
            return true;
        }

        public static IList<TestDefinition> FindTestDefinitions(string name = "", Subject subject = null)
        {

            IList<TestDefinition> list = Repository.Repository<TestDefinition>.Instance.GetAll();
            IList<TestDefinition> sortedList = new List<TestDefinition>();
            string nametolower = name.ToLower();

            foreach (var item in list)
            {

                if (item.Title.ToLower().Contains(name))
                {
                    if (subject == item.Subject)
                    {
                        sortedList.Add(item);
                    }
                    else if (subject == null)
                    {
                        sortedList.Add(item);
                    }
                }
            }

            return sortedList;
        }

        public static IList<TestForm> GetTestFormResults(TestDefinition testDefinition)
        {
            //hämta alla test forms som finns på en test definition
            IList<TestForm> forms = Repository<TestForm>.Instance.GetAll();
            IList<TestForm> neededforms = forms.Where(x => x.TestDefinitionId == testDefinition.Id).ToList();
            return neededforms;
        }

        public static IList<Tuple<string, GradeType, int, int>> GetResults(IList<TestForm> testForms)
        {
            string name;
            int testTime = 0;
            int testScore = 0;
            GradeType grade = GradeType.IG;
            Tuple<string, GradeType, int, int> tup;
            IList<Tuple<string, GradeType, int, int>> list = new List<Tuple<string, GradeType, int, int>>();
            IList<StudentAccount> stud = Repository<StudentAccount>.Instance.GetAll();

            foreach (var item in testForms)
            {
                name = stud.First(x => x.Id == item.StudentAccountId).Name;
                grade = CalcGrade(item);
                TimeSpan duration = (DateTime)item.FinishedDate - (DateTime)item.StartDate;
                testTime = (int)duration.TotalMinutes;
                testScore = item.Score;
                tup = Tuple.Create(name, grade, testScore, testTime);
                list.Add(tup);
            }

            return list;
        }

        public static Tuple<int, int, int, int, int, int> CalcStatistics(IList<TestForm> testForms) {
            int totPoints = 0;
            int totTime = 0;
            int G = 0;
            int IG = 0;
            int VG = 0;
            int nCompleted = 0;
            List<int> scores = new List<int>();

            foreach (TestForm tf in testForms) {
                if(tf.IsCompleted) {
                    nCompleted++;
                    GradeType grade = CalcGrade(tf);
                    switch (grade) {
                        case GradeType.G:
                            G++;
                            break;
                        case GradeType.VG:
                            VG++;
                            break;
                        case GradeType.IG:
                            IG++;
                            break;
                    }
                    totTime += tf.FinishedDate.Value.Minute - tf.StartDate.Value.Minute;
                    totPoints += tf.Score;
                    scores.Add(tf.Score);
                }
            }

            scores.Sort();

            int median = scores.Count % 2 == 0
                ? scores[scores.Count / 2 + 1]
                : scores[scores.Count / 2];
            
            return Tuple.Create(totPoints / nCompleted, median, totTime / nCompleted, G, VG, IG);
        }

        public static TeacherAccount GetTestDefinitionAuthor(TestDefinition testDefinition)
        {
            return Repository<TeacherAccount>.Instance.Get(testDefinition.TeacherAccountId);
        }

        public static Subject GetTestDefinitionSubject(TestDefinition testDefinition)
        {
            return Repository<Subject>.Instance.Get(testDefinition.SubjectId);
        }

        public static bool ValidateTestDefinition(TestDefinition testDefinition, int time, DateTime finalDate) {
            foreach (StudentAccount student in Repository<StudentAccount>.Instance.GetAll()) {
                student.TestForms.Add(new TestForm { TimeLimit = time, FinalDate = finalDate, TestDefinition = testDefinition });
                Repository<StudentAccount>.Instance.Update(student);
            }
            return true;
        }

        public static bool ReturnTestDefinition(TestDefinition testDefinition)
        {
            testDefinition.TestDefinitionState = TestDefinitionState.Returned;
            return true;
        }

        public static bool IsEmailValid(string email) {
            return new EmailAddressAttribute().IsValid(email) &&
                !Repository<AdminAccount>.Instance.GetAll().Any(admin => admin.Email == email) &&
                !Repository<StudentAccount>.Instance.GetAll().Any(student => student.Email == email) &&
                !Repository<TeacherAccount>.Instance.GetAll().Any(teacher => teacher.Email == email);
        }
        public static bool UpdateEmail(AbstractUser user, string email) {
            if(IsEmailValid(email)) {
                user.Email = email;
                Repository<AbstractUser>.Instance.Update(user);
                return true;
            }
            return false;
        }

        public static bool IsPasswordValid(string password) {
            return password.Length > 6;
        }

        public static bool UpdatePassword(AbstractUser user, string password) {
            if(IsPasswordValid(password)) {
                user.Password = password;
                Repository<AbstractUser>.Instance.Update(user);
                return true;
            }
            return false;
        }

        public static bool IsUserNameValid(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        public static GradeType CalcGrade(TestForm testform) {
            double G = Repository<TestDefinition>.Instance.Get(testform.TestDefinitionId).MaxScore * 0.5;
            double Vg = Repository<TestDefinition>.Instance.Get(testform.TestDefinitionId).MaxScore * 0.75;

            if (testform.Score > Vg)
                return GradeType.VG;
            else if (testform.Score > G)
                return GradeType.G;
            else
                return GradeType.IG;
        }
    }
}
