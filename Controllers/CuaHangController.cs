using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CuaHangController : ControllerBase
{
    private readonly CuaHangService _cuaHangService;

    public CuaHangController(CuaHangService cuaHangService) =>
        _cuaHangService = cuaHangService;

    [HttpGet]
    public async Task<List<CuaHang>> Get() =>
        await _cuaHangService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<CuaHang>> Get(string id)
    {
        var cuaHang = await _cuaHangService.GetAsync(id);

        if (cuaHang is null)
        {
            return NotFound();
        }

        return cuaHang;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CuaHang newCuaHang)
    {
        await _cuaHangService.CreateAsync(newCuaHang);

        return CreatedAtAction(nameof(Get), new { id = newCuaHang.Id }, newCuaHang);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, CuaHang updatedCuaHang)
    {
        var cuaHang = await _cuaHangService.GetAsync(id);

        if (cuaHang is null)
        {
            return NotFound();
        }

        updatedCuaHang.Id = cuaHang.Id;

        await _cuaHangService.UpdateAsync(id, updatedCuaHang);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var cuaHang = await _cuaHangService.GetAsync(id);

        if (cuaHang is null)
        {
            return NotFound();
        }

        await _cuaHangService.RemoveAsync(cuaHang.Id);

        return NoContent();
    }
}