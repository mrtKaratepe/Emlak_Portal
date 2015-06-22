using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.NA.Emlak.Domain
{
    public abstract class Person
    {
        public Guid Id
        {
            get;
            private set;
        }

        public int Age
        {
            get;
            set;
        }
        public String FirstName
        {
            get;
            set;
        }
        public String LastName
        {
            get;
            set;
        }

        public Boolean Active
        {
            get;
            private set;
        }

        [Obsolete("Don't use this, it is only for EF")]
        protected Person()
        {
            
        }

        public Person(string firstName, string lastName, int age)
        {
            this.Id = Guid.NewGuid();
            this.Age = age;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

    }
}
