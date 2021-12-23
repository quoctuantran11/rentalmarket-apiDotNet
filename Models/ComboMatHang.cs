using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiChoHoCS.Models;
public class ComboMatHang
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string ten_combo { get; set; } = null!;

    public int so_luong_ton { get; set; }

    public double khoi_luong { get; set; }

    public int gia_ban { get; set; }

    public string ma_ch { get; set; } = null!;
}