using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class NhanVienPhanQuyen
{
    public int NhanVien { get; set; }

    public int PermissionName { get; set; }

    public int PermissionAction { get; set; }

    public virtual NhanVien NhanVienNavigation { get; set; } = null!;

    public virtual PermissionAction PermissionActionNavigation { get; set; } = null!;

    public virtual PermissionName PermissionNameNavigation { get; set; } = null!;
}
