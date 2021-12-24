using DiChoHoCS.Models;
using DiChoHoCS.Services;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins, builder =>
    {
        builder.AllowAnyOrigin();
    });
});

// Add services to the container.
builder.Services.Configure<DiChoHoDatabaseSettings>(
    builder.Configuration.GetSection("DiChoHoDatabase"));

builder.Services.AddSingleton<DoiTacService>();
builder.Services.AddSingleton<CuaHangService>();
builder.Services.AddSingleton<MatHangService>();
builder.Services.AddSingleton<ComboMatHangService>();
builder.Services.AddSingleton<ChiTietComboService>();
builder.Services.AddSingleton<DonHangService>();
builder.Services.AddSingleton<ChiTietDonHangMatHangService>();
builder.Services.AddSingleton<ChiTietDonHangComboService>();
builder.Services.AddSingleton<GioHangService>();
builder.Services.AddSingleton<KhachHangService>();

builder.Services.AddControllers().AddJsonOptions(
    options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

// builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();