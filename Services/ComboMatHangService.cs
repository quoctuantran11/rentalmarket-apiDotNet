using DiChoHoCS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DiChoHoCS.Services;

public class ComboMatHangService
{
    private readonly IMongoCollection<ComboMatHang> _comboMatHangCollection;

    public ComboMatHangService(
        IOptions<DiChoHoDatabaseSettings> diChoHoDatabaseSettings)
    {
        var mongoClient = new MongoClient(diChoHoDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(diChoHoDatabaseSettings.Value.DatabaseName);

        _comboMatHangCollection = mongoDatabase.GetCollection<ComboMatHang>(
            diChoHoDatabaseSettings.Value.ComboMatHangCollectionName);
    }

    public async Task<List<ComboMatHang>> GetAsync() =>
        await _comboMatHangCollection.Find(_ => true).ToListAsync();

    public async Task<ComboMatHang?> GetAsync(string id) =>
        await _comboMatHangCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ComboMatHang newComboMatHang) =>
        await _comboMatHangCollection.InsertOneAsync(newComboMatHang);

    public async Task UpdateAsync(string id, ComboMatHang updatedComboMatHang) =>
        await _comboMatHangCollection.ReplaceOneAsync(x => x.Id == id, updatedComboMatHang);

    public async Task RemoveAsync(string? id) =>
        await _comboMatHangCollection.DeleteOneAsync(x => x.Id == id);
}