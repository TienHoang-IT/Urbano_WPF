using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class NhanVien
{
    public int Id { get; set; }

    public string HoTen { get; set; } = null!;

    public int ChucVu { get; set; }

    public string Sdt { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public int TrangThai { get; set; }

    public string MaNhanVien { get; set; } = null!;

    public string Cccd { get; set; } = null!;

    public DateTime NgaySinh { get; set; }

    public DateTime NgayVaoLam { get; set; }

    public DateTime? NgayNghiLam { get; set; }

    public string? GhiChu { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ChucVu ChucVuNavigation { get; set; } = null!;

    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();

    public virtual ICollection<NhanVienPhanQuyen> NhanVienPhanQuyens { get; set; } = new List<NhanVienPhanQuyen>();

    public virtual ICollection<NhatKyHeThong> NhatKyHeThongs { get; set; } = new List<NhatKyHeThong>();

    public virtual ICollection<ThongBao> ThongBaos { get; set; } = new List<ThongBao>();

    public virtual ICollection<YeuCauCuDan> YeuCauCuDans { get; set; } = new List<YeuCauCuDan>();
}
