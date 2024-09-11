using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Categoria
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("Id_Categoria")]
    public string Id_Categoria { get; set; }

    [BsonElement("Nombre_Categoria")]
    public string Nombre_Categoria { get; set; }

    [BsonElement("Descripcion_Categoria")]
    public string Descripcion_Categoria { get; set; }

    [BsonElement("Activo_Categoria")]
    public bool Activo_Categoria { get; set; }
}
