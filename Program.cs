using SachAPI.Payloads.Converter;
using SachAPI.Payloads.DataResponses;
using SachAPI.Payloads.Responses;
using SachAPI.Services.Implements;
using SachAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<INhanVienService, NhanVienService>();
builder.Services.AddScoped<IKhachHangService, KhachHangService>();
builder.Services.AddScoped<ITheLoaiSachService, TheLoaiSachService>();
builder.Services.AddScoped<IHoaDonNhapService, HoaDonNhapService>();
builder.Services.AddScoped<ISachService, SachService>();
builder.Services.AddScoped<IHoaDonThueService, HoaDonThueService>();
builder.Services.AddSingleton<NhanVienConverter>();
builder.Services.AddSingleton<KhachHangConverter>();
builder.Services.AddSingleton<TheLoaiSachConverter>();
builder.Services.AddSingleton<ChiTietNhapConverter>();
builder.Services.AddSingleton<HoaDonNhapConverter>();
builder.Services.AddSingleton<SachConverter>();
builder.Services.AddSingleton<HoaDonThueConverter>();
builder.Services.AddSingleton<ChiTietThueConverter>();
builder.Services.AddSingleton<ResponseObject<DataResponseNhanVien>>();
builder.Services.AddSingleton<ResponseObject<DataResponseKhachHang>>();
builder.Services.AddSingleton<ResponseObject<DataResponseTheLoaiSach>>();
builder.Services.AddSingleton<ResponseObject<DataResponseHoaDonNhap>>();
builder.Services.AddSingleton<ResponseObject<DataResponseSach>>();
builder.Services.AddSingleton<ResponseObject<DataResponseHoaDonThue>>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
