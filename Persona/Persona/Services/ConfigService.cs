using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persona.Services
{
    public class ConfigService : BaseService
    {

        public static string EmailUserName
        {
            get
            {

                return GetFromConfig("EmailUserName");

            }
        }

        public static bool IsCacheEnabled
        {
            get
            {

                return GetBoolFromConfig("IsCacheEnabled");

            }
        }

        public static string EmailPassword
        {
            get
            {

                return GetFromConfig("EmailPassword");

            }
        }

        public static string AwsAccessKeyId
        {
            get
            {

                return GetFromConfig("AwsAccessKeyId");

            }
        }

        public static string AwsSecretAccessKey
        {
            get
            {

                return GetFromConfig("AwsSecretAccessKey");

            }
        }

        public static string SiteDomain
        {
            get
            {

                return GetFromConfig("SiteDomain");

            }
        }

        public static string MapApiKey
        {
            get
            {

                return GetFromConfig("MapApiKey");

            }
        }




        public static string FileDomain
        {
            get
            {
                return GetFromConfig("FileDomain");
            }

        }

        public static string BucketName
        {
            get
            {

                return GetFromConfig("BucketName");

            }
        }

        public static string RemoteFilePath
        {
            get
            {

                return GetFromConfig("RemoteFilePath");

            }
        }

        private static string GetFromConfig(string AppSettingsKey)
        {
            return System.Configuration.ConfigurationManager.AppSettings[AppSettingsKey];
        }


        private static bool GetBoolFromConfig(string AppSettingsKey)
        {
            string val = GetFromConfig(AppSettingsKey);

            if (string.IsNullOrEmpty(val))
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(val);
            }
        }

    }
}