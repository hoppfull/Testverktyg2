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
            var testdefinition = new TestDefinition {Title = name, Subject = subject,TestDefinitionState = TestDefinitionState.Created, Paragraph = "" };

            Repository<TestDefinition>.Instance.Add(testdefinition);
            return true;
        }

        
        public static bool IsTestDefinitionNameValid(string name)
        {
            return true;
        }

        public static bool TestDefinitionNameExists(string name)
        {
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
            return true;
        }

        public static bool UpdateTestDefinition(TestDefinition testDefinition)
        {
            return true;
        }

        public static IList<TestDefinition> FindTestDefinitions(string name = "", Subject subject = null)
        {
            return null;
        }

        public static IList<TestForm> GetTestFormResults(TestDefinition testDefinition)
        {
            return null;
        }

        public static IList<Tuple<string, GradeType, int, int>> GetResults(IList<TestForm> testForms)
        {
            // Get student related to each testform
            // return studentname * grade * time * score
            return null;
        }

        public static Tuple<int, int, int, int, int, int, int> CalcStatistics(IList<Tuple<string, GradeType, int, int>> result)
        {
            //Tuple tup = new Tuple<int, int, int, int, int, int, int>;

            foreach (var item in result)
            {
                //item.
            }

            return null;
        }

        public static string GetTestDefinitionAuthorName(TestDefinition testDefinition)
        {

            using (var db = new TestverktygContext())
            {
                List<TeacherAccount> list = new List<TeacherAccount>();
                foreach (var item in Repository<TeacherAccount>.Instance.GetAll())
                {
                    TeacherAccount t = db.TeacherAccounts.Where(x => x.Id == item.Id).Include(x => x.TestDefinitions).First();
                    list.Add(t);
                }
                return list.First(x => x.TestDefinitions.Any(y => y.Id == testDefinition.Id)).Name;
            }
            
        }

        public static bool ValidateTestDefinition(TestDefinition testDefinition, IList<StudentAccount> studentAccounts, int time, DateTime finalDate)
        {
            //Create a Test for each user

            foreach (var item in studentAccounts)
            {
                item.TestForms.Add(new TestForm(time, finalDate, testDefinition));
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
