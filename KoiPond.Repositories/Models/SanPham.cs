using System;
using System.Collections.Generic;

namespace KoiPond.Repositories.Models;

public partial class SanPham
{
    public int MaSanPham { get; set; }

    public string TenSanPham { get; set; } = null!;

    public string? DanhMuc { get; set; }

    public string? MoTaSanPham { get; set; }

    public decimal? Gia { get; set; }

    public int? SoLuongTrongKho { get; set; }

    public string? DuongDanFileMau { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }
}
