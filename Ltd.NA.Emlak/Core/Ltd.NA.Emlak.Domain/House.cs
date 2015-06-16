using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.NA.Emlak.Domain
{
    public class House
    {
        private Guid id;
        private string name;
        private string description;


        public Guid Id
        {
            get { return this.id; }
        }

        public string Name
        {
            get { return name; }
        }

        public string Description
        {
            get { return description; }
        }

        public bool IsValid
        {
            get { return this.id != Guid.Empty; }
        }

        public static House Create(Guid id, string name, string description)
        {
            return new House
            {
                id = id,
                name = name,
                description = description
            };
        }
    }
}
