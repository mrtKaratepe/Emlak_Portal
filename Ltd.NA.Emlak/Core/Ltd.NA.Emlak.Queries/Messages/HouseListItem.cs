using Ltd.NA.Emlak.Domain;
using System;
using System.Collections.Generic;
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
        public string Code { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public double Price { get; set; }

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
        public string Address1 { get; set; }
        [DataMember]
        public string Address2 { get; set; }
        [DataMember]
        public string city { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public string Province { get; set; }
        [DataMember]
        public string ZipCode { get; set; }
        [DataMember]
        public string TaxNumber { get; set; }
        [DataMember]
        public IList<House> Houses { get; set; }
        [DataMember]
        public string AgentCode{ get; set; }
        [DataMember]
        public string AgentDescription{ get; set; }
        [DataMember]
        public IList<House> HousesInCharge { get; set; }
    }
}
