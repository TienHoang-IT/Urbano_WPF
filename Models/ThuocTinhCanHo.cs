using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class ThuocTinhCanHo
{
    public int CanHo { get; set; }

    public int ThuocTinh { get; set; }

    public string GiaTriThuocTinh { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual CanHo CanHoNavigation { get; set; } = null!;

    public virtual ThuocTinh ThuocTinhNavigation { get; set; } = null!;
}
