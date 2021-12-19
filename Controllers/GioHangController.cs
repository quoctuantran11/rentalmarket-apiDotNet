using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GioHangController : ControllerBase
{
    private readonly GioHangService _GioHangService;

    public GioHangController(GioHangService GioHangService) =>
        _GioHangService = GioHangService;

    [HttpGet]
    public async Task<List<GioHang>> Get() =>
        await _GioHangService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<GioHang>> Get(string id)
    {
        var GioHang = await _GioHangService.GetAsync(id);

        if (GioHang is null)
        {
            return NotFound();
        }

        return GioHang;
    }

    [HttpPost]
    public async Task<IActionResult> Post(GioHang newGioHang)
    {
        await _GioHangService.CreateAsync(newGioHang);

        return CreatedAtAction(nameof(Get), new { id = newGioHang.Id }, newGioHang);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, GioHang updatedGioHang)
    {
        var GioHang = await _GioHangService.GetAsync(id);

        if (GioHang is null)
        {
            return NotFound();
        }

        updatedGioHang.Id = GioHang.Id;

        await _GioHangService.UpdateAsync(id, updatedGioHang);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var GioHang = await _GioHangService.GetAsync(id);

        if (GioHang is null)
        {
            return NotFound();
        }

        await _GioHangService.RemoveAsync(GioHang.Id);

        return NoContent();
    }
}