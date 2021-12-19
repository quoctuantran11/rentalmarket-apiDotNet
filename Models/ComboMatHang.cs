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

    public int soluongton { get; set; }

    public double khoiluong { get; set; }

    public int gia { get; set; }


    public string mach { get; set; } = null!;

}

