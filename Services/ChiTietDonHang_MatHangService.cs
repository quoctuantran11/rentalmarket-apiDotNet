using DiChoHoCS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DiChoHoCS.Services;

public class ChiTietDonHang_MatHangService
{
    private readonly IMongoCollection<ChiTietDonHang_MatHang> _ChiTietDonHang_MatHangCollection;

    public ChiTietDonHang_MatHangService(
        IOptions<DiChoHoDatabaseSettings> diChoHoDatabaseSettings)
    {
        var mongoClient = new MongoClient(diChoHoDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(diChoHoDatabaseSettings.Value.DatabaseName);

        _ChiTietDonHang_MatHangCollection = mongoDatabase.GetCollection<ChiTietDonHang_MatHang>(
            diChoHoDatabaseSettings.Value.ChiTietDonHang_MatHangCollectionName);
    }

    public async Task<List<ChiTietDonHang_MatHang>> GetAsync() =>
        await _ChiTietDonHang_MatHangCollection.Find(_ => true).ToListAsync();

    public async Task<ChiTietDonHang_MatHang?> GetAsync(string id) =>
        await _ChiTietDonHang_MatHangCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ChiTietDonHang_MatHang newChiTietDonHang_MatHang) =>
        await _ChiTietDonHang_MatHangCollection.InsertOneAsync(newChiTietDonHang_MatHang);

    public async Task UpdateAsync(string id, ChiTietDonHang_MatHang updatedChiTietDonHang_MatHang) =>
        await _ChiTietDonHang_MatHangCollection.ReplaceOneAsync(x => x.Id == id, updatedChiTietDonHang_MatHang);

    public async Task RemoveAsync(string? id) =>
        await _ChiTietDonHang_MatHangCollection.DeleteOneAsync(x => x.Id == id);
}