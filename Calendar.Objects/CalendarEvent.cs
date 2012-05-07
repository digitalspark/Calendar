using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace Calendar.Objects
{
    public class CalendarEvent
    {
        public ObjectId Id { get; set; }
        public WijmoEvent WijmoEvent { get; set; } 
    }
    public class WijmoEvent
    {
        public string id { get; set; }
        public string calendar { get; set; }
        public string subject { get; set; }
        public string location { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public bool allday { get; set; }
        public string tag { get; set; }
    }
}
