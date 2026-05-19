using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class ToaNha
{
    public int Id { get; set; }

    public string TenToaNha { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public int SoTang { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<CanHo> CanHos { get; set; } = new List<CanHo>();
}
