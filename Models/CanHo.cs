using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class CanHo
{
    public int Id { get; set; }

    public int ToaNha { get; set; }

    public int TinhTrangSoHuu { get; set; }

    public string SoCanHo { get; set; } = null!;

    public int Tang { get; set; }

    public decimal DienTich { get; set; }

    public int TrangThaiSuDung { get; set; }

    public decimal Gia { get; set; }

    public int LoaiCanHo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<CanHoPhiDichVu> CanHoPhiDichVus { get; set; } = new List<CanHoPhiDichVu>();

    public virtual CuDanCanHo? CuDanCanHo { get; set; }

    public virtual HoaDon? HoaDon { get; set; }

    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();

    public virtual ICollection<LichDatTienIch> LichDatTienIches { get; set; } = new List<LichDatTienIch>();

    public virtual LoaiCanHo LoaiCanHoNavigation { get; set; } = null!;

    public virtual ICollection<PhuongTien> PhuongTiens { get; set; } = new List<PhuongTien>();

    public virtual ICollection<ThuocTinhCanHo> ThuocTinhCanHos { get; set; } = new List<ThuocTinhCanHo>();

    public virtual TinhTrangSoHuuCanHo TinhTrangSoHuuNavigation { get; set; } = null!;

    public virtual ToaNha ToaNhaNavigation { get; set; } = null!;

    public virtual TrangThaiSuDungCanHo TrangThaiSuDungNavigation { get; set; } = null!;
}
