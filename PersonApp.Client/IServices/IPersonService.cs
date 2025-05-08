using PersonApp.Shared.Entities;

namespace PersonApp.Client.IServices
{
    public interface IPersonService
    {
        Task<List<Person>> GetPeople();
        Task<Person> GetPersonById(int PersonId);
        Task InsertPerson(Person Person);
        Task UpdatePerson(Person Person);
        Task DeletePerson(int PersonId);
    }
}