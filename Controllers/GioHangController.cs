using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;
[ApiController]
[Route("api/[controller]")]
public class GioHangController : ControllerBase
{
    private readonly GioHangService _gioHangService;

    public GioHangController(GioHangService gioHangService) =>
        _gioHangService = gioHangService;

    [HttpGet]
    public async Task<List<GioHang>> Get() =>
        await _gioHangService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<GioHang>> Get(string id)
    {
        var gioHang = await _gioHangService.GetAsync(id);

        if (gioHang is null)
        {
            return NotFound();
        }

        return gioHang;
    }

    [HttpPost]
    public async Task<IActionResult> Post(GioHang newGioHang)
    {
        await _gioHangService.CreateAsync(newGioHang);

        return CreatedAtAction(nameof(Get), new { id = newGioHang.Id }, newGioHang);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, GioHang updatedGioHang)
    {
        var gioHang = await _gioHangService.GetAsync(id);

        if (gioHang is null)
        {
            return NotFound();
        }

        updatedGioHang.Id = gioHang.Id;
        await _gioHangService.UpdateAsync(id, updatedGioHang);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var gioHang = await _gioHangService.GetAsync(id);

        if (gioHang is null)
        {
            return NotFound();
        }

        await _gioHangService.RemoveAsync(gioHang.Id);

        return NoContent();
    }
}