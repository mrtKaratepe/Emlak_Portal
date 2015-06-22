using Ltd.NA.Emlak.Queries.Messages;
using Ltd.NA.Emlak.Queries.Projections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ltd.NA.Emlak.Api.Controllers
{
    [RoutePrefix("api/houses")]
    public class HouseController : ApiController
    {
        public IHttpActionResult Get(int top, int skip)
        {
            var count = HouseProjections.GetHouseCount();
            var items = HouseProjections.GetHouseList(top, skip);

            var result = new HouseSearchResponse
            {
                TotalRecords = count,
                Items = items
            };

            return Ok(result);
        }
    }
}
