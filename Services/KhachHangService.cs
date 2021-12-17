using DiChoHoCS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DiChoHoCS.Services;

public class KhachHangService
{
    private readonly IMongoCollection<KhachHang> _KhachHangCollection;

    public KhachHangService(
        IOptions<DiChoHoDatabaseSettings> diChoHoDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            diChoHoDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            diChoHoDatabaseSettings.Value.DatabaseName);

        _KhachHangCollection = mongoDatabase.GetCollection<KhachHang>(
            diChoHoDatabaseSettings.Value.KhachHangCollectionName);
    }

    public async Task<List<KhachHang>> GetAsync() =>
        await _KhachHangCollection.Find(_ => true).ToListAsync();

    public async Task<KhachHang?> GetAsync(string id) =>
        await _KhachHangCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(KhachHang newKhachHang) =>
        await _KhachHangCollection.InsertOneAsync(newKhachHang);

    public async Task UpdateAsync(string id, KhachHang updatedKhachHang) =>
        await _KhachHangCollection.ReplaceOneAsync(x => x.Id == id, updatedKhachHang);

    public async Task RemoveAsync(string? id) =>
        await _KhachHangCollection.DeleteOneAsync(x => x.Id == id);
}