namespace SachAPI.Entities
{
    public class TrangThaiSach
    {
        public int TrangThaiSachID {  get; set; }
        public string TenTrangThai {  get; set; }

        public IEnumerable<ChiTietSach> ChiTietSachs { get; set; }
    }
}
