namespace SachAPI.Entities
{
    public class ChiTietNhap
    {
        public int ChiTietNhapID {  get; set; }
        public string TenSach {  get; set; }
        public DateTime NgayXuatBan { get; set; }
        public string TacGia {  get; set; }
        public int SoLuong {  get; set; }

        public int? SachID { get; set; }
        public Sach Sach {  get; set; }
        public int HoaDonNhapSachID {  get; set; }
        public HoaDonNhapSach HoaDonNhapSach { get; set; }
        public int TheLoaiSachID { get; set; }
        public TheLoaiSach TheLoaiSach { get; set; }
    }
}
