using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiChoHoCS.Models;
public class KhachHang
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    // [JsonPropertyName("Name")]
    public string TenDT { get; set; } = null!;

    public string SDT { get; set; } = null!;

    public string CMND { get; set; } = null!;

    public string DiaChiDT { get; set; } = null!;

    public string TenCH { get; set; } = null!;

    public string DiaChiCH { get; set; } = null!;

    public DateTime NgayThamGia { get; set; }

    public string TrangThai { get; set; } = null!;
}

