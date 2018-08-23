using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding
{
    class Person
    {
        private string fullname;
        public string Fullname {
            get {
                return fullname;
            }

            set
            {
                this.fullname = value;
            }
        }
        private string nickname;
        public string Nickname
        {
            get
            {
                return nickname;
            }

            set
            {
                this.nickname = value;
            }
        }

    }
}

