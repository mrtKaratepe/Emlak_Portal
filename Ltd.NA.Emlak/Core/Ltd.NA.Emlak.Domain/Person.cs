using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.NA.Emlak.Domain
{
    public class Person
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

    }
}
