using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class LoaiTinhPhiDichVu
{
    public int Id { get; set; }

    public string TenLoai { get; set; } = null!;

    public virtual ICollection<PhiDichVu> PhiDichVus { get; set; } = new List<PhiDichVu>();
}
