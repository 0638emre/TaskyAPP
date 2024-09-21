namespace Tasky.Entities.Models;

public class Konu
{
    public int Id { get; set; }
    public string KonuAdi { get; set; }
    public ICollection<KullaniciKonu> KullaniciKonular { get; set; }

}