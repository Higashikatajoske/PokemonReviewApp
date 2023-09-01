

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Column("LastName")]
        public string Surname { get; set; }
        public int? Age { get; set; }
        public string MiddleName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public Address Address { get; set; }
        public ICollection<Hobby> Hobbies { get; set; }
    }
}
