using Persona.Interfaces;
using Persona.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persona.Sabio
{
    public sealed class DataProvider
    {
        private DataProvider() { }

        public static IDao Instance
        {
            get
            {
                return SqlDao.Instance;
            }
        }

    }
}