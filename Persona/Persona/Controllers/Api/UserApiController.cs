using Microsoft.AspNet.Identity.EntityFramework;
using Persona.Models;
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



        [Route("login"), HttpPost]
        public HttpResponseMessage LoginPost(LoginPostRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                BaseResponse response = null;

                HttpStatusCode code = HttpStatusCode.OK;

                ApplicationUser user = UserService.Signin(model.UserName, model.Password);

                if (user != null)
                {
                    response = new SuccessResponse();
                    HttpResponseMessage resp = Request.CreateResponse(response);

                    //ResetClientState(user.Id, resp);

                    return resp;

                }
                else
                {
                    response = new ErrorResponse("Unable to Log in");
                    code = HttpStatusCode.BadRequest;

                }

                return Request.CreateResponse(code, response);

            }

            catch (Exception e)
            {
                ErrorResponse er = new ErrorResponse(e.Message);

                //sabio.layout.showMessage(er);

                return Request.CreateResponse(HttpStatusCode.InternalServerError, er);

            }

        }

    }
}
