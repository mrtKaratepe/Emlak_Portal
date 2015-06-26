using System;
using System.Web.Http;

namespace Ltd.NA.Emlak.Apis.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get(int top, int skip)
        {
            return BadRequest("To be implemented");
        }

        // GET api/values/5
        public IHttpActionResult Get(Guid id)
        {
            return BadRequest("To be implemented");
        }
    }
}