namespace Tasky.Application.DTOs;

public class KullaniciResponseDTO
{
    public int Id { get; set; }
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public string Email { get; set; }
    public string GSM { get; set; }
    public bool Aktif { get; set; }
}