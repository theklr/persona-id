using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Persona.Services
{
    public class ProfileService : BaseService
    {

        public static void UpdatePhotoPath(string userId, string photoPath)
        {

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Users_UpsertPhoto_byUserId"
               , inputParamMapper: delegate(SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@UserId", userId);
                   paramCollection.AddWithValue("@PhotoPath", photoPath);

               }, returnParameters: delegate(SqlParameterCollection param)
               {

               }
               );


        }

    }
}