using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace CapaEntidad
{
    public class Evento
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Id_Evento")]

        public string Id_Evento { get; set; }

        [BsonElement("Nombre_Evento")]
        public string Nombre_Evento { get; set; }

        [BsonElement("Descripcion_Evento")]
        public string Descripcion_Evento { get; set; }

        [BsonElement("Fecha_Evento")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Fecha_Evento { get; set; }

        [BsonElement("Activo_Evento")]
        public bool Activo_Evento { get; set; }

        [BsonElement("Lugar_Evento")]
        public string Lugar_Evento { get; set; }
    }
}
