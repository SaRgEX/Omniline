using Application.Contracts;
using Application.Models.Contacts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactController(IContactService contactService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<ContactResponse>>> GetAll()
    {
        var contacts = await contactService.AllAsync();
        return Ok(contacts);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Contact>> Find(int id)
    {
        var contact = await contactService.FindAsync(id);
        if (contact is null)
        {
            return NotFound();
        }
        return Ok(contact);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] ContactRequest request)
    {
        var contactId = await contactService.Create(request);

        return CreatedAtAction(nameof(Create), new { id = contactId }, contactId);
    }
    [HttpPut("{id:int}")]
    public async Task<ActionResult<int>> Update(int id, [FromBody] ContactRequest request)
    {
        await contactService.UpdateAsync(id, request);
        return NoContent();
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<int>> Delete(int id)
    {
        await contactService.DeleteAsync(id);
        return Ok(id);
    }
}