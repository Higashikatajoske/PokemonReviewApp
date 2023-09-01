
namespace EntityFramework.Models
{
    public class Hobby
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}
