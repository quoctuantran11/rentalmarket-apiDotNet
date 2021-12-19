using DiChoHoCS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DiChoHoCS.Services;

public class GioHangService
{
    private readonly IMongoCollection<GioHang> _GioHangCollection;

    public GioHangService(
        IOptions<DiChoHoDatabaseSettings> diChoHoDatabaseSettings)
    {
        var mongoClient = new MongoClient(diChoHoDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(diChoHoDatabaseSettings.Value.DatabaseName);

        _GioHangCollection = mongoDatabase.GetCollection<GioHang>(
            diChoHoDatabaseSettings.Value.GioHangCollectionName);
    }

    public async Task<List<GioHang>> GetAsync() =>
        await _GioHangCollection.Find(_ => true).ToListAsync();

    public async Task<GioHang?> GetAsync(string id) =>
        await _GioHangCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(GioHang newGioHang) =>
        await _GioHangCollection.InsertOneAsync(newGioHang);

    public async Task UpdateAsync(string id, GioHang updatedGioHang) =>
        await _GioHangCollection.ReplaceOneAsync(x => x.Id == id, updatedGioHang);

    public async Task RemoveAsync(string? id) =>
        await _GioHangCollection.DeleteOneAsync(x => x.Id == id);
}