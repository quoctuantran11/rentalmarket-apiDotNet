using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiChoHoCS.Models;
public class KhachHang
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string cccd { get; set; } = null!;

    public string sdt { get; set; } = null!;

    public string dia_chi { get; set; } = null!;

    public string ma_khu_vuc { get; set; } = null!;

    public string gioi_tinh { get; set; } = null!;

    public string ten_khach_hang { get; set; } = null!;

    public DateTime ngay_sinh { get; set; }

    public string username { get; set; } = null!;

    public string password { get; set; } = null!;
}