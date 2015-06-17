using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.NA.Emlak.Domain
{
    public class Category
    {
        /// <summary>
        /// 
        /// </summary>
        private string entry;
        private string description;

        public string Entry
        {
            get { return this.entry; }
        }

        public string Description
        {
            get { return this.description; }
        }

        public static Category Create(string entry, string description)
        {
            return new Category 
            {
                entry=entry,
                description=description

            };
        }

        
    }
}
