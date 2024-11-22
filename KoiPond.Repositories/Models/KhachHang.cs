using System;
using System.Collections.Generic;

namespace KoiPond.Repositories.Models;

public partial class KhachHang
{
    public int MaKhachHang { get; set; }

    public string? TenKhachHang { get; set; }

    public string? DiaChi { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public DateTime? NgayTao { get; set; }

    public string? DiemTrungThanh { get; set; }

    public string? ImagePath { get; set; }

    public virtual ICollection<DanhGiaPhanHoi> DanhGiaPhanHois { get; set; } = new List<DanhGiaPhanHoi>();

    public virtual ICollection<YeuCauDichVu> YeuCauDichVus { get; set; } = new List<YeuCauDichVu>();

    public virtual ICollection<YeuCauThiCong> YeuCauThiCongs { get; set; } = new List<YeuCauThiCong>();
}
