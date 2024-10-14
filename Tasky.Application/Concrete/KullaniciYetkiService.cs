using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasky.Application.Abstraction;
using Tasky.Application.Constans;
using Tasky.Application.DTOs;
using Tasky.DAL.Context;
using Tasky.Entities.Models;

namespace Tasky.Application.Concrete
{


    public class KullaniciYetkiService : IKullaniciYetkiService
    {
        private readonly TaskDBContext _dbContext;

        public KullaniciYetkiService(TaskDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> KullaniciyaYetkiVer(int kullaniciId, int yetkiId)
        {
            var yetkiVer = await _dbContext.Yetkiler.Where(y => y.Id.Equals(yetkiId)).AnyAsync();

            if (!yetkiVer)
            {
                throw new Exception(BussinessConstans.YetkiBulunamadi);
            }

            var kullaniciKontrol = await _dbContext.Kullanicilar.Where(k => k.Id.Equals(kullaniciId)).AnyAsync();

            if (!kullaniciKontrol)
            {
                throw new ApplicationException(BussinessConstans.KullaniciBulunamadi);
            }

            KullaniciYetki kullaniciYetki = new()
            {
                KayitTarihi = DateTime.Now,
                YetkiId = yetkiId,
                KullaniciId = kullaniciId,
            };

            var result = await _dbContext.KullaniciYetkiler.AddAsync(kullaniciYetki);

            if (result is null)
            {
                throw new ApplicationException(BussinessConstans.YetkiEklenemedi);
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<KullaniciYetkiGetirResponseDTO>> KullanicilarinYetkiListesi()
        {
            //throw new NotImplementedException();

            var datas = await _dbContext.KullaniciYetkiler
            .Include(k => k.Yetki)
            .Include(k => k.Kullanici)
            .OrderBy(k => k.Id).ToListAsync();

            List<KullaniciYetkiGetirResponseDTO> yetkiGetirList = new();

            foreach (var yetki in datas)
            {
                KullaniciYetkiGetirResponseDTO yetkiGetirResponseDto = new();
                yetkiGetirResponseDto.Id = yetki.Id;
                yetkiGetirResponseDto.KullaniciId = yetki.KullaniciId;
                yetkiGetirResponseDto.YetkiId = yetki.YetkiId;
                yetkiGetirResponseDto.YetkiAdi = yetki.Yetki.YetkiAdi;
                yetkiGetirResponseDto.YetkiTarihi = yetki.KayitTarihi;
                yetkiGetirResponseDto.KullaniciAdSoyad = yetki.Kullanici.Ad + " " + yetki.Kullanici.Soyad;

                yetkiGetirList.Add(yetkiGetirResponseDto);
            }

            return yetkiGetirList;


        }

        public async Task<KullaniciYetkiGetirResponseDTO> YetkiGetirKullaniciIdyeGore(int kullaniciId)
        {
            var kullanici = await _dbContext.Kullanicilar.Where(k => k.Id == kullaniciId).FirstOrDefaultAsync();
            if (kullanici is null)
            {
                throw new Exception(BussinessConstans.KullaniciBulunamadi);
            }

            var result = await _dbContext.KullaniciYetkiler.Include(k => k.Yetki)
              .Include(k => k.Kullanici).Where(k => k.KullaniciId == kullaniciId).FirstOrDefaultAsync();

            if (result is null)
            {
                throw new Exception(BussinessConstans.KullaniciyaAitYetkiBulunamadi);
            }

            KullaniciYetkiGetirResponseDTO response = new();
            response.Id = result.Id;
            response.YetkiId = result.YetkiId;
            response.KullaniciId = result.KullaniciId;
            response.YetkiAdi = result.Yetki.YetkiAdi;
            response.YetkiTarihi = result.KayitTarihi;
            response.KullaniciAdSoyad = result.Kullanici.Ad + " " + result.Kullanici.Soyad;

            return response;
        }
    }
}
