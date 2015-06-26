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
        /// <summary>
        /// The Unique Id of the House
        /// </summary>
        public Guid Id
        {
            get; private set; }

        public string Code
        {
            get;
            private set;
        }

        public double Price
        {
            get;
            private set;
        }
        /// <summary>
        /// The Name that identify the House
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// The Description of the House
        /// </summary>
        public string Description
        {
            get;
            private set;
        }

        /// <summary>
        /// Identify if the House is Valid
        /// </summary>
        public bool IsValid
        {
            get { return this.Id != Guid.Empty; }
        }

        /// <summary>
        /// Represents the Category of the House
        /// </summary>
        public Category Category
        {
            get;
            private set;
        }

        public Address Address
        {
            get;
            private set;
        }

        public Agent Agent
        {
            get;
            private set;
        }

        public Customer Owner
        {
            get;
            private set;
        }

        /// <summary>
        /// Create a new House object
        /// </summary>
        /// <param name="name">The name of the house</param>
        /// <param name="description">The description of the house</param>
        /// <returns></returns>
        public static House Create(string name, string description, Customer owner)
        {
            var house = new House
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Owner = owner
            };
            owner.AddHouse(house);
            return house;
        }

        /// <summary>
        /// Modify the Name and the Description of an house
        /// </summary>
        /// <param name="name">The new Name of the House</param>
        public void ModifyName(string name)
        {
            if (this.Name != name)
            {
                this.Name = name;                
            }
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
            this.Category = new Category(entry, description);
        }

        /// <summary>
        /// Change the current house category
        /// </summary>
        /// <param name="category">The new category</param>
        public void ChangeCategory(Category category)
        {
            this.Category = category;
        }

        public void AddAddress(string address1,
            string city,
            string country,
            string number,
            string zipCode)
        {
            this.Address = new Address(address1, city, country, number, zipCode);
        }

        public void ChangeAddress(Address address)
        {
            this.Address = address;
        }

        public void AssociateAgent(Agent agent)
        {
            this.Agent = agent;
        }
    }
}
