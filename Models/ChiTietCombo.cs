using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace DiChoHoCS.Models;

public class ChiTietCombo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    //[BsonElement("Name")]
    // [JsonPropertyName("Name")]
    public string macombo { get; set; } = null!;

    public string mamathang { get; set; } = null!;

    public int  soluong { get; set; } 

}

