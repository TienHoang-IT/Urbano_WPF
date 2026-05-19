using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class TrangThaiYeuCau
{
    public int Id { get; set; }

    public string TenTrangThai { get; set; } = null!;

    public virtual ICollection<YeuCauCuDan> YeuCauCuDans { get; set; } = new List<YeuCauCuDan>();
}
