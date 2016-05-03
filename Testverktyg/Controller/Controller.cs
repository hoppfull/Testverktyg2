using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Model;
using Testverktyg.Context;

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

        public static bool DeleteTestDefinition(string name) {
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

        public static bool UpdateEmail(StudentAccount selectedStudentAccount, string email) {
            // hint: mylist.Exists(x => x.Email == email);
            return true;
        }

        public static bool IsPasswordValid(string email) {
            return true;
        }

        public static bool UpdatePassword(string password) {
            return true;
        }

        public static bool IsUserEmailValid(string email) {
            return true;
        }
    }
}
