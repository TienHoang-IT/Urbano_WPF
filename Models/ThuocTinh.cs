using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class ThuocTinh
{
    public int Id { get; set; }

    public string TenThuocTinh { get; set; } = null!;

    public virtual ICollection<ThuocTinhCanHo> ThuocTinhCanHos { get; set; } = new List<ThuocTinhCanHo>();
}
