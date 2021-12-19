using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace DiChoHoCS.Models;

public class ChiTietDonHang_Combo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    //[BsonElement("Name")]
    // [JsonPropertyName("Name")]
    public string madh { get; set; } = null!;

    public string macb { get; set; } = null!;

    public int soluong { get; set; } 
}

