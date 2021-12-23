using DiChoHoCS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DiChoHoCS.Services;
public class DonHangService
{
    private readonly IMongoCollection<DonHang> _donHangCollection;

    public DonHangService(
        IOptions<DiChoHoDatabaseSettings> diChoHoDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            diChoHoDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(
            diChoHoDatabaseSettings.Value.DatabaseName);

        _donHangCollection = mongoDatabase.GetCollection<DonHang>(
            diChoHoDatabaseSettings.Value.DonHangCollectionName);
    }

    public async Task<List<DonHang>> GetAsync() =>
        await _donHangCollection.Find(_ => true).ToListAsync();

    public async Task<DonHang?> GetAsync(string id) =>
        await _donHangCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(DonHang newDonHang) =>
        await _donHangCollection.InsertOneAsync(newDonHang);

    public async Task UpdateAsync(string id, DonHang updatedDonHang) =>
        await _donHangCollection.ReplaceOneAsync(x => x.Id == id, updatedDonHang);

    public async Task RemoveAsync(string? id) =>
        await _donHangCollection.DeleteOneAsync(x => x.Id == id);
}