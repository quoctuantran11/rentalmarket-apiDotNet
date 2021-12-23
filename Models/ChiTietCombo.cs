using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiChoHoCS.Models;
public class ChiTietCombo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string ma_mat_hang { get; set; } = null!;

    public string ma_combo { get; set; } = null!;

    public int so_luong { get; set; }
}