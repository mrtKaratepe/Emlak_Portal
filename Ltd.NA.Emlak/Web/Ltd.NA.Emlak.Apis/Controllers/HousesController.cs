using Ltd.NA.Emlak.Apis.Models;
using Ltd.NA.Emlak.Queries.Messages;
using Ltd.NA.Emlak.Queries.Projections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Ltd.NA.Emlak.Apis.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, OPTIONS")]
    [RoutePrefix("api/Houses")]
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
