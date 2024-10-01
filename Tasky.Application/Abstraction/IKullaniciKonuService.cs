using Tasky.Application.DTOs;

namespace Tasky.Application.Abstraction;

public interface IKullaniciKonuService
{
    Task<bool> BugunTamamladim(int kullaniciId, int konuId);

    Task<List<CeteleGetirResponseDTO>> CeteleGetirKullaniciIdyeGore(int kullaniciId);
    
    //TODO: ceteleId ye göre cetele getir
    //TODO: cetele sil id ye göre
    //TODO: tüm ceteleyi dön
}