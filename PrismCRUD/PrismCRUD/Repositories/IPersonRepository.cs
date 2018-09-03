using PrismCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCRUD.Repositories
{
    public interface IPersonRepository
    {        

        Task<ICollection<Person>> GetPersonAsync();

        Task SavePersonAsync(Person person);

        Task<List<Person>> SearchPersonAsync(string query);
    }
}
