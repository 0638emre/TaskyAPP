using Microsoft.EntityFrameworkCore;
using Tasky.Application.Abstraction;
using Tasky.Application.Constans;
using Tasky.Application.DTOs;
using Tasky.Application.Helpers;
using Tasky.DAL.Context;
using Tasky.Entities.Models;

namespace Tasky.Application.Concrete;

public class KullaniciService : IKullaniciService
{
    #region Ctor

    private readonly TaskDBContext _dbContext;
    public KullaniciService(TaskDBContext dbContext) //CONSTRUCTOR
    {
        _dbContext = dbContext;
    }

    #endregion
    
    public async Task<Kullanici> KullaniciKontrol(int kullaniciId)
    {
        var kullanici = await _dbContext.Kullanicilar.Where(k => k.Id.Equals(kullaniciId)).FirstOrDefaultAsync();

        if (kullanici is null)
        {
            throw new Exception(BussinessConstans.KullaniciBulunamadi);
        }
        
        return kullanici;
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

        var emailValidasyon = await _dbContext.Kullanicilar.Where(k => k.Email.Equals(kullaniciOlusturRequest.Email))
            .FirstOrDefaultAsync();

        if (emailValidasyon is not null)
        {
            throw new Exception("Böyle bir mail adresi sistemde vardır ! Olusturamazsınız !");
        }

        var gsmValidasyon = await _dbContext.Kullanicilar.Where(k => k.GSM.Equals(kullaniciOlusturRequest.GSM))
            .FirstOrDefaultAsync();

        if (gsmValidasyon is not null)
        {
            throw new Exception("Böyle bir GSM numarası sistemde vardır ! Olusturamazsınız !");
        }

        if (kullaniciOlusturRequest.Sifre.Length < 6)
        {
            throw new Exception("Lütfen şifreniz 6 karakterden fazla olsun !");
        }

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

    public async Task<KullaniciResponseDTO> KullaniciGetirIdyeGore(int kullaniciId)
    {
        var kullanici = await KullaniciKontrol(kullaniciId);

        return new KullaniciResponseDTO()
        {
            Id = kullanici.Id,
            Ad = kullanici.Ad,
            Soyad = kullanici.Soyad,
            Email = kullanici.Email,
            GSM = kullanici.GSM,
            Aktif = kullanici.Aktif,
        };
    }

    public async Task<List<KullaniciResponseDTO>> KullanicilariListele()
    {
        //automapper
        List<KullaniciResponseDTO> kullaniciListesi = new List<KullaniciResponseDTO>();

        var dbdenDonenKullanicilar = await _dbContext.Kullanicilar.ToListAsync();

        foreach (var k in dbdenDonenKullanicilar)
        {
            KullaniciResponseDTO kullaniciResponseDTO = new KullaniciResponseDTO();

            kullaniciResponseDTO.Id = k.Id;
            kullaniciResponseDTO.Ad = k.Ad;
            kullaniciResponseDTO.Soyad = k.Soyad;
            kullaniciResponseDTO.GSM = k.GSM;
            kullaniciResponseDTO.Email = k.Email;
            kullaniciResponseDTO.Aktif = k.Aktif;

            kullaniciListesi.Add(kullaniciResponseDTO);
        }

        return kullaniciListesi;
    }

    public async Task<bool> KullaniciSil(int kullaniciId)
    {
        var kullanici = await KullaniciKontrol(kullaniciId);
        
        var result = _dbContext.Kullanicilar.Remove(kullanici);

        if (result is null)
        {
            return false;
        }

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> KullaniciyiPasifeAl(int kullaniciId)
    {
        var kullanici = await KullaniciKontrol(kullaniciId);

        kullanici.Aktif = false;
        
        var result = _dbContext.Kullanicilar.Update(kullanici);
        
        if (result is null)
        {
            return false;
        }

        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> KullaniciyiAktifEt(int kullaniciId)
    {
        var kullanici = await KullaniciKontrol(kullaniciId);


        kullanici.Aktif = true;
        var result = _dbContext.Kullanicilar.Update(kullanici);
        if (result is null)
        {
            return false;
        }

        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> KullaniciGuncelle(KullaniciGuncelleRequestDTO kullaniciGuncelleRequest)
    {
        var kullanici = await KullaniciKontrol(kullaniciGuncelleRequest.KullaniciId);
        
        kullanici.Ad = kullaniciGuncelleRequest.Adi;
        kullanici.Soyad = kullaniciGuncelleRequest.Soyadi;
        kullanici.Email = kullaniciGuncelleRequest.Email;
        kullanici.GSM = kullaniciGuncelleRequest.GSM;
        kullanici.Sifre = kullaniciGuncelleRequest.Sifre;

        _dbContext.Kullanicilar.Update(kullanici);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<ResponseDTO> GirisYap(string email, string sifre)
    {
        var kullanici = await _dbContext.Kullanicilar.Where(k => k.Email.Equals(email)).FirstOrDefaultAsync();

        if (kullanici is null)
        {
            return new ResponseDTO() //object initialize
            {
                Message = BussinessConstans.KullaniciMailBulunamadi,
                Success = false
            };
        }

        if (kullanici.Sifre.Equals(sifre))
        {
            return new()
            {
                Message = BussinessConstans.KullaniciGirisiBasarili,
                Success = true
            };
        }

        return new()
        {
            Message = BussinessConstans.KullaniciGirisiBasarisiz,
            Success = false
        };
    }
}