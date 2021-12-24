using DiChoHoCS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DiChoHoCS.Services;
public class ChiTietDonHangComboService
{
    private readonly IMongoCollection<ChiTietDonHangCombo> _chiTietDonHangComboCollection;

    public ChiTietDonHangComboService(
        IOptions<DiChoHoDatabaseSettings> diChoHoDatabaseSettings)
    {
        var mongoClient = new MongoClient(diChoHoDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(diChoHoDatabaseSettings.Value.DatabaseName);

        _chiTietDonHangComboCollection = mongoDatabase.GetCollection<ChiTietDonHangCombo>(
            diChoHoDatabaseSettings.Value.ChiTietDonHangComboCollectionName);
    }

    public async Task<List<ChiTietDonHangCombo>> GetAsync() =>
        await _chiTietDonHangComboCollection.Find(_ => true).ToListAsync();

    public async Task<ChiTietDonHangCombo?> GetAsync(string id) =>
        await _chiTietDonHangComboCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ChiTietDonHangCombo newChiTietDonHangCombo) =>
        await _chiTietDonHangComboCollection.InsertOneAsync(newChiTietDonHangCombo);

    public async Task UpdateAsync(string id, ChiTietDonHangCombo updatedChiTietDonHangCombo) =>
        await _chiTietDonHangComboCollection.ReplaceOneAsync(x => x.Id == id, updatedChiTietDonHangCombo);

    public async Task RemoveAsync(string? id) =>
        await _chiTietDonHangComboCollection.DeleteOneAsync(x => x.Id == id);
}