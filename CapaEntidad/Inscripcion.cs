using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace CapaEntidad
{
    public class Inscripcion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } // MongoDB uses ObjectId for primary keys

        [BsonElement("Id_Inscripcion")]
        public int Id_Inscripcion { get; set; }

        [BsonElement("Estado_Inscripcion")]
        public string Estado_Inscripcion { get; set; }

        [BsonElement("Fecha_Inscripcion")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Fecha_Inscripcion { get; set; }

        [BsonElement("Nombre_Evento")]
        public string Nombre_Evento { get; set; }

        [BsonElement("Descripcion_Evento")]
        public string Descripcion_Evento { get; set; }

        [BsonElement("Id_Subcategorias")]
        public int Id_Subcategorias { get; set; }

        [BsonElement("Id_Participante")]
        public int Id_Participante { get; set; }

        [BsonElement("Nombre_Participante")]
        public string Nombre_Participante { get; set; }

        [BsonElement("Telefono_Participante")]
        public string Telefono_Participante { get; set; }

        [BsonElement("Id_Categoria")]
        public int Id_Categoria { get; set; }
    }
}
