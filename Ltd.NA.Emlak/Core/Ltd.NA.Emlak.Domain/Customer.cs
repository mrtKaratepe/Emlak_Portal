using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.NA.Emlak.Domain
{
    public class Customer : Person
    {

        public int TcNo
        {
            get;
            private set;
        }

        public Boolean active
        {
            get;
            private set;
        }

        public string Rent
        {
            get;
            private set;
        }

        public House House
        {
            get;
            private set;
        }

        
    }
}
