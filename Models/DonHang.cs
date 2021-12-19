using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace DiChoHoCS.Models;

public class DonHang
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    //[BsonElement("Name")]
    // [JsonPropertyName("Name")]
    public string tinhtrangdon { get; set; } = null!;

    public string hinhthucthanhtoan { get; set; } = null!;

    public int tongtien { get; set; } 

    public string makh { get; set; } = null!;

    public string mach { get; set; } = null!;
    public string mashipper { get; set; } = null!;
    public string manvxl { get; set; } = null!;

}

