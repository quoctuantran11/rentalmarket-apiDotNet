using DiChoHoCS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DiChoHoCS.Services;
public class ShipperService
{
    private readonly IMongoCollection<Shipper> _shipperCollection;

    public ShipperService(
        IOptions<DiChoHoDatabaseSettings> diChoHoDatabaseSettings)
    {
        var mongoClient = new MongoClient(diChoHoDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(diChoHoDatabaseSettings.Value.DatabaseName);

        _shipperCollection = mongoDatabase.GetCollection<Shipper>(
            diChoHoDatabaseSettings.Value.ShipperCollectionName);
    }

    public async Task<List<Shipper>> GetAsync() =>
        await _shipperCollection.Find(_ => true).ToListAsync();

    public async Task<Shipper?> GetAsync(string id) =>
        await _shipperCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Shipper newShipper) =>
        await _shipperCollection.InsertOneAsync(newShipper);

    public async Task UpdateAsync(string id, Shipper updatedShipper) =>
        await _shipperCollection.ReplaceOneAsync(x => x.Id == id, updatedShipper);

    public async Task RemoveAsync(string? id) =>
        await _shipperCollection.DeleteOneAsync(x => x.Id == id);
}