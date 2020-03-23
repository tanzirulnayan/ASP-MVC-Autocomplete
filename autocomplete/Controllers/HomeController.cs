using autocomplete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace autocomplete.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(string keyword)
        {
            //This can be replaced with database call.  
            List<Games> objGameList = new List<Games>() {
                new Games {
                    Id = 1, GameName = "Cricket"
                },  
                new Games {
                    Id = 2, GameName = "Football"
                },  
                new Games {
                    Id = 3, GameName = "Chesh"
                },  
                new Games {
                    Id = 4, GameName = "VallyBall"
                },  
                new Games {
                    Id = 5, GameName = "Kabbadi"
                },  
                new Games {
                    Id = 6, GameName = "Hockey"
                }
            };
            var result = (from a in objGameList where a.GameName.ToLower().StartsWith(keyword.ToLower())
                          select new
                          {
                              a.GameName
                          });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}