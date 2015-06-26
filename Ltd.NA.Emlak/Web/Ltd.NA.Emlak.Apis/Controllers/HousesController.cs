using Ltd.NA.Emlak.Queries.Messages;
using Ltd.NA.Emlak.Queries.Projections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ltd.NA.Emlak.Apis.Controllers
{
    public class HousesController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetHouses(HouseSearchRequest search)
        {
            //throw new NotImplementedException("To do");

            // #01 get the result from projection
            HouseSearchResponse responseObject = HouseProjections.GetHouseList(search);
            
            // #02 send back 200 OK with response
            return Ok(responseObject);
        }

    }
}
