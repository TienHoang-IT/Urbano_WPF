using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class YeuCauCuDan
{
    public int Id { get; set; }

    public int CuDan { get; set; }

    public string TieuDe { get; set; } = null!;

    public string NoiDung { get; set; } = null!;

    public DateTime NgayGui { get; set; }

    public int MucDoUuTien { get; set; }

    public int TrangThai { get; set; }

    public int? NhanVienXuLy { get; set; }

    public DateTime? NgayHoanThanh { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual CuDan CuDanNavigation { get; set; } = null!;

    public virtual NhanVien? NhanVienXuLyNavigation { get; set; }

    public virtual TrangThaiYeuCau TrangThaiNavigation { get; set; } = null!;
}
