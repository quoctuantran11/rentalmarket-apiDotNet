using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CuaHangController : ControllerBase
{
    private readonly CuaHangService _CuaHangService;

    public CuaHangController(CuaHangService cuaHangService) =>
        _CuaHangService = cuaHangService;

    [HttpGet]
    public async Task<List<CuaHang>> Get() =>
        await _CuaHangService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<CuaHang>> Get(string id)
    {
        var CuaHang = await _CuaHangService.GetAsync(id);

        if (CuaHang is null)
        {
            return NotFound();
        }

        return CuaHang;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CuaHang newCuaHang)
    {
        await _CuaHangService.CreateAsync(newCuaHang);

        return CreatedAtAction(nameof(Get), new { id = newCuaHang.Id }, newCuaHang);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, CuaHang updatedCuaHang)
    {
        var CuaHang = await _CuaHangService.GetAsync(id);

        if (CuaHang is null)
        {
            return NotFound();
        }

        updatedCuaHang.Id = CuaHang.Id;

        await _CuaHangService.UpdateAsync(id, updatedCuaHang);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var CuaHang = await _CuaHangService.GetAsync(id);

        if (CuaHang is null)
        {
            return NotFound();
        }

        await _CuaHangService.RemoveAsync(CuaHang.Id);

        return NoContent();
    }
}