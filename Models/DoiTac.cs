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

    public string dia_chi_lien_he { get; set; } = null!;

    public string loai_doi_tac { get; set; } = null!;

    public DateTime ngay_tham_gia { get; set; }

    public string so_luong_cua_hang { get; set; } = null!;

    public string ten_dt { get; set; } = null!;

    public string trang_thai_tham_gia { get; set; } = null!;

    public string hinh_anh { get; set; } = null!;

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

    public string ComboMatHangCollectionName { get; set; } = null!;

    public string DonHangCollectionName { get; set; } = null!;

    public string ChiTietDonHang_MatHangCollectionName { get; set; } = null!;

    public string ChiTietDonHang_ComboCollectionName { get; set; } = null!;

    public string ChiTietComboCollectionName { get; set; } = null!;

    public string GioHangCollectionName { get; set; } = null!;
}