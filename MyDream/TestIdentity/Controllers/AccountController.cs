using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TestIdentity.Domain;
using TestIdentity.Identity;
using TestIdentity.Models;

namespace TestIdentity.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyIdentityDbContext _dbContext;
        private readonly MyRepository<MyIdentityDbContext, MyUser, long> _repository;
        private MyUserManager UserManager => new MyUserManager(new MyUserStore(_repository));
        private IAuthenticationManager Authentication =>HttpContext.GetOwinContext().Authentication ;

        public AccountController()
        {
            _dbContext=new MyIdentityDbContext();
            _repository=new MyRepository<MyIdentityDbContext, MyUser, long>(_dbContext);
        }

    
        #region Action
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new MyUser() { UserName = model.UserName, EmailAddress = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("AccountList");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }

            return View(model);
        }

        public  ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View("Error", new string[] {"您已经登录"});
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(UserLoginModel model, string returnUrl = "accountlist")
        {
            var user =await UserManager.FindAsync(model.UserName, model.Password);

            if (user == null)
            {
                ModelState.AddModelError("","密码或帐号错误");
            }
            else
            {
                var claimsIdentity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                Authentication.SignOut();
                Authentication.SignIn(new AuthenticationProperties { IsPersistent = false }, claimsIdentity);

                return Redirect(returnUrl);
            }
            ViewBag.ReturnUrl = returnUrl;

            return View(model);
        }

        public  ActionResult SignOut()
        {
             Authentication.SignOut();

            return RedirectToAction("Login");
        }

        public ActionResult AccountList()
        {
            var userList = UserManager.Users.ToList();

            var list = userList.Select(user => new UserViewModel
            {
                Email = user.EmailAddress,
                UserName = user.UserName,
                Password = user.Password
            }).ToList();

            return View(list);
        }

        public ActionResult UpdateUser(string userName)
        {
            var model = UserManager.Users.SingleOrDefault(u => u.UserName == userName);
            if (model == null)
                return HttpNotFound("404");

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateUser(UserViewModel model)
        {

            return new JsonResult();
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUser(string userName)
        {
            var user = UserManager.Users.FirstOrDefault(u => u.UserName == userName);
            if (user == null)
                return Json(new {result = false});

            var deleteResult = await UserManager.DeleteAsync(user);

            return Json(new { result = deleteResult.Succeeded });
        }

        #endregion

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}