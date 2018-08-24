using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleCRUD
{
    public class PersonService
    {
        private ObservableCollection<Person> persons = new ObservableCollection<Person>();

        public PersonService() {            
        }
        

        public void addPerson(Person person)
        {
            Person tmp = new Person();
            tmp.Name = person.Name;
            tmp.Age = person.Age;
            persons.Add(tmp);            
        }



        public ObservableCollection<Person> GetAllPersons()
        {
            return this.persons;
        }

        public void removePerson(Person person)
        {
            persons.Remove(person);
        }

        public void removeIndex(int index) {
            persons.RemoveAt(index);
        }


    }
}
