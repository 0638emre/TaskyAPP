namespace Tasky.Application.DTOs;

public class KullaniciYetkiGetirResponseDTO
{
    public int Id { get; set; }
    public int KullaniciId { get; set; }
    public string KullaniciAdSoyad { get; set; }
    public int YetkiId { get; set; }
    public string YetkiAdi { get; set; }
    public DateTime YetkiTarihi { get; set; }
}