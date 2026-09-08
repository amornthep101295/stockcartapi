using Microsoft.EntityFrameworkCore;
using StockCartApi.Models;

namespace StockCartApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // กำหนด Relation 1-to-1
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Stock)
            .WithOne(s => s.Product)
            .HasForeignKey<Stock>(s => s.ProductId);

        // --- แก้ไข: เปลี่ยนจาก Guid.NewGuid() เป็น Static Hardcoded Guid ---
        var pIds = new List<Guid>
        {
            Guid.Parse("a0000000-0000-0000-0000-000000000001"),
            Guid.Parse("a0000000-0000-0000-0000-000000000002"),
            Guid.Parse("a0000000-0000-0000-0000-000000000003"),
            Guid.Parse("a0000000-0000-0000-0000-000000000004"),
            Guid.Parse("a0000000-0000-0000-0000-000000000005"),
            Guid.Parse("a0000000-0000-0000-0000-000000000006"),
            Guid.Parse("a0000000-0000-0000-0000-000000000007"),
            Guid.Parse("a0000000-0000-0000-0000-000000000008"),
            Guid.Parse("a0000000-0000-0000-0000-000000000009"),
            Guid.Parse("a0000000-0000-0000-0000-000000000010"),
            Guid.Parse("a0000000-0000-0000-0000-000000000011"),
            Guid.Parse("a0000000-0000-0000-0000-000000000012")
        };

        var sIds = new List<Guid>
        {
            Guid.Parse("b0000000-0000-0000-0000-000000000001"),
            Guid.Parse("b0000000-0000-0000-0000-000000000002"),
            Guid.Parse("b0000000-0000-0000-0000-000000000003"),
            Guid.Parse("b0000000-0000-0000-0000-000000000004"),
            Guid.Parse("b0000000-0000-0000-0000-000000000005"),
            Guid.Parse("b0000000-0000-0000-0000-000000000006"),
            Guid.Parse("b0000000-0000-0000-0000-000000000007"),
            Guid.Parse("b0000000-0000-0000-0000-000000000008"),
            Guid.Parse("b0000000-0000-0000-0000-000000000009"),
            Guid.Parse("b0000000-0000-0000-0000-000000000010"),
            Guid.Parse("b0000000-0000-0000-0000-000000000011"),
            Guid.Parse("b0000000-0000-0000-0000-000000000012")
        };

        var products = new List<Product>
        {
            new Product { Id = pIds[0], Sku = "ITM-001", Name = "สบู่ก้อนนกแก้ว (สีเขียว)", Price = 15m },
            new Product { Id = pIds[1], Sku = "ITM-002", Name = "ยาสีฟันคอลเกต 150g", Price = 45m },
            new Product { Id = pIds[2], Sku = "ITM-003", Name = "แชมพูซันซิล 400ml", Price = 129m },
            new Product { Id = pIds[3], Sku = "ITM-004", Name = "ผงซักฟอกบรีส เอกเซล 1500g", Price = 145m },
            new Product { Id = pIds[4], Sku = "ITM-005", Name = "น้ำยาล้างจานซันไลต์ 800ml", Price = 42m },
            new Product { Id = pIds[5], Sku = "ITM-006", Name = "กระดาษทิชชู่ Scott (แพ็ค 6 ม้วน)", Price = 89m },
            new Product { Id = pIds[6], Sku = "ITM-007", Name = "น้ำดื่มคริสตัล 1.5 ลิตร", Price = 15m },
            new Product { Id = pIds[7], Sku = "ITM-008", Name = "บะหมี่กึ่งสำเร็จรูป มาม่าหมูสับ", Price = 7m },
            new Product { Id = pIds[8], Sku = "ITM-009", Name = "ปลากระป๋องสามแม่ครัว", Price = 20m },
            new Product { Id = pIds[9], Sku = "ITM-010", Name = "สมุดโน้ตริมลวด A5", Price = 35m },
            new Product { Id = pIds[10], Sku = "ITM-011", Name = "ปากกาลูกลื่นสีน้ำเงิน (แพ็ค 3 ด้าม)", Price = 25m },
            new Product { Id = pIds[11], Sku = "ITM-012", Name = "ถ่านอัลคาไลน์ AA (แพ็ค 4 ก้อน)", Price = 75m }
        };

        var stocks = new List<Stock>
        {
            new Stock { Id = sIds[0], ProductId = pIds[0], Quantity = 50 },
            new Stock { Id = sIds[1], ProductId = pIds[1], Quantity = 30 },
            new Stock { Id = sIds[2], ProductId = pIds[2], Quantity = 25 },
            new Stock { Id = sIds[3], ProductId = pIds[3], Quantity = 20 },
            new Stock { Id = sIds[4], ProductId = pIds[4], Quantity = 40 },
            new Stock { Id = sIds[5], ProductId = pIds[5], Quantity = 100 },
            new Stock { Id = sIds[6], ProductId = pIds[6], Quantity = 200 },
            new Stock { Id = sIds[7], ProductId = pIds[7], Quantity = 150 },
            new Stock { Id = sIds[8], ProductId = pIds[8], Quantity = 60 },
            new Stock { Id = sIds[9], ProductId = pIds[9], Quantity = 15 },
            new Stock { Id = sIds[10], ProductId = pIds[10], Quantity = 80 },
            new Stock { Id = sIds[11], ProductId = pIds[11], Quantity = 10 }
        };

        modelBuilder.Entity<Product>().HasData(products);
        modelBuilder.Entity<Stock>().HasData(stocks);
    }
}