using Tasky.Application.DTOs;

namespace Tasky.Application.Abstraction;

public interface IKullaniciKonuService
{
    Task<bool> BugunTamamladim(int kullaniciId, int konuId);

    Task<List<CeteleGetirResponseDTO>> CeteleGetirKullaniciIdyeGore(int kullaniciId);

    Task<CeteleGetirResponseDTO> CeteleGetirIdyeGore(int ceteleId);

    Task<bool> CeteleSil(int ceteleId);
    
    Task<List<CeteleGetirResponseDTO>> CeteleListesi();
}