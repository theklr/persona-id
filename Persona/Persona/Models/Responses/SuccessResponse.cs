using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persona.Models.Responses
{
    public class SuccessResponse : BaseResponse
    {
        public SuccessResponse()
        {

            this.IsSuccessFull = true;

        }
    }
}