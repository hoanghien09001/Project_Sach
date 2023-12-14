using SachAPI.DataContext;
using SachAPI.Entities;
using SachAPI.Payloads.Converter;
using SachAPI.Payloads.DataRequests.DataRequestHoaDonNhap;
using SachAPI.Payloads.DataResponses;
using SachAPI.Payloads.Responses;
using SachAPI.Services.Interfaces;

namespace SachAPI.Services.Implements
{
    public class HoaDonNhapService : IHoaDonNhapService
    {
        private readonly AppDBContext _context;
        private readonly ResponseObject<DataResponseHoaDonNhap> _responseObject;
        private readonly HoaDonNhapConverter _converter;

        public HoaDonNhapService(ResponseObject<DataResponseHoaDonNhap> responseObject, HoaDonNhapConverter converter)
        {
            _context = new AppDBContext();
            _responseObject = responseObject;
            _converter = converter;
        }
        public List<ChiTietNhap> ThemListChiTietNhap(int hoaDonNhapID, List<Request_ThemChiTietNhap> requests)
        {
            var hoaDonNhap=_context.hoaDonNhapSachs.SingleOrDefault(x=>x.HoaDonNhapSachID==hoaDonNhapID);
            if(hoaDonNhap==null)
            {
                return null;
            }
            List<ChiTietNhap> list=new List<ChiTietNhap>();
            foreach (var request in requests)
            {
                ChiTietNhap ct = new ChiTietNhap();
                if(request.SachID!=null)
                {
                    //update sách nếu sách đã tồn tại
                    var sach=_context.sachs.FirstOrDefault(x=>x.SachID==request.SachID);
                    sach.SoLuong += request.SoLuong;
                    ct.TenSach = sach.TenSach;
                    ct.TacGia=sach.TacGia;
                    ct.NgayXuatBan=sach.NgayXuatBan;
                    ct.SoLuong = request.SoLuong;
                    ct.TheLoaiSachID=sach.TheLoaiSachID;
                    ct.HoaDonNhapSachID = hoaDonNhapID;
                    ct.SachID=sach.SachID;
                    list.Add(ct);
                    _context.Update(sach);
                    _context.SaveChanges();
                    for (int i = 0; i <= request.SoLuong; i++)
                    {
                        ChiTietSach chiTietSach = new ChiTietSach
                        {
                            SachID = sach.SachID,
                            TrangThaiSachID = 1,
                            KeSachID = 1,
                        };
                        _context.chiTietSachs.Add(chiTietSach);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    ct.TenSach = request.TenSach;
                    ct.TacGia = request.TacGia;
                    ct.SoLuong = request.SoLuong;
                    ct.NgayXuatBan=request.NgayXuatBan;
                    ct.TheLoaiSachID= request.TheLoaiSachID;
                    ct.HoaDonNhapSachID= hoaDonNhapID;
                    //thêm sách mới
                    Sach sach = new Sach();
                    sach.TheLoaiSachID = request.TheLoaiSachID;
                    sach.TenSach= request.TenSach;
                    sach.SoLuong= request.SoLuong;
                    sach.NgayXuatBan= request.NgayXuatBan;
                    sach.GiaChoThue = 0;
                    sach.TacGia = request.TacGia;
                    _context.sachs.Add(sach);
                    _context.SaveChanges();
                    int sachID = _context.sachs.SingleOrDefault(x => x.TenSach == sach.TenSach).SachID;
                    ct.SachID= sachID;
                    for (int i = 0; i <= request.SoLuong; i++)
                    {
                        ChiTietSach chiTietSach = new ChiTietSach
                        {
                            SachID=sachID,
                            TrangThaiSachID = 1,
                            KeSachID = 1,
                        };
                        _context.chiTietSachs.Add(chiTietSach);
                        _context.SaveChanges();
                    }
                    list.Add(ct);
                }
            }
            _context.chiTietNhaps.AddRange(list);
            _context.SaveChanges();
            return list;
        }
        public ResponseObject<DataResponseHoaDonNhap> ThemHoaDonNhap(Request_ThemHoaDonNhap request)
        {
            if (request == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng nhập đầy đủ thông tin", null);
            }
            var hoaDonNhap = new HoaDonNhapSach
            {
                NgayNhap = DateTime.Now,
                NhanVienID = request.NhanVienID,
                ChiTietNhaps = null,
            };
            _context.hoaDonNhapSachs.Add(hoaDonNhap);
            _context.SaveChanges();
            hoaDonNhap.ChiTietNhaps = ThemListChiTietNhap(hoaDonNhap.HoaDonNhapSachID, request.themChiTietNhaps);
            return _responseObject.ResponseSucess("Thêm phiếu nhập thành công", _converter.EntityToDTO(hoaDonNhap));
        }
    }
}
