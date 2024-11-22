using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPond.Repositories.Models
{
    public partial class DuAn
    {
        public int Id { get; set; }

        public string TenDuAn { get; set; } = null!;

        public string? MoTa { get; set; }

        public string? UuDiem { get; set; }

        public string? KichThuoc { get; set; }

        public string? VatLieu { get; set; }

        public string? SoLuongCa { get; set; }

        public string? ThietKe { get; set; }

        public string? HinhAnh { get; set; }
    }
}
