using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class Person
    {
        public string Name;
        public string Tag;
        public Person UnderPerson;
        public Person DeputyPerson; //заместитель
        public Person(string Name)
        {
            this.Name = Name;
        }
        public Person(string Name, Person DepPerson) : this(Name)
        {
            this.DeputyPerson = DepPerson;
        }
        public Person(string name, string tag) : this(name)
        {
            Tag = tag;
        }
    }
}
