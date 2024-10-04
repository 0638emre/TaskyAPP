namespace Tasky.Entities.Models;

public class Kullanici
{
    public int Id { get; set; }
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public string Email { get; set; }
    public string GSM { get; set; }
    public string Sifre { get; set; } 
    public bool Aktif { get; set; }
    public ICollection<KullaniciKonu> KullaniciKonular { get; set; }
    public KullaniciYetki YeKullaniciYetkitki { get; set; }
}