using Persona.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persona.Models.Response
{
    public class ItemResponse<T> : SuccessResponse
    {

        public T Item { get; set; }

    }
}