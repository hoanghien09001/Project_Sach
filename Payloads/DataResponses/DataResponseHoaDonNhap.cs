namespace SachAPI.Payloads.DataResponses
{
    public class DataResponseHoaDonNhap
    {
        public string TenNhanVien {  get; set; }
        public DateTime NgayNhap { get; set; }
        
        public IQueryable<DataResponseChiTietNhap> ChiTietNhaps { get; set; }
    }
}
