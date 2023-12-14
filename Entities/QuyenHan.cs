namespace SachAPI.Entities
{
    public class QuyenHan
    {
        public int QuyenHanId { get; set; }
        public string TenQuyenHan {  get; set; }

        public IEnumerable<NhanVien> NhanViens { get; set;}
    }
}
