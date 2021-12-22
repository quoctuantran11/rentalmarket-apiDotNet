using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComboMatHangController : ControllerBase
{
    private readonly ComboMatHangService _comboMatHangService;

    public ComboMatHangController(ComboMatHangService comboMatHangService) =>
        _comboMatHangService = comboMatHangService;

    [HttpGet]
    public async Task<List<ComboMatHang>> Get() =>
        await _comboMatHangService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ComboMatHang>> Get(string id)
    {
        var comboMatHang = await _comboMatHangService.GetAsync(id);

        if (comboMatHang is null)
        {
            return NotFound();
        }

        return comboMatHang;
    }

    [HttpPost]
    public async Task<IActionResult> Post(ComboMatHang newComboMatHang)
    {
        await _comboMatHangService.CreateAsync(newComboMatHang);

        return CreatedAtAction(nameof(Get), new { id = newComboMatHang.Id }, newComboMatHang);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, ComboMatHang updatedCBMatHang)
    {
        var comboMatHang = await _comboMatHangService.GetAsync(id);

        if (comboMatHang is null)
        {
            return NotFound();
        }

        updatedCBMatHang.Id = comboMatHang.Id;

        await _comboMatHangService.UpdateAsync(id, updatedCBMatHang);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var comboMatHang = await _comboMatHangService.GetAsync(id);

        if (comboMatHang is null)
        {
            return NotFound();
        }

        await _comboMatHangService.RemoveAsync(comboMatHang.Id);

        return NoContent();
    }
}