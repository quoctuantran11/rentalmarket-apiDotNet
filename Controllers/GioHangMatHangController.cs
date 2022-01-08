using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;


namespace DiChoHoCS.Controllers;
[ApiController]
[Route("api/[controller]")]
public class GioHangMatHangController : ControllerBase
{
    private readonly GioHangMatHangService _GioHangMatHangService;

    public GioHangMatHangController(GioHangMatHangService GioHangMatHangService) =>
        _GioHangMatHangService = GioHangMatHangService;

    [HttpGet]
    public async Task<List<GioHang>>  Get() =>
        await _GioHangMatHangService.GetGioHangWithMatHang();
    
}