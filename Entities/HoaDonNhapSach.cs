namespace SachAPI.Entities
{
    public class HoaDonNhapSach
    {
        public int HoaDonNhapSachID { get; set; }
        public DateTime NgayNhap {  get; set; }

        public int NhanVienID {  get; set; }
        public NhanVien NhanVien { get; set; }

        public IEnumerable<ChiTietNhap> ChiTietNhaps { get; set; }
    }
}
