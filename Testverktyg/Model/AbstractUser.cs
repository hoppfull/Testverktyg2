using System.ComponentModel.DataAnnotations;

namespace Testverktyg.Model {
    public enum UserType {
        Admin, Student, Teacher
    }
    public abstract class AbstractUser {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsNotRemoved { get; set; }
        public AbstractUser() {
            IsNotRemoved = true;
        }
    }
}
