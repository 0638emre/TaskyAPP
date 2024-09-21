using Microsoft.AspNetCore.Mvc;
using Tasky.Application.Abstraction;
using Tasky.Application.DTOs;
using Tasky.Entities.Models;

namespace Tasky.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskyController : ControllerBase
{
    private readonly IKullaniciService _kullaniciService;

    public TaskyController(IKullaniciService kullaniciService)
    {
        _kullaniciService = kullaniciService;
    }
    
    [HttpPost(Name = "KullaniciEkle")]
    public async Task<IActionResult> KullaniciEkle(KullaniciOlusturRequestDTO request)
    {
        var result =  await _kullaniciService.KullaniciOlustur(request);
        
        return Ok(result);
    }
}