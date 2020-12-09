using Definer.Entity.Users;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Definer.Web.Controllers
{
    [AllowAnonymous, RoutePrefix("")]
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
    }
}