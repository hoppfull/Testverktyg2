using AdminApp.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Model;
using Testverktyg.Repository;

namespace AdminApp.Controller
{
    public class Controller
    {

        private static Random rng = new Random();

        public static Subject CreateSubject(string name)
        {

            if (IsSubjectValid(name))
            {
                var subject = new Subject(name);
                Repository<Subject>.Instance.Add(subject);
                return subject;
            }
            return null;
        }

        public static bool IsSubjectValid(string name)
        {
            return true;
        }

        public static AbstractUser CreateUser(string name, string email, UserType userType)
        {

            if (userType == UserType.Student)
            {
                var user = new StudentAccount();
                user.Name = name;
                user.Email = email;
                user.TestForms = new List<TestForm>();
                Repository<StudentAccount>.Instance.Add(user as StudentAccount);


            }
            else if (userType == UserType.Admin)
            {
                var user = new AdminAccount();
                user.Name = name;
                user.Email = email;
                Repository<AdminAccount>.Instance.Add(user as AdminAccount);

            }
            else if (userType == UserType.Teacher)
            {
                var user = new TeacherAccount();
                user.Name = name;
                user.Email = email;
                user.TestDefinitions = new List<TestDefinition>();
                Repository<TeacherAccount>.Instance.Add(user as TeacherAccount);

            }

            return null;
        }

        public static bool DeleteUser(AbstractUser user)
        {

            if (user is StudentAccount)
            {
                StudentAccount suser = (StudentAccount)user;
                if (suser.TestForms.Count() < 0)
                {
                    suser.IsNotRemoved = false;
                    return true;

                }
                else
                {
                    Repository<StudentAccount>.Instance.Delete(suser);
                    return true;
                }
            }
            else if (user is AdminAccount)
            {
                //Admin ska inte kunna deleta sig själv
                AdminAccount auser = (AdminAccount)user;

                Repository<AdminAccount>.Instance.Delete(auser);

            }
            else if (user is TeacherAccount)
            {
                TeacherAccount tuser = (TeacherAccount)user;
                if (tuser.TestDefinitions.Count() < 0)
                {
                    tuser.IsNotRemoved = false;
                    return true;
                }
                else
                {
                    Repository<TeacherAccount>.Instance.Delete(tuser);
                }
            }       
                    return true;
        }

        public static string ResetPassword(AbstractUser user)
{

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

public static string GenerateNewPassword()
{

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
