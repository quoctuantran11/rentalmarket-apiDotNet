using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KhachHangController : ControllerBase
{
    private readonly KhachHangService _KhachHangService;

    public KhachHangController(KhachHangService KhachHangService) =>
        _KhachHangService = KhachHangService;

    [HttpGet]
    public async Task<List<KhachHang>> Get() =>
        await _KhachHangService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<KhachHang>> Get(string id)
    {
        var KhachHang = await _KhachHangService.GetAsync(id);

        if (KhachHang is null)
        {
            return NotFound();
        }

        return KhachHang;
    }

    [HttpPost]
    public async Task<IActionResult> Post(KhachHang newKhachHang)
    {
        await _KhachHangService.CreateAsync(newKhachHang);

        return CreatedAtAction(nameof(Get), new { id = newKhachHang.Id }, newKhachHang);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, KhachHang updatedKhachHang)
    {
        var KhachHang = await _KhachHangService.GetAsync(id);

        if (KhachHang is null)
        {
            return NotFound();
        }

        updatedKhachHang.Id = KhachHang.Id;

        await _KhachHangService.UpdateAsync(id, updatedKhachHang);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var KhachHang = await _KhachHangService.GetAsync(id);

        if (KhachHang is null)
        {
            return NotFound();
        }

        await _KhachHangService.RemoveAsync(KhachHang.Id);

        return NoContent();
    }
}