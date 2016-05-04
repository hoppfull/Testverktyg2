using System.ComponentModel.DataAnnotations;

namespace Testverktyg.Model {
    public class Subject {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
