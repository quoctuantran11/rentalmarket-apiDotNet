using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiChoHoCS.Models;
public class CuaHang
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string ten_cua_hang { get; set; } = null!;

    public string sdt { get; set; } = null!;

    public string dia_chi { get; set; } = null!;

    public string ma_khu_vuc { get; set; } = null!;

    public string ma_doi_tac { get; set; } = null!;

    public string password { get; set; } = null!;

    public string username { get; set; } = null!;

    public string hinh_anh { get; set; } = null!;
}