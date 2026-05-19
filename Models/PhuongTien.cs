using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class PhuongTien
{
    public int Id { get; set; }

    public string TenPhuongTien { get; set; } = null!;

    public string BienSo { get; set; } = null!;

    public int LoaiPhuongTien { get; set; }

    public int CanHo { get; set; }

    public DateTime NgayDangKy { get; set; }

    public DateTime? NgayHuy { get; set; }

    public int TrangThai { get; set; }

    public virtual CanHo CanHoNavigation { get; set; } = null!;

    public virtual LoaiPhuongTien LoaiPhuongTienNavigation { get; set; } = null!;
}
