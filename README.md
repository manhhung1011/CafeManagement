# CafeManagement - ASP.NET MVC

## 1. Mô tả chủ đề

CafeManagement là project ASP.NET MVC mô phỏng hệ thống quản lý món trong quán cà phê.
Hệ thống cho phép người dùng quản lý danh sách món gồm: tên món, loại món, giá, số lượng và mô tả.

Project được xây dựng nhằm thực hành mô hình MVC, Razor View Engine, Layout dùng chung và các chức năng CRUD cơ bản.

---

## 2. Chức năng chính

* Hiển thị danh sách món trong quán cà phê.
* Xem chi tiết thông tin món.
* Thêm món mới.
* Cập nhật thông tin món.
* Xóa món.
* Tìm kiếm món theo tên hoặc loại món.
* Sắp xếp danh sách theo giá.
* Phân trang danh sách món.
* Hiển thị thông báo sau khi thêm, sửa, xóa thành công.
* Tách Header, Menu, Footer thành Partial View.

---

## 3. Công nghệ sử dụng

* ASP.NET Core MVC
* C#
* Razor View Engine
* Bootstrap 5
* HTML, CSS, JavaScript

---

## 4. Hướng dẫn chạy project

### Bước 1: Clone project

```bash
git clone https://github.com/manhhung1011/CafeManagement.git
```

### Bước 2: Mở project

Mở project bằng:

* Visual Studio
  hoặc
* Visual Studio Code

---

### Bước 3: Restore package

Mở terminal tại thư mục project và chạy:

```bash
dotnet restore
```

---

### Bước 4: Chạy project

```bash
dotnet run
```

---

### Bước 5: Truy cập website

Sau khi chạy thành công, mở trình duyệt và truy cập địa chỉ:

```txt
https://localhost:xxxx
```

hoặc:

```txt
http://localhost:xxxx
```

(Port sẽ hiển thị trong terminal khi chạy project)

---

## 5. Ghi chú

Project hiện đang sử dụng dữ liệu mẫu lưu trong `List<CafeItem>` và chưa kết nối cơ sở dữ liệu.

Mục tiêu chính của project là thực hành:

* CRUD Controller
* Razor View Engine
* Layout và Partial View
* Routing trong ASP.NET MVC
* Giao diện cơ bản bằng Bootstrap
