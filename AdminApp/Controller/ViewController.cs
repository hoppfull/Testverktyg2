using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Testverktyg.Repository;
using Testverktyg.Model;

namespace AdminApp.Controller {
    static class ViewController {
        public enum LoginResponse {
            InvalidUser, InvalidPassword, Success
        }
        static public LoginResponse Login(Window window, string email, string password) {
            IList<AdminAccount> admins = Repository<AdminAccount>.Instance.GetAll();
            IList<TeacherAccount> teachers = Repository<TeacherAccount>.Instance.GetAll();
            AdminAccount someAdmin = admins.FirstOrDefault(admin => admin.Email == email);
            TeacherAccount someTeacher = teachers.FirstOrDefault(teacher => teacher.Email == email);

            if(someAdmin != null) {
                if(someAdmin.Password == password) {
                    LoginAdmin(window, someAdmin);
                    return LoginResponse.Success;
                } else {
                    return LoginResponse.InvalidPassword;
                }
            } else if (someTeacher != null) {
                if (someTeacher.Password == password) {
                    LoginTeacher(window, someTeacher);
                    return LoginResponse.Success;
                } else {
                    return LoginResponse.InvalidPassword;
                }
            } else {
                return LoginResponse.InvalidUser;
            }
        }

        static private void LoginAdmin(Window window, AdminAccount admin) {
            AdminPage w = new AdminPage(admin);
            w.Show();
            window.Close();
        }

        static private void LoginTeacher(Window window, TeacherAccount teacher) {
            TeacherPage w = new TeacherPage(teacher);
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
