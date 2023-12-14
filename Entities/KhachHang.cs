namespace SachAPI.Entities
{
    public class KhachHang
    {
        public int KhachHangID {  get; set; }
        public string TenKhachHang {  get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh {  get; set; }
        public string DiaChi {  get; set; }
        public string SDT {  get; set; }

        public IEnumerable<ChiTietThue> ChiTietThues { get; set; }
    }
}
