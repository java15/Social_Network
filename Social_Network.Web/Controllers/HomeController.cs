using System.Web.Mvc;

namespace Social_Network.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
