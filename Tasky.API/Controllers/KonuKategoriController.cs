using Microsoft.AspNetCore.Mvc;
using Tasky.Application.Abstraction;
using Tasky.Application.Concrete;
using Tasky.Application.DTOs;

namespace Tasky.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class KonuKategoriController : ControllerBase
    {
        private readonly IKonuKategoriService _konuKategoriService;

        public KonuKategoriController(IKonuKategoriService konuKategoriService)
        {
            _konuKategoriService = konuKategoriService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> KategoriyeKonuEkle(int konuId, int kategoriId)
        {
            var result = await _konuKategoriService.KategoriyeKonuEkle(kategoriId, konuId);

            return Ok(result);
        }
        

        [HttpGet("[action]")]
        public async Task<IActionResult> KategoriyeGoreKonulariListele(int kategoriId)
        {
            var result = await _konuKategoriService.KonuKategoriGetirIdyeGore(kategoriId);

            return Ok(result);
        }


    }
}
