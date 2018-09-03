using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCRUD.Models
{
    public class Person: BindableBase
    {

        public Person() {
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        private string name;        

        public string Name
        {
            get {
                return name;
            }
            set
            {
                SetProperty(ref name, value);
            }
        }

        private int age;

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                SetProperty(ref age, value);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return ((Person)obj).name.Equals(this.name);                        
        }

        public override int GetHashCode()
        {
            
            return (this.name != null)? this.name.GetHashCode():0;
        }

    }
}
