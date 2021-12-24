namespace DiChoHoCS.Models;
public class DiChoHoDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string DoiTacCollectionName { get; set; } = null!;

    public string CuaHangCollectionName { get; set; } = null!;

    public string KhachHangCollectionName { get; set; } = null!;

    public string MatHangCollectionName { get; set; } = null!;

    public string ComboMatHangCollectionName { get; set; } = null!;

    public string DonHangCollectionName { get; set; } = null!;

    public string ChiTietDonHangMatHangCollectionName { get; set; } = null!;

    public string ChiTietDonHangComboCollectionName { get; set; } = null!;

    public string ChiTietComboCollectionName { get; set; } = null!;

    public string GioHangCollectionName { get; set; } = null!;
}