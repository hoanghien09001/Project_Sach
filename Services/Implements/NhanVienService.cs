using SachAPI.DataContext;
using SachAPI.Entities;
using SachAPI.Payloads.Converter;
using SachAPI.Payloads.DataRequests.DataRequestNhanVien;
using SachAPI.Payloads.DataResponses;
using SachAPI.Payloads.Responses;
using SachAPI.Services.Interfaces;
using BCryptNet = BCrypt.Net.BCrypt;

namespace SachAPI.Services.Implements
{
    public class NhanVienService : INhanVienService
    {
        private readonly AppDBContext _context;
        private readonly ResponseObject<DataResponseNhanVien> _responseObject;
        private readonly NhanVienConverter _converter;

        public NhanVienService(ResponseObject<DataResponseNhanVien> responseObject, NhanVienConverter converter)
        {
            _context = new AppDBContext();
            _responseObject = responseObject;
            _converter = converter;
        }

        public ResponseObject<DataResponseNhanVien> DangKy(Request_DangKy request)
        {
            if(string.IsNullOrWhiteSpace(request.TenNhanVien) || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.DiaChi)
                || string.IsNullOrWhiteSpace(request.SDT) || request.NgaySinh == null || string.IsNullOrWhiteSpace(request.Password))
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng nhập đầy đủ thông tin", null);
            }
            if (_context.nhanViens.Any(x => x.Email == request.Email))
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Email đã tồn tại", null);
            }

            var nhanVien = new NhanVien
            {
                TenNhanVien = request.TenNhanVien,
                Email = request.Email,
                DiaChi = request.DiaChi,
                GioiTinh = request.GioiTinh,
                NgaySinh = request.NgaySinh,
                Password = BCryptNet.HashPassword(request.Password),
                SDT = request.SDT,
                QuyenHanID = 3,
            };

            _context.nhanViens.Add(nhanVien);
            _context.SaveChanges();
            return _responseObject.ResponseSucess("Thêm nhân viên thành công", _converter.EntityToDTO(nhanVien));
        }

        public string DangNhap(Request_DangNhap request)
        {
            if(string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            {
                return "Vui lòng điền đầy đủ thông tin";
            }
            var nhanVien=_context.nhanViens.FirstOrDefault(x=>x.Email== request.Email);
            if(nhanVien==null)
            {
                return "Email không tồn tại";
            }
            bool checkMatKhau = BCryptNet.Verify(request.Password, nhanVien.Password);
            if(!checkMatKhau)
            {
                return "Sai mat khau";
            }
            return "Đăng nhập thành công";
        }

        public ResponseObject<DataResponseNhanVien> SuaThongTinNhanVien(Request_SuaThongTInNhanVien request)
        {
            var nhanVienHienTai=_context.nhanViens.FirstOrDefault(x=>x.NhanVienID==request.NhanVienID);
            if (nhanVienHienTai == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Nhân viên không tồn tại", null);
            }
            nhanVienHienTai.TenNhanVien = request.TenNhanVien;
            nhanVienHienTai.DiaChi= request.DiaChi;
            nhanVienHienTai.Email=request.Email;
            nhanVienHienTai.NgaySinh= request.NgaySinh; 
            nhanVienHienTai.SDT=request.SDT;
            nhanVienHienTai.GioiTinh= request.GioiTinh;
            _context.Update(nhanVienHienTai);
            _context.SaveChanges();
            return _responseObject.ResponseSucess("Sua thong tin thanh cong",_converter.EntityToDTO(nhanVienHienTai));
        }
    }
}
