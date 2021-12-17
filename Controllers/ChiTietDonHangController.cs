using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChiTietDonHangController : ControllerBase
{
    private readonly ChiTietDonHangService _ChiTietDonHangService;

    public ChiTietDonHangController(ChiTietDonHangService ChiTietDonHangService) =>
        _ChiTietDonHangService = ChiTietDonHangService;

    [HttpGet]
    public async Task<List<ChiTietDonHang>> Get() =>
        await _ChiTietDonHangService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ChiTietDonHang>> Get(string id)
    {
        var ChiTietDonHang = await _ChiTietDonHangService.GetAsync(id);

        if (ChiTietDonHang is null)
        {
            return NotFound();
        }

        return ChiTietDonHang;
    }

    [HttpPost]
    public async Task<IActionResult> Post(ChiTietDonHang newChiTietDonHang)
    {
        await _ChiTietDonHangService.CreateAsync(newChiTietDonHang);

        return CreatedAtAction(nameof(Get), new { id = newChiTietDonHang.Id }, newChiTietDonHang);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, ChiTietDonHang updatedChiTietDonHang)
    {
        var ChiTietDonHang = await _ChiTietDonHangService.GetAsync(id);

        if (ChiTietDonHang is null)
        {
            return NotFound();
        }

        updatedChiTietDonHang.Id = ChiTietDonHang.Id;

        await _ChiTietDonHangService.UpdateAsync(id, updatedChiTietDonHang);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var ChiTietDonHang = await _ChiTietDonHangService.GetAsync(id);

        if (ChiTietDonHang is null)
        {
            return NotFound();
        }

        await _ChiTietDonHangService.RemoveAsync(ChiTietDonHang.Id);

        return NoContent();
    }
}