using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class PermissionName
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<NhanVienPhanQuyen> NhanVienPhanQuyens { get; set; } = new List<NhanVienPhanQuyen>();
}
