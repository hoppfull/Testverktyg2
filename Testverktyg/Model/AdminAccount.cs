namespace Testverktyg.Model {
    public class AdminAccount : AbstractUser {
        public AdminAccount(string name, string email, string password):base(name, email, password) {
        }
    }
}
