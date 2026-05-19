using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class NguonTao
{
    public int Id { get; set; }

    public string TenNguonTao { get; set; } = null!;

    public virtual ICollection<LichSuThanhToan> LichSuThanhToans { get; set; } = new List<LichSuThanhToan>();
}
