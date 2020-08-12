using Gosh.Controllers.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Gosh.Controllers
{
    public class UpdatesController : ApiController
    {
        // GET: api/Updates
        public async Task<HttpResponseMessage> Get()
        {
            var updates = await new TweeterUpdateRetviver().FetchUpdate("");
            var stringUpdate = JsonConvert.SerializeObject(updates);
            return Request.CreateResponse(HttpStatusCode.OK, stringUpdate, Configuration.Formatters.JsonFormatter);
        }


        // GET: api/Updates/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Updates
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Updates/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Updates/5
        public void Delete(int id)
        {
        }
    }
}
