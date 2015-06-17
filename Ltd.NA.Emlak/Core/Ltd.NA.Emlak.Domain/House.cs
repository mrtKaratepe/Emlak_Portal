using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.NA.Emlak.Domain
{
    /// <summary>
    /// Represent an House Entity
    /// </summary>
    public class House
    {
        private Guid id;
        private string name;
        private string description;

        /// <summary>
        /// The Unique Id of the House
        /// </summary>
        public Guid Id
        {
            get { return this.id; }
        }

        /// <summary>
        /// The Name that identify the House
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// The Description of the House
        /// </summary>
        public string Description
        {
            get { return description; }
        }

        /// <summary>
        /// Identify if the House is Valid
        /// </summary>
        public bool IsValid
        {
            get { return this.id != Guid.Empty; }
        }

        /// <summary>
        /// Create a new House object
        /// </summary>
        /// <param name="id">The unique id</param>
        /// <param name="name">The name of the house</param>
        /// <param name="description">The description of the house</param>
        /// <returns></returns>
        public static House Create(Guid id, string name, string description)
        {
            return new House
            {
                id = id,
                name = name,
                description = description
            };
        }

        /// <summary>
        /// Protected constructor, developer cannot use it but Entity Framework can
        /// </summary>
        protected House()
        {
            
        }
    }
}
