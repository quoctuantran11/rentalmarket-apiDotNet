using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatHangController : ControllerBase
{
    private readonly MatHangService _matHangService;

    public MatHangController(MatHangService matHangService) =>
        _matHangService = matHangService;

    [HttpGet]
    public async Task<List<MatHang>> Get() =>
        await _matHangService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<MatHang>> Get(string id)
    {
        var matHang = await _matHangService.GetAsync(id);

        if (matHang is null)
        {
            return NotFound();
        }

        return matHang;
    }

    [HttpPost]
    public async Task<IActionResult> Post(MatHang newMatHang)
    {
        await _matHangService.CreateAsync(newMatHang);

        return CreatedAtAction(nameof(Get), new { id = newMatHang.Id }, newMatHang);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, MatHang updatedMatHang)
    {
        var matHang = await _matHangService.GetAsync(id);

        if (matHang is null)
        {
            return NotFound();
        }

        updatedMatHang.Id = matHang.Id;

        await _matHangService.UpdateAsync(id, updatedMatHang);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var matHang = await _matHangService.GetAsync(id);

        if (matHang is null)
        {
            return NotFound();
        }

        await _matHangService.RemoveAsync(matHang.Id);

        return NoContent();
    }
}