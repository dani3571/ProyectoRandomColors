﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class InteractionResult
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Hora { get; set; }
        public string TextColor { get; set; }
        public string ContentColor { get; set; }
        public bool Type { get; set; }
        public string Reaccion { get; set; }
        public string Result { get; set; }
    }
}
