using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChiTietDonHangMatHangController : ControllerBase
{
    private readonly ChiTietDonHangMatHangService _chiTietDonHangMatHangService;

    public ChiTietDonHangMatHangController(ChiTietDonHangMatHangService chiTietDonHangMatHangService) =>
        _chiTietDonHangMatHangService = chiTietDonHangMatHangService;

    [HttpGet]
    public async Task<List<ChiTietDonHangMatHang>> Get() =>
        await _chiTietDonHangMatHangService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ChiTietDonHangMatHang>> Get(string id)
    {
        var chiTietDonHangMatHang = await _chiTietDonHangMatHangService.GetAsync(id);

        if (chiTietDonHangMatHang is null)
        {
            return NotFound();
        }

        return chiTietDonHangMatHang;
    }

    [HttpPost]
    public async Task<IActionResult> Post(ChiTietDonHangMatHang newChiTietDonHangMatHang)
    {
        await _chiTietDonHangMatHangService.CreateAsync(newChiTietDonHangMatHang);

        return CreatedAtAction(nameof(Get), new { id = newChiTietDonHangMatHang.Id }, newChiTietDonHangMatHang);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, ChiTietDonHangMatHang updatedChiTietDonHangMatHang)
    {
        var chiTietDonHangMatHang = await _chiTietDonHangMatHangService.GetAsync(id);

        if (chiTietDonHangMatHang is null)
        {
            return NotFound();
        }

        updatedChiTietDonHangMatHang.Id = chiTietDonHangMatHang.Id;

        await _chiTietDonHangMatHangService.UpdateAsync(id, updatedChiTietDonHangMatHang);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var chiTietDonHangMatHang = await _chiTietDonHangMatHangService.GetAsync(id);

        if (chiTietDonHangMatHang is null)
        {
            return NotFound();
        }

        await _chiTietDonHangMatHangService.RemoveAsync(chiTietDonHangMatHang.Id);

        return NoContent();
    }
}