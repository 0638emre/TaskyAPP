namespace Tasky.Application.DTOs;

public class KullaniciGuncelleRequestDTO
{
    public int KullaniciId { get; set; }
    public string Adi { get; set; }
    public string Soyadi { get; set; }
    public string Sifre { get; set; }
    public string Email { get; set; }
    public string GSM { get; set; }
}