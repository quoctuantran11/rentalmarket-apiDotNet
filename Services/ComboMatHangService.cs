using DiChoHoCS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DiChoHoCS.Services;
public class ComboMatHangService
{
    private readonly IMongoCollection<ComboMatHang> _comboMatHang;

    public ComboMatHangService(
        IOptions<DiChoHoDatabaseSettings> diChoHoDatabaseSettings)
    {
        var mongoClient = new MongoClient(diChoHoDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(diChoHoDatabaseSettings.Value.DatabaseName);

        _comboMatHang = mongoDatabase.GetCollection<ComboMatHang>(
            diChoHoDatabaseSettings.Value.ComboMatHangCollectionName);
    }

    public async Task<List<ComboMatHang>> GetAsync() =>
        await _comboMatHang.Find(_ => true).ToListAsync();

    public async Task<ComboMatHang?> GetAsync(string id) =>
        await _comboMatHang.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ComboMatHang newComboMatHang) =>
        await _comboMatHang.InsertOneAsync(newComboMatHang);

    public async Task UpdateAsync(string id, ComboMatHang updatedComboMatHang) =>
        await _comboMatHang.ReplaceOneAsync(x => x.Id == id, updatedComboMatHang);

    public async Task RemoveAsync(string? id) =>
        await _comboMatHang.DeleteOneAsync(x => x.Id == id);
}