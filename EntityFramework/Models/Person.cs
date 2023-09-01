

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        //[Required]
        //[Column("Title")]
        public string Name { get; set; }
        [Column("LastName")]
        public string Surname { get; set; }
        public int? Age { get; set; }

        [NotMapped]
        public int NotMapped { get; set; }
    }
}
