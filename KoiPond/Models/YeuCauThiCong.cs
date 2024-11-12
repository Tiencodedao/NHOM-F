using System;
using System.Collections.Generic;

namespace KoiPond.Models;

public partial class YeuCauThiCong
{
    public int MaYeuCau { get; set; }

    public string? LoaiThietKe { get; set; }

    public string? ChiTietYeuCau { get; set; }

    public string? TrangThaiYeuCau { get; set; }

    public string? PhanHoi { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public string? DiaChi { get; set; }

    public string? FileDinhKem { get; set; }

    public string? Sdt { get; set; }

    public string? SoLuong { get; set; }

    public string? TenKhachHang { get; set; }

    public virtual ICollection<BaoGiaDuAn> BaoGiaDuAns { get; set; } = new List<BaoGiaDuAn>();

    public virtual ICollection<DanhGiaPhanHoi> DanhGiaPhanHois { get; set; } = new List<DanhGiaPhanHoi>();

    public virtual ICollection<QuanLyDonHang> QuanLyDonHangs { get; set; } = new List<QuanLyDonHang>();
}
