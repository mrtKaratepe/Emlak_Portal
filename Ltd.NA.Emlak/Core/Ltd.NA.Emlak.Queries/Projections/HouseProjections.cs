using Ltd.NA.Emlak.Data;
using Ltd.NA.Emlak.Queries.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.NA.Emlak.Queries.Projections
{
    public class HouseProjections
    {
        public static IEnumerable<HouseListItem> GetHouseList()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = context.Houses
                    .Select(x => new HouseListItem
                    {
                        Id = x.Id,
                        Name = x.Name
                    });
                return result.ToList();
            }        
        }
    }
}
