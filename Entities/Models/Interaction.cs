﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Interaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Ip { get; set; }
        public DateTime Hora { get; set; }
        public string TextColor { get; set; }
        public string ContentColor { get; set; }
        public string Reaccion { get; set; }
    }
}
