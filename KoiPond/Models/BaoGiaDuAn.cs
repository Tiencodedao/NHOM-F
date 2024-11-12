using System;
using System.Collections.Generic;

namespace KoiPond.Models;

public partial class BaoGiaDuAn
{
    public int MaBaoGia { get; set; }

    public int? MaYeuCau { get; set; }

    public decimal? ChiPhiUocTinh { get; set; }

    public string? DesignFilePath { get; set; }

    public string? GhiChu { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public virtual YeuCauThiCong? MaYeuCauNavigation { get; set; }
}
