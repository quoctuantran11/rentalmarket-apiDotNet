using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComboMatHangController : ControllerBase
{
    private readonly ComboMatHangService _comboMatHangService;

    public ComboMatHangController(ComboMatHangService cbMatHangService) =>
        _comboMatHangService = cbMatHangService;

    [HttpGet]
    public async Task<List<ComboMatHang>> Get() =>
        await _comboMatHangService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ComboMatHang>> Get(string id)
    {
        var cbmathang = await _comboMatHangService.GetAsync(id);

        if (cbmathang is null)
        {
            return NotFound();
        }

        return cbmathang;
    }

    [HttpPost]
    public async Task<IActionResult> Post(ComboMatHang newCBMatHang)
    {
        await _comboMatHangService.CreateAsync(newCBMatHang);

        return CreatedAtAction(nameof(Get), new { id = newCBMatHang.Id }, newCBMatHang);
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
        var cbMatHang = await _comboMatHangService.GetAsync(id);

        if (cbMatHang is null)
        {
            return NotFound();
        }

        await _comboMatHangService.RemoveAsync(cbMatHang.Id);

        return NoContent();
    }
}