using System;
using System.Collections.Generic;

namespace Urbano_WPF.Models;

public partial class CauHinhThanhToan
{
    public int Id { get; set; }

    public string LoaiPhuongThuc { get; set; } = null!;

    public string TenNhaCungCap { get; set; } = null!;

    public string DinhDanhThuHuong { get; set; } = null!;

    public string MaNhanDien { get; set; } = null!;

    public string TenChuTaiKhoan { get; set; } = null!;

    public string? ApiKey { get; set; }

    public string? WebhookSecret { get; set; }

    public int TrangThai { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
