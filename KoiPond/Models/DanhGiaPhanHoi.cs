using System;
using System.Collections.Generic;

namespace KoiPond.Models;

public partial class DanhGiaPhanHoi
{
    public int MaPhanHoi { get; set; }

    public int? MaKhachHang { get; set; }

    public int? MaYeuCauDichVu { get; set; }

    public int? MaYeuCauThiCong { get; set; }

    public int? DanhGia { get; set; }

    public string? BinhLuan { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    public virtual YeuCauDichVu? MaYeuCauDichVuNavigation { get; set; }

    public virtual YeuCauThiCong? MaYeuCauThiCongNavigation { get; set; }
}
