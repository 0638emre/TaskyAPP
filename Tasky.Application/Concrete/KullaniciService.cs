using Tasky.Application.Abstraction;
using Tasky.Application.DTOs;
using Tasky.DAL.Context;
using Tasky.Entities.Models;

namespace Tasky.Application.Concrete;

public class KullaniciService : IKullaniciService
{
    private readonly TaskDBContext _dbContext;

    //dependency injecktion DI
    public KullaniciService(TaskDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<bool> KullaniciOlustur(KullaniciOlusturRequestDTO kullaniciOlusturRequest)
    {
        #region eski yöntem
                // Kullanici kullanici = new Kullanici();
                // kullanici.Ad = kullaniciOlusturRequest.Ad;
                // kullanici.Soyad = kullaniciOlusturRequest.Soyad;
                // kullanici.Email = kullaniciOlusturRequest.Email;
                // kullanici.GSM = kullaniciOlusturRequest.GSM;
                // kullanici.Sifre = kullaniciOlusturRequest.Sifre;
                // kullanici.Aktif = true;
        #endregion  
        
        Kullanici kullanici = new Kullanici()
        {
            Ad = kullaniciOlusturRequest.Ad,
            Soyad = kullaniciOlusturRequest.Soyad,
            Email = kullaniciOlusturRequest.Email,
            GSM = kullaniciOlusturRequest.GSM,
            Sifre = kullaniciOlusturRequest.Sifre,
            Aktif = true
        };

        var result = await _dbContext.Kullanicilar.AddAsync(kullanici);

        if (result is null)
        {
            return false;
        }
        
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public Task<KullaniciResponseDTO> KullaniciGetirIdyeGore(int KullaniciId)
    {
        throw new NotImplementedException();
    }

    public Task<List<KullaniciResponseDTO>> KullacilariListele()
    {
        throw new NotImplementedException();
    }

    public Task<bool> KullaniciSil(int kullaniciId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> KullaniciGuncelle(KullaniciGuncelleRequestDTO kullaniciGuncelleRequest)
    {
        throw new NotImplementedException();
    }
}