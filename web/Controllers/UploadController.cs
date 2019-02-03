using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
    public class UploadController : Controller
    {
        [HttpGet]
        public ActionResult Index() {
            return View(viewName:"Upload");
        }

        [HttpPost]
        public ActionResult Index(object o ) {
            return View(viewName:"Upload");
        }
    }

}