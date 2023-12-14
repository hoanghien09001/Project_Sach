namespace SachAPI.Entities
{
    public class ChiTietSach
    {
        public int ChiTietSachID {  get; set; }
        public int TrangThaiSachID {  get; set; }
        public TrangThaiSach TrangThaiSachs { get; set; }

        public int SachID {  get; set; }
        public Sach Sach { get; set; }

        public int KeSachID { get; set; }
        public KeSach KeSach { get; set; }

        public IEnumerable<ChiTietThue> ChiTietThues { get; set; }
    }
}
