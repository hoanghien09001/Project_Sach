namespace SachAPI.Entities
{
    public class ChiTietThue
    {
        public int ChiTietThueId { get; set; }
        public int ThoiGianThue {  get; set; }
        
        public int HoaDonThueSachID {  get; set; }
        public HoaDonThueSach HoaDonThueSach { get; set; }
        public int ChiTietSachID { get; set; }
        public ChiTietSach ChiTietSach { get; set; }
    }
}
