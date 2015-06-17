using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.NA.Emlak.Domain
{
    public class Category
    {
        public Guid Id
        {
            get;
            private set;
        }

        public string Entry
        {
            get;
            private set;
        }

        public string Description
        {
            get;
            private set;
        }

        internal Category(string entry, string description)
        {
            this.Id = Guid.NewGuid();
            this.Entry = entry;
            this.Description = description;
        }

        protected Category()
        {
            
        }
    }
}
