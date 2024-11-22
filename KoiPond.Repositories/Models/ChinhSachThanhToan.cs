using System;
using System.Collections.Generic;

namespace KoiPond.Repositories.Models;

public partial class ChinhSachThanhToan
{
    public int MaChinhSach { get; set; }

    public string TenChinhSach { get; set; } = null!;

    public string? MoTaChinhSach { get; set; }

    public string? DieuKhoanThanhToan { get; set; }

    public string? ChinhSachHuyDon { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public virtual ICollection<QuanLyDonHang> QuanLyDonHangs { get; set; } = new List<QuanLyDonHang>();
}
