using Definer.Business.Users;
using Definer.Entity.Users;
using Definer.Web.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Definer.Web.Controllers
{
    [AllowAnonymous, RoutePrefix("")]
    public class AccountController : Controller
    {
        [Route("login")]
        public ActionResult Login()
        {
            UsersView model = new UsersView();
            return View(model);
        }

        [Route("login"), HttpPost]
        public ActionResult Login(UsersView model)
        {
            Users user = new UserManager().Login(model.Email, model.Password);
            if (user != null)
            {
                if (user.IsActive)
                {
                    if (model.RememberMe)
                    {
                        Response.Cookies.Clear();
                        DateTime expiryDate = DateTime.Now.AddMonths(3);
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, user.Name, DateTime.Now, expiryDate, true, user.ID.ToString());
                        string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                        HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        authenticationCookie.Expires = ticket.Expiration;
                        Response.Cookies.Add(authenticationCookie);

                        return Redirect("/");
                    }
                    else
                    {
                        string DefinerCookie = "{ ID: '" + user.ID + "', Name: '" + user.Name + "' }";

                        FormsAuthentication.SetAuthCookie(DefinerCookie, true);
                        return Redirect("/");
                    }
                }
                else
                {
                    //TempData["Message"] = new { title = "Giriş Başarısız!", type = "orange", content = "Üyeliğinizi henüz aktif etmemişsiniz. Lütfen mail adresinize gönderilen doğrulama linkine tıklayınız!", icon = "fa fa-times-circle fa-thin" };
                }
            }
            else
            {
                //TempData["Message"] = new { title = "Giriş Başarısız!", type = "orange", content = "Kullanıcı adı veya parola bilgilerini kontrol ediniz!", icon = "fa fa-times-circle fa-thin" };
            }

            return Redirect(Request.UrlReferrer.LocalPath);
        }

        [Route("register")]
        public ActionResult Register()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            else
            {
                UsersView model = new UsersView();
                return View(model);
            }
        }

        [Route("register"), HttpPost]
        public ActionResult Register(UsersView model)
        {
            if (ModelState.IsValid)
            {
                Users user = new Users();
                user.Name = model.Name;
                user.Email = model.Email;
                user.Password = model.Password;
                user.EULA = true;
                user.RegisterDate = DateTime.Now;
                user.IsActive = true;

                new UserManager().Add(user);
                return RedirectToAction("login");
            }
            return View("register");
        }

        [Route("logout"), Authorize, HttpGet]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        [Route("CheckExistingEmail")]
        [HttpPost]
        public JsonResult CheckExistingEmail(string Email)
        {
            return Json(new UserManager().CheckMail(Email));
        }
        [Route("CheckExistingUsername")]
        [HttpPost]
        public JsonResult CheckExistingUsername(string Name)
        {
            return Json(new UserManager().CheckUsername(Name));
        }
    }
}