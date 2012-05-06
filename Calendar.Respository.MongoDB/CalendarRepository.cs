using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Calendar.Respository.MongoDB
{
    public class CalendarRepository<T>
    {
        private MongoDatabase _database = Calendar.Respository.MongoDB.CalendarDatabase.Calendar.GetDatabase;
        private MongoCollection<T> _collection;
        public CalendarRepository(string collectionName)
        {
            _collection = _database.GetCollection<T>(collectionName);

        }
        public SafeModeResult Insert(T item){
            return _collection.Insert(item);
        }
        public IEnumerable<SafeModeResult> Insert(List<T> items)
        {
            return _collection.InsertBatch(items);
        }

        public List<T> GetAll()
        {
            return _collection.FindAll().ToList();
        }

        public T FindOne(QueryComplete query)
        {
            return _collection.FindOne(query);
        }
        public List<T> Find(QueryComplete query)
        {
            return _collection.Find(query).ToList();
        }
        public SafeModeResult Remove(QueryComplete query)
        {
            return _collection.Remove(query);
        }
        public SafeModeResult RemoveAll()
        {
            return _collection.RemoveAll();
        }
        public CommandResult Drop()
        {
            return _collection.Drop();
        }
    }
}
