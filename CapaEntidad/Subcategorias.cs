using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace CapaEntidad
{
    public class Subcategorias
    {
        [BsonId]
        public string Id_Subcategorias { get; set; }

        [BsonElement("Activo_Subcategoria")]
        public bool Activo_Subcategoria { get; set; }

        [BsonElement("Id_Categoria")]
        public string Id_Categoria { get; set; }

        [BsonElement("Cantidad_Miembros")]
        public string Cantidad_Miembros { get; set; }
    }
}

