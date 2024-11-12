using System;
using System.Collections.Generic;

namespace KoiPond.Models;

public partial class YeuCauDichVu
{
    public int MaYeuCau { get; set; }

    public string? LoaiDichVu { get; set; }

    public DateTime? NgayYeuCau { get; set; }

    public string? TrangThaiDichVu { get; set; }

    public string? PhanHoi { get; set; }

    public int? MaNhanVien { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public string? DiaChi { get; set; }

    public string? MoTa { get; set; }

    public string? Sdt { get; set; }

    public string? SoLuong { get; set; }

    public string? TenKhachHang { get; set; }

    public virtual ICollection<DanhGiaPhanHoi> DanhGiaPhanHois { get; set; } = new List<DanhGiaPhanHoi>();

    public virtual ICollection<QuanLyDonHang> QuanLyDonHangs { get; set; } = new List<QuanLyDonHang>();
}
