using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChiTietDonHangComboController : ControllerBase
{
    private readonly ChiTietDonHangComboService _chiTietDonHangComboService;

    public ChiTietDonHangComboController(ChiTietDonHangComboService ChiTietDonHangComboService) =>
        _chiTietDonHangComboService = ChiTietDonHangComboService;

    [HttpGet]
    public async Task<List<ChiTietDonHangCombo>> Get() =>
        await _chiTietDonHangComboService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ChiTietDonHangCombo>> Get(string id)
    {
        var ChiTietDonHangCombo = await _chiTietDonHangComboService.GetAsync(id);

        if (ChiTietDonHangCombo is null)
        {
            return NotFound();
        }

        return ChiTietDonHangCombo;
    }

    [HttpPost]
    public async Task<IActionResult> Post(ChiTietDonHangCombo newChiTietDonHangCombo)
    {
        await _chiTietDonHangComboService.CreateAsync(newChiTietDonHangCombo);

        return CreatedAtAction(nameof(Get), new { id = newChiTietDonHangCombo.Id }, newChiTietDonHangCombo);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, ChiTietDonHangCombo updatedChiTietDonHangCombo)
    {
        var ChiTietDonHangCombo = await _chiTietDonHangComboService.GetAsync(id);

        if (ChiTietDonHangCombo is null)
        {
            return NotFound();
        }

        updatedChiTietDonHangCombo.Id = ChiTietDonHangCombo.Id;

        await _chiTietDonHangComboService.UpdateAsync(id, updatedChiTietDonHangCombo);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var ChiTietDonHangCombo = await _chiTietDonHangComboService.GetAsync(id);

        if (ChiTietDonHangCombo is null)
        {
            return NotFound();
        }

        await _chiTietDonHangComboService.RemoveAsync(ChiTietDonHangCombo.Id);

        return NoContent();
    }
}