using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DonHangController : ControllerBase
{
    private readonly DonHangService _donHangService;

    public DonHangController(DonHangService donHangService) =>
        _donHangService = donHangService;

    [HttpGet]
    public async Task<List<DonHang>> Get() =>
        await _donHangService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<DonHang>> Get(string id)
    {
        var donHang = await _donHangService.GetAsync(id);

        if (donHang is null)
        {
            return NotFound();
        }

        return donHang;
    }

    [HttpPost]
    public async Task<IActionResult> Post(DonHang newDonHang)
    {
        await _donHangService.CreateAsync(newDonHang);

        return CreatedAtAction(nameof(Get), new { id = newDonHang.Id }, newDonHang);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, DonHang updatedDonHang)
    {
        var donHang = await _donHangService.GetAsync(id);

        if (donHang is null)
        {
            return NotFound();
        }

        updatedDonHang.Id = donHang.Id;
        await _donHangService.UpdateAsync(id, updatedDonHang);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var donHang = await _donHangService.GetAsync(id);

        if (donHang is null)
        {
            return NotFound();
        }

        await _donHangService.RemoveAsync(donHang.Id);

        return NoContent();
    }
}