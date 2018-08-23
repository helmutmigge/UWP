using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemControl
{
    class PersoinService
    {

        public List<Person> People
        {
            get
            {
                return new List<Person>() {
                    new Person("Helmut", 35),
                    new Person("Eduardo", 38),
                    new Person("Bruno", 32),
                    new Person("Galvão", 38)
                };
            }
        }
    }
}
