using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persona.Models
{
    public class IdentityResultException : Exception
    {
        public IdentityResultException(IdentityResult result)
        {
            this.IdentityResult = result;
        }

        public IdentityResult IdentityResult { get; set; }
    }
}