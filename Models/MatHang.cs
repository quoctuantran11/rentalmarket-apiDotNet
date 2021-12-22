using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiChoHoCS.Models;
public class MatHang
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string ten_mh { get; set; } = null!;

    public string xuat_xu { get; set; } = null!;

    public int so_luong_ton { get; set; }

    public double khoi_luong { get; set; }

    public int gia_ban { get; set; }

    public string ma_loai { get; set; } = null!;

    public string ma_ch { get; set; } = null!;

    public string hinh_anh { get; set; } = null!;
}