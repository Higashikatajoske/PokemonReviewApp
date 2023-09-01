
using EntityFramework.Content;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

using (var context = new Context())
{
    //var dep1 = new Department()
    //{
    //    Name = "Dep1"
    //};

    //var dep2 = new Department()
    //{
    //    Name = "Dep2"
    //};

    //var hobby1 = new Hobby()
    //{
    //    Title = "Cars"
    //};

    //var hobby2 = new Hobby()
    //{
    //    Title = "Programming"
    //};

    //var hobby3 = new Hobby()
    //{
    //    Title = "Singing"
    //};

    //var hobby4 = new Hobby()
    //{
    //    Title = "Swimming"
    //};

    //var address = new Address()
    //{
    //    Street = "Volgograskaya street"
    //};

    //var address2 = new Address()
    //{
    //    Street = "Moscovskaya street"
    //};

    //var address3 = new Address()
    //{
    //    Street = "Mira street"
    //};

    //var person1 = new Person()
    //{
    //    Name = "Oleg",
    //    Surname = "Petrov",
    //    Department = dep1,
    //    Hobbies = new List<Hobby> { hobby1, hobby2 },
    //    Address = address
    //};

    //var person2 = new Person()
    //{
    //    Name = "Vasya",
    //    Surname = "Pupkin",
    //    Department = dep1,
    //    Hobbies = new List<Hobby> { hobby3, hobby4 },
    //    Address = address2
    //};

    //var person3 = new Person()
    //{
    //    Name = "Andrew",
    //    Surname = "Sidorov",
    //    Department = dep2,
    //    Hobbies = new List<Hobby> { hobby1 },
    //    Address = address3
    //};

    ////context.Departments.Add(dep1);
    ////context.Departments.Add(dep2);

    //context.Persons.Add(person1);
    //context.Persons.Add(person2);
    //context.Persons.Add(person3);
    //context.SaveChanges();
    var persons = context.Persons.Include(p => p.Address).Include(p => p.Hobbies).Include(p => p.Department);

    foreach (var person in persons)
    {
        Console.WriteLine($"{person.Name} {person.Surname} {person.Address?.Street} {person.Department.Name}");
        Console.WriteLine($"Hobbies: ");
        foreach (var hobby in person.Hobbies)
        {
            Console.WriteLine(hobby.Title);
        }
        Console.WriteLine("---------------------");
    }
    Console.ReadKey();

    
}

using (var context = new Context())
{
    var persons = context.Persons.Join(
        context.Departments,
        p => p.DepartmentId,
        d => d.Id,
        (person, department) => new
        {
            PersonId = person.Id,
            Department = department.Name
        });

    foreach (var person in persons)
    {
        Console.WriteLine(person.PersonId);
        Console.WriteLine(person.Department);
    }
    Console.WriteLine("---------------------");
    Console.ReadKey();
}

using (var context = new Context())
{
    var persons = from p in context.Persons
                  join d in context.Departments
                  on p.DepartmentId equals d.Id
                  select new
                  {
                      PersonId = p.Id,
                      DepName = d.Name,
                      PersonName = $"{p.Name} {p.Surname}"
                  };

    foreach (var person in persons)
    {
        Console.WriteLine(person.PersonId);
        Console.WriteLine(person.DepName);
        Console.WriteLine(person.PersonName);
    }

    Console.ReadKey();
}

using (var context = new Context())
{
    var person = context.Persons
        .Include(p => p.Address)
        .Include(p => p.Hobbies)
        .Include(p => p.Department)
        .Where(p => p.Name.Contains("Vasya")).FirstOrDefault();

    if (person != null)
    {
        person.Hobbies = new List<Hobby>();
    }
    context.SaveChanges();

    Console.ReadKey();
}

using (var context = new Context())
{
    var person = context.Persons.Where(p => p.Name.Contains("Vasya")).Single();
    context.Persons.Remove(person);
    context.SaveChanges();
}
