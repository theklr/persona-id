using Persona.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Persona.Providers;

namespace Persona.Services
{
    
    public class BaseService
    {


        protected static IDao DataProvider
        {

            get { return Persona.Providers.DataProvider.Instance; }
        }

        protected static SqlConnection GetConnection()
        {
            return new System.Data.SqlClient.SqlConnection(
                System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        }

    }
}