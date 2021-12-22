using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiChoHoCS.Models;
public class Shipper
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string ten_ch { get; set; } = null!;

    public string sdt { get; set; } = null!;

    public string dia_chi { get; set; } = null!;

    public string ma_kv { get; set; } = null!;

    public string ma_dt { get; set; } = null!;
}