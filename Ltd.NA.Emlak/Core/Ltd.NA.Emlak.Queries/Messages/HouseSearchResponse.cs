using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ltd.NA.Emlak.Queries.Messages
{
    [DataContract]
    public class HouseSearchResponse
    {
        [DataMember]
        public IEnumerable<HouseListItem> Items { get; set; }
        [DataMember]
        public int TotalRecords { get; set; }
    }
}