using DiChoHoCS.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace DiChoHoCS.Services;
public class GioHangMatHangService
{
    private readonly IMongoCollection<GioHang> _GioHangCollection;

    private readonly IMongoCollection<MatHang> _MatHangCollection;



    public GioHangMatHangService(IOptions<DiChoHoDatabaseSettings> diChoHoDatabaseSettings)
    {
        
        var mongoClient = new MongoClient(diChoHoDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(diChoHoDatabaseSettings.Value.DatabaseName);

        _GioHangCollection = mongoDatabase.GetCollection<GioHang>(
            diChoHoDatabaseSettings.Value.GioHangCollectionName);

            _MatHangCollection = mongoDatabase.GetCollection<MatHang>(
            diChoHoDatabaseSettings.Value.GioHangCollectionName);

    }

    public async Task<List<GioHang>> GetGioHangWithMatHang() {
        var giohangmathang = await _GioHangCollection.Aggregate().Lookup("_MatHangCollection", "ma_mat_hang", "Id", "ten_mat_hang").ToListAsync();
        // var giohangmathang = await _GioHangCollection.Aggregate()
        // .Lookup(foreignCollectionName: "MatHang",
        // localField: GioHang => GioHang.ma_mat_hang,
        // foreignField: MatHang => MatHang.entity,
        // @as: "ten_mat_hang").ToListAsync();
        List<GioHang> giohang = new List<GioHang>();
        foreach(var ghmh in giohangmathang){
            giohang.Add(BsonSerializer.Deserialize<GioHang>(ghmh));
        }
        return  giohang;
    }

    // IAggregateFluent<GioHang> results = _GioHangCollection.Aggregate().
    //                 Lookup<GioHang, MatHang, GioHang>(
    //                     _MatHangCollection,
    //                     a => a.classBReferenceid,
    //                     b => b.Id,
    //                     a => a.myBs);
   
}