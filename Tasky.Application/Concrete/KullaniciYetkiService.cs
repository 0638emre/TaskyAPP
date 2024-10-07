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
            var yetkiVer = await _dbContext.Yetkiler.Where(k => k.Id.Equals(yetkiId)).AnyAsync();

            if (!yetkiVer) 
            {
                throw new Exception("Yetki bulunamadı!");
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
                throw new ApplicationException("Kullanıcıya yetki eklenemedi!");
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public Task<YetkiGetirResponseDTO> YetkiGetirKullaniciIdyeGore(int kullaniciId)
        {
            throw new NotImplementedException();
        }

        public Task<List<KullaniciYetkiGetirResponseDTO>> KullanicilarinYetkiListesi()
        {
            throw new NotImplementedException();
        }
    }
}
