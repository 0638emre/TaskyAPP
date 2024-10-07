using Microsoft.AspNetCore.Mvc;
using Tasky.Application.Abstraction;
using Tasky.Application.Concrete;

namespace Tasky.API.Controllers;

[ApiController]
[Route("[controller]")]

public class KullaniciYetkiController : ControllerBase
{
    private readonly IKullaniciYetkiService _kullaniciYetkiService;

    public KullaniciYetkiController(IKullaniciYetkiService kullaniciYetkiService)
    {
        _kullaniciYetkiService = kullaniciYetkiService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> KullaniciyaYetkiVer(int kullaniciId, int yetkiId)
    {
        var result = await _kullaniciYetkiService.KullaniciyaYetkiVer(kullaniciId, yetkiId);

        return Ok(result);
    }

}