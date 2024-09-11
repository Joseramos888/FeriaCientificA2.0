using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CapaEntidad
{
    public class Participantes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } // MongoDB uses ObjectId for primary keys

        [BsonElement("ID_Participantes")]
        public string ID_Participantes { get; set; }

        [BsonElement("Nombre_Participantes")]
        public string Nombre_Participantes { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Contraseña")]
        public string Contraseña { get; set; }

        [BsonElement("ID_Evento")]
        public string ID_Evento { get; set; }
    }
}
