using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Excercises.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Excercises.Controllers
{
    [Authorize]
    public class BaseAuthController : Controller
    {
        protected ApplicationDBContext db { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public BaseAuthController()
        {
            db = new ApplicationDBContext();
            UserManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(this.db));
        }

        public ApplicationUser ApplicationUser
        {
            get
            {
                return UserManager.FindById(UserID);
            }
            set
            {
                this.ApplicationUser = value;
            }
        }

        public string UserID
        {
            get
            {
                return User.Identity.GetUserId();
            }
            set
            {
                this.UserID = value;
            }
        }
    }
}