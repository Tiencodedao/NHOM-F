using System;
using System.Collections.Generic;

namespace KoiPond.Models;

public partial class NhanVien
{
    public int MaNhanVien { get; set; }

    public string TenNhanVien { get; set; } = null!;

    public string? ChucVu { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public DateTime? NgayTao { get; set; }

    public string? ImagePath { get; set; }
}
