using PersonApp.Client.IServices;
using PersonApp.Shared.Entities;

namespace PersonApp.Client.Services
{
    public class PersonInMemoryService : IPersonService
    {
        private List<Person> people = new List<Person>()
        {
            new Person{
              PersonId=1, FirstName = "Leonel",LastName = "Messi",BirthDate = new DateTime(1993,6,16)
            },
            new Person{
                PersonId=2, FirstName = "Robert",LastName = "Dopskie",BirthDate = new DateTime(1983,9,15) },
            new Person{
                PersonId=3, FirstName = "Cristiano",LastName = "Ronaldo",BirthDate = new DateTime(1983,9,15) },

        };


        public async Task<List<Person>> GetPeople()
        {
            return people.OrderByDescending(p => p.PersonId).ToList();
        }

        public async Task<Person> GetPersonById(int PersonId)
        {
            return people.FirstOrDefault(x => x.PersonId == PersonId);
        }

        public async Task InsertPerson(Person Person)
        {
            people.Add(Person);
            await Task.CompletedTask;
        }

        public async Task UpdatePerson(Person Person)
        {
            var p = people.FirstOrDefault(c => c.Equals(Person));
            if (p != null)
            {
                p.FirstName = Person.FirstName;
                p.LastName = Person.LastName;
                p.BirthDate = Person.BirthDate;
            }

            await Task.CompletedTask;
        }
        public async Task DeletePerson(int PersonId)
        {
            await Task.CompletedTask;
        }
    }
}