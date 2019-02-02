using Microsoft.AspNetCore.Mvc;

public class XmlController : Controller
    {
        [HttpGet]
        public ActionResult Index() {
            return View(viewName:"Xml");
        }

        [HttpPost]
        public ActionResult Index(object o ) {
            return View(viewName:"Xml");
        }
    }