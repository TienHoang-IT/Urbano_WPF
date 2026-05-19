using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class HoaDon
{
    public int Id { get; set; }

    public string MaThanhToan { get; set; } = null!;

    public int CanHo { get; set; }

    public int Thang { get; set; }

    public int Nam { get; set; }

    public decimal TongTien { get; set; }

    public decimal? SoTienDaThanhToan { get; set; }

    public decimal ChiPhi { get; set; }

    public DateTime HanThanhToan { get; set; }

    public int TrangThai { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual CanHo CanHoNavigation { get; set; } = null!;

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual ICollection<LichSuThanhToan> LichSuThanhToans { get; set; } = new List<LichSuThanhToan>();

    public virtual TrangThaiThanhToan TrangThaiNavigation { get; set; } = null!;
}
