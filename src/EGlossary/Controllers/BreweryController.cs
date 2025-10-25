using EGlossary.Domain.Entities;
using EGlossary.Domain.Models;
using EGlossary.Service.Features.BreweryFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EGlossary.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/Brewery")]
[ApiVersion("1.0")]
public class BreweryController : ControllerBase
{

    private readonly IMediator _mediator;
    private ILogger<BreweryController> _logger;
    private readonly IMemoryCache _cache;

    public BreweryController(IMediator mediator, IMemoryCache cache, ILogger<BreweryController> logger)
    {
        _mediator = mediator;
        _cache = cache;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<BreweryEntity>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
    {
        const string cacheKey = "all_breweries";

        _logger.LogInformation("Starting {Method} at {Time}", nameof(GetAll), DateTime.UtcNow);

        try
        {
            if (_cache.TryGetValue(cacheKey, out List<BreweryEntity> cachedBreweries) && cachedBreweries is not null)
            {                
                    _logger.LogInformation("Returning cached brewery list with {Count} items", cachedBreweries.Count);
                    return Ok(cachedBreweries);               
                
            }

            var response = await _mediator.Send(new GetAllBreweryQuery());

            _logger.LogInformation("Successfully retrieved {Count} breweries at {Time}", response?.Count() ?? 0, DateTime.UtcNow);

            // Set cache options
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(10))
                .SetAbsoluteExpiration(TimeSpan.FromHours(1));

            _cache.Set(cacheKey, response, cacheEntryOptions);

            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in {Method} at {Time}", nameof(GetAll), DateTime.UtcNow);
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving breweries.");
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BreweryEntity), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBreweryById(Guid id)
    {
        _logger.LogInformation($"Fetching brewery by ID: [Id]:{id} at [Time]", nameof(GetBreweryById), DateTime.UtcNow);

        try
        {
            var response = await _mediator.Send(new GetBreweryByIdQuery { Id = id });

            if (response == null)
            {
                _logger.LogWarning("No brewery found for ID: {Id}", id);
                return NotFound($"Brewery with ID {id} not found.");
            }

            _logger.LogInformation("Successfully retrieved brewery: {Name}", response.Name);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "$Error retrieving brewery by ID: {id}", nameof(GetBreweryById));
            return StatusCode(500, "Internal server error.");
        }
    }

    [HttpGet("search-by-Name")]
    [ProducesResponseType(typeof(BreweryEntity), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> SearchByName([FromQuery] string name)
    {
        _logger.LogInformation($"Searching brewery by name: {name}", nameof(SearchByName));

        try
        {
            var response = await _mediator.Send(new GetBreweryByNameQuery { Name = name });

            if (response == null)
            {
                _logger.LogWarning("No brewery found with name: {Name}", name);
                return NotFound($"Brewery with name '{name}' not found.");
            }

            _logger.LogInformation("Found brewery: {Name}", response.Name);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error searching brewery by name: {name}", nameof(SearchByName));
            return StatusCode(500, "Internal server error.");
        }
    }

    [HttpGet("search-by-City")]
    [ProducesResponseType(typeof(List<BreweryEntity>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> SearchByCity([FromQuery] string city)
    {
        _logger.LogInformation($"Searching breweries in city: {city}", nameof(SearchByCity));

        try
        {
            var response = await _mediator.Send(new GetBreweryByCityQuery { City = city });

            _logger.LogInformation("Found {Count} breweries in city: {City}", response?.Count() ?? 0, city);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error searching breweries in city: {city}", nameof(SearchByCity));
            return StatusCode(500, "Internal server error.");
        }
    }

    [HttpGet("search-by-distance")]
    [ProducesResponseType(typeof(List<BreweryEntity>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> SearchByDistance([FromQuery] double latitude, [FromQuery] double longitude)
    {
        _logger.LogInformation($"Searching breweries near coordinates: [latitude]: {latitude},[Longitude]: {longitude}", nameof(SearchByDistance));

        try
        {
            var response = await _mediator.Send(new GetBreweryByDistanceQuery { latitude = latitude, longitude = longitude });

            _logger.LogInformation("Found {Count} breweries near location", response?.Count() ?? 0);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error searching breweries by distance: [latitude]: {latitude},[Longitude]: {longitude}", nameof(SearchByDistance));
            return StatusCode(500, "Internal server error.");
        }
    }

    [HttpGet("search")]
    [ProducesResponseType(typeof(List<BreweryEntity>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Search([FromQuery] BrewerySearchRequest request)
    {
        _logger.LogInformation("Searching breweries with criteria: {@request}", request);

        try
        {
            var response = await _mediator.Send(new SearchBreweryQuery
            {
                Name = request.Name,
                City = request.City,
                State = request.State,
                Type = request.Type,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                Phone = request.Phone
            });

            _logger.LogInformation("Found {Count} breweries", response.Count());
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred during brewery search");
            return StatusCode(500, "An error occurred while searching breweries.");
        }
    }

}

