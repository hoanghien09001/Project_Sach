using SachAPI.Entities;

namespace SachAPI.Payloads.DataResponses
{
    public class DataResponseKeSach
    {
        public string TenKeSach { get; set; }
        public IQueryable<ChiTietSach> ChiTietSachs { get;set; }
    }
}
