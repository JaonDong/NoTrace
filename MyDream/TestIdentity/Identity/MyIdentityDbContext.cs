
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TestIdentity.Identity
{
    public class MyIdentityDbContext: DbContext
    {
        public virtual DbSet<MyUser> Users { get; set; }
         
        public MyIdentityDbContext() : base("IdentityDB")
        {
        }
    }
}