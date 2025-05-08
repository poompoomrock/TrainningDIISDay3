using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonApp.Client.IServices;
using PersonApp.Shared.Entities;

namespace PersonApp.Client.Services
{
    public class PersonService : IPersonService
    {
        private readonly IDbContextFactory<DbModelContext> contextFactory;
        public PersonService(IDbContextFactory<DbModelContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task DeletePerson(int PersonId)
        {
            using var dbcontext = await contextFactory.CreateDbContextAsync();
            using var trans = await dbcontext.Database.BeginTransactionAsync();

            try
            {
                Person? temp = await dbcontext.Person
                    .Where(c => c.PersonId == PersonId)
                    .FirstOrDefaultAsync();
                if (temp == null)
                {
                    return;
                }

                dbcontext.Person.RemoveRange(temp);
                await dbcontext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<List<Person>> GetPeople()
        {
            using (var context = contextFactory.CreateDbContext())
            {
                return await context.Person.ToListAsync();
            }
        }

        public async Task<Person> GetPersonById(int PersonId)
        {
            Person person = new Person();
            if (PersonId == default)
            {
                return null;
            }
            try
            {
                using (var context = contextFactory.CreateDbContext())
                {
                    person = await context.Person.Where(p => p.PersonId == PersonId).FirstAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return person;
        }

        public async Task InsertPerson(Person Person)
        {
            using var dbcontext = await contextFactory.CreateDbContextAsync();
            using var trans = await dbcontext.Database.BeginTransactionAsync();

            try
            {
                await dbcontext.Person.AddRangeAsync(Person);
                await dbcontext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task UpdatePerson(Person Person)
        {
            using var dbcontext = await contextFactory.CreateDbContextAsync();
            using var trans = await dbcontext.Database.BeginTransactionAsync();

            try
            {
                dbcontext.Person.Update(Person);
                await dbcontext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }
    }
}