using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemControl
{
    class Person:INotifyPropertyChanged
    {

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

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public int Age
        {
            get
            {
                return this.age;

            }

            set
            {
                this.age = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Age"));
            }
        }
    }
}
