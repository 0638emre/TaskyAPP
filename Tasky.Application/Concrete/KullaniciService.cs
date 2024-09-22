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

    public Task<List<KullaniciResponseDTO>> KullanicilariListele()
    {
        throw new NotImplementedException();
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

    public Task<bool> KullaniciGuncelle(KullaniciGuncelleRequestDTO kullaniciGuncelleRequest)
    {
        throw new NotImplementedException();
    }
}