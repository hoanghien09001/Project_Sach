using SachAPI.DataContext;
using SachAPI.Entities;
using SachAPI.Payloads.Converter;
using SachAPI.Payloads.DataRequests.DataRequestTheLoaiSach;
using SachAPI.Payloads.DataResponses;
using SachAPI.Payloads.Responses;
using SachAPI.Services.Interfaces;

namespace SachAPI.Services.Implements
{
    public class TheLoaiSachService : ITheLoaiSachService
    {
        private readonly AppDBContext _context;
        private readonly ResponseObject<DataResponseTheLoaiSach> _responseObject;
        private readonly TheLoaiSachConverter _converter;

        public TheLoaiSachService(ResponseObject<DataResponseTheLoaiSach> responseObject, TheLoaiSachConverter converter)
        {
            _context = new AppDBContext();
            _responseObject = responseObject;
            _converter = converter;
        }

        public ResponseObject<DataResponseTheLoaiSach> ThemTheLoaiSach(Request_ThemTheLoaiSach request)
        {
            if (request == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng nhập đầy đủ thông tin", null);
            }
            if(_context.theLoaiSachs.Any(x=>x.TenLoaiSach == request.TenLoaiSach))
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Thể loại này đã tồn tại", null);
            }
            var theLoaiSach = new TheLoaiSach
            {
                TenLoaiSach = request.TenLoaiSach,
            };
            _context.theLoaiSachs.Add(theLoaiSach);
            _context.SaveChanges();
            return _responseObject.ResponseSucess("Thêm thành công",_converter.EntityToDTO(theLoaiSach));
        }
    }
}
