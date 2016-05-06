using System;
using System.Collections.Generic;
using System.Linq;
using Testverktyg.Model;
using Testverktyg.Repository;

namespace AdminApp.Controllers {
    public class Controller {
        public static Subject CreateSubject(string name) {
            if (IsSubjectValid(name)) {
                Subject subject = new Subject { Name = name };
                Repository<Subject>.Instance.Add(new Subject { Name = name });
                return subject;
            }
            return null;
        }

        public static bool DeleteSubject(Subject subject) {
            if (subject != null) {
                return Repository<Subject>.Instance.Delete(subject);
            }
            return false;
        }

        public static bool EditSubject(Subject subject, string name) {
            if (subject != null && IsSubjectValid(name)) {
                subject.Name = name;
                Repository<Subject>.Instance.Update(subject);
                return true;
            }
            return false;
        }

        public static bool IsSubjectValid(string name) {
            IList<Subject> subjects = Repository<Subject>.Instance.GetAll();
            // Check if name exists in db and if it's not empty:
            return !(string.IsNullOrWhiteSpace(name) || subjects.Any(subject => subject.Name == name));
        }

        public static AbstractUser CreateUser(string name, string email, UserType userType) {
            switch (userType) {
                case UserType.Admin:
                    return TryAppendNewUserToDB(new AdminAccount {
                        Name = name,
                        Email = email,
                        Password = GenerateNewPassword()
                    });
                case UserType.Student:
                    return TryAppendNewUserToDB(new StudentAccount {
                        Name = name,
                        Email = email,
                        Password = GenerateNewPassword()
                    });
                case UserType.Teacher:
                    return TryAppendNewUserToDB(new TeacherAccount {
                        Name = name,
                        Email = email,
                        Password = GenerateNewPassword()
                    });
                default:
                    return null;
            }
        }

        private static T TryAppendNewUserToDB<T>(T newUser) where T : AbstractUser {
            // Check first if user email already exists:
            if (Repository<T>.Instance.GetAll().Any(user => user.Email == newUser.Email))
                return null;
            Repository<T>.Instance.Add(newUser);
            return newUser;
        }

        public static bool DeleteUser<T>(AdminAccount admin, T user) where T : AbstractUser {
            if (user != null) {
                // Admin account cannot delete itself:
                if (user is AdminAccount && user.Id == admin.Id)
                    return false;
                // Try to delete entry from database:
                if (Repository<T>.Instance.Delete(user))
                    return true;
                // If entry could not be deleted, flag entry as removed:
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
            Random rng = new Random();
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[rng.Next(s.Length)]).ToArray());
        }
    }
}
