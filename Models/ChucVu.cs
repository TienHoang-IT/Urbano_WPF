using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class ChucVu
{
    public int Id { get; set; }

    public string ChucVu1 { get; set; } = null!;

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
