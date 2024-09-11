using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CapaEntidad
{
    public class Reporte
    {
        [BsonElement("Id_Reporte")]
        public int Id_Reporte { get; set; }

        [BsonElement("Nombre_Evento")]
        public string Nombre_Evento { get; set; }

        [BsonElement("Nombre_Categoria")]
        public string Nombre_Categoria { get; set; }

        [BsonElement("Descripcion_Evento")]
        public string Descripcion_Evento { get; set; }

        [BsonElement("Fecha_Evento")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Fecha_Evento { get; set; }

        [BsonElement("Id_Administrador")]
        public int Id_Administrador { get; set; }
    }
}
