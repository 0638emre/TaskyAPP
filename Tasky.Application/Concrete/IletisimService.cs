using Microsoft.EntityFrameworkCore;
using Tasky.Application.Abstraction;
using Tasky.Application.Constans;
using Tasky.Application.DTOs;
using Tasky.DAL.Context;
using Tasky.Entities.Models;

namespace Tasky.Application.Concrete
{
    public class IletisimService : IIletisimService
    {
        private readonly TaskDBContext _dbContext;

        public IletisimService(TaskDBContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> IletisimBilgiEkle(IletisimEkleRequestDTO iletisimEkleRequest)
        {
            var kullanici = await _dbContext.Kullanicilar.Where(k => k.Id.Equals(iletisimEkleRequest.KullaniciId)).FirstOrDefaultAsync();

            if (kullanici is null)
            {
                throw new Exception(BussinessConstans.KullaniciBulunamadi);
            }

            Iletisim iletisim = new Iletisim()
            {
                EvAdres = iletisimEkleRequest.EvAdres,
                KullaniciId = iletisimEkleRequest.KullaniciId,
                IsAdres = iletisimEkleRequest.IsAdres,
                PostaKodu = iletisimEkleRequest.PostaKodu,
                KanGrubu = iletisimEkleRequest.KanGrubu,
                Il = iletisimEkleRequest.Il,
                Ilce = iletisimEkleRequest.Ilce,
                Memleket = iletisimEkleRequest.Memleket,
                AracPlaka = iletisimEkleRequest.AracPlaka
            };

            var result = await _dbContext.Iletisimler.AddAsync(iletisim);


            if (result is null)
            {
                throw new Exception(BussinessConstans.IletisimBilgileriBulunamadi);
            }

            await _dbContext.SaveChangesAsync();

            return true;

        }

        public async Task<bool> IletisimBilgiGuncelle(IletisimGuncelleRequestDTO iletisimGuncelleRequest)
        {
            //throw new NotImplementedException();
            var iletisim = await _dbContext.Iletisimler.Where(i => i.Id == iletisimGuncelleRequest.Id).FirstOrDefaultAsync();

            if (iletisim is null)
            {
                throw new Exception(BussinessConstans.KullaniciBulunamadi);
            }

            iletisim.Id = iletisimGuncelleRequest.Id;
            iletisim.KullaniciId = iletisimGuncelleRequest.KullaniciId;
            iletisim.EvAdres = iletisimGuncelleRequest.EvAdres;
            iletisim.IsAdres = iletisimGuncelleRequest.IsAdres;
            iletisim.PostaKodu = iletisimGuncelleRequest.PostaKodu;
            iletisim.KanGrubu = iletisimGuncelleRequest.KanGrubu;
            iletisim.Il = iletisimGuncelleRequest.Il;
            iletisim.Ilce = iletisimGuncelleRequest.Ilce;
            iletisim.Memleket = iletisimGuncelleRequest.Memleket;
            iletisim.AracPlaka = iletisimGuncelleRequest.AracPlaka;

            _dbContext.Iletisimler.Update(iletisim);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<IletisimResponseDTO>> IletisimBilgiListele()
        {
            List<IletisimResponseDTO> iletisimListesi = new List<IletisimResponseDTO>();

            var dbdenDonenIletisimler = await _dbContext.Iletisimler.ToListAsync();

            foreach (var k in dbdenDonenIletisimler)
            {
                IletisimResponseDTO iletisimResponse = new IletisimResponseDTO();

                iletisimResponse.Id = k.Id;
                iletisimResponse.KullaniciId = k.KullaniciId;
                iletisimResponse.KanGrubu = k.KanGrubu;
                iletisimResponse.AracPlaka = k.AracPlaka;
                iletisimResponse.Il = k.Il;
                iletisimResponse.Ilce = k.Ilce;
                iletisimResponse.EvAdres = k.EvAdres;
                iletisimResponse.IsAdres = k.IsAdres;


                iletisimListesi.Add(iletisimResponse);
            }

            return iletisimListesi;
        }

        public async Task<bool> IletisimBilgiSil(int Id)
        {
            //throw new NotImplementedException();
            var iletisim = await _dbContext.Iletisimler.Where(k => k.Id.Equals(Id)).FirstOrDefaultAsync();

            if (iletisim is null)
            {
                throw new Exception(BussinessConstans.IletisimBilgileriBulunamadi);
            }

            _dbContext.Iletisimler.Remove(iletisim);

            await _dbContext.SaveChangesAsync();

            return true;

        }
    }
}