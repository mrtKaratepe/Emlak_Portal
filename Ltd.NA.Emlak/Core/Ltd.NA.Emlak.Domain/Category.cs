using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.NA.Emlak.Domain
{
    public class Category
    {
        private Guid id;
        private string entry;
        private string description;

        public Guid Id
        {
            get { return this.id; }
        }

        public string Entry
        {
            get { return this.entry; }
        }

        public string Description
        {
            get { return this.description; }
        }

        internal Category(string entry, string description)
        {
            this.id = Guid.NewGuid();
            this.entry = entry;
            this.description = description;
        }
        
    }
}
