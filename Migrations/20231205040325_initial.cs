using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SachAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "khachHangs",
                columns: table => new
                {
                    KhachHangID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khachHangs", x => x.KhachHangID);
                });

            migrationBuilder.CreateTable(
                name: "quyenHans",
                columns: table => new
                {
                    QuyenHanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyenHan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quyenHans", x => x.QuyenHanId);
                });

            migrationBuilder.CreateTable(
                name: "theLoaiSachs",
                columns: table => new
                {
                    TheLoaiSachID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiSach = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_theLoaiSachs", x => x.TheLoaiSachID);
                });

            migrationBuilder.CreateTable(
                name: "trangThaiSachs",
                columns: table => new
                {
                    TrangThaiSachID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trangThaiSachs", x => x.TrangThaiSachID);
                });

            migrationBuilder.CreateTable(
                name: "nhanViens",
                columns: table => new
                {
                    NhanVienID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuyenHanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhanViens", x => x.NhanVienID);
                    table.ForeignKey(
                        name: "FK_nhanViens_quyenHans_QuyenHanID",
                        column: x => x.QuyenHanID,
                        principalTable: "quyenHans",
                        principalColumn: "QuyenHanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sachs",
                columns: table => new
                {
                    SachID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayXuatBan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TacGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaChoThue = table.Column<double>(type: "float", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TheLoaiSachID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sachs", x => x.SachID);
                    table.ForeignKey(
                        name: "FK_sachs_theLoaiSachs_TheLoaiSachID",
                        column: x => x.TheLoaiSachID,
                        principalTable: "theLoaiSachs",
                        principalColumn: "TheLoaiSachID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hoaDonNhapSachs",
                columns: table => new
                {
                    HoaDonNhapSachID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NhanVienID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoaDonNhapSachs", x => x.HoaDonNhapSachID);
                    table.ForeignKey(
                        name: "FK_hoaDonNhapSachs_nhanViens_NhanVienID",
                        column: x => x.NhanVienID,
                        principalTable: "nhanViens",
                        principalColumn: "NhanVienID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hoaDonThueSachs",
                columns: table => new
                {
                    HoaDonThueSachID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayThue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TongTien = table.Column<double>(type: "float", nullable: false),
                    KhachHangID = table.Column<int>(type: "int", nullable: false),
                    NhanVienID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoaDonThueSachs", x => x.HoaDonThueSachID);
                    table.ForeignKey(
                        name: "FK_hoaDonThueSachs_khachHangs_KhachHangID",
                        column: x => x.KhachHangID,
                        principalTable: "khachHangs",
                        principalColumn: "KhachHangID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hoaDonThueSachs_nhanViens_NhanVienID",
                        column: x => x.NhanVienID,
                        principalTable: "nhanViens",
                        principalColumn: "NhanVienID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chiTietSachs",
                columns: table => new
                {
                    ChiTietSachID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrangThaiSachID = table.Column<int>(type: "int", nullable: false),
                    SachID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietSachs", x => x.ChiTietSachID);
                    table.ForeignKey(
                        name: "FK_chiTietSachs_sachs_SachID",
                        column: x => x.SachID,
                        principalTable: "sachs",
                        principalColumn: "SachID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietSachs_trangThaiSachs_TrangThaiSachID",
                        column: x => x.TrangThaiSachID,
                        principalTable: "trangThaiSachs",
                        principalColumn: "TrangThaiSachID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chiTietNhaps",
                columns: table => new
                {
                    ChiTietNhapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayXuatBan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TacGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    SachID = table.Column<int>(type: "int", nullable: true),
                    HoaDonNhapSachID = table.Column<int>(type: "int", nullable: false),
                    TheLoaiSachID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietNhaps", x => x.ChiTietNhapID);
                    table.ForeignKey(
                        name: "FK_chiTietNhaps_hoaDonNhapSachs_HoaDonNhapSachID",
                        column: x => x.HoaDonNhapSachID,
                        principalTable: "hoaDonNhapSachs",
                        principalColumn: "HoaDonNhapSachID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietNhaps_sachs_SachID",
                        column: x => x.SachID,
                        principalTable: "sachs",
                        principalColumn: "SachID");
                    table.ForeignKey(
                        name: "FK_chiTietNhaps_theLoaiSachs_TheLoaiSachID",
                        column: x => x.TheLoaiSachID,
                        principalTable: "theLoaiSachs",
                        principalColumn: "TheLoaiSachID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chiTietThues",
                columns: table => new
                {
                    ChiTietThueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGianThue = table.Column<int>(type: "int", nullable: false),
                    HoaDonThueSachID = table.Column<int>(type: "int", nullable: false),
                    ChiTietSachID = table.Column<int>(type: "int", nullable: false),
                    KhachHangID = table.Column<int>(type: "int", nullable: true),
                    NhanVienID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietThues", x => x.ChiTietThueId);
                    table.ForeignKey(
                        name: "FK_chiTietThues_chiTietSachs_ChiTietSachID",
                        column: x => x.ChiTietSachID,
                        principalTable: "chiTietSachs",
                        principalColumn: "ChiTietSachID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietThues_hoaDonThueSachs_HoaDonThueSachID",
                        column: x => x.HoaDonThueSachID,
                        principalTable: "hoaDonThueSachs",
                        principalColumn: "HoaDonThueSachID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietThues_khachHangs_KhachHangID",
                        column: x => x.KhachHangID,
                        principalTable: "khachHangs",
                        principalColumn: "KhachHangID");
                    table.ForeignKey(
                        name: "FK_chiTietThues_nhanViens_NhanVienID",
                        column: x => x.NhanVienID,
                        principalTable: "nhanViens",
                        principalColumn: "NhanVienID");
                });

            migrationBuilder.CreateTable(
                name: "keSachs",
                columns: table => new
                {
                    KeSachID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKeSach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChiTietSachID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_keSachs", x => x.KeSachID);
                    table.ForeignKey(
                        name: "FK_keSachs_chiTietSachs_ChiTietSachID",
                        column: x => x.ChiTietSachID,
                        principalTable: "chiTietSachs",
                        principalColumn: "ChiTietSachID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chiTietNhaps_HoaDonNhapSachID",
                table: "chiTietNhaps",
                column: "HoaDonNhapSachID");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietNhaps_SachID",
                table: "chiTietNhaps",
                column: "SachID");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietNhaps_TheLoaiSachID",
                table: "chiTietNhaps",
                column: "TheLoaiSachID");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietSachs_SachID",
                table: "chiTietSachs",
                column: "SachID");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietSachs_TrangThaiSachID",
                table: "chiTietSachs",
                column: "TrangThaiSachID");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietThues_ChiTietSachID",
                table: "chiTietThues",
                column: "ChiTietSachID");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietThues_HoaDonThueSachID",
                table: "chiTietThues",
                column: "HoaDonThueSachID");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietThues_KhachHangID",
                table: "chiTietThues",
                column: "KhachHangID");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietThues_NhanVienID",
                table: "chiTietThues",
                column: "NhanVienID");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDonNhapSachs_NhanVienID",
                table: "hoaDonNhapSachs",
                column: "NhanVienID");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDonThueSachs_KhachHangID",
                table: "hoaDonThueSachs",
                column: "KhachHangID");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDonThueSachs_NhanVienID",
                table: "hoaDonThueSachs",
                column: "NhanVienID");

            migrationBuilder.CreateIndex(
                name: "IX_keSachs_ChiTietSachID",
                table: "keSachs",
                column: "ChiTietSachID");

            migrationBuilder.CreateIndex(
                name: "IX_nhanViens_QuyenHanID",
                table: "nhanViens",
                column: "QuyenHanID");

            migrationBuilder.CreateIndex(
                name: "IX_sachs_TheLoaiSachID",
                table: "sachs",
                column: "TheLoaiSachID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chiTietNhaps");

            migrationBuilder.DropTable(
                name: "chiTietThues");

            migrationBuilder.DropTable(
                name: "keSachs");

            migrationBuilder.DropTable(
                name: "hoaDonNhapSachs");

            migrationBuilder.DropTable(
                name: "hoaDonThueSachs");

            migrationBuilder.DropTable(
                name: "chiTietSachs");

            migrationBuilder.DropTable(
                name: "khachHangs");

            migrationBuilder.DropTable(
                name: "nhanViens");

            migrationBuilder.DropTable(
                name: "sachs");

            migrationBuilder.DropTable(
                name: "trangThaiSachs");

            migrationBuilder.DropTable(
                name: "quyenHans");

            migrationBuilder.DropTable(
                name: "theLoaiSachs");
        }
    }
}
