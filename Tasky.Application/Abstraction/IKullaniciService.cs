using Tasky.Application.DTOs;

namespace Tasky.Application.Abstraction;

public interface IKullaniciService
{
    Task<bool> KullaniciOlustur(KullaniciOlusturRequestDTO kullaniciOlusturRequest);
    
    Task<KullaniciResponseDTO> KullaniciGetirIdyeGore(int kullaniciId);
    
    Task<List<KullaniciResponseDTO>> KullanicilariListele();
    
    Task<bool> KullaniciSil(int kullaniciId);

    Task<bool> KullaniciyiPasifeAl(int kullaniciId);
    
    Task<bool> KullaniciyiAktifEt(int kullaniciId);
    
    Task<bool> KullaniciGuncelle(KullaniciGuncelleRequestDTO kullaniciGuncelleRequest);

    Task<ResponseDTO> GirisYap(string email, string sifre);
    
    

}