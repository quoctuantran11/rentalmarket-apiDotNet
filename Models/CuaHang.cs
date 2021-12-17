using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace DiChoHoCS.Models;

public class CuaHang
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    // [JsonPropertyName("Name")]
    public string tench { get; set; } = null!;

    public string sdt { get; set; } = null!;

    public string diachi { get; set; } = null!;

    public string makv { get; set; } = null!;

    public string madt { get; set; } = null!;
}

