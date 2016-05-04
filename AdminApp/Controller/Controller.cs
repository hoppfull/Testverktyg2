using AdminApp.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Model;
using Testverktyg.Repository;

namespace AdminApp.Controller {
    public class Controller {

        private static Random rng = new Random();

        public static Subject CreateSubject(string name) {
            return null;
        }

        public static bool SubjectExists(string name) {
            Console.WriteLine("test");
            return true;
            
            //ss
        }

        public static bool IsSubjectValid(string name) {
            return true;
        }

        public static AbstractUser CreateUser(string name, string email, UserType userType) {
            // return null if operation fails
            // client code must check if result is null
            return null;
        }

        public static bool DeleteUser(AbstractUser user) {
            // if last admin, don't delete else, remove from DB
            // if student has testforms, only set IsNotRemoved = false, else delete from DB
            // if teacher has testdefinitions, only set IsNotRemoved = false, else delete from DB
            return true;
        }

        public static string ResetPassword(AbstractUser user) {

            user.Password = GenerateNewPassword();

            if (user is StudentAccount)
            {
                Repository<StudentAccount>.Instance.Update(user as StudentAccount);
                return user.Password;

            }
            else if (user is AdminAccount)
            {
                Repository<AdminAccount>.Instance.Update(user as AdminAccount);
                return user.Password;


            }
            else if (user is TeacherAccount)
            {
                Repository<TeacherAccount>.Instance.Update(user as TeacherAccount);
                return user.Password;

            }

            return null;
        }

        public static string GenerateNewPassword() {

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[6];
            
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[rng.Next(chars.Length)];
        
            }

            var password = new string(stringChars);
            return password;
        }
    }
}
