using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipperController : ControllerBase
{
    private readonly ShipperService _ShipperService;

    public ShipperController(ShipperService ShipperService) =>
        _ShipperService = ShipperService;

    [HttpGet]
    public async Task<List<Shipper>> Get() =>
        await _ShipperService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Shipper>> Get(string id)
    {
        var Shipper = await _ShipperService.GetAsync(id);

        if (Shipper is null)
        {
            return NotFound();
        }

        return Shipper;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Shipper newShipper)
    {
        await _ShipperService.CreateAsync(newShipper);

        return CreatedAtAction(nameof(Get), new { id = newShipper.Id }, newShipper);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Shipper updatedShipper)
    {
        var Shipper = await _ShipperService.GetAsync(id);

        if (Shipper is null)
        {
            return NotFound();
        }

        updatedShipper.Id = Shipper.Id;

        await _ShipperService.UpdateAsync(id, updatedShipper);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var Shipper = await _ShipperService.GetAsync(id);

        if (Shipper is null)
        {
            return NotFound();
        }

        await _ShipperService.RemoveAsync(Shipper.Id);

        return NoContent();
    }
}