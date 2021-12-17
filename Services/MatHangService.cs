using DiChoHoCS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DiChoHoCS.Services;

public class MatHangService
{
    private readonly IMongoCollection<MatHang> _MatHangCollection;

    public MatHangService(
        IOptions<DiChoHoDatabaseSettings> diChoHoDatabaseSettings)
    {
        var mongoClient = new MongoClient(diChoHoDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(diChoHoDatabaseSettings.Value.DatabaseName);

        _MatHangCollection = mongoDatabase.GetCollection<MatHang>(
            diChoHoDatabaseSettings.Value.MatHangCollectionName);
    }

    public async Task<List<MatHang>> GetAsync() =>
        await _MatHangCollection.Find(_ => true).ToListAsync();

    public async Task<MatHang?> GetAsync(string id) =>
        await _MatHangCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(MatHang newMatHang) =>
        await _MatHangCollection.InsertOneAsync(newMatHang);

    public async Task UpdateAsync(string id, MatHang updatedMatHang) =>
        await _MatHangCollection.ReplaceOneAsync(x => x.Id == id, updatedMatHang);

    public async Task RemoveAsync(string? id) =>
        await _MatHangCollection.DeleteOneAsync(x => x.Id == id);
}