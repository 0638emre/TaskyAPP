namespace Tasky.Application.DTOs;

public class CeteleGetirResponseDTO
{
    public int CeteleId { get; set; }
    public int KullaniciId { get; set; }
    public string KullaniciAdveSoyad { get; set; }
    public int KonuId { get; set; }
    public string KonuAd { get; set; }
    public DateTime KayitTarih { get; set; }
    
    
}