using System.Diagnostics;
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
        public static int GetHouseCount()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Houses.Count();
            }
        }

        public static HouseSearchResponse GetHouseList(int top, int skip)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                HouseSearchResponse houseSearchResponse = new HouseSearchResponse();
#if DEBUG
                context.Database.Log = delegate(string s)
                {
                    Debug.WriteLine(s);
                };

#endif
                var result = context.Houses
                    .OrderBy(x => x.Name)
                    .Skip(skip)
                    .Take(top)
                    .Select(x => new HouseListItem
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description
                    });
                houseSearchResponse.Items = result.ToList();
                houseSearchResponse.TotalRecords = result.ToList().Count();
                return houseSearchResponse;
            }        
        }

        public static IEnumerable<HouseDetailsItem> GetHouseDetailsList(int top, int skip)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
#if DEBUG
                context.Database.Log = delegate(string s)
                {
                    Debug.WriteLine(s);
                };

#endif
                var result = context.Houses
                    .OrderBy(x => x.Name)
                    .Skip(skip)
                    .Take(top)
                    .Select(x => new HouseDetailsItem
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        Address = x.Address,
                        Category = x.Category,
                        Agent = x.Agent,
                        Owner = x.Owner
                    });
                return result.ToList();
            }
        }
    }
}
