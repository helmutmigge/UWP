using PrismCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCRUD.Repositories
{
    public class PersonRepositoryImpl: IPersonRepository
    {
        private ISet<Person> data;

        public PersonRepositoryImpl() {
            this.data = new HashSet<Person>();
            this.data.Add(new Person("Helmut Migge", 35));
        }

        public Task<ICollection<Person>> GetPersonAsync()
        {
            return Task.FromResult<ICollection<Person>>(this.data);
        }

        public Task SavePersonAsync(Person person)
        {            
            return Task.FromResult(this.data.Add(person));            
        }

        public Task<List<Person>> SearchPersonAsync(string query)
        {
            query = query.ToLowerInvariant();
            List<Person> result = this.data.Where<Person>(obj => obj.Name.ToLowerInvariant().Contains(query)).ToList();
            return Task.FromResult(result);         
        }
    }
}
