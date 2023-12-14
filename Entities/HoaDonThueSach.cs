namespace SachAPI.Entities
{
    public class HoaDonThueSach
    {
        public int HoaDonThueSachID { get; set; }
        public DateTime NgayThue {  get; set; }
        public int SoLuong {  get; set; }
        public double TongTien {  get; set; }

        public int KhachHangID {  get; set; }
        public KhachHang KhachHang { get; set; }
        public int NhanVienID {  get; set; }
        public NhanVien NhanVien { get; set; }

        public IEnumerable<ChiTietThue> ChiTietThues { get; set; }
    }
}
