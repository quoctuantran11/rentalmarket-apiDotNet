using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChiTietComboController : ControllerBase
{
    private readonly ChiTietComboService _ChiTietComboService;

    public ChiTietComboController(ChiTietComboService ChiTietComboService) =>
        _ChiTietComboService = ChiTietComboService;

    [HttpGet]
    public async Task<List<ChiTietCombo>> Get() =>
        await _ChiTietComboService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ChiTietCombo>> Get(string id)
    {
        var ChiTietCombo = await _ChiTietComboService.GetAsync(id);

        if (ChiTietCombo is null)
        {
            return NotFound();
        }

        return ChiTietCombo;
    }

    [HttpPost]
    public async Task<IActionResult> Post(ChiTietCombo newChiTietCombo)
    {
        await _ChiTietComboService.CreateAsync(newChiTietCombo);

        return CreatedAtAction(nameof(Get), new { id = newChiTietCombo.Id }, newChiTietCombo);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, ChiTietCombo updatedChiTietCombo)
    {
        var ChiTietCombo = await _ChiTietComboService.GetAsync(id);

        if (ChiTietCombo is null)
        {
            return NotFound();
        }

        updatedChiTietCombo.Id = ChiTietCombo.Id;

        await _ChiTietComboService.UpdateAsync(id, updatedChiTietCombo);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var ChiTietCombo = await _ChiTietComboService.GetAsync(id);

        if (ChiTietCombo is null)
        {
            return NotFound();
        }

        await _ChiTietComboService.RemoveAsync(ChiTietCombo.Id);

        return NoContent();
    }
}