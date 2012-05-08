using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calendar.Models;
using MongoDB.Driver.Builders;
using Calendar.Objects;
using System.IO;
using MongoDB.Driver;

namespace Calendar.Controllers
{
    public class CalendarController : Controller
    {
        //
        // GET: /Calendar/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Add(WijmoEvent ev)
        {
            //var y = HttpContext.Request.InputStream;
            //y.Position = 0;
            //var json = string.Empty;
            //using (var reader = new StreamReader(y))
            //{
            //    json = reader.ReadToEnd();
            //}
            var repository = new Calendar.Respository.MongoDB.CalendarRepository<CalendarEvent>("CalendarEvents");
            var calendarEvent = new CalendarEvent { WijmoEvent = ev };
            var smr = repository.Insert(calendarEvent);
            if (smr != null)
            {
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public JsonResult Get(string[] calendars)
        {
            var repository = new Calendar.Respository.MongoDB.CalendarRepository<CalendarEvent>("CalendarEvents");
            var results = new List<CalendarEvent>();
            foreach (var calendar in calendars)
            {
                var query = Query.EQ("WijmoEvent.calendar", calendar);
                results.AddRange(repository.Find(query));
            }
            return Json(results.Select(t => t.WijmoEvent));
        }
        [HttpPost]
        public JsonResult Update(WijmoEvent ev)
        {
            //var y = HttpContext.Request.InputStream;
            //y.Position = 0;
            //var json = string.Empty;
            //using (var reader = new StreamReader(y))
            //{
            //    json = reader.ReadToEnd();
            //}
            var repository = new Calendar.Respository.MongoDB.CalendarRepository<CalendarEvent>("CalendarEvents");
            var query = Query.EQ("WijmoEvent._id", ev.id);
            var result = repository.FindOne(query);
            if (result != null)
            {
                result.WijmoEvent = ev;
                repository.Save(result);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public JsonResult Delete(WijmoEvent ev)
        {
            //var y = HttpContext.Request.InputStream;
            //y.Position = 0;
            //var json = string.Empty;
            //using (var reader = new StreamReader(y))
            //{
            //    json = reader.ReadToEnd();
            //}
            var repository = new Calendar.Respository.MongoDB.CalendarRepository<CalendarEvent>("CalendarEvents");
            var query = Query.EQ("WijmoEvent._id", ev.id);
            var result = repository.Remove(query);
            if (result != null)
            {
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
