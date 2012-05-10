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
        public string recurrenceState { get; set; }
        public WijmoRecurrencePattern recurrencePattern { get; set; }
    }
    public class WijmoRecurrencePattern
    {
        public string parentRecurrenceId { get; set; }
        public string recurrenceType { get; set; }
        public int interval { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public DateTime patternStartDate { get; set; }
        public DateTime patternEndDate { get; set; }
        public int occurrences { get; set; }
        public string instance { get; set; }
        public string dayOfWeekMask { get; set; }
        public int dayOfMonth { get; set; }
        public int monthOfYear { get; set; }
        public bool noEndDate { get; set; }
        public List<WijmoEvent> exceptions { get; set; }
        public List<WijmoEvent> removedOccurrences { get; set; }
    }
}
