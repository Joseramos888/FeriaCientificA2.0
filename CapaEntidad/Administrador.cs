using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace CapaEntidad
{
    public class Administrador
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } // MongoDB uses ObjectId for primary keys

        [BsonElement("Nombre_Administrador")]
        public string Nombre_Administrador { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Contraseña")]
        public string Contraseña { get; set; }

        [BsonElement("Rol")]
        public string Rol { get; set; }

        [BsonElement("Telefono")]
        public string Telefono { get; set; }

        [BsonElement("ImagenDePerfil")]
        public string ImagenDePerfil { get; set; }

    }
}
