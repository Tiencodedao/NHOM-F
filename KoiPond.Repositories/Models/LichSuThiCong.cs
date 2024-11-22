using System;
using System.Collections.Generic;

namespace KoiPond.Repositories.Models;

public partial class LichSuThiCong
{
    public int MaLichSu { get; set; }

    public int? MaDonHang { get; set; }

    public string? GiaiDoan { get; set; }

    public string? MoTa { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public string? TrangThai { get; set; }

    public int? MaNhanVien { get; set; }

    public string? GhiChu { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public virtual QuanLyDonHang? MaDonHangNavigation { get; set; }
}
