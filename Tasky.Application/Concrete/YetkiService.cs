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
    public class YetkiService : IYetkiService
    {
        private readonly TaskDBContext _dbContext;

        public YetkiService(TaskDBContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> YetkiEkle(string yetkiAdi)
        {
            var yetki = await _dbContext.Yetkiler.Where(k => k.YetkiAdi.Equals(yetkiAdi)).FirstOrDefaultAsync();

            if (yetki is not null)
            {
                throw new Exception("Yetki ekleme işlemi zaten yapılmış. Başka bir yetki ekleyiniz");
            }

            var result = await _dbContext.Yetkiler.AddAsync(new Yetki()
            {
                YetkiAdi = yetkiAdi
            });

            if (result is null)
            {
                throw new Exception("Yetki eklenemedi");
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<YetkiGetirResponseDTO> YetkiGetirIdyeGore(int yetkiId)
        {
            YetkiGetirResponseDTO yetkiResponseDto = new YetkiGetirResponseDTO();

            var yetki = await _dbContext.Yetkiler.Where(k => k.Id.Equals(yetkiId)).FirstOrDefaultAsync();

            if (yetki is null)
            {
                throw new Exception("Herhangi bir yetki bulunamadı.");
            }

            yetkiResponseDto.YetkiId = yetki.Id;
            yetkiResponseDto.YetkiAdi = yetki.YetkiAdi;

            return yetkiResponseDto;

        }

        public async Task<bool> YetkiGuncelle(int yetkiId, string yetkiAdi)
        {
            var yetki = await _dbContext.Yetkiler.Where(k => k.Id.Equals(yetkiId)).FirstOrDefaultAsync();

            if (yetki is null)
            {
                throw new Exception("Herhangi bir yetki bulunamadı.");
            }

            yetki.YetkiAdi = yetkiAdi;

            _dbContext.Yetkiler.Update(yetki);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<YetkiGetirResponseDTO>> YetkileriListele()
        {
            List<YetkiGetirResponseDTO> yetkileriListele = new List<YetkiGetirResponseDTO>();

            var yetkiListesi = await _dbContext.Yetkiler.ToListAsync();

            if (yetkiListesi.Count < 1)
            {
                throw new Exception("Yetkiler Listelenemedi");
            }

            foreach (var yl in yetkiListesi)
            {
                YetkiGetirResponseDTO YetkiGetirResponseDTO = new YetkiGetirResponseDTO();

                YetkiGetirResponseDTO.YetkiId = yl.Id;
                YetkiGetirResponseDTO.YetkiAdi = yl.YetkiAdi;

                yetkileriListele.Add(YetkiGetirResponseDTO);
            }

          return yetkileriListele;

        }

        public async Task<bool> YetkiSil(int yetkiId)
        {
            var yetki = await _dbContext.Yetkiler.Where(k => k.Id == yetkiId).FirstOrDefaultAsync();//EQUALS VE == HATA VERMİŞTİ. ÇALIŞIYOR

            if (yetki is null)
            {
                throw new Exception("Yetki Silinemedi");
            }

           _dbContext.Yetkiler.Remove(yetki);

            await _dbContext.SaveChangesAsync();

            return true;  
        }
    }
}
