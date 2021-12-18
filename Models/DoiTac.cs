using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiChoHoCS.Models;
public class DoiTac
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    //[BsonElement("Name")]
    // [JsonPropertyName("Name")]
    public string tendt { get; set; } = null!;

    public string SDT { get; set; } = null!;

    public string CMND { get; set; } = null!;

    public string DiaChiDT { get; set; } = null!;

    public string TenCH { get; set; } = null!;

    public string DiaChiCH { get; set; } = null!;

    public DateTime NgayThamGia { get; set; }

    public string TrangThai { get; set; } = null!;
}

public class DiChoHoDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string DoiTacCollectionName { get; set; } = null!;

    public string CuaHangCollectionName { get; set; } = null!;

    public string KhachHangCollectionName { get; set; } = null!;

    public string ShipperCollectionName { get; set; } = null!;

    public string MatHangCollectionName { get; set; } = null!;

    public string DonHangCollectionName { get; set; } = null!;

    public string ChiTietDonHangCollectionName { get; set; } = null!;
}