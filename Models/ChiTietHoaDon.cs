using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class ChiTietHoaDon
{
    public int Id { get; set; }

    public int HoaDon { get; set; }

    public int PhiDichVu { get; set; }

    public decimal DonGia { get; set; }

    public int? ChiSoCu { get; set; }

    public int? ChiSoMoi { get; set; }

    public decimal SoLuong { get; set; }

    public decimal ThanhTien { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual HoaDon HoaDonNavigation { get; set; } = null!;

    public virtual PhiDichVu PhiDichVuNavigation { get; set; } = null!;
}
