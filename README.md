# 🏢 Hệ Thống Quản Lý Tòa Nhà & Chung Cư (Building Management System)

Dự án phần mềm quản lý vận hành tòa nhà, chung cư toàn diện. Hệ thống được thiết kế theo kiến trúc Multi-tenant (quản lý nhiều tòa nhà độc lập), tích hợp theo dõi hóa đơn, thanh toán tự động qua Webhook, và hệ thống tiếp nhận yêu cầu (Ticket System) của cư dân.

Được phát triển trên nền tảng **.NET 10** với giao diện **WPF** hiện đại, áp dụng chặt chẽ mô hình **MVVM**.

## 🛠 Công Nghệ Sử Dụng (Tech Stack)

* **Framework:** .NET 10
* **Giao diện (UI):** WPF (Windows Presentation Foundation)
* **UI Toolkit:** Hỗ trợ tích hợp Material Design in XAML / WPF UI / HandyControl
* **Kiến trúc:** MVVM (Model - View - ViewModel) (Sử dụng *CommunityToolkit.Mvvm*)
* **ORM:** Entity Framework Core (EF Core)
* **Cơ sở dữ liệu:** MySQL

## ✨ Tính Năng Nổi Bật (Key Features)

* **👥 Quản lý Cư dân & Phương tiện:** Lưu trữ thông tin cư dân, theo dõi lịch sử lưu trú, hợp đồng thuê và danh sách phương tiện ra vào.
* **💰 Quản lý Phí & Hóa đơn:** * Cấu hình linh hoạt các loại phí (theo m2, theo định mức, theo phương tiện...).
  * Tự động chốt chỉ số (điện, nước) và phát hành hóa đơn hàng tháng.
* **🛠 Hệ thống Yêu cầu (Helpdesk):** Tiếp nhận, phân công và theo dõi tiến độ xử lý sự cố (điện, nước, an ninh...) từ cư dân.
* **🔒 Phân quyền & Audit Log:** Tính năng `nhat_ky_he_thong` lưu lại toàn bộ lịch sử (Dữ liệu cũ - Dữ liệu mới dưới dạng JSON) mọi thao tác thay đổi dữ liệu của nhân viên.
