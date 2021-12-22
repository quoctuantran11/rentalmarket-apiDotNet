using DiChoHoCS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DiChoHoCS.Services;
public class ChiTietComboService
{
    private readonly IMongoCollection<ChiTietCombo> _chiTietComboCollection;

    public ChiTietComboService(
        IOptions<DiChoHoDatabaseSettings> diChoHoDatabaseSettings)
    {
        var mongoClient = new MongoClient(diChoHoDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(diChoHoDatabaseSettings.Value.DatabaseName);

        _chiTietComboCollection = mongoDatabase.GetCollection<ChiTietCombo>(
            diChoHoDatabaseSettings.Value.ChiTietComboCollectionName);
    }

    public async Task<List<ChiTietCombo>> GetAsync() =>
        await _chiTietComboCollection.Find(_ => true).ToListAsync();

    public async Task<ChiTietCombo?> GetAsync(string id) =>
        await _chiTietComboCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ChiTietCombo newChiTietCombo) =>
        await _chiTietComboCollection.InsertOneAsync(newChiTietCombo);

    public async Task UpdateAsync(string id, ChiTietCombo updatedChiTietCombo) =>
        await _chiTietComboCollection.ReplaceOneAsync(x => x.Id == id, updatedChiTietCombo);

    public async Task RemoveAsync(string? id) =>
        await _chiTietComboCollection.DeleteOneAsync(x => x.Id == id);
}