using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChiTietDonHang_MatHangController : ControllerBase
{
    private readonly ChiTietDonHang_MatHangService _ChiTietDonHang_MatHangService;

    public ChiTietDonHang_MatHangController(ChiTietDonHang_MatHangService ChiTietDonHang_MatHangService) =>
        _ChiTietDonHang_MatHangService = ChiTietDonHang_MatHangService;

    [HttpGet]
    public async Task<List<ChiTietDonHang_MatHang>> Get() =>
        await _ChiTietDonHang_MatHangService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ChiTietDonHang_MatHang>> Get(string id)
    {
        var ChiTietDonHang_MatHang = await _ChiTietDonHang_MatHangService.GetAsync(id);

        if (ChiTietDonHang_MatHang is null)
        {
            return NotFound();
        }

        return ChiTietDonHang_MatHang;
    }

    [HttpPost]
    public async Task<IActionResult> Post(ChiTietDonHang_MatHang newChiTietDonHang_MatHang)
    {
        await _ChiTietDonHang_MatHangService.CreateAsync(newChiTietDonHang_MatHang);

        return CreatedAtAction(nameof(Get), new { id = newChiTietDonHang_MatHang.Id }, newChiTietDonHang_MatHang);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, ChiTietDonHang_MatHang updatedChiTietDonHang_MatHang)
    {
        var ChiTietDonHang_MatHang = await _ChiTietDonHang_MatHangService.GetAsync(id);

        if (ChiTietDonHang_MatHang is null)
        {
            return NotFound();
        }

        updatedChiTietDonHang_MatHang.Id = ChiTietDonHang_MatHang.Id;

        await _ChiTietDonHang_MatHangService.UpdateAsync(id, updatedChiTietDonHang_MatHang);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var ChiTietDonHang_MatHang = await _ChiTietDonHang_MatHangService.GetAsync(id);

        if (ChiTietDonHang_MatHang is null)
        {
            return NotFound();
        }

        await _ChiTietDonHang_MatHangService.RemoveAsync(ChiTietDonHang_MatHang.Id);

        return NoContent();
    }
}