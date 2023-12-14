using SachAPI.DataContext;
using SachAPI.Payloads.Converter;
using SachAPI.Payloads.DataRequests.DataRequestSach;
using SachAPI.Payloads.DataResponses;
using SachAPI.Payloads.Responses;
using SachAPI.Services.Interfaces;

namespace SachAPI.Services.Implements
{
    public class SachService : ISachService
    {
        private readonly AppDBContext _context;
        private readonly ResponseObject<DataResponseSach> _responseObject;
        private readonly SachConverter _converter;

        public SachService(ResponseObject<DataResponseSach> responseObject, SachConverter converter)
        {
            _context = new AppDBContext();
            _responseObject = responseObject;
            _converter = converter;
        }

        public ResponseObject<DataResponseSach> SuaSach(Request_SuaSach request)
        {
            if(request == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng nhập đầy đủ thông tin", null);
            }
            var sach = _context.sachs.FirstOrDefault(x => x.SachID == request.SachID);
            if(sach == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Sách không tồn tại", null);
            }
            sach.TenSach = request.TenSach;
            sach.TacGia= request.TacGia;
            sach.TheLoaiSachID= request.TheLoaiSachID;
            sach.NgayXuatBan=request.NgayXuatBan;
            sach.GiaChoThue=request.GiaChoThue;
            sach.SoLuong=request.SoLuong;
            _context.Update(sach);
            _context.SaveChanges();
            return _responseObject.ResponseSucess("Sửa sách thành công", _converter.EntityToDTO(sach));
        }

        public ResponseObject<DataResponseSach> XoaSach(int sachID)
        {
            var sach = _context.sachs.FirstOrDefault(x => x.SachID == sachID);
            if (sach == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Sách không tồn tại", null);
            }
            _context.Remove(sach);
            _context.SaveChanges();
            return _responseObject.ResponseSucess("Xóa sách thành công",_converter.EntityToDTO(sach));
        }
    }
}
