﻿// <auto-generated />
using System;
using KoiPond.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KoiPond.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241107064104_update1107.2")]
    partial class update11072
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KoiPond.Models.BaoGiaDuAn", b =>
                {
                    b.Property<int>("MaBaoGia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaBaoGia"));

                    b.Property<decimal?>("ChiPhiUocTinh")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("DesignFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaYeuCau")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("NgayTao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("MaBaoGia")
                        .HasName("PK__BaoGiaDu__507FF70EE69CCAD0");

                    b.HasIndex("MaYeuCau");

                    b.ToTable("BaoGiaDuAn", (string)null);
                });

            modelBuilder.Entity("KoiPond.Models.ChinhSachThanhToan", b =>
                {
                    b.Property<int>("MaChinhSach")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaChinhSach"));

                    b.Property<string>("ChinhSachHuyDon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DieuKhoanThanhToan")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("MoTaChinhSach")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("NgayTao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("TenChinhSach")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("MaChinhSach")
                        .HasName("PK__ChinhSac__82663E3020D20890");

                    b.ToTable("ChinhSachThanhToan", (string)null);
                });

            modelBuilder.Entity("KoiPond.Models.DanhGiaPhanHoi", b =>
                {
                    b.Property<int>("MaPhanHoi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPhanHoi"));

                    b.Property<string>("BinhLuan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DanhGia")
                        .HasColumnType("int");

                    b.Property<int?>("MaKhachHang")
                        .HasColumnType("int");

                    b.Property<int?>("MaYeuCauDichVu")
                        .HasColumnType("int");

                    b.Property<int?>("MaYeuCauThiCong")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayTao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("MaPhanHoi")
                        .HasName("PK__DanhGiaP__3458D20F55013E6A");

                    b.HasIndex("MaKhachHang");

                    b.HasIndex("MaYeuCauDichVu");

                    b.HasIndex("MaYeuCauThiCong");

                    b.ToTable("DanhGiaPhanHoi", (string)null);
                });

            modelBuilder.Entity("KoiPond.Models.KhachHang", b =>
                {
                    b.Property<int>("MaKhachHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKhachHang"));

                    b.Property<string>("DiaChi")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("DiemTrungThanh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayTao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("SoDienThoai")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenKhachHang")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("MaKhachHang")
                        .HasName("PK__KhachHan__88D2F0E58CD9662F");

                    b.ToTable("KhachHang", (string)null);
                });

            modelBuilder.Entity("KoiPond.Models.LichSuThiCong", b =>
                {
                    b.Property<int>("MaLichSu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaLichSu"));

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GiaiDoan")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("MaDonHang")
                        .HasColumnType("int");

                    b.Property<int?>("MaNhanVien")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayBatDau")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("NgayKetThuc")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("NgayTao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("TrangThai")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaLichSu")
                        .HasName("PK__LichSuTh__C443222A7761903A");

                    b.HasIndex("MaDonHang");

                    b.ToTable("LichSuThiCong", (string)null);
                });

            modelBuilder.Entity("KoiPond.Models.NhanVien", b =>
                {
                    b.Property<int>("MaNhanVien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaNhanVien"));

                    b.Property<string>("ChucVu")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayTao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("SoDienThoai")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenNhanVien")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("MaNhanVien")
                        .HasName("PK__NhanVien__77B2CA47C57AF336");

                    b.ToTable("NhanVien", (string)null);
                });

            modelBuilder.Entity("KoiPond.Models.QuanLyDonHang", b =>
                {
                    b.Property<int>("MaDonHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDonHang"));

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GiaiDoanThiCong")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("MaChinhSach")
                        .HasColumnType("int");

                    b.Property<int?>("MaYeuCauDichVu")
                        .HasColumnType("int");

                    b.Property<int?>("MaYeuCauThiCong")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayBatDau")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("NgayHoanThanh")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("NgayTao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("TrangThaiDonHang")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaDonHang")
                        .HasName("PK__QuanLyDo__129584ADF39E9178");

                    b.HasIndex("MaChinhSach");

                    b.HasIndex("MaYeuCauDichVu");

                    b.HasIndex("MaYeuCauThiCong");

                    b.ToTable("QuanLyDonHang", (string)null);
                });

            modelBuilder.Entity("KoiPond.Models.SanPham", b =>
                {
                    b.Property<int>("MaSanPham")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSanPham"));

                    b.Property<string>("DanhMuc")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DuongDanFileMau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Gia")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("MoTaSanPham")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("NgayTao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("SoLuongTrongKho")
                        .HasColumnType("int");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("MaSanPham")
                        .HasName("PK__SanPham__FAC7442D0FE6DE50");

                    b.ToTable("SanPham", (string)null);
                });

            modelBuilder.Entity("KoiPond.Models.YeuCauDichVu", b =>
                {
                    b.Property<int>("MaYeuCau")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaYeuCau"));

                    b.Property<string>("LoaiDichVu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("MaKhachHang")
                        .HasColumnType("int");

                    b.Property<int?>("MaNhanVien")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("NgayTao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("NgayYeuCau")
                        .HasColumnType("datetime");

                    b.Property<string>("PhanHoi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrangThaiDichVu")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("DangChoXuLy");

                    b.HasKey("MaYeuCau")
                        .HasName("PK__YeuCauDi__CFA5DF4E177AA576");

                    b.HasIndex("MaKhachHang");

                    b.ToTable("YeuCauDichVu", (string)null);
                });

            modelBuilder.Entity("KoiPond.Models.YeuCauThiCong", b =>
                {
                    b.Property<int>("MaYeuCau")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaYeuCau"));

                    b.Property<string>("ChiTietYeuCau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoaiThietKe")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("MaKhachHang")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("NgayTao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("PhanHoi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrangThaiYeuCau")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("DangChoXuLy");

                    b.HasKey("MaYeuCau")
                        .HasName("PK__YeuCauTh__CFA5DF4E98224A33");

                    b.HasIndex("MaKhachHang");

                    b.ToTable("YeuCauThiCong", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("KoiPond.Models.BaoGiaDuAn", b =>
                {
                    b.HasOne("KoiPond.Models.YeuCauThiCong", "MaYeuCauNavigation")
                        .WithMany("BaoGiaDuAns")
                        .HasForeignKey("MaYeuCau")
                        .HasConstraintName("FK__BaoGiaDuA__MaYeu__45F365D3");

                    b.Navigation("MaYeuCauNavigation");
                });

            modelBuilder.Entity("KoiPond.Models.DanhGiaPhanHoi", b =>
                {
                    b.HasOne("KoiPond.Models.KhachHang", "MaKhachHangNavigation")
                        .WithMany("DanhGiaPhanHois")
                        .HasForeignKey("MaKhachHang")
                        .HasConstraintName("FK__DanhGiaPh__MaKha__4E88ABD4");

                    b.HasOne("KoiPond.Models.YeuCauDichVu", "MaYeuCauDichVuNavigation")
                        .WithMany("DanhGiaPhanHois")
                        .HasForeignKey("MaYeuCauDichVu")
                        .HasConstraintName("FK__DanhGiaPh__MaYeu__4F7CD00D");

                    b.HasOne("KoiPond.Models.YeuCauThiCong", "MaYeuCauThiCongNavigation")
                        .WithMany("DanhGiaPhanHois")
                        .HasForeignKey("MaYeuCauThiCong")
                        .HasConstraintName("FK__DanhGiaPh__MaYeu__5070F446");

                    b.Navigation("MaKhachHangNavigation");

                    b.Navigation("MaYeuCauDichVuNavigation");

                    b.Navigation("MaYeuCauThiCongNavigation");
                });

            modelBuilder.Entity("KoiPond.Models.LichSuThiCong", b =>
                {
                    b.HasOne("KoiPond.Models.QuanLyDonHang", "MaDonHangNavigation")
                        .WithMany("LichSuThiCongs")
                        .HasForeignKey("MaDonHang")
                        .HasConstraintName("FK__LichSuThi__MaDon__5DCAEF64");

                    b.Navigation("MaDonHangNavigation");
                });

            modelBuilder.Entity("KoiPond.Models.QuanLyDonHang", b =>
                {
                    b.HasOne("KoiPond.Models.ChinhSachThanhToan", "MaChinhSachNavigation")
                        .WithMany("QuanLyDonHangs")
                        .HasForeignKey("MaChinhSach")
                        .HasConstraintName("FK__QuanLyDon__MaChi__59FA5E80");

                    b.HasOne("KoiPond.Models.YeuCauDichVu", "MaYeuCauDichVuNavigation")
                        .WithMany("QuanLyDonHangs")
                        .HasForeignKey("MaYeuCauDichVu")
                        .HasConstraintName("FK__QuanLyDon__MaYeu__59063A47");

                    b.HasOne("KoiPond.Models.YeuCauThiCong", "MaYeuCauThiCongNavigation")
                        .WithMany("QuanLyDonHangs")
                        .HasForeignKey("MaYeuCauThiCong")
                        .HasConstraintName("FK__QuanLyDon__MaYeu__5812160E");

                    b.Navigation("MaChinhSachNavigation");

                    b.Navigation("MaYeuCauDichVuNavigation");

                    b.Navigation("MaYeuCauThiCongNavigation");
                });

            modelBuilder.Entity("KoiPond.Models.YeuCauDichVu", b =>
                {
                    b.HasOne("KoiPond.Models.KhachHang", "MaKhachHangNavigation")
                        .WithMany("YeuCauDichVus")
                        .HasForeignKey("MaKhachHang")
                        .HasConstraintName("FK__YeuCauDic__MaKha__49C3F6B7");

                    b.Navigation("MaKhachHangNavigation");
                });

            modelBuilder.Entity("KoiPond.Models.YeuCauThiCong", b =>
                {
                    b.HasOne("KoiPond.Models.KhachHang", "MaKhachHangNavigation")
                        .WithMany("YeuCauThiCongs")
                        .HasForeignKey("MaKhachHang")
                        .HasConstraintName("FK__YeuCauThi__MaKha__412EB0B6");

                    b.Navigation("MaKhachHangNavigation");
                });

            modelBuilder.Entity("KoiPond.Models.ChinhSachThanhToan", b =>
                {
                    b.Navigation("QuanLyDonHangs");
                });

            modelBuilder.Entity("KoiPond.Models.KhachHang", b =>
                {
                    b.Navigation("DanhGiaPhanHois");

                    b.Navigation("YeuCauDichVus");

                    b.Navigation("YeuCauThiCongs");
                });

            modelBuilder.Entity("KoiPond.Models.QuanLyDonHang", b =>
                {
                    b.Navigation("LichSuThiCongs");
                });

            modelBuilder.Entity("KoiPond.Models.YeuCauDichVu", b =>
                {
                    b.Navigation("DanhGiaPhanHois");

                    b.Navigation("QuanLyDonHangs");
                });

            modelBuilder.Entity("KoiPond.Models.YeuCauThiCong", b =>
                {
                    b.Navigation("BaoGiaDuAns");

                    b.Navigation("DanhGiaPhanHois");

                    b.Navigation("QuanLyDonHangs");
                });
#pragma warning restore 612, 618
        }
    }
}
