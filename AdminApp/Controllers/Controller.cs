using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Model;
using Testverktyg.Repository;

namespace AdminApp.Controllers
{
    public class Controller
    {

        private static Random rng = new Random();

        public static Subject CreateSubject(string name)
        {

            if (IsSubjectValid(name))
            {
                var subject = new Subject { Name = name };
                Repository<Subject>.Instance.Add(subject);
                return subject;
            }
            return null;
        }

        public static bool IsSubjectValid(string name)
        {
            IList<Subject> subjects = Repository<Subject>.Instance.GetAll();
            return !(subjects.Any(x => x.Name == name) || String.IsNullOrWhiteSpace(name)); //Check if name exists in db and if it's not empty
        }

        public static AbstractUser CreateUser(string name, string email, UserType userType) {
            switch (userType) {
                case UserType.Admin:
                    return AppendNewUserToDB(new AdminAccount {
                        Name = name,
                        Email = email,
                        Password = GenerateNewPassword()
                    });
                case UserType.Student:
                    return AppendNewUserToDB(new StudentAccount {
                        Name = name,
                        Email = email,
                        Password = GenerateNewPassword()
                    });
                case UserType.Teacher:
                    return AppendNewUserToDB(new TeacherAccount {
                        Name = name,
                        Email = email,
                        Password = GenerateNewPassword()
                    });
                default:
                    return null;
            }
        }

        private static T AppendNewUserToDB<T>(T newUser) where T : AbstractUser {
            Repository<T>.Instance.Add(newUser);
            return newUser;
        }

        public static bool DeleteUser<T>(AdminAccount admin, T user) where T : AbstractUser {
            if (user != null) {
                // Admin account cannot delete itself:
                if (user is AdminAccount && user.Id == admin.Id)
                    return false;

                user.IsNotRemoved = false;
                Repository<T>.Instance.Update(user);
                return true;
            }
            return false;
        }

        public static string ResetPassword<T>(T user) where T : AbstractUser {
            user.Password = GenerateNewPassword();
            Repository<T>.Instance.Update(user);
            return user.Password;
        }

        public static string GenerateNewPassword() {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[rng.Next(s.Length)]).ToArray());
        }
    }
}
