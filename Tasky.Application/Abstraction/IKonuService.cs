using Tasky.Application.DTOs;

namespace Tasky.Application.Abstraction;

public interface IKonuService
{
    Task<bool> KonuEkle(string konuAd);
    Task<bool> KonuSil(int konuId);
    Task<bool> KonuGuncelle(int konuId ,string konuAd);
    Task<List<KonuResponseDTO>> KonulariListele();
    Task<KonuResponseDTO> KonuGetirIdyeGore(int konuId);
}