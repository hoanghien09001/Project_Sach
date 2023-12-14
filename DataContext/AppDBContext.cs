using Microsoft.EntityFrameworkCore;
using SachAPI.Entities;

namespace SachAPI.DataContext
{
    public class AppDBContext:DbContext
    {
        public virtual DbSet<ChiTietNhap> chiTietNhaps { get; set; }
        public virtual DbSet<ChiTietSach> chiTietSachs { get; set; }
        public virtual DbSet<ChiTietThue> chiTietThues { get; set; }
        public virtual DbSet<HoaDonNhapSach> hoaDonNhapSachs { get; set; }
        public virtual DbSet<HoaDonThueSach> hoaDonThueSachs { get; set; }
        public virtual DbSet<KeSach> keSachs { get; set; }
        public virtual DbSet<KhachHang> khachHangs { get; set; }
        public virtual DbSet<NhanVien> nhanViens { get; set; }
        public virtual DbSet<QuyenHan> quyenHans { get; set; }
        public virtual DbSet<Sach> sachs { get; set; }
        public virtual DbSet<TheLoaiSach> theLoaiSachs { get; set; }
        public virtual DbSet<TrangThaiSach> trangThaiSachs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server=DESKTOP-C7QLD0H\\SQLEXPRESS; Database=QLThuVien; Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
