using Ltd.NA.Emlak.Domain;
using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.NA.Emlak.Queries.Messages
{
    [DataContract]
    public class HouseListItem
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }

    }

    [DataContract]
    public class HouseDetailsItem
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public Category Category { get; set; }
        [DataMember]
        public Address Address { get; set; }
        [DataMember]
        public Customer Owner { get; set; }
        [DataMember]
        public Agent Agent { get; set; }
    }
}
