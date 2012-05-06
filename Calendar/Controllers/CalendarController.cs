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

    }
}
