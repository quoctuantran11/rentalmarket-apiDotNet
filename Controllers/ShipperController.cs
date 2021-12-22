using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipperController : ControllerBase
{
    private readonly ShipperService _shipperService;

    public ShipperController(ShipperService shipperService) =>
        _shipperService = shipperService;

    [HttpGet]
    public async Task<List<Shipper>> Get() =>
        await _shipperService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Shipper>> Get(string id)
    {
        var shipper = await _shipperService.GetAsync(id);

        if (shipper is null)
        {
            return NotFound();
        }

        return shipper;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Shipper newShipper)
    {
        await _shipperService.CreateAsync(newShipper);

        return CreatedAtAction(nameof(Get), new { id = newShipper.Id }, newShipper);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Shipper updatedShipper)
    {
        var shipper = await _shipperService.GetAsync(id);

        if (shipper is null)
        {
            return NotFound();
        }

        updatedShipper.Id = shipper.Id;

        await _shipperService.UpdateAsync(id, updatedShipper);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var shipper = await _shipperService.GetAsync(id);

        if (shipper is null)
        {
            return NotFound();
        }

        await _shipperService.RemoveAsync(shipper.Id);

        return NoContent();
    }
}