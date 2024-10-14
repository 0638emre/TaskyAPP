using Microsoft.AspNetCore.Mvc;
using Tasky.Application.Abstraction;
using Tasky.Application.Concrete;
using Tasky.Application.DTOs;

namespace Tasky.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class KategoriController : ControllerBase
    {
        private readonly IKategoriService _kategoriService;

        public KategoriController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> KategoriEkle(string kategoriAdi)
        {
            var result = await _kategoriService.KategoriEkle(kategoriAdi);

            return Ok(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> KategoriSil(int kategoriId)
        {
            var result = await _kategoriService.KategoriSil(kategoriId);

            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> KategoriGetirIdyeGore(int kategoriId)
        {
            var result = await _kategoriService.KategoriGetirIdyeGore(kategoriId);

            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> KateegoriGuncelle(int kategoriId, string kategoriAdi)
        {
            var result = await _kategoriService.KategoriGuncelle(kategoriId, kategoriAdi);

            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> KategorileriListele()
        {
            var result = await _kategoriService.KategoriListele();

            return Ok(result);
        }
    }
}
