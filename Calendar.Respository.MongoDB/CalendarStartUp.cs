using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;

namespace Calendar.Respository.MongoDB
{
    public class CalendarDatabase : IDisposable
    {
        private static bool _issetup = false;
        private static string _connectionstring;
        private static CalendarDatabase _calendarDatabase;
        private CalendarDatabase() { }

        public static void Setup(string connectionstring)
        {
            if (!string.IsNullOrWhiteSpace(connectionstring))
            {
                _connectionstring = connectionstring;
                _issetup = true;
            }
            else
            {
                throw new Exception("database connectionstring cannot be blank");
            }
        }
        public static CalendarDatabase Calendar
        {
            get
            {
                if (_calendarDatabase == null)
                {
                    if(_issetup)
                        _calendarDatabase = new CalendarDatabase();
                    else
                        throw new Exception("database connectionstring has not been set. please use the Setup method to pass the connectionstring before using the database");
                }
                return _calendarDatabase;
            }
        }
        //note that MongoServer.Create returns the SAME database connection for the same connectionstring. No need to singleton it myself. http://www.mongodb.org/display/DOCS/CSharp+Driver+Quickstart
        //also appharbor's connection string automatically selects the database, so using MongoDatabase.create to directly get the database.
        public MongoDatabase GetDatabase{
            get { return MongoDatabase.Create(_connectionstring); }
        }
        public void Dispose()
        {
            _issetup = false;
            _connectionstring = null;
            _calendarDatabase = null;
        }
    }
}
