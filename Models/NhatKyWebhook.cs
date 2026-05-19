using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class NhatKyWebhook
{
    public int Id { get; set; }

    public DateTime NgayNhan { get; set; }

    public string NhaCungCap { get; set; } = null!;

    public string MaGiaoDichGoc { get; set; } = null!;

    public string DuLieuJson { get; set; } = null!;

    public int TrangThaiXuLy { get; set; }

    public string? LoiChiTiet { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<LichSuThanhToan> LichSuThanhToans { get; set; } = new List<LichSuThanhToan>();
}
