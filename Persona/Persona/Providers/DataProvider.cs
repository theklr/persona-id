using Persona.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persona.Providers
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