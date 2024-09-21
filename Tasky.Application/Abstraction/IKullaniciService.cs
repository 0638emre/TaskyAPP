using Tasky.Application.DTOs;

namespace Tasky.Application.Abstraction;

public interface IKullaniciService
{
    Task<bool> KullaniciOlustur(KullaniciOlusturRequestDTO kullaniciOlusturRequest);
    
    Task<KullaniciResponseDTO> KullaniciGetirIdyeGore(int KullaniciId);
    
    Task<List<KullaniciResponseDTO>> KullacilariListele();
    
    Task<bool> KullaniciSil(int kullaniciId);
    
    Task<bool> KullaniciGuncelle(KullaniciGuncelleRequestDTO kullaniciGuncelleRequest);
    
}