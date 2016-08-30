using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Events.Data
{    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Event> Events { get; set; }
        public IDbSet<Comment> Comments { get; set; }
    }
}