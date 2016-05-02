using System.ComponentModel.DataAnnotations;

namespace Testverktyg.Model {
    public abstract class AbstractUser {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsNotRemoved { get; set; }

        public AbstractUser(string name, string email, string password) {
            Name = name;
            Email = email;
            Password = password;
            IsNotRemoved = true;
        }
    }
}
