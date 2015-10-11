using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Persona.Controllers.Api
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        [Route("")]
        public string Get() {
            return "success!";
        }

    }
}
