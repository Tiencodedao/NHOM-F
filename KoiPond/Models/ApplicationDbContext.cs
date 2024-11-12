using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KoiPond.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaoGiaDuAn> BaoGiaDuAns { get; set; }

    public virtual DbSet<ChinhSachThanhToan> ChinhSachThanhToans { get; set; }

    public virtual DbSet<DanhGiaPhanHoi> DanhGiaPhanHois { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LichSuThiCong> LichSuThiCongs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<QuanLyDonHang> QuanLyDonHangs { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleClaim> RoleClaims { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserClaim> UserClaims { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserToken> UserTokens { get; set; }

    public virtual DbSet<YeuCauDichVu> YeuCauDichVus { get; set; }

    public virtual DbSet<YeuCauThiCong> YeuCauThiCongs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaoGiaDuAn>(entity =>
        {
            entity.HasKey(e => e.MaBaoGia).HasName("PK__BaoGiaDu__507FF70EE69CCAD0");

            entity.ToTable("BaoGiaDuAn");

            entity.Property(e => e.ChiPhiUocTinh).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.MaYeuCauNavigation).WithMany(p => p.BaoGiaDuAns)
                .HasForeignKey(d => d.MaYeuCau)
                .HasConstraintName("FK__BaoGiaDuA__MaYeu__45F365D3");
        });

        modelBuilder.Entity<ChinhSachThanhToan>(entity =>
        {
            entity.HasKey(e => e.MaChinhSach).HasName("PK__ChinhSac__82663E3020D20890");

            entity.ToTable("ChinhSachThanhToan");

            entity.Property(e => e.DieuKhoanThanhToan).HasMaxLength(255);
            entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TenChinhSach).HasMaxLength(255);
        });

        modelBuilder.Entity<DanhGiaPhanHoi>(entity =>
        {
            entity.HasKey(e => e.MaPhanHoi).HasName("PK__DanhGiaP__3458D20F55013E6A");

            entity.ToTable("DanhGiaPhanHoi");

            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.DanhGiaPhanHois)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__DanhGiaPh__MaKha__4E88ABD4");

            entity.HasOne(d => d.MaYeuCauDichVuNavigation).WithMany(p => p.DanhGiaPhanHois)
                .HasForeignKey(d => d.MaYeuCauDichVu)
                .HasConstraintName("FK__DanhGiaPh__MaYeu__4F7CD00D");

            entity.HasOne(d => d.MaYeuCauThiCongNavigation).WithMany(p => p.DanhGiaPhanHois)
                .HasForeignKey(d => d.MaYeuCauThiCong)
                .HasConstraintName("FK__DanhGiaPh__MaYeu__5070F446");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KhachHan__88D2F0E58CD9662F");

            entity.ToTable("KhachHang");

            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.DiemTrungThanh).HasDefaultValue(0);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SoDienThoai).HasMaxLength(50);
            entity.Property(e => e.TenKhachHang).HasMaxLength(255);
        });

        modelBuilder.Entity<LichSuThiCong>(entity =>
        {
            entity.HasKey(e => e.MaLichSu).HasName("PK__LichSuTh__C443222A7761903A");

            entity.ToTable("LichSuThiCong");

            entity.Property(e => e.GiaiDoan).HasMaxLength(50);
            entity.Property(e => e.NgayBatDau).HasColumnType("datetime");
            entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");
            entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaDonHangNavigation).WithMany(p => p.LichSuThiCongs)
                .HasForeignKey(d => d.MaDonHang)
                .HasConstraintName("FK__LichSuThi__MaDon__5DCAEF64");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA47C57AF336");

            entity.ToTable("NhanVien");

            entity.Property(e => e.ChucVu).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SoDienThoai).HasMaxLength(50);
            entity.Property(e => e.TenNhanVien).HasMaxLength(255);
        });

        modelBuilder.Entity<QuanLyDonHang>(entity =>
        {
            entity.HasKey(e => e.MaDonHang).HasName("PK__QuanLyDo__129584ADF39E9178");

            entity.ToTable("QuanLyDonHang");

            entity.Property(e => e.GiaiDoanThiCong).HasMaxLength(50);
            entity.Property(e => e.NgayBatDau).HasColumnType("datetime");
            entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");
            entity.Property(e => e.NgayHoanThanh).HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TrangThaiDonHang).HasMaxLength(50);

            entity.HasOne(d => d.MaChinhSachNavigation).WithMany(p => p.QuanLyDonHangs)
                .HasForeignKey(d => d.MaChinhSach)
                .HasConstraintName("FK__QuanLyDon__MaChi__59FA5E80");

            entity.HasOne(d => d.MaYeuCauDichVuNavigation).WithMany(p => p.QuanLyDonHangs)
                .HasForeignKey(d => d.MaYeuCauDichVu)
                .HasConstraintName("FK__QuanLyDon__MaYeu__59063A47");

            entity.HasOne(d => d.MaYeuCauThiCongNavigation).WithMany(p => p.QuanLyDonHangs)
                .HasForeignKey(d => d.MaYeuCauThiCong)
                .HasConstraintName("FK__QuanLyDon__MaYeu__5812160E");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSanPham).HasName("PK__SanPham__FAC7442D0FE6DE50");

            entity.ToTable("SanPham");

            entity.Property(e => e.DanhMuc).HasMaxLength(100);
            entity.Property(e => e.Gia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TenSanPham).HasMaxLength(255);
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<UserToken>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<YeuCauDichVu>(entity =>
        {
            entity.HasKey(e => e.MaYeuCau).HasName("PK__YeuCauDi__CFA5DF4E177AA576");

            entity.ToTable("YeuCauDichVu");

            entity.Property(e => e.LoaiDichVu).HasMaxLength(50);
            entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayYeuCau).HasColumnType("datetime");
            entity.Property(e => e.Sdt).HasColumnName("SDT");
            entity.Property(e => e.TrangThaiDichVu)
                .HasMaxLength(50)
                .HasDefaultValue("DangChoXuLy");
        });

        modelBuilder.Entity<YeuCauThiCong>(entity =>
        {
            entity.HasKey(e => e.MaYeuCau).HasName("PK__YeuCauTh__CFA5DF4E98224A33");

            entity.ToTable("YeuCauThiCong");

            entity.Property(e => e.LoaiThietKe).HasMaxLength(50);
            entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Sdt).HasColumnName("SDT");
            entity.Property(e => e.TrangThaiYeuCau)
                .HasMaxLength(50)
                .HasDefaultValue("DangChoXuLy");
        });

        OnModelCreatingPartial(modelBuilder);

        modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
        modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
        modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
