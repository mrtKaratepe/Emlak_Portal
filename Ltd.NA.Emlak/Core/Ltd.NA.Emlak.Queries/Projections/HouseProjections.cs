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

        public static HouseSearchResponse GetHouseList(HouseSearchRequest filter)
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
                // #01 get IQueryable with filter applied, not paging yet
                var result = context.Houses;
                if (!string.IsNullOrEmpty(filter.City))
                {
                    result.Where(x => x.Address.City.Contains(filter.City));
                }

                // #02 get total count with filter applied
                var totalRows = result.Count();

                // #03 get record using paging

                var items = result
                    .OrderBy(x => x.Name)
                    .Skip(filter.Skip)
                    .Take(filter.Take)
                    .Select(x => new HouseListItem
                    {
                        Id = x.Id,
                        Code = x.Code,
                        Price = x.Price,
                        Address = x.Address.Address1 
                        + " " + x.Address.Address2
                        +" " + x.Address.City
                        + " " + x.Address.Country
                        + " " + x.Address.Province
                    });
                houseSearchResponse.Items = items.ToList();
                houseSearchResponse.TotalRecords = totalRows;
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
                        Address1 = x.Address.Address1,
                        Address2 = x.Address.Address2,
                        Province = x.Address.Province,
                        ZipCode = x.Address.ZipCode,
                        country = x.Address.Country,
                        Category = x.Category,
                        AgentCode = x.Agent.AgentCode,
                        AgentDescription = x.Agent.Description,
                        HousesInCharge = x.Agent.HousesInCharge,
                        TaxNumber = x.Owner.TaxNumber,
                        Houses = x.Owner.Houses
                    });
                return result.ToList();
            }
        }
    }
}
