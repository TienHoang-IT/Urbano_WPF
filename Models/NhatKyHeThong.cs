using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class NhatKyHeThong
{
    public int Id { get; set; }

    public int NguoiThucHien { get; set; }

    public DateTime ThoiGian { get; set; }

    public string HanhDong { get; set; } = null!;

    public string BangTacDong { get; set; } = null!;

    public int IdBanGhi { get; set; }

    public string? GiaTriCu { get; set; }

    public string? GiaTriMoi { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual NhanVien NguoiThucHienNavigation { get; set; } = null!;
}
