# PinRu Backend API

### 📝 Deskripsi
Sistem backend untuk layanan PinRu yang mengelola data customer dengan fitur CRUD lengkap.

### 🛠️ Teknologi
* **Runtime**: .NET 10
* **Database**: PostgreSQL
* **ORM**: Entity Framework Core
* **API Doc**: OpenAPI (Native .NET 10)

### ⚙️ Instalasi & Env
1. **Clone Repository**:
   `git clone <repository-url>`
2. **Konfigurasi Database** 🗄️:
   Buka `appsettings.json` dan sesuaikan `ConnectionStrings`:
   ```json
   "DefaultConnection": "Host=localhost;Database=PinRuDB;Username=postgres;Password=your_password"

## 🚀 Panduan Menjalankan Proyek

Pastikan Anda sudah menginstal **.NET 10 SDK** dan **PostgreSQL** di komputer Anda.

### 1. Persiapan Database
1. Buka **pgAdmin 4** atau terminal PostgreSQL.
2. Buat database baru dengan nama `PinRuDB`.
3. Buka file `appsettings.json` di folder backend, lalu sesuaikan password PostgreSQL Anda pada bagian `DefaultConnection`.

### 2. Menjalankan Backend
Buka terminal di folder `2026-PinRu-backend` dan jalankan perintah berikut:

# Restore library yang diperlukan
dotnet restore

# Terapkan struktur tabel dan data awal (seeding) ke database
dotnet ef database update

# Jalankan aplikasi
dotnet run