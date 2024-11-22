using System;
using System.Collections.Generic;

namespace KoiPond.Repositories.Models;

public partial class QuanLyDonHang
{
    public int MaDonHang { get; set; }

    public int? MaYeuCauThiCong { get; set; }

    public int? MaYeuCauDichVu { get; set; }

    public int? MaChinhSach { get; set; }

    public string? GiaiDoanThiCong { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayHoanThanh { get; set; }

    public string? TrangThaiDonHang { get; set; }

    public string? GhiChu { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public virtual ICollection<LichSuThiCong> LichSuThiCongs { get; set; } = new List<LichSuThiCong>();

    public virtual ChinhSachThanhToan? MaChinhSachNavigation { get; set; }

    public virtual YeuCauDichVu? MaYeuCauDichVuNavigation { get; set; }

    public virtual YeuCauThiCong? MaYeuCauThiCongNavigation { get; set; }
}
