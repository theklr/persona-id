using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persona.Models.Request
{
    public class PhotosAdd
    {
        public string URL { get; set; }

        public int PhotoId { get; set; }

        public string userId { get; set; }

    }
}