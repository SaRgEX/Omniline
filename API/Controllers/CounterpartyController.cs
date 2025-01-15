using Application.Contracts;
using Application.Models.Counterparties;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class CounterpartyController(ICounterpartyService counterpartyService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var counterparties = await counterpartyService.AllAsync();
        return Ok(counterparties);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> FindAsync(int id)
    {
        var counterparty = await counterpartyService.FindAsync(id);
        if (counterparty is null)
            return NotFound();
        return Ok(counterparty);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CounterpartyRequest request)
    {
        var id = await counterpartyService.Create(request);
        return CreatedAtAction(nameof(Create), new { id }, request);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] CounterpartyRequest request)
    {
        await counterpartyService.UpdateAsync(id, request);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await counterpartyService.DeleteAsync(id);
        return Ok(id);
    }
}