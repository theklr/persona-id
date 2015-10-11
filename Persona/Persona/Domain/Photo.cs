using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persona.Domain
{
    public class Photo
    {

        public string URL { get; set; }

        public int PhotoId { get; set; }

        public string UserId { get; set; }

        public bool isPrimary { get; set; }



    }
}