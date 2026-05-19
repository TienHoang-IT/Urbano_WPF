using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class ThongBao
{
    public int Id { get; set; }

    public string TieuDe { get; set; } = null!;

    public string NoiDung { get; set; } = null!;

    public int NguoiTao { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual NhanVien NguoiTaoNavigation { get; set; } = null!;
}
