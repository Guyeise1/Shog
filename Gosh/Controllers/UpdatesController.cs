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
        // A random account will be loaded
        public async Task<HttpResponseMessage> Get()
        {
            var vals = TweeterUpdateRetviver.SUPPRTED_TWEETER_PAGES;
            Random random = new Random();
            int randomNumber = random.Next(0, vals.Length);
            return await Get(vals[randomNumber]);
        }

        // GET: api/Updates/tasty
        public async Task<HttpResponseMessage> Get(string account)
        {
            try
            {
                var updates = await new TweeterUpdateRetviver().FetchUpdate(account);
                var stringUpdate = JsonConvert.SerializeObject(updates);
                return Request.CreateResponse(HttpStatusCode.OK, stringUpdate, Configuration.Formatters.JsonFormatter);
            } catch(ApplicationException)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No support for account "+ account, Configuration.Formatters.JsonFormatter);

            }
        }

    }
}
