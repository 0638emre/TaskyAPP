namespace Tasky.Entities.Models;

public class Lugat
{
    public int Id { get; set; }
    public string OzluSoz { get; set; }
    public int KullaniciId { get; set; }
    public Kullanici Kullanici { get; set; }
}