using System.Linq;
using System.Windows;
using Testverktyg.Repository;
using Testverktyg.Model;

namespace AdminApp.Controllers {
    static class ViewController {
        public enum LoginResponse {
            InvalidUser, InvalidPassword, Success
        }
        static public LoginResponse Login(Window window, string email, string password) {
            AbstractUser someAdmin = FindUser<AdminAccount>(email);
            AbstractUser someTeacher = FindUser<TeacherAccount>(email);

            AbstractUser someUser = someAdmin != null ? someAdmin : someTeacher;

            if (someUser != null) {
                if(someUser.Password == password) {
                    LoginUser(window, someUser);
                    return LoginResponse.Success;
                }
                return LoginResponse.InvalidPassword;
            }
            return LoginResponse.InvalidUser;
        }

        static private void LoginUser(Window window, AbstractUser user) {
            Window w = null;
            if (user is AdminAccount)
                w = new AdminPage((AdminAccount)user);
            else if (user is TeacherAccount)
                w = new TeacherPage((TeacherAccount)user);
            if (w != null) {
                w.Show();
                window.Close();
            }
        }

        static private T FindUser<T>(string email) where T : AbstractUser {
            return Repository<T>.Instance.GetAll()
                .FirstOrDefault(user => user.IsNotRemoved && user.Email == email);
        }

        static public void Logout(Window window) {
            //MainWindow loginscreen = new MainWindow();
            //loginscreen.Show();
            window.Close();
        }
    }
}
