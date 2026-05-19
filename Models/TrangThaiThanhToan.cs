using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class TrangThaiThanhToan
{
    public int Id { get; set; }

    public string TenTrangThai { get; set; } = null!;

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
