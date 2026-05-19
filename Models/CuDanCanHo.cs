using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class CuDanCanHo
{
    public int Id { get; set; }

    public int CuDan { get; set; }

    public int CanHo { get; set; }

    public int VaiTro { get; set; }

    public DateTime NgayChuyenDen { get; set; }

    public DateTime? NgayChuyenDi { get; set; }

    public int TrangThai { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual CanHo CanHoNavigation { get; set; } = null!;

    public virtual CuDan CuDanNavigation { get; set; } = null!;

    public virtual VaiTro VaiTroNavigation { get; set; } = null!;
}
