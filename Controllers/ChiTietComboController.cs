using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ChiTietComboController : ControllerBase
{
    private readonly ChiTietComboService _chiTietComboService;

    public ChiTietComboController(ChiTietComboService chiTietComboService) =>
        _chiTietComboService = chiTietComboService;

    [HttpGet]
    public async Task<List<ChiTietCombo>> Get() =>
        await _chiTietComboService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ChiTietCombo>> Get(string id)
    {
        var chiTietCombo = await _chiTietComboService.GetAsync(id);

        if (chiTietCombo is null)
        {
            return NotFound();
        }

        return chiTietCombo;
    }

    [HttpPost]
    public async Task<IActionResult> Post(ChiTietCombo newChiTietCombo)
    {
        await _chiTietComboService.CreateAsync(newChiTietCombo);

        return CreatedAtAction(nameof(Get), new { id = newChiTietCombo.Id }, newChiTietCombo);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, ChiTietCombo updatedChiTietCombo)
    {
        var chiTietCombo = await _chiTietComboService.GetAsync(id);

        if (chiTietCombo is null)
        {
            return NotFound();
        }

        updatedChiTietCombo.Id = chiTietCombo.Id;
        await _chiTietComboService.UpdateAsync(id, updatedChiTietCombo);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var chiTietCombo = await _chiTietComboService.GetAsync(id);

        if (chiTietCombo is null)
        {
            return NotFound();
        }

        await _chiTietComboService.RemoveAsync(chiTietCombo.Id);

        return NoContent();
    }
}