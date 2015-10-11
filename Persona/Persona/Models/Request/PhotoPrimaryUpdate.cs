using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Persona.Models.Request
{
    public class PhotoPrimaryUpdate
    {

        //[Required]
        public int PhotoId { get; set; }

        public bool IsPrimary { get; set; }



    }
}