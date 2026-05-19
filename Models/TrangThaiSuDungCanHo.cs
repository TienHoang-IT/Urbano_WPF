using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class TrangThaiSuDungCanHo
{
    public int Id { get; set; }

    public string TenTrangThai { get; set; } = null!;

    public virtual ICollection<CanHo> CanHos { get; set; } = new List<CanHo>();
}
