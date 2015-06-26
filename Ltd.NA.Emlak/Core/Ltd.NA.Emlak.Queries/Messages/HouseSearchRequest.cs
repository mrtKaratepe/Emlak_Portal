using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.NA.Emlak.Queries.Messages
{
    [DataContract]
    public class HouseSearchRequest
    {
        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string Street { get; set; }

        [DataMember]
        public string Address { get; set; }
        
        [DataMember]
        public string ZipCode { get; set; }
        
        [DataMember]
        public Boolean TypeRent { get; set; }

        [DataMember]
        public int Price { get; set; }

        [DataMember]
        public int Take { get; set; }

        [DataMember]
        public int Skip { get; set; }
    }
}
