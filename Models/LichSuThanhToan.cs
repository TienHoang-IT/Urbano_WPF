using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class LichSuThanhToan
{
    public int Id { get; set; }

    public int HoaDon { get; set; }

    public DateTime NgayThanhToan { get; set; }

    public decimal SoTien { get; set; }

    public string PhuongThucThanhToan { get; set; } = null!;

    public string MaGiaoDich { get; set; } = null!;

    public int NguoiThanhToan { get; set; }

    public string? GhiChu { get; set; }

    public int NguonTao { get; set; }

    public int? IdWebhook { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual HoaDon HoaDonNavigation { get; set; } = null!;

    public virtual NhatKyWebhook? IdWebhookNavigation { get; set; }

    public virtual CuDan NguoiThanhToanNavigation { get; set; } = null!;

    public virtual NguonTao NguonTaoNavigation { get; set; } = null!;
}
