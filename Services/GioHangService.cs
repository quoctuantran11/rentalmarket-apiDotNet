using DiChoHoCS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DiChoHoCS.Services;
public class GioHangService
{
    private readonly IMongoCollection<GioHang> _gioHangCollection;

    public GioHangService(
        IOptions<DiChoHoDatabaseSettings> diChoHoDatabaseSettings)
    {
        var mongoClient = new MongoClient(diChoHoDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(diChoHoDatabaseSettings.Value.DatabaseName);

        _gioHangCollection = mongoDatabase.GetCollection<GioHang>(
            diChoHoDatabaseSettings.Value.GioHangCollectionName);
    }

    public async Task<List<GioHang>> GetAsync() =>
        await _gioHangCollection.Find(_ => true).ToListAsync();

    public async Task<GioHang?> GetAsync(string id) =>
        await _gioHangCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(GioHang newGioHang) =>
        await _gioHangCollection.InsertOneAsync(newGioHang);

    public async Task UpdateAsync(string id, GioHang updatedGioHang) =>
        await _gioHangCollection.ReplaceOneAsync(x => x.Id == id, updatedGioHang);

    public async Task RemoveAsync(string? id) =>
        await _gioHangCollection.DeleteOneAsync(x => x.Id == id);
}