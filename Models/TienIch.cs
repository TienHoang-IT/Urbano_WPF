using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class TienIch
{
    public int Id { get; set; }

    public string TenTienIch { get; set; } = null!;

    public string ViTri { get; set; } = null!;

    public decimal? GiaThue { get; set; }

    public int DonViTinh { get; set; }

    public TimeOnly GioMoCua { get; set; }

    public TimeOnly GioDongCua { get; set; }

    public int TrangThai { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual DonViTinhPhiDichVu DonViTinhNavigation { get; set; } = null!;

    public virtual ICollection<LichDatTienIch> LichDatTienIches { get; set; } = new List<LichDatTienIch>();
}
