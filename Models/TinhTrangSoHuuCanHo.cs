using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class TinhTrangSoHuuCanHo
{
    public int Id { get; set; }

    public string TenTinhTrang { get; set; } = null!;

    public virtual ICollection<CanHo> CanHos { get; set; } = new List<CanHo>();
}
