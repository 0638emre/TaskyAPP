using Microsoft.EntityFrameworkCore;
using Tasky.Application.Abstraction;
using Tasky.Application.Constans;
using Tasky.Application.DTOs;
using Tasky.DAL.Context;
using Tasky.Entities.Models;

namespace Tasky.Application.Concrete;

public class KullaniciKonuService : IKullaniciKonuService
{
    private readonly TaskDBContext _dbContext;

    public KullaniciKonuService(TaskDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> BugunTamamladim(int kullaniciId, int konuId)
    {
        var konuKontrol = await _dbContext.Konular.Where(k => k.Id.Equals(konuId)).AnyAsync();
        if (!konuKontrol)
        {
            throw new ApplicationException(BussinessConstans.KonuBulunamadi);
        }
        var kullaniciKontrol = await _dbContext.Kullanicilar.Where(k => k.Id.Equals(kullaniciId)).AnyAsync();
        if (!kullaniciKontrol)
        {
            throw new ApplicationException(BussinessConstans.KullaniciBulunamadi);
        }

        KullaniciKonu kullaniciKonu = new()
        {
            KayitTarihi = DateTime.Now,
            KonuId = konuId,
            KullaniciId = kullaniciId,
        };
        
        var result =  await _dbContext.KullaniciKonulari.AddAsync(kullaniciKonu);
        
        if (result is null)
        {
            throw new ApplicationException(BussinessConstans.CeteleEklenemedi);
        }
        
        await _dbContext.SaveChangesAsync();
        
        return true;
    }

    public async Task<List<CeteleGetirResponseDTO>> CeteleGetirKullaniciIdyeGore(int kullaniciId)
    {
        var kullaniciKontrol = await _dbContext.Kullanicilar.Where(k => k.Id.Equals(kullaniciId)).AnyAsync();
        if (!kullaniciKontrol)
        {
            throw new ApplicationException(BussinessConstans.KullaniciBulunamadi);
        }
        
        List<CeteleGetirResponseDTO> ceteleGetirList = new();
        
        var data = await _dbContext.KullaniciKonulari
            .Include(k=> k.Konu)
            .Include(k=> k.Kullanici)
            .Where(k => k.KullaniciId.Equals(kullaniciId)).ToListAsync();

        foreach (var k in data)
        {
            CeteleGetirResponseDTO ceteleGetirResponseDto = new();
            ceteleGetirResponseDto.CeteleId = k.Id;
            ceteleGetirResponseDto.KullaniciId = k.KullaniciId;
            ceteleGetirResponseDto.KullaniciAdveSoyad = k.Kullanici.Ad + " " + k.Kullanici.Soyad;
            ceteleGetirResponseDto.KonuId = k.KonuId;
            ceteleGetirResponseDto.KonuAd = k.Konu.KonuAdi;
            ceteleGetirResponseDto.KayitTarih = k.KayitTarihi;
            
            ceteleGetirList.Add(ceteleGetirResponseDto);
        }

        return ceteleGetirList;
    }

    public async Task<CeteleGetirResponseDTO> CeteleGetirIdyeGore(int ceteleId)
    {
        var cetele = await _dbContext.KullaniciKonulari
            .Include(k=> k.Konu)
            .Include(k=> k.Kullanici)
            .Where(k => k.Id.Equals(ceteleId)).FirstOrDefaultAsync();

        if (cetele is null)
        {
            throw new ApplicationException(BussinessConstans.CeteleBulunamadi);
        }
        
        CeteleGetirResponseDTO ceteleGetirResponseDto = new(); 
        ceteleGetirResponseDto.CeteleId = cetele.Id;
        ceteleGetirResponseDto.KullaniciId = cetele.KullaniciId;
        ceteleGetirResponseDto.KonuId = cetele.KonuId;
        ceteleGetirResponseDto.KonuAd = cetele.Konu.KonuAdi;
        ceteleGetirResponseDto.KayitTarih = cetele.KayitTarihi;
        ceteleGetirResponseDto.KullaniciAdveSoyad = cetele.Kullanici.Ad + " " + cetele.Kullanici.Soyad;
        
        return ceteleGetirResponseDto;
    }

    public async Task<bool> CeteleSil(int ceteleId)
    {
        var cetele = await _dbContext.KullaniciKonulari.Where(k => k.Id.Equals(ceteleId)).FirstOrDefaultAsync();
        if (cetele is null)
        {
            throw new ApplicationException(BussinessConstans.CeteleBulunamadi);
        }
        
        var result =  _dbContext.KullaniciKonulari.Remove(cetele);
        if (result is null)
        {
            throw new ApplicationException(BussinessConstans.CeteleSilinemedi);
        }

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<CeteleGetirResponseDTO>> CeteleListesi()
    {
        var datas = await _dbContext.KullaniciKonulari
            .Include(k => k.Konu)
            .Include(k => k.Kullanici)
            .OrderBy(k => k.KonuId).ToListAsync();
        
        List<CeteleGetirResponseDTO> ceteleGetirList = new();

        foreach (var cetele in datas)
        {
            CeteleGetirResponseDTO ceteleGetirResponseDto = new(); 
            ceteleGetirResponseDto.CeteleId = cetele.Id;
            ceteleGetirResponseDto.KullaniciId = cetele.KullaniciId;
            ceteleGetirResponseDto.KonuId = cetele.KonuId;
            ceteleGetirResponseDto.KonuAd = cetele.Konu.KonuAdi;
            ceteleGetirResponseDto.KayitTarih = cetele.KayitTarihi;
            ceteleGetirResponseDto.KullaniciAdveSoyad = cetele.Kullanici.Ad + " " + cetele.Kullanici.Soyad;
            
            ceteleGetirList.Add(ceteleGetirResponseDto);
        }

        return ceteleGetirList;

    }
}