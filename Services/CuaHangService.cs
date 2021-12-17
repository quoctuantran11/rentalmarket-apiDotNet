using DiChoHoCS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DiChoHoCS.Services;

public class CuaHangService
{
    private readonly IMongoCollection<CuaHang> _cuaHangCollection;

    public CuaHangService(
        IOptions<DiChoHoDatabaseSettings> diChoHoDatabaseSettings)
    {
        var mongoClient = new MongoClient(diChoHoDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(diChoHoDatabaseSettings.Value.DatabaseName);

        _cuaHangCollection = mongoDatabase.GetCollection<CuaHang>(
            diChoHoDatabaseSettings.Value.CuaHangCollectionName);
    }

    public async Task<List<CuaHang>> GetAsync() =>
        await _cuaHangCollection.Find(_ => true).ToListAsync();

    public async Task<CuaHang?> GetAsync(string id) =>
        await _cuaHangCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(CuaHang newCuaHang) =>
        await _cuaHangCollection.InsertOneAsync(newCuaHang);

    public async Task UpdateAsync(string id, CuaHang updatedCuaHang) =>
        await _cuaHangCollection.ReplaceOneAsync(x => x.Id == id, updatedCuaHang);

    public async Task RemoveAsync(string? id) =>
        await _cuaHangCollection.DeleteOneAsync(x => x.Id == id);
}