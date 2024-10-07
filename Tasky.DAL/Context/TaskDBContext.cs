using Microsoft.EntityFrameworkCore;
using Tasky.Entities.Models;

namespace Tasky.DAL.Context;

public class TaskDBContext : DbContext
{
    public TaskDBContext(DbContextOptions<TaskDBContext> options) : base(options)
    {
        
    }
    
    public DbSet<Konu> Konular { get; set; }
    public DbSet<Kullanici> Kullanicilar { get; set; }
    public DbSet<KullaniciKonu> KullaniciKonulari { get; set; }
    public DbSet<Yetki> Yetkiler { get; set; }
    public DbSet<KullaniciYetki> KullaniciYetkiler { get; set; }
    public DbSet<Lugat> Lugatlar { get; set; }


}