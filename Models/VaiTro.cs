using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class VaiTro
{
    public int Id { get; set; }

    public string VaiTro1 { get; set; } = null!;

    public virtual ICollection<CuDanCanHo> CuDanCanHos { get; set; } = new List<CuDanCanHo>();
}
