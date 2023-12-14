using SachAPI.DataContext;
using SachAPI.Entities;
using SachAPI.Payloads.Converter;
using SachAPI.Payloads.DataRequests.DataRequestKhachHang;
using SachAPI.Payloads.DataResponses;
using SachAPI.Payloads.Responses;
using SachAPI.Services.Interfaces;

namespace SachAPI.Services.Implements
{
    public class KhachHangService : IKhachHangService
    {
        private readonly AppDBContext _context;
        private readonly ResponseObject<DataResponseKhachHang> _responseObject;
        private readonly KhachHangConverter _converter;

        public KhachHangService(ResponseObject<DataResponseKhachHang> responseObject, KhachHangConverter converter)
        {
            _context = new AppDBContext();
            _responseObject = responseObject;
            _converter = converter;
        }

        public ResponseObject<DataResponseKhachHang> ThemKhachHang(Request_ThemKhachHang request)
        {
            if(request == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng nhập thông tin đầy đủ", null);
            }
            if (_context.khachHangs.Any(x => x.TenKhachHang == request.TenKhachHang))
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Khách hàng đã tồn tại", null);
            }
            var khachHang = new KhachHang
            {
                TenKhachHang = request.TenKhachHang,
                DiaChi = request.DiaChi,
                GioiTinh = request.GioiTinh,
                NgaySinh = request.NgaySinh,
                SDT = request.SDT,
            };
            _context.khachHangs.Add(khachHang);
            _context.SaveChanges();
            return _responseObject.ResponseSucess("Thêm khách hàng thành công",_converter.EntityToDTO(khachHang));
        }
    }
}
