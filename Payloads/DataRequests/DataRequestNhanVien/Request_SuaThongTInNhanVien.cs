namespace SachAPI.Payloads.DataRequests.DataRequestNhanVien
{
    public class Request_SuaThongTInNhanVien
    {
        public int NhanVienID { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
    }
}
