# 🛒 Stock & Shopping Cart System (Backend API)

RESTful API สำหรับจัดการระบบสต๊อกและการสั่งซื้อสินค้า พัฒนาด้วยสถาปัตยกรรม N-Tier Architecture เน้นความปลอดภัยของข้อมูล (Data Integrity) การจัดการ Concurrency ขั้นสูง และออกแบบตามหลักการ SOLID Principles

## 🚀 Tech Stack (เทคโนโลยีที่ใช้)
* **Framework:** .NET 10 (ASP.NET Core Web API)
* **Language:** C#
* **Database:** PostgreSQL
* **ORM:** Entity Framework Core (EF Core) 
* **API Documentation:** Swagger / OpenAPI

---

## 🛠️ Prerequisites (สิ่งที่ต้องเตรียมก่อนติดตั้ง)
กรุณาตรวจสอบให้แน่ใจว่าเครื่องของคุณได้ติดตั้งซอฟต์แวร์เหล่านี้แล้ว:
* **.NET 10 SDK**
* **PostgreSQL** (รันเป็น Local Service หรือผ่าน Docker)
* **EF Core CLI Tools** (กรณีรันผ่าน Terminal ให้รันคำสั่ง `dotnet tool install --global dotnet-ef` ก่อน)

---

## ⚙️ Configuration & Setup (การตั้งค่าและรันโปรเจกต์)

**1. ตั้งค่า Connection String**
เปิดไฟล์ `appsettings.Development.json` (หรือ `appsettings.json`) และแก้ไข `PostgresConnection` ให้ตรงกับ Database ในเครื่องของคุณ:
```json
"ConnectionStrings": {
  "PostgresConnection": "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=your_password"
}

**2. สร้างฐานข้อมูล (Database Migration)
โปรเจกต์นี้ใช้ EF Core แบบ Code-First Approach คุณไม่ต้องสร้างตารางเอง ให้รันคำสั่งต่อไปนี้เพื่อสร้าง Database และ Insert Mock Data อัตโนมัติ:

สำหรับ Visual Studio (ผ่าน Package Manager Console):
Update-Database

สำหรับ VS Code / Terminal (ผ่าน .NET CLI):
dotnet ef database update

**3. รัน Development Server
เริ่มต้นเซิร์ฟเวอร์ด้วยคำสั่ง:

Bash
dotnet run
เมื่อรันสำเร็จ สามารถเปิดดู API Documentation และทดสอบยิง API ได้ที่เบราว์เซอร์: http://localhost:5232/swagger