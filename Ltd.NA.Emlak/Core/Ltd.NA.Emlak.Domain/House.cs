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
        private string code;
        private Boolean rent;
        private Category category;
        private Address address;
        
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
        /// Represents the Category of the House
        /// </summary>
        public Category Category
        {
            get { return this.category; }
        }

        public Address Address
        {
            get { return this.address; }
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

        /// <summary>
        /// Create a new Category
        /// </summary>
        /// <param name="entry">The Entry for the Category</param>
        /// <param name="description">The Description for the Category</param>
        public void AddCategory(string entry, string description)
        {
            this.category = new Category(entry, description);
        }

        /// <summary>
        /// Change the current house category
        /// </summary>
        /// <param name="category">The new category</param>
        public void ChangeCategory(Category category)
        {
            this.category = category;
        }

        public void AddAddress(string address1,
            string city,
            string country,
            string number,
            string zipCode)
        {
            this.address = new Address(address1, city, country, number, zipCode);
        }

        public void ChangeAddress(Address address)
        {
            this.address = address;
        }
    }
}
