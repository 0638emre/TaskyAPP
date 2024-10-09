using Microsoft.AspNetCore.Mvc;
using Tasky.Application.Abstraction;
using Tasky.Application.Concrete;
using Tasky.Application.DTOs;

namespace Tasky.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class IletisimController : ControllerBase
    {
        private readonly IIletisimService _iletisimService;

        public IletisimController(IIletisimService iletisimService)
        {
          _iletisimService = iletisimService ;     
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> IletisimBilgiEkle(IletisimEkleRequestDTO iletisimEkleRequest)
        {
            var result = await _iletisimService.IletisimBilgiEkle(iletisimEkleRequest);

            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> IletisimBilgiGuncelle(IletisimGuncelleRequestDTO iletisimGuncelleRequest)
        {
            var result = await _iletisimService.IletisimBilgiGuncelle(iletisimGuncelleRequest);

            return Ok(result);
        }
    }
}
