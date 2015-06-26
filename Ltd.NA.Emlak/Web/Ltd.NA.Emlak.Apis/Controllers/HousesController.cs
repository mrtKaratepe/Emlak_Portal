using Ltd.NA.Emlak.Queries.Messages;
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
        public IHttpActionResult GetHouses(HouseSearchResponse search)
        {
            throw new NotImplementedException("To do");

            // #01 get the result from projection
            // #02 send back 200 OK with response
        }

    }
}
