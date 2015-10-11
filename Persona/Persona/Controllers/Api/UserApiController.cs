using Microsoft.AspNet.Identity.EntityFramework;
using Persona.Models.Request;
using Persona.Models.Responses;
using Persona.Providers;
using Persona.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Persona.Controllers.Api
{
    [RoutePrefix("api/users")]
    public class UserApiController : ApiController
    {

        [Route("register"), HttpPost]
        public HttpResponseMessage RegistrationAdd(RegistrationAddRequest model)
        {

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                IdentityUser user = UserService.CreateUser(model.Email, model.Password);

                UserService.InsertRegistration(model, user.Id);

                //_messagingService.SendConfirmationEmail(model, user.Id);

                return Request.CreateResponse(user);

            }
            catch (IdentityResultException ire)
            {

                ErrorResponse er = new ErrorResponse(ire.Result.Errors);

                return Request.CreateResponse(HttpStatusCode.InternalServerError, er);

            }
            catch (Exception e)
            {
                ErrorResponse er = new ErrorResponse(e.Message);

                return Request.CreateResponse(HttpStatusCode.InternalServerError, er);


            }


        }

    }
}
