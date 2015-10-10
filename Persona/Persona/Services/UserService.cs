using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Persona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Data;




namespace Persona.Services
{
    public class UserService : BaseService
    {
        public static string GetCurrentUserId()
        {
            return HttpContext.Current.User.Identity.GetUserId();
        }

        private static ApplicationUserManager GetUserManager()
        {
            return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        public static IdentityUser AddUser(string phoneNumber, string email, string userName, string password)
        {
            ApplicationUserManager userManager = GetUserManager();

            ApplicationUser newUser = new ApplicationUser { PhoneNumber = phoneNumber, UserName = userName, Email = email, LockoutEnabled = false };

            IdentityResult result = userManager.Create(newUser, password);

            if (result.Succeeded)
                return newUser;

            else
                throw new IdentityResultException(result);
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

        public static bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(GetCurrentUserId());

        }


    }
}