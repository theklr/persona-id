using Persona.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Persona.Services
{
    public class FileUploadService : BaseService
    {

        public List<Photo> GetPhotoGallery(string UserId)
        {

            List<Photo> list = null;// must match stored procedure

            DataProvider.ExecuteCmd(GetConnection, "dbo.Photos_SelectByUserId"
                , inputParamMapper: delegate(SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@UserId", UserId);


                }, map: delegate(IDataReader reader, short set)
                {
                    int startingIndex = 0;


                    Photo myPhoto = new Photo();

                    //myPhoto.UserId = reader.GetSafeString(startingIndex++);
                    myPhoto.isPrimary = reader.GetBoolean(startingIndex++);
                    myPhoto.URL = "https://persona.risenyc.s3-website-us-west-2.amazonaws.com" + reader.GetString(startingIndex++); //concatenate photo path
                    myPhoto.PhotoId = reader.GetInt32(startingIndex++);



                    if (list == null)
                    {
                        list = new List<Photo>();
                    }

                    list.Add(myPhoto);

                }

               );

            return list;
        }

    }
}