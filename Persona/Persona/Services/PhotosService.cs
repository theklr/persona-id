using Persona.Models.Request;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Persona.Services
{
    public class PhotosService : BaseService
    {
        //PHOTOS - INSERT
        public static int PhotosInsert(PhotosAdd model)
        {
            int id = 0;//000-0000-0000-0000

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Photos_Insert"
               , inputParamMapper: delegate(SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@URL", model.URL);
                   paramCollection.AddWithValue("@isPrimary", 0);
                   paramCollection.AddWithValue("@userId", model.userId);


                   SqlParameter p = new SqlParameter("@PhotoId", System.Data.SqlDbType.Int); //output parameter sending into proc to get value
                   p.Direction = System.Data.ParameterDirection.Output;

                   paramCollection.Add(p);

               },
               returnParameters: delegate(SqlParameterCollection param)
               {
                   int.TryParse(param["@PhotoId"].Value.ToString(), out id);
               }

               );

            return id;
        }


        //isPRIMARY UPDATE PHOTO - PUT
        public static void UpdatePhoto(PhotoPrimaryUpdate model, string userId)
        {

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.PhotosMap_UpdatebyUserId"
               , inputParamMapper: delegate(SqlParameterCollection paramCollection)
               {

                   paramCollection.AddWithValue("@PhotoId", model.PhotoId);//pass to model
                   paramCollection.AddWithValue("@userId", userId); //not needed for model


                   //Not returning anything = no code

               }
               , returnParameters: delegate(SqlParameterCollection param)
               {
                   //No code
               }
               );

            //return Id;
        }

    }
}