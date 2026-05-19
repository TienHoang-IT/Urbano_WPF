using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class CuDan
{
    public int Id { get; set; }

    public string HoTen { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string Cccd { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime NamSinh { get; set; }

    public string? QueQuan { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual CuDanCanHo? CuDanCanHo { get; set; }

    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();

    public virtual ICollection<LichDatTienIch> LichDatTienIches { get; set; } = new List<LichDatTienIch>();

    public virtual ICollection<LichSuThanhToan> LichSuThanhToans { get; set; } = new List<LichSuThanhToan>();

    public virtual ICollection<YeuCauCuDan> YeuCauCuDans { get; set; } = new List<YeuCauCuDan>();
}
