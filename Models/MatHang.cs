using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace DiChoHoCS.Models;

public class MatHang
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    // [BsonElement("Name")]
    // [JsonPropertyName("Name")]
    public string ten { get; set; } = null!;

    public string xuatxu { get; set; } = null!;

    public int soluongton;

    public double khoiluong ;

    public int gia { get; set; }

    public string maloai { get; set; } = null!;

    public string mach { get; set; } = null!;
}

