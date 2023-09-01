
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models
{
    //[Table("Deps")]
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[ForeignKey(nameof(Person.DepartmentId))]
        public ICollection<Person> Persons { get; set; }
    }
}
