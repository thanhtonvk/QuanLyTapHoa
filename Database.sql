use master
go
create database QuanLyCuaHangTapHoa
go
use QuanLyCuaHangTapHoa
go
create table TaiKhoan
(
    TenDangNhap nvarchar(20) primary key,
    MatKhau     nvarchar(20) not null,
    LoaiTK      nvarchar(10)
)
go
insert into TaiKhoan values('admin','admin','admin')
go
create table LoaiSanPham
(
    MaLoai  int identity primary key,
    TenLoai nvarchar(50)
)

go
create table NhanVien
(
    MaNV   int identity primary key,
    TenNV  nvarchar(50),
    SDT    char(10),
    DiaChi nvarchar(50),
)
go
create table SanPham
(
    MaSP   int identity primary key,
    TenSP  nvarchar(50),
    MaLoai int not null,
    NgaySX nvarchar(30),
    HanSD  varchar(30),
    SoLo   int,
    DonGia int
)
go
create table HoaDonBan
(
    MaHD     int identity primary key,
    NgayBan  varchar(30),
    TenKhach nvarchar(50),
    SDT      char(10),
    DiaChi   nvarchar(100),
    MaNV     int not null,
    TongTien int
)
go

create table ChiTietHDB
(
ID int identity primary key,
    MaHD      int not null,
    MaSP      int not null,
    GiaBan    int,
    SoLuong   int,
    ThanhTien int
)

go
create proc ThongKeTheoNgay
as
begin
    select NgayBan,Sum(GiaBan*SoLuong)[TongTien] from HoaDonBan,ChiTietHDB where HoaDonBan.MaHD = ChiTietHDB.MaHD group by NgayBan
end
go
create proc ThongKeSPBanChay
as
begin
    select top 10 SanPham.TenSP,SanPham.DonGia,Sum(ChiTietHDB.SoLuong)[SoLuongBan] 
    from HoaDonBan,ChiTietHDB,SanPham 
    where HoaDonBan.MaHD = ChiTietHDB.MaHD and SanPham.MaSP = ChiTietHDB.MaSP
    group by SanPham.TenSP,SanPham.DonGia

end



go
create proc GetHoaDonBan
as
begin
    select HoaDonBan.MaHD,
           NgayBan,
           TenKhach,
           HoaDonBan.SDT,
           HoaDonBan.DiaChi,
           NhanVien.TenNV,
           SUM(ChiTietHDB.SoLuong * ChiTietHDB.GiaBan) [Tổng tiền]
    from HoaDonBan,
         ChiTietHDB,
         NhanVien
    where HoaDonBan.MaHD = ChiTietHDB.MaHD
      and NhanVien.MaNV = HoaDonBan.MaNV
    group by HoaDonBan.MaHD, NgayBan, TenKhach, HoaDonBan.SDT, HoaDonBan.DiaChi, NhanVien.TenNV
end
go
create proc getChiTietHoaDonBan @MaHD int
as
begin
    select ChiTietHDB.ID,SanPham.TenSP, ChiTietHDB.SoLuong, ChiTietHDB.GiaBan, ChiTietHDB.GiaBan * ChiTietHDB.SoLuong[Thành tiền]
    from HoaDonBan,
         ChiTietHDB,
         SanPham
    where HoaDonBan.MaHD = ChiTietHDB.MaHD
      and ChiTietHDB.MaSP = SanPham.MaSP
      and HoaDonBan.MaHD = @MaHD
end 


