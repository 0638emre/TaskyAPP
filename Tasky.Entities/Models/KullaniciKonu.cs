namespace Tasky.Entities.Models;

public class KullaniciKonu
{
    public int Id { get; set; }
    
    public int KullaniciId { get; set; }
    public Kullanici Kullanici { get; set; }

    public int KonuId { get; set; }
    public Konu Konu { get; set; }
}