using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Selu383.SP26.Api.Data;
using Selu383.SP26.Api.Dtos;
using Selu383.SP26.Api.Models;

namespace Selu383.SP26.Api.Controllers;

[ApiController]
[Route("api/locations")]
public class LocationsController : ControllerBase
{

    private readonly ILogger<LocationsController> _logger;
    private readonly DataContext _context;

    public LocationsController(ILogger<LocationsController> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LocationDto>>> GetAll()
    {
        var lists = await _context.Location.ToListAsync();
        var locations = lists.Select(l => new LocationDto
        {
            Id = l.Id,
            Name = l.Name,
            Address = l.Address,
            TableCount = l.TableCount
        }).ToList();
        return Ok(locations);
    }

    [HttpGet("{id}", Name = "GetLocation")]
    public async Task<ActionResult<LocationDto>> GetById(int id)
    {
        var location = await _context.Location.FindAsync(id);
        if (location == null)
        {
            return NotFound();
        }
        var dto = new LocationDto
        {
            Id = location.Id,
            Name = location.Name,
            Address = location.Address,
            TableCount = location.TableCount
        };
        return Ok(dto);
    }

    [HttpPost(Name = "CreateLocation")]
    public async Task<ActionResult<LocationDto>> CreateLocation([FromBody] Location location)


    {
        if (location == null)
            return BadRequest();

        if (string.IsNullOrWhiteSpace(location.Name))
            return BadRequest();

        if (location.Name.Length > 120)
            return BadRequest();

        if (string.IsNullOrWhiteSpace(location.Address))
            return BadRequest();

        if (location.TableCount < 1)
            return BadRequest();

        _context.Location.Add(location);
        await _context.SaveChangesAsync();

        var dto = new LocationDto
        {
            Id = location.Id,
            Name = location.Name,
            Address = location.Address,
            TableCount = location.TableCount
        };

        return CreatedAtRoute("GetLocation", new { id = dto.Id }, dto);


    }

    [HttpPut("{id}", Name = "UpdateLocation")]
    public async Task<ActionResult<LocationDto>> UpdateLocation(int id, [FromBody] Location location)
    {
        var existingLocation = await _context.Location.FindAsync(id);
        if (existingLocation == null)
        {
            return NotFound();
        }
        existingLocation.Name = location.Name;
        existingLocation.Address = location.Address;
        existingLocation.TableCount = location.TableCount;
        await _context.SaveChangesAsync();
        var locationDto = new LocationDto
        {
            Id = existingLocation.Id,
            Name = existingLocation.Name,
            Address = existingLocation.Address,
            TableCount = existingLocation.TableCount
        };
        return Ok(locationDto);
    }

    [HttpDelete("{id}", Name = "DeleteLocation")]
    public async Task<IActionResult> DeleteLocation(int id)
    {
        var location = await _context.Location.FindAsync(id);
        if (location == null)
        {
            return NotFound();
        }
        _context.Location.Remove(location);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
