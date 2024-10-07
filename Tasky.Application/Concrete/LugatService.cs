using Microsoft.EntityFrameworkCore;
using Tasky.Application.Abstraction;
using Tasky.Application.Constans;
using Tasky.Application.DTOs;
using Tasky.DAL.Context;
using Tasky.Entities.Models;

namespace Tasky.Application.Concrete;

public class LugatService(TaskDBContext _dbContext) : ILugatService
{
    public async Task<bool> OzluSozEkle(string ozluSoz, int kullaniciId)
    {
        var kullanici = await _dbContext.Kullanicilar.Where(k => k.Id.Equals(kullaniciId)).FirstOrDefaultAsync();

        if (kullanici is null)
        {
            throw new Exception(BussinessConstans.KullaniciBulunamadi);
        }
        
        if (await _dbContext.Lugatlar.Where(l => l.KullaniciId.Equals(kullaniciId)).AnyAsync())
        {
            throw new Exception(BussinessConstans.KullaniciyeAitOzluSozBulunmaktadir);
        }

        Lugat model = new()
        {
            KullaniciId = kullaniciId,
            OzluSoz = ozluSoz
        };

        var result = await _dbContext.Lugatlar.AddAsync(model);

        if (result is null)
        {
            throw new Exception(BussinessConstans.KullaniciyeAitOzluSozEklenemedi);
        }

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> OzluSozGuncelle(int lugatId, string ozluSoz)
    {
        var lugat = await _dbContext.Lugatlar.Where(l => l.Id.Equals(lugatId)).FirstOrDefaultAsync();
        if (lugat is null)
        {
            throw new Exception(BussinessConstans.HerhangiBirOzluSozBulunamadi);
        }

        lugat.OzluSoz = ozluSoz;

        _dbContext.Lugatlar.Update(lugat);

        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> OzluSozSil(int lugatId)
    {
        var lugat = await _dbContext.Lugatlar.Where(l => l.Id.Equals(lugatId)).FirstOrDefaultAsync();
        if (lugat is null)
        {
            throw new Exception(BussinessConstans.HerhangiBirOzluSozBulunamadi);
        }

        _dbContext.Lugatlar.Remove(lugat);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<OzluSozResponseDTO> OzluSozGetir(int kullaniciId)
    {
        var lugat = await _dbContext.Lugatlar
            .Include(l => l.Kullanici)
            .Where(l => l.KullaniciId.Equals(kullaniciId)).FirstOrDefaultAsync();

        if (lugat is null)
        {
            throw new Exception(BussinessConstans.HerhangiBirOzluSozBulunamadi);
        }

        OzluSozResponseDTO responseDto = new OzluSozResponseDTO();
        responseDto.OzluSoz = lugat.OzluSoz;
        responseDto.KullaniciId = lugat.KullaniciId;
        responseDto.LugatId = lugat.Id;
        responseDto.KullaniciAdiSoyadi = lugat.Kullanici.Ad + " " + lugat.Kullanici.Soyad;

        return responseDto;
    }

    public async Task<List<OzluSozResponseDTO>> OzluSozleriListele()
    {
        List<OzluSozResponseDTO> lugatListesi = new List<OzluSozResponseDTO>();

        var lugatlar = await _dbContext.Lugatlar
            .Include(l => l.Kullanici)
            .ToListAsync();

        foreach (var soz in lugatlar)
        {
            OzluSozResponseDTO ozluSozResponseDTO = new OzluSozResponseDTO();
            ozluSozResponseDTO.OzluSoz = soz.OzluSoz;
            ozluSozResponseDTO.KullaniciId = soz.KullaniciId;
            ozluSozResponseDTO.LugatId = soz.Id;
            ozluSozResponseDTO.KullaniciAdiSoyadi = soz.Kullanici.Ad + " " + soz.Kullanici.Soyad;
            
            lugatListesi.Add(ozluSozResponseDTO);
        }

        return lugatListesi;
    }
}