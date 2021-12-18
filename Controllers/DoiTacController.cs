using DiChoHoCS.Models;
using DiChoHoCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiChoHoCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoiTacController : ControllerBase
{
    private readonly DoiTacService _doiTacService;

    public DoiTacController(DoiTacService doiTacService) =>
        _doiTacService = doiTacService;

    [HttpGet]
    public async Task<List<DoiTac>> Get() =>
        await _doiTacService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<DoiTac>> Get(string id)
    {
        var doiTac = await _doiTacService.GetAsync(id);
        if (doiTac is null)
        {
            return NotFound();
        }

        return doiTac;
    }

    [HttpPost]
    public async Task<IActionResult> Post(DoiTac newDoiTac)
    {
        await _doiTacService.CreateAsync(newDoiTac);

        return CreatedAtAction(nameof(Get), new { id = newDoiTac.Id }, newDoiTac);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, DoiTac updatedDoiTac)
    {
        var doiTac = await _doiTacService.GetAsync(id);
        if (doiTac is null)
        {
            return NotFound();
        }

        updatedDoiTac.Id = doiTac.Id;
        await _doiTacService.UpdateAsync(id, updatedDoiTac);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var doiTac = await _doiTacService.GetAsync(id);
        if (doiTac is null)
        {
            return NotFound();
        }
        await _doiTacService.RemoveAsync(doiTac.Id);

        return NoContent();
    }
}