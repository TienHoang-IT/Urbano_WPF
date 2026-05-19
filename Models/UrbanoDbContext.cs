using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using System;
using System.Collections.Generic;
using System.Windows;
using Urbano_WPF.Data;

namespace Urbano_WPF.Models;

public partial class UrbanoDbContext : DbContext
{
    public UrbanoDbContext()
    {
    }

    public UrbanoDbContext(DbContextOptions<UrbanoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CanHo> CanHos { get; set; }

    public virtual DbSet<CanHoPhiDichVu> CanHoPhiDichVus { get; set; }

    public virtual DbSet<CauHinhThanhToan> CauHinhThanhToans { get; set; }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<ChucVu> ChucVus { get; set; }

    public virtual DbSet<CuDan> CuDans { get; set; }

    public virtual DbSet<CuDanCanHo> CuDanCanHos { get; set; }

    public virtual DbSet<DonViTinhPhiDichVu> DonViTinhPhiDichVus { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<HopDong> HopDongs { get; set; }

    public virtual DbSet<LichDatTienIch> LichDatTienIches { get; set; }

    public virtual DbSet<LichSuThanhToan> LichSuThanhToans { get; set; }

    public virtual DbSet<LoaiCanHo> LoaiCanHos { get; set; }

    public virtual DbSet<LoaiHopDong> LoaiHopDongs { get; set; }

    public virtual DbSet<LoaiPhiDichVu> LoaiPhiDichVus { get; set; }

    public virtual DbSet<LoaiPhuongTien> LoaiPhuongTiens { get; set; }

    public virtual DbSet<LoaiTinhPhiDichVu> LoaiTinhPhiDichVus { get; set; }

    public virtual DbSet<NguonTao> NguonTaos { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<NhanVienPhanQuyen> NhanVienPhanQuyens { get; set; }

    public virtual DbSet<NhatKyHeThong> NhatKyHeThongs { get; set; }

    public virtual DbSet<NhatKyWebhook> NhatKyWebhooks { get; set; }

    public virtual DbSet<PermissionAction> PermissionActions { get; set; }

    public virtual DbSet<PermissionName> PermissionNames { get; set; }

    public virtual DbSet<PhiDichVu> PhiDichVus { get; set; }

    public virtual DbSet<PhuongTien> PhuongTiens { get; set; }

    public virtual DbSet<ThongBao> ThongBaos { get; set; }

    public virtual DbSet<ThuocTinh> ThuocTinhs { get; set; }

    public virtual DbSet<ThuocTinhCanHo> ThuocTinhCanHos { get; set; }

    public virtual DbSet<TienIch> TienIches { get; set; }

    public virtual DbSet<TinhTrangSoHuuCanHo> TinhTrangSoHuuCanHos { get; set; }

    public virtual DbSet<ToaNha> ToaNhas { get; set; }

    public virtual DbSet<TrangThaiDatCho> TrangThaiDatChos { get; set; }

    public virtual DbSet<TrangThaiSuDungCanHo> TrangThaiSuDungCanHos { get; set; }

    public virtual DbSet<TrangThaiThanhToan> TrangThaiThanhToans { get; set; }

    public virtual DbSet<TrangThaiYeuCau> TrangThaiYeuCaus { get; set; }

    public virtual DbSet<VaiTro> VaiTros { get; set; }

    public virtual DbSet<YeuCauCuDan> YeuCauCuDans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql($"server={Config.GetString("Database", "Server")};port={Config.GetString("Database", "Port")};database={Config.GetString("Database", "Database")};user={Config.GetString("Database", "User")};password={Config.GetString("Database", "Password")}", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<CanHo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("can_ho");

            entity.HasIndex(e => e.LoaiCanHo, "fk_can_ho_loai");

            entity.HasIndex(e => e.TinhTrangSoHuu, "fk_can_ho_so_huu");

            entity.HasIndex(e => e.TrangThaiSuDung, "fk_can_ho_su_dung");

            entity.HasIndex(e => e.ToaNha, "fk_can_ho_toa_nha");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.DienTich)
                .HasPrecision(10, 2)
                .HasColumnName("dien_tich");
            entity.Property(e => e.Gia)
                .HasPrecision(15, 2)
                .HasColumnName("gia");
            entity.Property(e => e.LoaiCanHo)
                .HasColumnType("int(11)")
                .HasColumnName("loai_can_ho");
            entity.Property(e => e.SoCanHo)
                .HasMaxLength(50)
                .HasColumnName("so_can_ho");
            entity.Property(e => e.Tang)
                .HasColumnType("int(11)")
                .HasColumnName("tang");
            entity.Property(e => e.TinhTrangSoHuu)
                .HasColumnType("int(11)")
                .HasColumnName("tinh_trang_so_huu");
            entity.Property(e => e.ToaNha)
                .HasColumnType("int(11)")
                .HasColumnName("toa_nha");
            entity.Property(e => e.TrangThaiSuDung)
                .HasColumnType("int(11)")
                .HasColumnName("trang_thai_su_dung");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.LoaiCanHoNavigation).WithMany(p => p.CanHos)
                .HasForeignKey(d => d.LoaiCanHo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_can_ho_loai");

            entity.HasOne(d => d.TinhTrangSoHuuNavigation).WithMany(p => p.CanHos)
                .HasForeignKey(d => d.TinhTrangSoHuu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_can_ho_so_huu");

            entity.HasOne(d => d.ToaNhaNavigation).WithMany(p => p.CanHos)
                .HasForeignKey(d => d.ToaNha)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_can_ho_toa_nha");

            entity.HasOne(d => d.TrangThaiSuDungNavigation).WithMany(p => p.CanHos)
                .HasForeignKey(d => d.TrangThaiSuDung)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_can_ho_su_dung");
        });

        modelBuilder.Entity<CanHoPhiDichVu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("can_ho_phi_dich_vu");

            entity.HasIndex(e => e.CanHo, "fk_chpdv_can_ho");

            entity.HasIndex(e => e.PhiDichVu, "fk_chpdv_phi_dich_vu");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CanHo)
                .HasColumnType("int(11)")
                .HasColumnName("can_ho");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.DonGia)
                .HasPrecision(15, 2)
                .HasColumnName("don_gia");
            entity.Property(e => e.PhiDichVu)
                .HasColumnType("int(11)")
                .HasColumnName("phi_dich_vu");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.CanHoNavigation).WithMany(p => p.CanHoPhiDichVus)
                .HasForeignKey(d => d.CanHo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_chpdv_can_ho");

            entity.HasOne(d => d.PhiDichVuNavigation).WithMany(p => p.CanHoPhiDichVus)
                .HasForeignKey(d => d.PhiDichVu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_chpdv_phi_dich_vu");
        });

        modelBuilder.Entity<CauHinhThanhToan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cau_hinh_thanh_toan");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ApiKey)
                .HasMaxLength(255)
                .HasColumnName("api_key");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.DinhDanhThuHuong)
                .HasMaxLength(255)
                .HasColumnName("dinh_danh_thu_huong");
            entity.Property(e => e.LoaiPhuongThuc)
                .HasMaxLength(100)
                .HasColumnName("loai_phuong_thuc");
            entity.Property(e => e.MaNhanDien)
                .HasMaxLength(255)
                .HasColumnName("ma_nhan_dien");
            entity.Property(e => e.TenChuTaiKhoan)
                .HasMaxLength(255)
                .HasColumnName("ten_chu_tai_khoan");
            entity.Property(e => e.TenNhaCungCap)
                .HasMaxLength(255)
                .HasColumnName("ten_nha_cung_cap");
            entity.Property(e => e.TrangThai)
                .HasColumnType("int(11)")
                .HasColumnName("trang_thai");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.WebhookSecret)
                .HasMaxLength(255)
                .HasColumnName("webhook_secret");
        });

        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("chi_tiet_hoa_don");

            entity.HasIndex(e => e.HoaDon, "fk_cthd_hoa_don");

            entity.HasIndex(e => e.PhiDichVu, "fk_cthd_phi_dich_vu");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ChiSoCu)
                .HasColumnType("int(11)")
                .HasColumnName("chi_so_cu");
            entity.Property(e => e.ChiSoMoi)
                .HasColumnType("int(11)")
                .HasColumnName("chi_so_moi");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.DonGia)
                .HasPrecision(15, 2)
                .HasColumnName("don_gia");
            entity.Property(e => e.HoaDon)
                .HasColumnType("int(11)")
                .HasColumnName("hoa_don");
            entity.Property(e => e.PhiDichVu)
                .HasColumnType("int(11)")
                .HasColumnName("phi_dich_vu");
            entity.Property(e => e.SoLuong)
                .HasPrecision(10, 2)
                .HasColumnName("so_luong");
            entity.Property(e => e.ThanhTien)
                .HasPrecision(15, 2)
                .HasColumnName("thanh_tien");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.HoaDonNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.HoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cthd_hoa_don");

            entity.HasOne(d => d.PhiDichVuNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.PhiDichVu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cthd_phi_dich_vu");
        });

        modelBuilder.Entity<ChucVu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("chuc_vu");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ChucVu1)
                .HasMaxLength(100)
                .HasColumnName("chuc_vu");
        });

        modelBuilder.Entity<CuDan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cu_dan");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Cccd)
                .HasMaxLength(20)
                .HasColumnName("cccd");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .HasColumnName("ho_ten");
            entity.Property(e => e.NamSinh)
                .HasColumnType("datetime")
                .HasColumnName("nam_sinh");
            entity.Property(e => e.QueQuan)
                .HasMaxLength(255)
                .HasColumnName("que_quan");
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .HasColumnName("sdt");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<CuDanCanHo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cu_dan_can_ho");

            entity.HasIndex(e => e.CanHo, "can_ho").IsUnique();

            entity.HasIndex(e => e.CuDan, "cu_dan").IsUnique();

            entity.HasIndex(e => e.VaiTro, "fk_cdch_vai_tro");

            entity.HasIndex(e => e.NgayChuyenDen, "ngay_chuyen_den").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CanHo)
                .HasColumnType("int(11)")
                .HasColumnName("can_ho");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CuDan)
                .HasColumnType("int(11)")
                .HasColumnName("cu_dan");
            entity.Property(e => e.NgayChuyenDen)
                .HasColumnType("datetime")
                .HasColumnName("ngay_chuyen_den");
            entity.Property(e => e.NgayChuyenDi)
                .HasColumnType("datetime")
                .HasColumnName("ngay_chuyen_di");
            entity.Property(e => e.TrangThai)
                .HasColumnType("int(11)")
                .HasColumnName("trang_thai");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.VaiTro)
                .HasColumnType("int(11)")
                .HasColumnName("vai_tro");

            entity.HasOne(d => d.CanHoNavigation).WithOne(p => p.CuDanCanHo)
                .HasForeignKey<CuDanCanHo>(d => d.CanHo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cdch_can_ho");

            entity.HasOne(d => d.CuDanNavigation).WithOne(p => p.CuDanCanHo)
                .HasForeignKey<CuDanCanHo>(d => d.CuDan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cdch_cu_dan");

            entity.HasOne(d => d.VaiTroNavigation).WithMany(p => p.CuDanCanHos)
                .HasForeignKey(d => d.VaiTro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cdch_vai_tro");
        });

        modelBuilder.Entity<DonViTinhPhiDichVu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("don_vi_tinh_phi_dich_vu");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DonVi)
                .HasMaxLength(50)
                .HasColumnName("don_vi");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("hoa_don");

            entity.HasIndex(e => e.CanHo, "can_ho").IsUnique();

            entity.HasIndex(e => e.TrangThai, "fk_hoa_don_trang_thai");

            entity.HasIndex(e => e.Nam, "nam").IsUnique();

            entity.HasIndex(e => e.Thang, "thang").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CanHo)
                .HasColumnType("int(11)")
                .HasColumnName("can_ho");
            entity.Property(e => e.ChiPhi)
                .HasPrecision(15, 2)
                .HasColumnName("chi_phi");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.HanThanhToan)
                .HasColumnType("datetime")
                .HasColumnName("han_thanh_toan");
            entity.Property(e => e.MaThanhToan)
                .HasMaxLength(100)
                .HasColumnName("ma_thanh_toan");
            entity.Property(e => e.Nam)
                .HasColumnType("int(11)")
                .HasColumnName("nam");
            entity.Property(e => e.SoTienDaThanhToan)
                .HasPrecision(15, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("so_tien_da_thanh_toan");
            entity.Property(e => e.Thang)
                .HasColumnType("int(11)")
                .HasColumnName("thang");
            entity.Property(e => e.TongTien)
                .HasPrecision(15, 2)
                .HasColumnName("tong_tien");
            entity.Property(e => e.TrangThai)
                .HasColumnType("int(11)")
                .HasColumnName("trang_thai");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.CanHoNavigation).WithOne(p => p.HoaDon)
                .HasForeignKey<HoaDon>(d => d.CanHo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hoa_don_can_ho");

            entity.HasOne(d => d.TrangThaiNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.TrangThai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hoa_don_trang_thai");
        });

        modelBuilder.Entity<HopDong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("hop_dong");

            entity.HasIndex(e => e.CanHo, "fk_hop_dong_can_ho");

            entity.HasIndex(e => e.CuDan, "fk_hop_dong_cu_dan");

            entity.HasIndex(e => e.LoaiHopDong, "fk_hop_dong_loai");

            entity.HasIndex(e => e.NguoiTao, "fk_hop_dong_nhan_vien");

            entity.HasIndex(e => e.SoHopDong, "so_hop_dong").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CanHo)
                .HasColumnType("int(11)")
                .HasColumnName("can_ho");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CuDan)
                .HasColumnType("int(11)")
                .HasColumnName("cu_dan");
            entity.Property(e => e.FileDinhKem)
                .HasMaxLength(255)
                .HasColumnName("file_dinh_kem");
            entity.Property(e => e.GhiChu)
                .HasColumnType("text")
                .HasColumnName("ghi_chu");
            entity.Property(e => e.GiaTriHopDong)
                .HasPrecision(15, 2)
                .HasColumnName("gia_tri_hop_dong");
            entity.Property(e => e.LoaiHopDong)
                .HasColumnType("int(11)")
                .HasColumnName("loai_hop_dong");
            entity.Property(e => e.NgayBatDau)
                .HasColumnType("datetime")
                .HasColumnName("ngay_bat_dau");
            entity.Property(e => e.NgayKetThuc)
                .HasColumnType("datetime")
                .HasColumnName("ngay_ket_thuc");
            entity.Property(e => e.NgayKy)
                .HasColumnType("datetime")
                .HasColumnName("ngay_ky");
            entity.Property(e => e.NguoiTao)
                .HasColumnType("int(11)")
                .HasColumnName("nguoi_tao");
            entity.Property(e => e.SoHopDong)
                .HasMaxLength(100)
                .HasColumnName("so_hop_dong");
            entity.Property(e => e.TienCoc)
                .HasPrecision(15, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("tien_coc");
            entity.Property(e => e.TrangThai)
                .HasColumnType("int(11)")
                .HasColumnName("trang_thai");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.CanHoNavigation).WithMany(p => p.HopDongs)
                .HasForeignKey(d => d.CanHo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hop_dong_can_ho");

            entity.HasOne(d => d.CuDanNavigation).WithMany(p => p.HopDongs)
                .HasForeignKey(d => d.CuDan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hop_dong_cu_dan");

            entity.HasOne(d => d.LoaiHopDongNavigation).WithMany(p => p.HopDongs)
                .HasForeignKey(d => d.LoaiHopDong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hop_dong_loai");

            entity.HasOne(d => d.NguoiTaoNavigation).WithMany(p => p.HopDongs)
                .HasForeignKey(d => d.NguoiTao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hop_dong_nhan_vien");
        });

        modelBuilder.Entity<LichDatTienIch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lich_dat_tien_ich");

            entity.HasIndex(e => e.CanHo, "fk_ldti_can_ho");

            entity.HasIndex(e => e.CuDan, "fk_ldti_cu_dan");

            entity.HasIndex(e => e.TienIch, "fk_ldti_tien_ich");

            entity.HasIndex(e => e.TrangThai, "fk_ldti_trang_thai");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CanHo)
                .HasColumnType("int(11)")
                .HasColumnName("can_ho");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CuDan)
                .HasColumnType("int(11)")
                .HasColumnName("cu_dan");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(255)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.ThoiGianBatDau)
                .HasColumnType("datetime")
                .HasColumnName("thoi_gian_bat_dau");
            entity.Property(e => e.ThoiGianKetThuc)
                .HasColumnType("datetime")
                .HasColumnName("thoi_gian_ket_thuc");
            entity.Property(e => e.TienIch)
                .HasColumnType("int(11)")
                .HasColumnName("tien_ich");
            entity.Property(e => e.TongTien)
                .HasPrecision(15, 2)
                .HasColumnName("tong_tien");
            entity.Property(e => e.TrangThai)
                .HasColumnType("int(11)")
                .HasColumnName("trang_thai");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.CanHoNavigation).WithMany(p => p.LichDatTienIches)
                .HasForeignKey(d => d.CanHo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ldti_can_ho");

            entity.HasOne(d => d.CuDanNavigation).WithMany(p => p.LichDatTienIches)
                .HasForeignKey(d => d.CuDan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ldti_cu_dan");

            entity.HasOne(d => d.TienIchNavigation).WithMany(p => p.LichDatTienIches)
                .HasForeignKey(d => d.TienIch)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ldti_tien_ich");

            entity.HasOne(d => d.TrangThaiNavigation).WithMany(p => p.LichDatTienIches)
                .HasForeignKey(d => d.TrangThai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ldti_trang_thai");
        });

        modelBuilder.Entity<LichSuThanhToan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lich_su_thanh_toan");

            entity.HasIndex(e => e.NguoiThanhToan, "fk_lstt_cu_dan");

            entity.HasIndex(e => e.HoaDon, "fk_lstt_hoa_don");

            entity.HasIndex(e => e.NguonTao, "fk_lstt_nguon");

            entity.HasIndex(e => e.IdWebhook, "fk_lstt_webhook");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(255)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.HoaDon)
                .HasColumnType("int(11)")
                .HasColumnName("hoa_don");
            entity.Property(e => e.IdWebhook)
                .HasColumnType("int(11)")
                .HasColumnName("id_webhook");
            entity.Property(e => e.MaGiaoDich)
                .HasMaxLength(255)
                .HasColumnName("ma_giao_dich");
            entity.Property(e => e.NgayThanhToan)
                .HasColumnType("datetime")
                .HasColumnName("ngay_thanh_toan");
            entity.Property(e => e.NguoiThanhToan)
                .HasColumnType("int(11)")
                .HasColumnName("nguoi_thanh_toan");
            entity.Property(e => e.NguonTao)
                .HasColumnType("int(11)")
                .HasColumnName("nguon_tao");
            entity.Property(e => e.PhuongThucThanhToan)
                .HasMaxLength(100)
                .HasColumnName("phuong_thuc_thanh_toan");
            entity.Property(e => e.SoTien)
                .HasPrecision(15, 2)
                .HasColumnName("so_tien");

            entity.HasOne(d => d.HoaDonNavigation).WithMany(p => p.LichSuThanhToans)
                .HasForeignKey(d => d.HoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_lstt_hoa_don");

            entity.HasOne(d => d.IdWebhookNavigation).WithMany(p => p.LichSuThanhToans)
                .HasForeignKey(d => d.IdWebhook)
                .HasConstraintName("fk_lstt_webhook");

            entity.HasOne(d => d.NguoiThanhToanNavigation).WithMany(p => p.LichSuThanhToans)
                .HasForeignKey(d => d.NguoiThanhToan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_lstt_cu_dan");

            entity.HasOne(d => d.NguonTaoNavigation).WithMany(p => p.LichSuThanhToans)
                .HasForeignKey(d => d.NguonTao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_lstt_nguon");
        });

        modelBuilder.Entity<LoaiCanHo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("loai_can_ho");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.TenLoaiCanHo)
                .HasMaxLength(255)
                .HasColumnName("ten_loai_can_ho");
        });

        modelBuilder.Entity<LoaiHopDong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("loai_hop_dong");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.TenLoai)
                .HasMaxLength(255)
                .HasColumnName("ten_loai");
        });

        modelBuilder.Entity<LoaiPhiDichVu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("loai_phi_dich_vu");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.TenLoaiPhiDichVu)
                .HasMaxLength(255)
                .HasColumnName("ten_loai_phi_dich_vu");
        });

        modelBuilder.Entity<LoaiPhuongTien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("loai_phuong_tien");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.TenLoaiPhuongTien)
                .HasMaxLength(255)
                .HasColumnName("ten_loai_phuong_tien");
        });

        modelBuilder.Entity<LoaiTinhPhiDichVu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("loai_tinh_phi_dich_vu");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.TenLoai)
                .HasMaxLength(255)
                .HasColumnName("ten_loai");
        });

        modelBuilder.Entity<NguonTao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("nguon_tao");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.TenNguonTao)
                .HasMaxLength(255)
                .HasColumnName("ten_nguon_tao");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("nhan_vien");

            entity.HasIndex(e => e.Cccd, "cccd").IsUnique();

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.ChucVu, "fk_nhan_vien_chuc_vu");

            entity.HasIndex(e => e.MaNhanVien, "ma_nhan_vien").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Cccd)
                .HasMaxLength(20)
                .HasColumnName("cccd");
            entity.Property(e => e.ChucVu)
                .HasColumnType("int(11)")
                .HasColumnName("chuc_vu");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.GhiChu)
                .HasColumnType("text")
                .HasColumnName("ghi_chu");
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .HasColumnName("ho_ten");
            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(50)
                .HasColumnName("ma_nhan_vien");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .HasColumnName("mat_khau");
            entity.Property(e => e.NgayNghiLam)
                .HasColumnType("datetime")
                .HasColumnName("ngay_nghi_lam");
            entity.Property(e => e.NgaySinh)
                .HasColumnType("datetime")
                .HasColumnName("ngay_sinh");
            entity.Property(e => e.NgayVaoLam)
                .HasColumnType("datetime")
                .HasColumnName("ngay_vao_lam");
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .HasColumnName("sdt");
            entity.Property(e => e.TrangThai)
                .HasColumnType("int(11)")
                .HasColumnName("trang_thai");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.ChucVuNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.ChucVu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_nhan_vien_chuc_vu");
        });

        modelBuilder.Entity<NhanVienPhanQuyen>(entity =>
        {
            entity.HasKey(e => new { e.NhanVien, e.PermissionName, e.PermissionAction })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("nhan_vien_phan_quyen");

            entity.HasIndex(e => e.PermissionAction, "fk_nvpq_perm_action");

            entity.HasIndex(e => e.PermissionName, "fk_nvpq_perm_name");

            entity.Property(e => e.NhanVien)
                .HasColumnType("int(11)")
                .HasColumnName("nhan_vien");
            entity.Property(e => e.PermissionName)
                .HasColumnType("int(11)")
                .HasColumnName("permission_name");
            entity.Property(e => e.PermissionAction)
                .HasColumnType("int(11)")
                .HasColumnName("permission_action");

            entity.HasOne(d => d.NhanVienNavigation).WithMany(p => p.NhanVienPhanQuyens)
                .HasForeignKey(d => d.NhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_nvpq_nhan_vien");

            entity.HasOne(d => d.PermissionActionNavigation).WithMany(p => p.NhanVienPhanQuyens)
                .HasForeignKey(d => d.PermissionAction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_nvpq_perm_action");

            entity.HasOne(d => d.PermissionNameNavigation).WithMany(p => p.NhanVienPhanQuyens)
                .HasForeignKey(d => d.PermissionName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_nvpq_perm_name");
        });

        modelBuilder.Entity<NhatKyHeThong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("nhat_ky_he_thong");

            entity.HasIndex(e => e.NguoiThucHien, "fk_nkht_nhan_vien");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.BangTacDong)
                .HasMaxLength(100)
                .HasColumnName("bang_tac_dong");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.GiaTriCu)
                .HasColumnType("text")
                .HasColumnName("gia_tri_cu");
            entity.Property(e => e.GiaTriMoi)
                .HasColumnType("text")
                .HasColumnName("gia_tri_moi");
            entity.Property(e => e.HanhDong)
                .HasMaxLength(50)
                .HasColumnName("hanh_dong");
            entity.Property(e => e.IdBanGhi)
                .HasColumnType("int(11)")
                .HasColumnName("id_ban_ghi");
            entity.Property(e => e.NguoiThucHien)
                .HasColumnType("int(11)")
                .HasColumnName("nguoi_thuc_hien");
            entity.Property(e => e.ThoiGian)
                .HasColumnType("datetime")
                .HasColumnName("thoi_gian");

            entity.HasOne(d => d.NguoiThucHienNavigation).WithMany(p => p.NhatKyHeThongs)
                .HasForeignKey(d => d.NguoiThucHien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_nkht_nhan_vien");
        });

        modelBuilder.Entity<NhatKyWebhook>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("nhat_ky_webhook");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.DuLieuJson)
                .HasColumnType("text")
                .HasColumnName("du_lieu_json");
            entity.Property(e => e.LoiChiTiet)
                .HasColumnType("text")
                .HasColumnName("loi_chi_tiet");
            entity.Property(e => e.MaGiaoDichGoc)
                .HasMaxLength(255)
                .HasColumnName("ma_giao_dich_goc");
            entity.Property(e => e.NgayNhan)
                .HasColumnType("datetime")
                .HasColumnName("ngay_nhan");
            entity.Property(e => e.NhaCungCap)
                .HasMaxLength(255)
                .HasColumnName("nha_cung_cap");
            entity.Property(e => e.TrangThaiXuLy)
                .HasColumnType("int(11)")
                .HasColumnName("trang_thai_xu_ly");
        });

        modelBuilder.Entity<PermissionAction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("permission_actions");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<PermissionName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("permission_names");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<PhiDichVu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("phi_dich_vu");

            entity.HasIndex(e => e.DonViTinh, "fk_pdv_dvt");

            entity.HasIndex(e => e.LoaiPhiDichVu, "fk_pdv_loai");

            entity.HasIndex(e => e.LoaiTinhPhi, "fk_pdv_loai_tinh");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.DonGia)
                .HasPrecision(15, 2)
                .HasColumnName("don_gia");
            entity.Property(e => e.DonViTinh)
                .HasColumnType("int(11)")
                .HasColumnName("don_vi_tinh");
            entity.Property(e => e.LoaiPhiDichVu)
                .HasColumnType("int(11)")
                .HasColumnName("loai_phi_dich_vu");
            entity.Property(e => e.LoaiTinhPhi)
                .HasColumnType("int(11)")
                .HasColumnName("loai_tinh_phi");
            entity.Property(e => e.TenPhiDichVu)
                .HasMaxLength(255)
                .HasColumnName("ten_phi_dich_vu");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.DonViTinhNavigation).WithMany(p => p.PhiDichVus)
                .HasForeignKey(d => d.DonViTinh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pdv_dvt");

            entity.HasOne(d => d.LoaiPhiDichVuNavigation).WithMany(p => p.PhiDichVus)
                .HasForeignKey(d => d.LoaiPhiDichVu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pdv_loai");

            entity.HasOne(d => d.LoaiTinhPhiNavigation).WithMany(p => p.PhiDichVus)
                .HasForeignKey(d => d.LoaiTinhPhi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pdv_loai_tinh");
        });

        modelBuilder.Entity<PhuongTien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("phuong_tien");

            entity.HasIndex(e => e.CanHo, "fk_phuong_tien_can_ho");

            entity.HasIndex(e => e.LoaiPhuongTien, "fk_phuong_tien_loai");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.BienSo)
                .HasMaxLength(50)
                .HasColumnName("bien_so");
            entity.Property(e => e.CanHo)
                .HasColumnType("int(11)")
                .HasColumnName("can_ho");
            entity.Property(e => e.LoaiPhuongTien)
                .HasColumnType("int(11)")
                .HasColumnName("loai_phuong_tien");
            entity.Property(e => e.NgayDangKy)
                .HasColumnType("datetime")
                .HasColumnName("ngay_dang_ky");
            entity.Property(e => e.NgayHuy)
                .HasColumnType("datetime")
                .HasColumnName("ngay_huy");
            entity.Property(e => e.TenPhuongTien)
                .HasMaxLength(255)
                .HasColumnName("ten_phuong_tien");
            entity.Property(e => e.TrangThai)
                .HasColumnType("int(11)")
                .HasColumnName("trang_thai");

            entity.HasOne(d => d.CanHoNavigation).WithMany(p => p.PhuongTiens)
                .HasForeignKey(d => d.CanHo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_phuong_tien_can_ho");

            entity.HasOne(d => d.LoaiPhuongTienNavigation).WithMany(p => p.PhuongTiens)
                .HasForeignKey(d => d.LoaiPhuongTien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_phuong_tien_loai");
        });

        modelBuilder.Entity<ThongBao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("thong_bao");

            entity.HasIndex(e => e.NguoiTao, "fk_thong_bao_nhan_vien");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deletedAt");
            entity.Property(e => e.NguoiTao)
                .HasColumnType("int(11)")
                .HasColumnName("nguoi_tao");
            entity.Property(e => e.NoiDung)
                .HasColumnType("text")
                .HasColumnName("noi_dung");
            entity.Property(e => e.TieuDe)
                .HasMaxLength(255)
                .HasColumnName("tieu_de");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.NguoiTaoNavigation).WithMany(p => p.ThongBaos)
                .HasForeignKey(d => d.NguoiTao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_thong_bao_nhan_vien");
        });

        modelBuilder.Entity<ThuocTinh>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("thuoc_tinh");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.TenThuocTinh)
                .HasMaxLength(255)
                .HasColumnName("ten_thuoc_tinh");
        });

        modelBuilder.Entity<ThuocTinhCanHo>(entity =>
        {
            entity.HasKey(e => new { e.CanHo, e.ThuocTinh })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("thuoc_tinh_can_ho");

            entity.HasIndex(e => e.ThuocTinh, "fk_ttch_thuoc_tinh");

            entity.Property(e => e.CanHo)
                .HasColumnType("int(11)")
                .HasColumnName("can_ho");
            entity.Property(e => e.ThuocTinh)
                .HasColumnType("int(11)")
                .HasColumnName("thuoc_tinh");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.GiaTriThuocTinh)
                .HasMaxLength(255)
                .HasColumnName("gia_tri_thuoc_tinh");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.CanHoNavigation).WithMany(p => p.ThuocTinhCanHos)
                .HasForeignKey(d => d.CanHo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ttch_can_ho");

            entity.HasOne(d => d.ThuocTinhNavigation).WithMany(p => p.ThuocTinhCanHos)
                .HasForeignKey(d => d.ThuocTinh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ttch_thuoc_tinh");
        });

        modelBuilder.Entity<TienIch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tien_ich");

            entity.HasIndex(e => e.DonViTinh, "fk_tien_ich_dvt");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.DonViTinh)
                .HasColumnType("int(11)")
                .HasColumnName("don_vi_tinh");
            entity.Property(e => e.GiaThue)
                .HasPrecision(15, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("gia_thue");
            entity.Property(e => e.GioDongCua)
                .HasColumnType("time")
                .HasColumnName("gio_dong_cua");
            entity.Property(e => e.GioMoCua)
                .HasColumnType("time")
                .HasColumnName("gio_mo_cua");
            entity.Property(e => e.TenTienIch)
                .HasMaxLength(255)
                .HasColumnName("ten_tien_ich");
            entity.Property(e => e.TrangThai)
                .HasColumnType("int(11)")
                .HasColumnName("trang_thai");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.ViTri)
                .HasMaxLength(255)
                .HasColumnName("vi_tri");

            entity.HasOne(d => d.DonViTinhNavigation).WithMany(p => p.TienIches)
                .HasForeignKey(d => d.DonViTinh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tien_ich_dvt");
        });

        modelBuilder.Entity<TinhTrangSoHuuCanHo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tinh_trang_so_huu_can_ho");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.TenTinhTrang)
                .HasMaxLength(255)
                .HasColumnName("ten_tinh_trang");
        });

        modelBuilder.Entity<ToaNha>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("toa_nha");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .HasColumnName("dia_chi");
            entity.Property(e => e.SoTang)
                .HasColumnType("int(11)")
                .HasColumnName("so_tang");
            entity.Property(e => e.TenToaNha)
                .HasMaxLength(255)
                .HasColumnName("ten_toa_nha");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<TrangThaiDatCho>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("trang_thai_dat_cho");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.TenTrangThai)
                .HasMaxLength(255)
                .HasColumnName("ten_trang_thai");
        });

        modelBuilder.Entity<TrangThaiSuDungCanHo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("trang_thai_su_dung_can_ho");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.TenTrangThai)
                .HasMaxLength(255)
                .HasColumnName("ten_trang_thai");
        });

        modelBuilder.Entity<TrangThaiThanhToan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("trang_thai_thanh_toan");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.TenTrangThai)
                .HasMaxLength(255)
                .HasColumnName("ten_trang_thai");
        });

        modelBuilder.Entity<TrangThaiYeuCau>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("trang_thai_yeu_cau");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.TenTrangThai)
                .HasMaxLength(255)
                .HasColumnName("ten_trang_thai");
        });

        modelBuilder.Entity<VaiTro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("vai_tro");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.VaiTro1)
                .HasMaxLength(100)
                .HasColumnName("vai_tro");
        });

        modelBuilder.Entity<YeuCauCuDan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("yeu_cau_cu_dan");

            entity.HasIndex(e => e.CuDan, "fk_yccd_cu_dan");

            entity.HasIndex(e => e.NhanVienXuLy, "fk_yccd_nhan_vien");

            entity.HasIndex(e => e.TrangThai, "fk_yccd_trang_thai");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CuDan)
                .HasColumnType("int(11)")
                .HasColumnName("cu_dan");
            entity.Property(e => e.MucDoUuTien)
                .HasColumnType("int(11)")
                .HasColumnName("muc_do_uu_tien");
            entity.Property(e => e.NgayGui)
                .HasColumnType("datetime")
                .HasColumnName("ngay_gui");
            entity.Property(e => e.NgayHoanThanh)
                .HasColumnType("datetime")
                .HasColumnName("ngay_hoan_thanh");
            entity.Property(e => e.NhanVienXuLy)
                .HasColumnType("int(11)")
                .HasColumnName("nhan_vien_xu_ly");
            entity.Property(e => e.NoiDung)
                .HasColumnType("text")
                .HasColumnName("noi_dung");
            entity.Property(e => e.TieuDe)
                .HasMaxLength(255)
                .HasColumnName("tieu_de");
            entity.Property(e => e.TrangThai)
                .HasColumnType("int(11)")
                .HasColumnName("trang_thai");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.CuDanNavigation).WithMany(p => p.YeuCauCuDans)
                .HasForeignKey(d => d.CuDan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_yccd_cu_dan");

            entity.HasOne(d => d.NhanVienXuLyNavigation).WithMany(p => p.YeuCauCuDans)
                .HasForeignKey(d => d.NhanVienXuLy)
                .HasConstraintName("fk_yccd_nhan_vien");

            entity.HasOne(d => d.TrangThaiNavigation).WithMany(p => p.YeuCauCuDans)
                .HasForeignKey(d => d.TrangThai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_yccd_trang_thai");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
