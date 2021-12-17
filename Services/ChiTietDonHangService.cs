using DiChoHoCS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DiChoHoCS.Services;

public class ChiTietDonHangService
{
    private readonly IMongoCollection<ChiTietDonHang> _ChiTietDonHangCollection;

    public ChiTietDonHangService(
        IOptions<DiChoHoDatabaseSettings> diChoHoDatabaseSettings)
    {
        var mongoClient = new MongoClient(diChoHoDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(diChoHoDatabaseSettings.Value.DatabaseName);

        _ChiTietDonHangCollection = mongoDatabase.GetCollection<ChiTietDonHang>(
            diChoHoDatabaseSettings.Value.ChiTietDonHangCollectionName);
    }

    public async Task<List<ChiTietDonHang>> GetAsync() =>
        await _ChiTietDonHangCollection.Find(_ => true).ToListAsync();

    public async Task<ChiTietDonHang?> GetAsync(string id) =>
        await _ChiTietDonHangCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ChiTietDonHang newChiTietDonHang) =>
        await _ChiTietDonHangCollection.InsertOneAsync(newChiTietDonHang);

    public async Task UpdateAsync(string id, ChiTietDonHang updatedChiTietDonHang) =>
        await _ChiTietDonHangCollection.ReplaceOneAsync(x => x.Id == id, updatedChiTietDonHang);

    public async Task RemoveAsync(string? id) =>
        await _ChiTietDonHangCollection.DeleteOneAsync(x => x.Id == id);
}