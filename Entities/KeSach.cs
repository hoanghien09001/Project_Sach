namespace SachAPI.Entities
{
    public class KeSach
    {
        public int KeSachID {  get; set; }
        public string TenKeSach { get; set; }

        public IEnumerable<ChiTietSach> ChiTietSach { get; set; }
    }
}
