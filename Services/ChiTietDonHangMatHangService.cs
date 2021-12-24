using DiChoHoCS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DiChoHoCS.Services;
public class ChiTietDonHangMatHangService
{
    private readonly IMongoCollection<ChiTietDonHangMatHang> _chiTietDonHangMatHangCollection;

    public ChiTietDonHangMatHangService(
        IOptions<DiChoHoDatabaseSettings> diChoHoDatabaseSettings)
    {
        var mongoClient = new MongoClient(diChoHoDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(diChoHoDatabaseSettings.Value.DatabaseName);

        _chiTietDonHangMatHangCollection = mongoDatabase.GetCollection<ChiTietDonHangMatHang>(
            diChoHoDatabaseSettings.Value.ChiTietDonHangMatHangCollectionName);
    }

    public async Task<List<ChiTietDonHangMatHang>> GetAsync() =>
        await _chiTietDonHangMatHangCollection.Find(_ => true).ToListAsync();

    public async Task<ChiTietDonHangMatHang?> GetAsync(string id) =>
        await _chiTietDonHangMatHangCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ChiTietDonHangMatHang newChiTietDonHangMatHang) =>
        await _chiTietDonHangMatHangCollection.InsertOneAsync(newChiTietDonHangMatHang);

    public async Task UpdateAsync(string id, ChiTietDonHangMatHang updatedChiTietDonHangMatHang) =>
        await _chiTietDonHangMatHangCollection.ReplaceOneAsync(x => x.Id == id, updatedChiTietDonHangMatHang);

    public async Task RemoveAsync(string? id) =>
        await _chiTietDonHangMatHangCollection.DeleteOneAsync(x => x.Id == id);
}