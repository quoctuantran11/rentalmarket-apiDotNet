using DiChoHoCS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DiChoHoCS.Services;

public class ChiTietDonHang_ComboService
{
    private readonly IMongoCollection<ChiTietDonHang_Combo> _ChiTietDonHang_ComboCollection;

    public ChiTietDonHang_ComboService(
        IOptions<DiChoHoDatabaseSettings> diChoHoDatabaseSettings)
    {
        var mongoClient = new MongoClient(diChoHoDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(diChoHoDatabaseSettings.Value.DatabaseName);

        _ChiTietDonHang_ComboCollection = mongoDatabase.GetCollection<ChiTietDonHang_Combo>(
            diChoHoDatabaseSettings.Value.ChiTietDonHang_ComboCollectionName);
    }

    public async Task<List<ChiTietDonHang_Combo>> GetAsync() =>
        await _ChiTietDonHang_ComboCollection.Find(_ => true).ToListAsync();

    public async Task<ChiTietDonHang_Combo?> GetAsync(string id) =>
        await _ChiTietDonHang_ComboCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ChiTietDonHang_Combo newChiTietDonHang_Combo) =>
        await _ChiTietDonHang_ComboCollection.InsertOneAsync(newChiTietDonHang_Combo);

    public async Task UpdateAsync(string id, ChiTietDonHang_Combo updatedChiTietDonHang_Combo) =>
        await _ChiTietDonHang_ComboCollection.ReplaceOneAsync(x => x.Id == id, updatedChiTietDonHang_Combo);

    public async Task RemoveAsync(string? id) =>
        await _ChiTietDonHang_ComboCollection.DeleteOneAsync(x => x.Id == id);
}