using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleCRUD
{
    public class Person
    {
        public Person()
        {           
        }

        public Person(string name, int age) {
            this.name = name;
            this.age = age;
        }

        private string name;
        public string Name {
            get
            {
                return this.name;

            }
            set
            {
                this.name = value;
            }
        }

        private int age;
        public int Age {
            get
            {
                return age;
            }
            set
            {
                this.age = value;
            }
        }

    }
}
