using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatHangController : ControllerBase
{
    private readonly MatHangService _MatHangService;

    public MatHangController(MatHangService MatHangService) =>
        _MatHangService = MatHangService;

    [HttpGet]
    public async Task<List<MatHang>> Get() =>
        await _MatHangService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<MatHang>> Get(string id)
    {
        var MatHang = await _MatHangService.GetAsync(id);

        if (MatHang is null)
        {
            return NotFound();
        }

        return MatHang;
    }

    [HttpPost]
    public async Task<IActionResult> Post(MatHang newMatHang)
    {
        await _MatHangService.CreateAsync(newMatHang);

        return CreatedAtAction(nameof(Get), new { id = newMatHang.Id }, newMatHang);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, MatHang updatedMatHang)
    {
        var MatHang = await _MatHangService.GetAsync(id);

        if (MatHang is null)
        {
            return NotFound();
        }

        updatedMatHang.Id = MatHang.Id;

        await _MatHangService.UpdateAsync(id, updatedMatHang);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var MatHang = await _MatHangService.GetAsync(id);

        if (MatHang is null)
        {
            return NotFound();
        }

        await _MatHangService.RemoveAsync(MatHang.Id);

        return NoContent();
    }
}