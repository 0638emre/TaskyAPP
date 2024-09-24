using Microsoft.EntityFrameworkCore;
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

        //TODO: Validasyon eksik.

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
        //instance
        KullaniciResponseDTO kullaniciResponseDTO = new KullaniciResponseDTO();

        var kullanici = await _dbContext.Kullanicilar.Where(k => k.Id.Equals(kullaniciId)).FirstOrDefaultAsync();
        // TODO : first ile single arasındaki fark nedir ?

        if (kullanici is null)
        {
            // return kullaniciResponseDTO;
            throw new Exception($" {kullaniciId} id ye sahip kullanıcı bulunamadı. !");
        }

        kullaniciResponseDTO.Id = kullanici.Id;
        kullaniciResponseDTO.Ad = kullanici.Ad;
        kullaniciResponseDTO.Soyad = kullanici.Soyad;
        kullaniciResponseDTO.Email = kullanici.Email;
        kullaniciResponseDTO.GSM = kullanici.GSM;
        kullaniciResponseDTO.Aktif = kullanici.Aktif;

        return kullaniciResponseDTO;
    }

    public async Task<List<KullaniciResponseDTO>> KullanicilariListele()
    {
        //automapper
        List<KullaniciResponseDTO> kullaniciListesi = new List<KullaniciResponseDTO>();

        var dbdenDonenKullanicilar =  await _dbContext.Kullanicilar.ToListAsync();

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
        var kullanici = await _dbContext.Kullanicilar.Where(k => k.Id.Equals(kullaniciId)).FirstOrDefaultAsync();

        if (kullanici is null)
        {
            throw new Exception($" {kullaniciId} id ye sahip kullanıcı bulunamadı. Bu sebeple silinemez !!!");
        }

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
        var kullanici = await _dbContext.Kullanicilar.Where(k => k.Id.Equals(kullaniciId)).FirstOrDefaultAsync();
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
        var kullanici = await _dbContext.Kullanicilar.Where(k => k.Id.Equals(kullaniciId)).FirstOrDefaultAsync();
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
        var kullanici = await _dbContext.Kullanicilar.Where(k => k.Id.Equals(kullaniciGuncelleRequest.KullaniciId)).FirstOrDefaultAsync();

        if (kullanici is null)
        {
            // return false;
            throw new Exception("Böyle bir kullanıcı bulunamadı.");
        }
        
        kullanici.Ad = kullaniciGuncelleRequest.Adi;
        kullanici.Soyad = kullaniciGuncelleRequest.Soyadi;
        kullanici.Email = kullaniciGuncelleRequest.Email;
        kullanici.GSM = kullaniciGuncelleRequest.GSM;
        kullanici.Sifre = kullaniciGuncelleRequest.Sifre;
        
        _dbContext.Kullanicilar.Update(kullanici);
        
        await _dbContext.SaveChangesAsync();
        
        return true;
    }
}