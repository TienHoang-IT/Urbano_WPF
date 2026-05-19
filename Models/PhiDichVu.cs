using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class PhiDichVu
{
    public int Id { get; set; }

    public int LoaiPhiDichVu { get; set; }

    public string TenPhiDichVu { get; set; } = null!;

    public decimal DonGia { get; set; }

    public int DonViTinh { get; set; }

    public int LoaiTinhPhi { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<CanHoPhiDichVu> CanHoPhiDichVus { get; set; } = new List<CanHoPhiDichVu>();

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual DonViTinhPhiDichVu DonViTinhNavigation { get; set; } = null!;

    public virtual LoaiPhiDichVu LoaiPhiDichVuNavigation { get; set; } = null!;

    public virtual LoaiTinhPhiDichVu LoaiTinhPhiNavigation { get; set; } = null!;
}
