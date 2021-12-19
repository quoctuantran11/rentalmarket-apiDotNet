using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChiTietDonHang_ComboController : ControllerBase
{
    private readonly ChiTietDonHang_ComboService _ChiTietDonHang_ComboService;

    public ChiTietDonHang_ComboController(ChiTietDonHang_ComboService ChiTietDonHang_ComboService) =>
        _ChiTietDonHang_ComboService = ChiTietDonHang_ComboService;

    [HttpGet]
    public async Task<List<ChiTietDonHang_Combo>> Get() =>
        await _ChiTietDonHang_ComboService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ChiTietDonHang_Combo>> Get(string id)
    {
        var ChiTietDonHang_Combo = await _ChiTietDonHang_ComboService.GetAsync(id);

        if (ChiTietDonHang_Combo is null)
        {
            return NotFound();
        }

        return ChiTietDonHang_Combo;
    }

    [HttpPost]
    public async Task<IActionResult> Post(ChiTietDonHang_Combo newChiTietDonHang_Combo)
    {
        await _ChiTietDonHang_ComboService.CreateAsync(newChiTietDonHang_Combo);

        return CreatedAtAction(nameof(Get), new { id = newChiTietDonHang_Combo.Id }, newChiTietDonHang_Combo);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, ChiTietDonHang_Combo updatedChiTietDonHang_Combo)
    {
        var ChiTietDonHang_Combo = await _ChiTietDonHang_ComboService.GetAsync(id);

        if (ChiTietDonHang_Combo is null)
        {
            return NotFound();
        }

        updatedChiTietDonHang_Combo.Id = ChiTietDonHang_Combo.Id;

        await _ChiTietDonHang_ComboService.UpdateAsync(id, updatedChiTietDonHang_Combo);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var ChiTietDonHang_Combo = await _ChiTietDonHang_ComboService.GetAsync(id);

        if (ChiTietDonHang_Combo is null)
        {
            return NotFound();
        }

        await _ChiTietDonHang_ComboService.RemoveAsync(ChiTietDonHang_Combo.Id);

        return NoContent();
    }
}