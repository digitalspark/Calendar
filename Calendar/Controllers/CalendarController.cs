using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calendar.Models;
using MongoDB.Driver.Builders;

namespace Calendar.Controllers
{
    public class CalendarController : Controller
    {
        //
        // GET: /Calendar/

        public ActionResult Index()
        {
            var database = Calendar.Respository.MongoDB.CalendarDatabase.Calendar.GetDatabase;

            var collection = database.GetCollection<testmodel>("TestModels");
            try
            {
                collection.RemoveAll();
            }
            catch (Exception)
            {
                //don't know if this throws an exception if the collection hasn't been created yet
            }
            // insert object
            collection.Insert(new testmodel { Name = "foo" });
            // fetch all objects
            var thingies = collection.FindAll();
            return View(thingies.ToList());
        }

    }
}
