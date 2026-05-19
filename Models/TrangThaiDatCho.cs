using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class TrangThaiDatCho
{
    public int Id { get; set; }

    public string TenTrangThai { get; set; } = null!;

    public virtual ICollection<LichDatTienIch> LichDatTienIches { get; set; } = new List<LichDatTienIch>();
}
