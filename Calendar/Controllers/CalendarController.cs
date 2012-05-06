using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calendar.Models;
using MongoDB.Driver.Builders;
using Calendar.Objects;
using System.IO;

namespace Calendar.Controllers
{
    public class CalendarController : Controller
    {
        //
        // GET: /Calendar/

        public ActionResult Index()
        {
            var repository = new Calendar.Respository.MongoDB.CalendarRepository<testmodel>("TestModels");

            try
            {
                repository.RemoveAll();
            }
            catch (Exception)
            {
                //don't know if this throws an exception if the collection hasn't been created yet
            }
            // insert object
            repository.Insert(new testmodel { Name = "foo" });
            // fetch all objects
            var thingies = repository.GetAll();
            return View(thingies.ToList());
        }
        [HttpPost]
        public JsonResult Add(CalendarEvent ev, string st, dynamic o, object data)
        {
            var s = ControllerContext;
            var y = HttpContext.Request.InputStream;
            y.Position = 0;
            var json = string.Empty;
            using (var reader = new StreamReader(y))
            {
                json = reader.ReadToEnd();
            }


            st = string.Empty;
            TryValidateModel(st);
            TryValidateModel(o);
            TryValidateModel(data);
            var x = Request;
            return Json(new { });
        }

    }
}
