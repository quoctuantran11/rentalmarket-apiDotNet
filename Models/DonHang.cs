using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiChoHoCS.Models;
public class DonHang
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string tinh_trang { get; set; } = null!;

    public string hinh_thuc_thanh_toan { get; set; } = null!;

    public int tong_tien { get; set; }

    public string ma_khach_hang { get; set; } = null!;

    public string ma_cua_hang { get; set; } = null!;

    public string ma_shipper { get; set; } = null!;

    public string dia_chi { get; set; } = null!;
    
    public string ngay_dat { get; set; } = null!;
}