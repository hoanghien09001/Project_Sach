using SachAPI.DataContext;
using SachAPI.Entities;
using SachAPI.Payloads.Converter;
using SachAPI.Payloads.DataRequests.DataRequestHoaDonThue;
using SachAPI.Payloads.DataResponses;
using SachAPI.Payloads.Responses;
using SachAPI.Services.Interfaces;

namespace SachAPI.Services.Implements
{
    public class HoaDonThueService : IHoaDonThueService
    {
        private readonly AppDBContext _context;
        private ResponseObject<DataResponseHoaDonThue> _responseObject;
        private readonly HoaDonThueConverter _converter;
        private readonly ChiTietThueConverter _thueConverter;

        public HoaDonThueService(ResponseObject<DataResponseHoaDonThue> responseObject, HoaDonThueConverter converter, ChiTietThueConverter thueConverter)
        {
            _context = new AppDBContext();
            _responseObject = responseObject;
            _converter = converter;
            _thueConverter = thueConverter;
        }

        public List<ChiTietThue> ThemListChiTietThue(int hoaDonThueID, List<Request_ThemChiTietThue> requests)
        {
            var hoaDonThue=_context.hoaDonThueSachs.FirstOrDefault(x=>x.HoaDonThueSachID==hoaDonThueID);
            if(hoaDonThue==null)
            {
                return null;
            }
            List<ChiTietThue> list=new List<ChiTietThue>();
            int d = 0;
            double tongtien = 0;
            foreach (var request in requests)
            {
                ChiTietThue ct=new ChiTietThue();
                ct.HoaDonThueSachID=hoaDonThueID;
                ct.ChiTietSachID=request.ChiTietSachID;
                ct.ThoiGianThue=request.ThoiGianThue;
                //Tính số lượng thuê và tổng tiền của hóa đơn
                var chiTietSach = _context.chiTietSachs.FirstOrDefault(x => x.ChiTietSachID == ct.ChiTietSachID);
                d += 1;
                double giaThue=_context.sachs.FirstOrDefault(x=>x.SachID==chiTietSach.SachID).GiaChoThue;
                tongtien += giaThue * ct.ThoiGianThue;
                list.Add(ct);
                //set trạng thái sách      
                chiTietSach.TrangThaiSachID = 2;
                _context.Update(chiTietSach);
                _context.SaveChanges();
            }
            _context.chiTietThues.AddRange(list);
            _context.SaveChanges();
            hoaDonThue.SoLuong = d;
            hoaDonThue.TongTien= tongtien;
            _context.Update(hoaDonThue);
            _context.SaveChanges();
            return list;
        }
        public ResponseObject<DataResponseHoaDonThue> ThemHoaDonThue(Request_ThemHoaDonThue request)
        {
            if (request == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng nhập đầy đủ thông tin",null);
            }
            var hoaDonThue = new HoaDonThueSach
            {
                KhachHangID = request.KhachHangID,
                NhanVienID = request.NhanVienID,
                NgayThue = request.NgayThue,
                SoLuong = 0,
                TongTien = 0,
                ChiTietThues = null,
            };
            _context.hoaDonThueSachs.Add(hoaDonThue);
            _context.SaveChanges();
            hoaDonThue.ChiTietThues = ThemListChiTietThue(hoaDonThue.HoaDonThueSachID, request.themChiTietThues);
            return _responseObject.ResponseSucess("Thêm hóa đơn thuê thành công",_converter.EntityToDTO(hoaDonThue));
        }

        public List<DataResponseChiTietThue> HienThiSachThue(int khachHangID)
        {
            var hoaDonThues=_context.hoaDonThueSachs.Where(x=>x.KhachHangID==khachHangID).ToList();
            List<DataResponseChiTietThue> lst = new List<DataResponseChiTietThue>();
            foreach (var hoaDonThue in hoaDonThues)
            {
                var lstThue = _context.chiTietThues.Where(x => x.HoaDonThueSachID == hoaDonThue.HoaDonThueSachID).Select(x => _thueConverter.EntityToDTO(x)).ToList();
                lst.AddRange(lstThue);
            }
            return lst;
        }

        public List<DataResponseChiTietThue> HienThiSachHoaDon(int hoaDonID)
        {
            var lstThue = _context.chiTietThues.Where(x => x.HoaDonThueSachID == hoaDonID).Select(x => _thueConverter.EntityToDTO(x)).ToList();
            return lstThue;
        }
    }
}
