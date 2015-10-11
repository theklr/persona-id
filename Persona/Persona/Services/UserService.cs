using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Data.SqlClient;
using System.Data;
using Persona.Models.Request;
using Persona.Providers;
using Persona.Models;

namespace Persona.Services
{
    public class UserService : BaseService
    {

        private static ApplicationUserManager GetUserManager()
        {
            return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        public static IdentityUser CreateUser(string email, string password, bool autoConfirm = false)
        {
            ApplicationUserManager userManager = GetUserManager();

            ApplicationUser newUser = new ApplicationUser { UserName = email, Email = email, LockoutEnabled = false, EmailConfirmed = autoConfirm };
            IdentityResult result = null;



            try
            {
                result = userManager.Create(newUser, password);

            }
            catch
            {
                new IdentityResultException(result);
            }

            if (result.Succeeded)
            {
                return newUser;
            }
            else
            {
                throw new IdentityResultException(result);
            }
        }


        public static int InsertRegistration(RegistrationAddRequest model, string userId)
        {
            int id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Users_Insert"   //this is the proc name
               , inputParamMapper: delegate(SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@FirstName", model.FirstName);
                   paramCollection.AddWithValue("@LastName", model.LastName);
                   paramCollection.AddWithValue("@Phone", model.Phone);
                   paramCollection.AddWithValue("@UserId", userId);

                   SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                   p.Direction = System.Data.ParameterDirection.Output;

                   paramCollection.Add(p);

               }, returnParameters: delegate(SqlParameterCollection param)
               {
                   int.TryParse(param["@Id"].Value.ToString(), out id);
               }
               );


            return id;
        }


        private static ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        public static ApplicationUser Signin(string email, string password)
        {
            ApplicationUser result = null;

            ApplicationUserManager userManager = GetUserManager();
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            ApplicationUser user = userManager.Find(email, password);

            if (user != null)
            {

                ClaimsIdentity signin = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, signin);
                result = user;

            }


            return result;
        }

        public static string GetCurrentUserId()
        {
            return HttpContext.Current.User.Identity.GetUserId();
        }

    }
}