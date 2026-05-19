using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class LoaiPhuongTien
{
    public int Id { get; set; }

    public string TenLoaiPhuongTien { get; set; } = null!;

    public virtual ICollection<PhuongTien> PhuongTiens { get; set; } = new List<PhuongTien>();
}
