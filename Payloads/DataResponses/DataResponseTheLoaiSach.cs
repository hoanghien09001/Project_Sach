namespace SachAPI.Payloads.DataResponses
{
    public class DataResponseTheLoaiSach
    {
        public string TenLoaiSach { get; set; }
        public IQueryable<DataResponseSach> Sachs { get; set; }  
    }
}
