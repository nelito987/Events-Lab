using Events.Data;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace Events.Web.Controllers
{
    [ValidateInput(false)]
    public class BaseController: Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        public bool IsAdmin()
        {
            string currentUserId = this.User.Identity.GetUserId();
            bool isAdmin = (currentUserId != null && this.User.IsInRole("Administrator"));
            return isAdmin;
        }
    }
}