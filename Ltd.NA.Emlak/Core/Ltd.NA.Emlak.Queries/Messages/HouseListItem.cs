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
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
    }

    [DataContract]
    public class HouseSearchResponse
    {
        [DataMember]
        public IEnumerable<HouseListItem> Items { get; set; }
        [DataMember]
        public int TotalRecords { get; set; }
    }
}
