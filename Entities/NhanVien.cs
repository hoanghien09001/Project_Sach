namespace SachAPI.Entities
{
    public class NhanVien
    {
        public int NhanVienID {  get; set; }
        public string TenNhanVien { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi {  get; set; }
        public string SDT {  get; set; }
        public string Email {  get; set; }
        public string Password {  get; set; }

        public int QuyenHanID {  get; set; }
        public QuyenHan QuyenHan { get; set; }

        public IEnumerable<ChiTietThue> ChiTietThues { get; set;}
    }
}
