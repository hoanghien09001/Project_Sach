namespace SachAPI.Entities
{
    public class Sach
    {
        public int SachID {  get; set; }
        public string TenSach { get; set;}
        public DateTime NgayXuatBan {  get; set;}
        public string TacGia {  get; set;}
        public double GiaChoThue {  get; set;}
        public int SoLuong {  get; set;}

        public int TheLoaiSachID {  get; set;}
        public TheLoaiSach TheLoaiSach { get; set;}

        public IEnumerable<ChiTietSach> ChiTietSachs { get; set; }
        public IEnumerable<ChiTietNhap> ChiTietNhaps { get; set; }
    }
}
