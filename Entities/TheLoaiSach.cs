namespace SachAPI.Entities
{
    public class TheLoaiSach
    {
        public int TheLoaiSachID {  get; set; }
        public string TenLoaiSach {  get; set; }

        public IEnumerable<Sach> Sachs { get; set; }
        public IEnumerable<ChiTietNhap> ChiTietNhaps { get; set; }
    }
}
