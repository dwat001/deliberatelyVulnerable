using Microsoft.AspNetCore.Mvc;

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