using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiChoHoCS.Models;

public class GioHang
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    //[BsonElement("Name")]
    // [JsonPropertyName("Name")]
    public string makh { get; set; } = null!;

    public string mamh { get; set; } = null!;

    public string macombo { get; set; } = null!;
}