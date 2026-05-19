using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class HopDong
{
    public int Id { get; set; }

    public string SoHopDong { get; set; } = null!;

    public int CanHo { get; set; }

    public int CuDan { get; set; }

    public int LoaiHopDong { get; set; }

    public DateTime NgayKy { get; set; }

    public DateTime NgayBatDau { get; set; }

    public DateTime NgayKetThuc { get; set; }

    public decimal GiaTriHopDong { get; set; }

    public decimal? TienCoc { get; set; }

    public string? FileDinhKem { get; set; }

    public string? GhiChu { get; set; }

    public int TrangThai { get; set; }

    public int NguoiTao { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual CanHo CanHoNavigation { get; set; } = null!;

    public virtual CuDan CuDanNavigation { get; set; } = null!;

    public virtual LoaiHopDong LoaiHopDongNavigation { get; set; } = null!;

    public virtual NhanVien NguoiTaoNavigation { get; set; } = null!;
}
