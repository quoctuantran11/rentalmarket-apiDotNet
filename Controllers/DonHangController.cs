using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DonHangController : ControllerBase
{
    private readonly DonHangService _DonHangService;

    public DonHangController(DonHangService DonHangService) =>
        _DonHangService = DonHangService;

    [HttpGet]
    public async Task<List<DonHang>> Get() =>
        await _DonHangService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<DonHang>> Get(string id)
    {
        var DonHang = await _DonHangService.GetAsync(id);

        if (DonHang is null)
        {
            return NotFound();
        }

        return DonHang;
    }

    [HttpPost]
    public async Task<IActionResult> Post(DonHang newDonHang)
    {
        await _DonHangService.CreateAsync(newDonHang);

        return CreatedAtAction(nameof(Get), new { id = newDonHang.Id }, newDonHang);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, DonHang updatedDonHang)
    {
        var DonHang = await _DonHangService.GetAsync(id);

        if (DonHang is null)
        {
            return NotFound();
        }

        updatedDonHang.Id = DonHang.Id;

        await _DonHangService.UpdateAsync(id, updatedDonHang);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var DonHang = await _DonHangService.GetAsync(id);

        if (DonHang is null)
        {
            return NotFound();
        }

        await _DonHangService.RemoveAsync(DonHang.Id);

        return NoContent();
    }
}