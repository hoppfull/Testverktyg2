using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Testverktyg.Repository;
using Testverktyg.Model;
using StudentApp;

namespace StudentApp.Controllers {
    static class ViewControllerStudent {
        public enum LoginResponse {
            InvalidUser, InvalidPassword, Success
        }
        static public LoginResponse Login(Window window, string email, string password) {
            IList<StudentAccount> students = Repository<StudentAccount>.Instance.GetAll();
            StudentAccount someStudent = students.FirstOrDefault(student => student.Email == email);

            if(someStudent != null) {
                if(someStudent.Password == password) {
                    LoginAdmin(window, someStudent);
                    return LoginResponse.Success;
                } else {
                    return LoginResponse.InvalidPassword;
                }
            } else {
                return LoginResponse.InvalidUser;
            }
        }

        static private void LoginAdmin(Window window, StudentAccount student) {
            StudentPage w = new StudentPage(student);
            w.Show();
            window.Close();
        }

        static public void Logout(Window window) {
            MainWindow loginscreen = new MainWindow();
            loginscreen.Show();
            window.Close();
        }
    }
}
