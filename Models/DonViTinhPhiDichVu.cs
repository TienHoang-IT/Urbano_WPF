using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class DonViTinhPhiDichVu
{
    public int Id { get; set; }

    public string DonVi { get; set; } = null!;

    public virtual ICollection<PhiDichVu> PhiDichVus { get; set; } = new List<PhiDichVu>();

    public virtual ICollection<TienIch> TienIches { get; set; } = new List<TienIch>();
}
