USE [master]
GO
/****** Object:  Database [KoiPond]    Script Date: 11/8/2024 4:43:08 PM ******/
CREATE DATABASE [KoiPond]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KoiPond', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\KoiPond.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KoiPond_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\KoiPond_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [KoiPond] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KoiPond].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KoiPond] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KoiPond] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KoiPond] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KoiPond] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KoiPond] SET ARITHABORT OFF 
GO
ALTER DATABASE [KoiPond] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [KoiPond] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KoiPond] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KoiPond] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KoiPond] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KoiPond] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KoiPond] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KoiPond] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KoiPond] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KoiPond] SET  ENABLE_BROKER 
GO
ALTER DATABASE [KoiPond] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KoiPond] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KoiPond] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KoiPond] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KoiPond] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KoiPond] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KoiPond] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KoiPond] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KoiPond] SET  MULTI_USER 
GO
ALTER DATABASE [KoiPond] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KoiPond] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KoiPond] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KoiPond] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KoiPond] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KoiPond] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [KoiPond] SET QUERY_STORE = ON
GO
ALTER DATABASE [KoiPond] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [KoiPond]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/8/2024 4:43:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaoGiaDuAn]    Script Date: 11/8/2024 4:43:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaoGiaDuAn](
	[MaBaoGia] [int] IDENTITY(1,1) NOT NULL,
	[MaYeuCau] [int] NULL,
	[ChiPhiUocTinh] [decimal](18, 2) NULL,
	[DesignFilePath] [nvarchar](max) NULL,
	[GhiChu] [nvarchar](max) NULL,
	[NgayTao] [datetime] NULL,
	[NgayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBaoGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChinhSachThanhToan]    Script Date: 11/8/2024 4:43:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChinhSachThanhToan](
	[MaChinhSach] [int] IDENTITY(1,1) NOT NULL,
	[TenChinhSach] [nvarchar](255) NOT NULL,
	[MoTaChinhSach] [nvarchar](max) NULL,
	[DieuKhoanThanhToan] [nvarchar](255) NULL,
	[ChinhSachHuyDon] [nvarchar](max) NULL,
	[NgayTao] [datetime] NULL,
	[NgayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChinhSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhGiaPhanHoi]    Script Date: 11/8/2024 4:43:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGiaPhanHoi](
	[MaPhanHoi] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [int] NULL,
	[MaYeuCauDichVu] [int] NULL,
	[MaYeuCauThiCong] [int] NULL,
	[DanhGia] [int] NULL,
	[BinhLuan] [nvarchar](max) NULL,
	[NgayTao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhanHoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 11/8/2024 4:43:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [int] IDENTITY(1,1) NOT NULL,
	[TenKhachHang] [nvarchar](255) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[SoDienThoai] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[NgayTao] [datetime] NULL,
	[DiemTrungThanh] [int] NULL,
	[ImagePath] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LichSuThiCong]    Script Date: 11/8/2024 4:43:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichSuThiCong](
	[MaLichSu] [int] IDENTITY(1,1) NOT NULL,
	[MaDonHang] [int] NULL,
	[GiaiDoan] [nvarchar](50) NULL,
	[MoTa] [nvarchar](max) NULL,
	[NgayBatDau] [datetime] NULL,
	[NgayKetThuc] [datetime] NULL,
	[TrangThai] [nvarchar](50) NULL,
	[MaNhanVien] [int] NULL,
	[GhiChu] [nvarchar](max) NULL,
	[NgayTao] [datetime] NULL,
	[NgayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLichSu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 11/8/2024 4:43:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[TenNhanVien] [nvarchar](255) NOT NULL,
	[ChucVu] [nvarchar](100) NULL,
	[SoDienThoai] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[NgayTao] [datetime] NULL,
	[ImagePath] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLyDonHang]    Script Date: 11/8/2024 4:43:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyDonHang](
	[MaDonHang] [int] IDENTITY(1,1) NOT NULL,
	[MaYeuCauThiCong] [int] NULL,
	[MaYeuCauDichVu] [int] NULL,
	[MaChinhSach] [int] NULL,
	[GiaiDoanThiCong] [nvarchar](50) NULL,
	[NgayBatDau] [datetime] NULL,
	[NgayHoanThanh] [datetime] NULL,
	[TrangThaiDonHang] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](max) NULL,
	[NgayTao] [datetime] NULL,
	[NgayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleClaims]    Script Date: 11/8/2024 4:43:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](max) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/8/2024 4:43:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[NormalizedName] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 11/8/2024 4:43:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](255) NOT NULL,
	[DanhMuc] [nvarchar](100) NULL,
	[MoTaSanPham] [nvarchar](max) NULL,
	[Gia] [decimal](18, 2) NULL,
	[SoLuongTrongKho] [int] NULL,
	[DuongDanFileMau] [nvarchar](max) NULL,
	[NgayTao] [datetime] NULL,
	[NgayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaims]    Script Date: 11/8/2024 4:43:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 11/8/2024 4:43:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[LoginProvider] [nvarchar](max) NOT NULL,
	[ProviderKey] [nvarchar](max) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 11/8/2024 4:43:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [nvarchar](max) NULL,
	[RoleId] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/8/2024 4:43:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTokens]    Script Date: 11/8/2024 4:43:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTokens](
	[UserId] [nvarchar](max) NULL,
	[LoginProvider] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Value] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[YeuCauDichVu]    Script Date: 11/8/2024 4:43:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[YeuCauDichVu](
	[MaYeuCau] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [int] NULL,
	[LoaiDichVu] [nvarchar](50) NULL,
	[NgayYeuCau] [datetime] NULL,
	[TrangThaiDichVu] [nvarchar](50) NULL,
	[PhanHoi] [nvarchar](max) NULL,
	[MaNhanVien] [int] NULL,
	[NgayTao] [datetime] NULL,
	[NgayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaYeuCau] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[YeuCauThiCong]    Script Date: 11/8/2024 4:43:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[YeuCauThiCong](
	[MaYeuCau] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [int] NULL,
	[LoaiThietKe] [nvarchar](50) NULL,
	[ChiTietYeuCau] [nvarchar](max) NULL,
	[TrangThaiYeuCau] [nvarchar](50) NULL,
	[PhanHoi] [nvarchar](max) NULL,
	[NgayTao] [datetime] NULL,
	[NgayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaYeuCau] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[BaoGiaDuAn] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[ChinhSachThanhToan] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[DanhGiaPhanHoi] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[KhachHang] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[KhachHang] ADD  DEFAULT ((0)) FOR [DiemTrungThanh]
GO
ALTER TABLE [dbo].[LichSuThiCong] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[NhanVien] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[QuanLyDonHang] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[SanPham] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[YeuCauDichVu] ADD  DEFAULT ('DangChoXuLy') FOR [TrangThaiDichVu]
GO
ALTER TABLE [dbo].[YeuCauDichVu] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[YeuCauThiCong] ADD  DEFAULT ('DangChoXuLy') FOR [TrangThaiYeuCau]
GO
ALTER TABLE [dbo].[YeuCauThiCong] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[BaoGiaDuAn]  WITH CHECK ADD FOREIGN KEY([MaYeuCau])
REFERENCES [dbo].[YeuCauThiCong] ([MaYeuCau])
GO
ALTER TABLE [dbo].[DanhGiaPhanHoi]  WITH CHECK ADD FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[DanhGiaPhanHoi]  WITH CHECK ADD FOREIGN KEY([MaYeuCauDichVu])
REFERENCES [dbo].[YeuCauDichVu] ([MaYeuCau])
GO
ALTER TABLE [dbo].[DanhGiaPhanHoi]  WITH CHECK ADD FOREIGN KEY([MaYeuCauThiCong])
REFERENCES [dbo].[YeuCauThiCong] ([MaYeuCau])
GO
ALTER TABLE [dbo].[LichSuThiCong]  WITH CHECK ADD FOREIGN KEY([MaDonHang])
REFERENCES [dbo].[QuanLyDonHang] ([MaDonHang])
GO
ALTER TABLE [dbo].[QuanLyDonHang]  WITH CHECK ADD FOREIGN KEY([MaChinhSach])
REFERENCES [dbo].[ChinhSachThanhToan] ([MaChinhSach])
GO
ALTER TABLE [dbo].[QuanLyDonHang]  WITH CHECK ADD FOREIGN KEY([MaYeuCauThiCong])
REFERENCES [dbo].[YeuCauThiCong] ([MaYeuCau])
GO
ALTER TABLE [dbo].[QuanLyDonHang]  WITH CHECK ADD FOREIGN KEY([MaYeuCauDichVu])
REFERENCES [dbo].[YeuCauDichVu] ([MaYeuCau])
GO
ALTER TABLE [dbo].[YeuCauDichVu]  WITH CHECK ADD FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[YeuCauThiCong]  WITH CHECK ADD FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[DanhGiaPhanHoi]  WITH CHECK ADD CHECK  (([DanhGia]>=(1) AND [DanhGia]<=(5)))
GO
USE [master]
GO
ALTER DATABASE [KoiPond] SET  READ_WRITE 
GO
