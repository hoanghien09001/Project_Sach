namespace SachAPI.Payloads.DataRequests.DataRequestSach
{
    public class Request_SuaSach
    {
        public int SachID { get; set; }
        public string TenSach { get; set; }
        public DateTime NgayXuatBan { get; set; }
        public string TacGia { get; set; }
        public double GiaChoThue { get; set; }
        public int SoLuong { get; set; }

        public int TheLoaiSachID { get; set; }
    }
}
