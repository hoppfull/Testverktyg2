using System;
using System.Collections.Generic;
using System.Linq;
using Testverktyg.Model;
using Testverktyg.Repository;

namespace Testverktyg.Controller {
    static public class Controller {
        public static bool CreateTest(string name, Subject subject) {
            return true;
        }

        public static bool IsTestDefinitionNameValid(string name) {
            return true;
        }

        public static bool TestDefinitionNameExists(string name) {
            return true;
        }

        public static bool DeleteTestDefinition(TestDefinition testDefinition) {
            // if validated, do not delete, only set IsNotRemoved = false
            return true;
        }

        public static bool SendTestDefinitionForValidation(TestDefinition testDefinition) {
            return true;
        }

        public static bool UpdateTestDefinition(TestDefinition testDefinition) {
            return true;
        }

        public static IList<TestDefinition> FindTestDefinitions(string name = "", Subject subject = null) {
            return null;
        }

        public static IList<TestForm> GetTestFormResults(TestDefinition testDefinition) {
            return null;
        }

        public static IList<Tuple<string, GradeType, int, int>> GetResults(IList<TestForm> testForms) {
            // Get student related to each testform
            // return studentname * grade * time * score
            return null;
        }

        public static Tuple<int, int, int, int, int, int, int> CalcStatistics(IList<Tuple<string, GradeType, int, int>> result) {
            return null;
        }

        public static string GetTestDefinitionAuthorName(TestDefinition testDefinition) {
            return null;
        }

        public static bool ValidateTestDefinition(TestDefinition testDefinition, IList<StudentAccount> studentAccounts, int time, DateTime finalDate) {
            return true;
        }

        public static bool ReturnTestDefinition(TestDefinition testDefinition) {
            // Necessary?
            return true;
        }

        public static bool IsEmailValid(string email) {
                return true;
        }

        public static bool UpdateEmail(AbstractUser user, string email) {
            // hint, check if exists: mylist.Exists(x => x.Email == email);
            // Hint:
            //user.Email = email;
            //if(user is StudentAccount) {
            //    Repository.Repository<StudentAccount>.Instance.Update(user as StudentAccount);
            //}
            return true;
        }

        public static bool IsPasswordValid(string email) {
            return true;
        }

        public static bool UpdatePassword(AbstractUser user, string password) {
            // Hint:
            //user.Password = password;
            //if(user is StudentAccount) {
            //    Repository.Repository<StudentAccount>.Instance.Update(user as StudentAccount);
            //}
            return true;
        }

        public static bool IsUserNameValid(string name) {
            // Check if name makes sense... if you like... or whatever
            return true;
        }
    }
}
