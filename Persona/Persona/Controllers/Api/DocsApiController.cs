using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Amazon.S3;
using Amazon.S3.Transfer;
using Persona.Services;
using Persona.Models.Response;

namespace Persona.Controllers.Api
{
    [RoutePrefix("api/fileupload")]
    public class DocsApiController : ApiController
    {

        [Route, HttpPost]
        public HttpResponseMessage Post()
        {
            HttpResponseMessage result = null;
            HttpRequest httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    HttpPostedFile postedFile = httpRequest.Files[file];
                    string filePath = HttpContext.Current.Server.MapPath("~/FileTemp" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                }

                result = Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return result;
        }

        [Route("aws"), HttpPost]
        public HttpResponseMessage ExternalPost()
        {
            HttpResponseMessage result = null;
            HttpRequest httpRequest = HttpContext.Current.Request;
            TransferUtility fileTransferUtility = new TransferUtility(new AmazonS3Client(ConfigService.cs.AwsAccessKeyId
                                , ConfigService.cs.AwsSecretAccessKey
                                , Amazon.RegionEndpoint.USWest2));

            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    HttpPostedFile postedFile = httpRequest.Files[file];

                    string guid = Guid.NewGuid().ToString();

                    string remoteFilePath = ConfigService.cs.RemoteFilePath + guid + "_" + postedFile.FileName;
                    TransferUtilityUploadRequest fileTransferUtilityRequest = new TransferUtilityUploadRequest
                    {
                        BucketName = ConfigService.cs.BucketName,
                        //FilePath = filePath,
                        InputStream = postedFile.InputStream,
                        //StorageClass = S3StorageClass.ReducedRedundancy,
                        //PartSize = 6291456, // 6 MB.
                        Key = remoteFilePath,
                        //CannedACL = S3CannedACL.PublicRead
                    };
                    fileTransferUtility.Upload(fileTransferUtilityRequest);

                    string paraRemoteFilePath = "/" + remoteFilePath;

                    ItemResponse<string> response = new ItemResponse<string>();

                    string userId = UserService.GetCurrentUserId();

                    ProfileService.UpdatePhotoPath(userId, paraRemoteFilePath);

                    response.Item = remoteFilePath;

                    return Request.CreateResponse(HttpStatusCode.Created, response.Item);


                }



            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }


            return result;

        }


        //PHOTO GALLERY UPLOAD
        [Route("gallery"), HttpPost]
        public HttpResponseMessage UploadGalleryPhoto()
        {
            HttpResponseMessage result = null;
            HttpRequest httpRequest = HttpContext.Current.Request;
            TransferUtility fileTransferUtility = new TransferUtility(new AmazonS3Client(ConfigService.AwsAccessKeyId
                                , ConfigService.AwsSecretAccessKey
                                , Amazon.RegionEndpoint.USWest2));

            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    HttpPostedFile postedFile = httpRequest.Files[file];

                    string guid = Guid.NewGuid().ToString();

                    string remoteFilePath = ConfigService.RemoteFilePath + guid + "_" + postedFile.FileName;
                    TransferUtilityUploadRequest fileTransferUtilityRequest = new TransferUtilityUploadRequest
                    {
                        BucketName = ConfigService.BucketName,

                        InputStream = postedFile.InputStream,

                        Key = remoteFilePath,

                    };

                    fileTransferUtility.Upload(fileTransferUtilityRequest);

                    string paraRemoteFilePath = "/" + remoteFilePath;

                    ItemResponse<string> response = new ItemResponse<string>();

                    PhotosAdd model = new PhotosAdd(); //model binding by hand. creating a new instance of the model w/ file uploads

                    model.userId = UserService.GetCurrentUserId();
                    model.URL = paraRemoteFilePath;

                    PhotosService.PhotosInsert(model);

                    response.Item = remoteFilePath;

                    return Request.CreateResponse(HttpStatusCode.Created, response.Item);

                }

            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return result;

        }


        [Route("companyPhoto"), HttpPost]
        public HttpResponseMessage UploadCompanyPhoto()
        {
            HttpResponseMessage result = null;
            HttpRequest httpRequest = HttpContext.Current.Request;
            TransferUtility fileTransferUtility = new TransferUtility(new AmazonS3Client(ConfigService.AwsAccessKeyId
                                , ConfigService.AwsSecretAccessKey
                                , Amazon.RegionEndpoint.USWest2));

            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    HttpPostedFile postedFile = httpRequest.Files[file];

                    string guid = Guid.NewGuid().ToString();

                    string remoteFilePath = "C08/" + guid + "_" + postedFile.FileName;
                    TransferUtilityUploadRequest fileTransferUtilityRequest = new TransferUtilityUploadRequest
                    {
                        BucketName = "sabio-training",

                        InputStream = postedFile.InputStream,

                        Key = remoteFilePath,

                    };

                    fileTransferUtility.Upload(fileTransferUtilityRequest);

                    string paraRemoteFilePath = "/" + remoteFilePath;

                    ItemResponse<string> response = new ItemResponse<string>();

                    
                    response.Item = remoteFilePath;

                    return Request.CreateResponse(HttpStatusCode.Created, response);

                }

            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return result;

        }

    }
}
