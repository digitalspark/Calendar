using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace Calendar.Models
{
    public class testmodel
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
}