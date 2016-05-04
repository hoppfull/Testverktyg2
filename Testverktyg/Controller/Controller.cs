using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using Testverktyg.Context;
using Testverktyg.Model;
using Testverktyg.Repository;

namespace Testverktyg.Controller
{
    static public class Controller
    {
        public static bool CreateTest(string name, Subject subject)
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
            //Check if exist
            //Andreas
            return true;
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
            return null;
            //Rickard
        }

        public static IList<TestForm> GetTestFormResults(TestDefinition testDefinition)
        {
            //hämta alla test forms som finns på en test definition
            //Andreas
            return null;
        }

        public static IList<Tuple<string, GradeType, int, int>> GetResults(IList<TestForm> testForms)
        {
            //Rickard
            // Get student related to each testform
            // return studentname * grade * time * score
            return null;
        }

        public static Tuple<int, int, int, int, int, int, int> CalcStatistics(IList<Tuple<string, GradeType, int, int>> result)
        {
            int totPoints = 0;
            int totTime = 0;
            int G =0;
            int IG = 0;
            int VG = 0;
            int median;
            List<int> listofpoints = new List<int>();
            foreach (var item in result)
            {
                totPoints += item.Item3;
                listofpoints.Add(item.Item3);
                totTime += item.Item4;
                switch (item.Item2)
                {
                    case GradeType.G:
                        G++;
                        break;
                    case GradeType.IG:
                        IG++;
                        break;
                    case GradeType.VG:
                        VG++;
                        break;
                    default:
                        break;
                }
            }
            listofpoints.Sort();
            if (listofpoints.Count % 2 == 0)
            {
                int x = listofpoints.Count / 2;
                median = listofpoints[x] + listofpoints[x + 1] / 2;
            }
            else
            {
                median = listofpoints[listofpoints.Count/2+1];
            }
            int avgPoints  = totPoints / result.Count();
            int avgTime = totTime / result.Count();

            return Tuple.Create(avgPoints, avgTime, median, G, IG, VG, result.Count);
        }

        public static string GetTestDefinitionAuthorName(TestDefinition testDefinition)
        {
            return Repository<TeacherAccount>.Instance.Get(testDefinition.TeacherAccountId).Name;
        }

        public static bool ValidateTestDefinition(TestDefinition testDefinition, IList<StudentAccount> studentAccounts, int time, DateTime finalDate)
        {
            //Create a Test for each user

            foreach (var item in studentAccounts)
            {
                item.TestForms.Add(new TestForm { TimeLimit = time, FinalDate = finalDate, TestDefinition = testDefinition});
                Repository.Repository<StudentAccount>.Instance.Update(item);
            }

            return true;
        }

        public static bool ReturnTestDefinition(TestDefinition testDefinition)
        {
            testDefinition.TestDefinitionState = TestDefinitionState.Returned;
            return true;
        }

        public static bool IsEmailValid(string email)
        {

            if (!new EmailAddressAttribute().IsValid(email))
            {
                return false;
            }
            List<string> emails = new List<string>();
            foreach (var item in Repository.Repository<AdminAccount>.Instance.GetAll()) { emails.Add(item.Email); }
            foreach (var item in Repository.Repository<StudentAccount>.Instance.GetAll()) { emails.Add(item.Email); }
            foreach (var item in Repository.Repository<TeacherAccount>.Instance.GetAll()) { emails.Add(item.Email); }
            return !(emails.Any(x => x == email));
        }

        public static bool UpdateEmail(AbstractUser user, string email)
        {
            if (IsEmailValid(email))
            {
                user.Email = email;

                if (user is StudentAccount)
                {
                    Repository.Repository<StudentAccount>.Instance.Update(user as StudentAccount);
                    return true;
                }
                else if (user is AdminAccount)
                {
                    Repository.Repository<AdminAccount>.Instance.Update(user as AdminAccount);
                    return true;
                }
                else if (user is TeacherAccount)
                {
                    Repository.Repository<TeacherAccount>.Instance.Update(user as TeacherAccount);
                    return true;
                }
            }
            return false;
        }

        public static bool IsPasswordValid(string password)
        {

            if (password.Length <= 6)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool UpdatePassword(AbstractUser user, string password)
        {

            user.Password = password;

            if (user is StudentAccount)
            {
                Repository.Repository<StudentAccount>.Instance.Update(user as StudentAccount);
                return true;

            }
            else if (user is AdminAccount)
            {
                Repository.Repository<AdminAccount>.Instance.Update(user as AdminAccount);
                return true;


            }
            else if (user is TeacherAccount)
            {
                Repository.Repository<TeacherAccount>.Instance.Update(user as TeacherAccount);
                return true;

            }
            return true;
        }

        public static bool IsUserNameValid(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }
    }
}
