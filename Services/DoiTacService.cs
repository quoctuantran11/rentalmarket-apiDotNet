using DiChoHoCS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DiChoHoCS.Services;
public class DoiTacService
{
    private readonly IMongoCollection<DoiTac> _doiTacCollection;

    public DoiTacService(
        IOptions<DiChoHoDatabaseSettings> diChoHoDatabaseSettings)
    {
        var mongoClient = new MongoClient(diChoHoDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(diChoHoDatabaseSettings.Value.DatabaseName);

        _doiTacCollection = mongoDatabase.GetCollection<DoiTac>(
            diChoHoDatabaseSettings.Value.DoiTacCollectionName);
    }

    public async Task<List<DoiTac>> GetAsync() =>
        await _doiTacCollection.Find(_ => true).ToListAsync();

    public async Task<DoiTac?> GetAsync(string id) =>
        await _doiTacCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(DoiTac newDoiTac) =>
        await _doiTacCollection.InsertOneAsync(newDoiTac);

    public async Task UpdateAsync(string id, DoiTac updatedDoiTac) =>
        await _doiTacCollection.ReplaceOneAsync(x => x.Id == id, updatedDoiTac);

    public async Task RemoveAsync(string? id) =>
        await _doiTacCollection.DeleteOneAsync(x => x.Id == id);
}