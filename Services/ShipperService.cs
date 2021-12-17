using DiChoHoCS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DiChoHoCS.Services;

public class ShipperService
{
    private readonly IMongoCollection<Shipper> _ShipperCollection;

    public ShipperService(
        IOptions<DiChoHoDatabaseSettings> diChoHoDatabaseSettings)
    {
        var mongoClient = new MongoClient(diChoHoDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(diChoHoDatabaseSettings.Value.DatabaseName);

        _ShipperCollection = mongoDatabase.GetCollection<Shipper>(
            diChoHoDatabaseSettings.Value.ShipperCollectionName);
    }

    public async Task<List<Shipper>> GetAsync() =>
        await _ShipperCollection.Find(_ => true).ToListAsync();

    public async Task<Shipper?> GetAsync(string id) =>
        await _ShipperCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Shipper newShipper) =>
        await _ShipperCollection.InsertOneAsync(newShipper);

    public async Task UpdateAsync(string id, Shipper updatedShipper) =>
        await _ShipperCollection.ReplaceOneAsync(x => x.Id == id, updatedShipper);

    public async Task RemoveAsync(string? id) =>
        await _ShipperCollection.DeleteOneAsync(x => x.Id == id);
}