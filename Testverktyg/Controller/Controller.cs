using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Model;

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

        public static bool EmailExists(string email) {
            return true;
        }

        public static bool UpdateEmail(string email) {
            return true;
        }

        public static bool IsPasswordValid(string email) {
            return true;
        }

        public static string ResetPassword(AbstractUser user) {
            return null;
        }

        public static string GenerateNewPassword() {
            return null;
        }

        public static bool UpdatePassword(string password) {
            return true;
        }

        public static bool IsUserEmailValid(string email) {
            return true;
        }

        public static AbstractUser CreateUser(string name, string email, UserType userType) {
            // return null if operation fails
            // client code must check if result is null
            return null;
        }

        public static Subject CreateSubject(string name) {
            return null;
        }

        public static bool SubjectExists(string name) {
            return true;
        }

        public static bool IsSubjectValid(string name) {
            return true;
        }

        public static bool DeleteUser(AbstractUser user) {
            // if last admin, don't delete else, remove from DB
            // if student has testforms, only set IsNotRemoved = false, else delete from DB
            // if teacher has testdefinitions, only set IsNotRemoved = false, else delete from DB
            return true;
        }
    }
}
