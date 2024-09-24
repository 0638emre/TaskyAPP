using Tasky.Application.Abstraction;
using Tasky.Application.DTOs;
using Tasky.DAL.Context;

namespace Tasky.Application.Concrete;

public class KonuService : IKonuService
{
    private readonly TaskDBContext _dbContext;

    public KonuService(TaskDBContext context)
    {
        _dbContext = context;
    }
    
    public Task<bool> KonuEkle(string konuAd)
    {
        throw new NotImplementedException();
    }

    public Task<bool> KonuSil(int konuId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> KonuGuncelle(int konuId, string konuAd)
    {
        throw new NotImplementedException();
    }

    public Task<List<KonuResponseDTO>> KonulariListele()
    {
        throw new NotImplementedException();
    }

    public Task<KonuResponseDTO> KonuGetirIdyeGore(int konuId)
    {
        throw new NotImplementedException();
    }
}