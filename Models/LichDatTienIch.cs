using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class LichDatTienIch
{
    public int Id { get; set; }

    public int TienIch { get; set; }

    public int CuDan { get; set; }

    public int CanHo { get; set; }

    public DateTime ThoiGianBatDau { get; set; }

    public DateTime ThoiGianKetThuc { get; set; }

    public decimal TongTien { get; set; }

    public int TrangThai { get; set; }

    public string? GhiChu { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual CanHo CanHoNavigation { get; set; } = null!;

    public virtual CuDan CuDanNavigation { get; set; } = null!;

    public virtual TienIch TienIchNavigation { get; set; } = null!;

    public virtual TrangThaiDatCho TrangThaiNavigation { get; set; } = null!;
}
