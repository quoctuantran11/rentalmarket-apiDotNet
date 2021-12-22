using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KhachHangController : ControllerBase
{
    private readonly KhachHangService _khachHangService;

    public KhachHangController(KhachHangService khachHangService) =>
        _khachHangService = khachHangService;

    [HttpGet]
    public async Task<List<KhachHang>> Get() =>
        await _khachHangService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<KhachHang>> Get(string id)
    {
        var khachHang = await _khachHangService.GetAsync(id);

        if (khachHang is null)
        {
            return NotFound();
        }

        return khachHang;
    }

    [HttpPost]
    public async Task<IActionResult> Post(KhachHang newKhachHang)
    {
        await _khachHangService.CreateAsync(newKhachHang);

        return CreatedAtAction(nameof(Get), new { id = newKhachHang.Id }, newKhachHang);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, KhachHang updatedKhachHang)
    {
        var khachHang = await _khachHangService.GetAsync(id);

        if (khachHang is null)
        {
            return NotFound();
        }

        updatedKhachHang.Id = khachHang.Id;

        await _khachHangService.UpdateAsync(id, updatedKhachHang);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var khachHang = await _khachHangService.GetAsync(id);

        if (khachHang is null)
        {
            return NotFound();
        }

        await _khachHangService.RemoveAsync(khachHang.Id);

        return NoContent();
    }
}