using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiChoHoCS.Models;
public class DoiTac
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string sdt { get; set; } = null!;

    public string cccd { get; set; } = null!;

    public string dia_chi { get; set; } = null!;

    public string loai_doi_tac { get; set; } = null!;

    public DateTime ngay_tham_gia { get; set; }

    public string so_luong_cua_hang { get; set; } = null!;

    public string ten_doi_tac { get; set; } = null!;

    public string trang_thai { get; set; } = null!;
}