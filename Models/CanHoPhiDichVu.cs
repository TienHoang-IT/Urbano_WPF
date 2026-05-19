using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class CanHoPhiDichVu
{
    public int Id { get; set; }

    public int CanHo { get; set; }

    public int PhiDichVu { get; set; }

    public decimal DonGia { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual CanHo CanHoNavigation { get; set; } = null!;

    public virtual PhiDichVu PhiDichVuNavigation { get; set; } = null!;
}
