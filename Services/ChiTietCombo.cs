using DiChoHoCS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DiChoHoCS.Services;

public class ChiTietComboService
{
    private readonly IMongoCollection<ChiTietCombo> _ChiTietComboCollection;

    public ChiTietComboService(
        IOptions<DiChoHoDatabaseSettings> diChoHoDatabaseSettings)
    {
        var mongoClient = new MongoClient(diChoHoDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(diChoHoDatabaseSettings.Value.DatabaseName);

        _ChiTietComboCollection = mongoDatabase.GetCollection<ChiTietCombo>(
            diChoHoDatabaseSettings.Value.ChiTietComboCollectionName);
    }

    public async Task<List<ChiTietCombo>> GetAsync() =>
        await _ChiTietComboCollection.Find(_ => true).ToListAsync();

    public async Task<ChiTietCombo?> GetAsync(string id) =>
        await _ChiTietComboCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ChiTietCombo newChiTietCombo) =>
        await _ChiTietComboCollection.InsertOneAsync(newChiTietCombo);

    public async Task UpdateAsync(string id, ChiTietCombo updatedChiTietCombo) =>
        await _ChiTietComboCollection.ReplaceOneAsync(x => x.Id == id, updatedChiTietCombo);

    public async Task RemoveAsync(string? id) =>
        await _ChiTietComboCollection.DeleteOneAsync(x => x.Id == id);
}