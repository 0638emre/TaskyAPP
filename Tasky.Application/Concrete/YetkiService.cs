using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasky.Application.Abstraction;
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
            throw new NotImplementedException();
            //var yetki = await _dbContext.Yetkiler.Where(k => k.YetkiAdi.Equals(yetkiAdi)).FirstOrDefaultAsync();


        }

        public Task<YetkiGetirResponseDTO> YetkiGetirIdyeGore(int yetkiId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> YetkiGuncelle(int yetkiId, string yetkiAdi)
        {
            throw new NotImplementedException();
        }

        public Task<List<YetkiGetirResponseDTO>> YetkileriListele()
        {
            throw new NotImplementedException();
        }

        public Task<bool> YetkiSil(int yetkiId)
        {
            throw new NotImplementedException();
        }
    }
}
