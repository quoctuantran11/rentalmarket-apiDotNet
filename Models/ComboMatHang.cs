using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace DiChoHoCS.Models;

public class ComboMatHang
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    // [BsonElement("Name")]
    // [JsonPropertyName("Name")]
    public string tencombo { get; set; } = null!;

}

