Create database KoiPond
go

use Koipond
go

CREATE TABLE KhachHang (
    MaKhachHang INT PRIMARY KEY IDENTITY,
    TenKhachHang NVARCHAR(255),
    DiaChi NVARCHAR(255),
    SoDienThoai NVARCHAR(50),
    Email NVARCHAR(100),
    NgayTao DATETIME DEFAULT GETDATE(),
    DiemTrungThanh INT DEFAULT 0
);

CREATE TABLE NhanVien (
    MaNhanVien INT PRIMARY KEY IDENTITY,
    TenNhanVien NVARCHAR(255) NOT NULL,
    ChucVu NVARCHAR(100),
    SoDienThoai NVARCHAR(50),
    Email NVARCHAR(100),
    NgayTao DATETIME DEFAULT GETDATE()
);

CREATE TABLE SanPham (
    MaSanPham INT PRIMARY KEY IDENTITY,
    TenSanPham NVARCHAR(255) NOT NULL,
    DanhMuc NVARCHAR(100),
    MoTaSanPham NVARCHAR(MAX),
    Gia DECIMAL(18, 2),
    SoLuongTrongKho INT,
    DuongDanFileMau NVARCHAR(MAX),
    NgayTao DATETIME DEFAULT GETDATE(),
    NgayCapNhat DATETIME
);

CREATE TABLE YeuCauThiCong (
    MaYeuCau INT PRIMARY KEY IDENTITY,
    MaKhachHang INT FOREIGN KEY REFERENCES KhachHang(MaKhachHang),
    LoaiThietKe NVARCHAR(50),
    ChiTietYeuCau NVARCHAR(MAX),
    TrangThaiYeuCau NVARCHAR(50) DEFAULT 'DangChoXuLy',
	PhanHoi NVARCHAR(max),
    NgayTao DATETIME DEFAULT GETDATE(),
    NgayCapNhat DATETIME
);

CREATE TABLE BaoGiaDuAn (
    MaBaoGia INT PRIMARY KEY IDENTITY,
    MaYeuCau INT FOREIGN KEY REFERENCES YeuCauThiCong(MaYeuCau),
    ChiPhiUocTinh DECIMAL(18, 2),
    DuongDanFileThietKe NVARCHAR(MAX),
	GhiChu NVARCHAR(MAX),
    NgayTao DATETIME DEFAULT GETDATE(),
    NgayCapNhat DATETIME
);

CREATE TABLE YeuCauDichVu (
    MaYeuCau INT PRIMARY KEY IDENTITY,
    MaKhachHang INT FOREIGN KEY REFERENCES KhachHang(MaKhachHang),
    LoaiDichVu NVARCHAR(50),
    NgayYeuCau DATETIME,
    TrangThaiDichVu NVARCHAR(50) DEFAULT 'DangChoXuLy',
	PhanHoi NVARCHAR(max),
    MaNhanVien INT,
    NgayTao DATETIME DEFAULT GETDATE(),
    NgayCapNhat DATETIME
);

CREATE TABLE DanhGiaPhanHoi (
    MaPhanHoi INT PRIMARY KEY IDENTITY,
    MaKhachHang INT FOREIGN KEY REFERENCES KhachHang(MaKhachHang),
    MaYeuCauDichVu INT FOREIGN KEY REFERENCES YeuCauDichVu(MaYeuCau),
	MaYeuCauThiCong INT FOREIGN KEY REFERENCES YeuCauThiCong(MaYeuCau),
    DanhGia INT CHECK (DanhGia >= 1 AND DanhGia <= 5),
    BinhLuan NVARCHAR(MAX),
    NgayTao DATETIME DEFAULT GETDATE()
);

CREATE TABLE ChinhSachThanhToan (
    MaChinhSach INT PRIMARY KEY IDENTITY,
    TenChinhSach NVARCHAR(255) NOT NULL,
    MoTaChinhSach NVARCHAR(MAX),
    DieuKhoanThanhToan NVARCHAR(255),
    ChinhSachHuyDon NVARCHAR(MAX),
    NgayTao DATETIME DEFAULT GETDATE(),
    NgayCapNhat DATETIME
);

CREATE TABLE QuanLyDonHang (
    MaDonHang INT PRIMARY KEY IDENTITY,
    MaYeuCauThiCong INT FOREIGN KEY REFERENCES YeuCauThiCong(MaYeuCau),
	MaYeuCauDichVu INT FOREIGN KEY REFERENCES YeuCauDichVu(MaYeuCau),
    MaChinhSach INT FOREIGN KEY REFERENCES ChinhSachThanhToan(MaChinhSach),
    GiaiDoanThiCong NVARCHAR(50),
    NgayBatDau DATETIME,
    NgayHoanThanh DATETIME,
    TrangThaiDonHang NVARCHAR(50),
    GhiChu NVARCHAR(MAX),
    NgayTao DATETIME DEFAULT GETDATE(),
    NgayCapNhat DATETIME
);

CREATE TABLE LichSuThiCong (
    MaLichSu INT PRIMARY KEY IDENTITY,
    MaDonHang INT FOREIGN KEY REFERENCES QuanLyDonHang(MaDonHang),
    GiaiDoan NVARCHAR(50),
    MoTa NVARCHAR(MAX),
    NgayBatDau DATETIME,
    NgayKetThuc DATETIME,
    TrangThai NVARCHAR(50),
    MaNhanVien INT,
    GhiChu NVARCHAR(MAX),
    NgayTao DATETIME DEFAULT GETDATE(),
    NgayCapNhat DATETIME
);



