using Microsoft.EntityFrameworkCore;
using Tasky.Application.Abstraction;
using Tasky.Application.Constans;
using Tasky.Application.DTOs;
using Tasky.DAL.Context;
using Tasky.Entities.Models;

namespace Tasky.Application.Concrete;

public class KonuService : IKonuService
{
    private readonly TaskDBContext _dbContext;

    public KonuService(TaskDBContext context)
    {
        _dbContext = context;
    }
    
    public async Task<bool> KonuEkle(string konuAd)
    {
        //VALİDATION dan geçirmem lazım.
        var konu = await _dbContext.Konular.Where(k => k.KonuAdi.Equals(konuAd)).FirstOrDefaultAsync();

        if (konu is not null)
        {
            throw new Exception("Konu zaten daha önce eklenmiş. Başka bir konu ekleyiniz.");
        }
        
        var result = await _dbContext.Konular.AddAsync(new Konu()
        {
            KonuAdi = konuAd
        });

        if (result is null)
        {
            throw new Exception("Konu eklenemedi");
        }
        
        await _dbContext.SaveChangesAsync();

        return true; 
    }

    public async Task<bool> KonuSil(int konuId)
    {
        var konu = await _dbContext.Konular.Where(k => k.Id.Equals(konuId)).FirstOrDefaultAsync();

        if (konu is null)
        {
            throw new Exception(BussinessConstans.KonuBulunamadi);
        }

        _dbContext.Konular.Remove(konu);
        
        await _dbContext.SaveChangesAsync(); 
        
        return true;
    }

    public async Task<bool> KonuGuncelle(int konuId, string konuAd)
    {
        var konu = await _dbContext.Konular.Where(k => k.Id.Equals(konuId)).FirstOrDefaultAsync();
        
        if (konu is null)
        {
            throw new Exception(BussinessConstans.KonuBulunamadi);
        }
        
        konu.KonuAdi = konuAd;
        
        _dbContext.Konular.Update(konu);
        
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<KonuResponseDTO>> KonulariListele()
    {
        List<KonuResponseDTO> konulariListele = new List<KonuResponseDTO>();
        
        var konularListesi = await _dbContext.Konular.ToListAsync();

        if (konularListesi.Count < 1)
        {
            throw new Exception(BussinessConstans.KonuBulunamadi); 
        }

        foreach (var kk in konularListesi)
        {
            KonuResponseDTO konuResponseDto = new KonuResponseDTO();
            konuResponseDto.KonuId = kk.Id;
            konuResponseDto.KonuAdi = kk.KonuAdi;
            
            konulariListele.Add(konuResponseDto);
        }

        return konulariListele;

    }

    public async Task<KonuResponseDTO> KonuGetirIdyeGore(int konuId)
    {
        KonuResponseDTO konuResponseDto = new KonuResponseDTO();
        
        var konu = await _dbContext.Konular.Where(k => k.Id.Equals(konuId)).FirstOrDefaultAsync();
        
        if (konu is null)
        {
            throw new Exception(BussinessConstans.KonuBulunamadi);
        }

        konuResponseDto.KonuId = konu.Id;
        konuResponseDto.KonuAdi = konu.KonuAdi;

        return konuResponseDto;
    }
}