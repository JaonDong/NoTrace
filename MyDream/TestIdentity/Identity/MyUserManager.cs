using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace TestIdentity.Identity
{
    public class MyUserManager: UserManager<MyUser, long>
    {

        public MyUserManager(MyUserStore store) : base(store)
        {
        }
        public  Task<IdentityResult> AddLoginAsync(MyUser user, UserLoginInfo login)
        {
            return base.AddLoginAsync(user.Id, login);
        }
    }
}