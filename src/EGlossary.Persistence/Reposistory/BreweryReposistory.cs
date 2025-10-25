using AutoMapper;
using EGlossary.Domain.Entities;
using EGlossary.Domain.InterfaceReposistory;
using EGlossary.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGlossary.Persistence.Reposistory;

public class BreweryReposistory : IBreweryReposistory
{
    private readonly InMemoryDbContext _dbContext;
    private readonly IMapper _mapper;
    public BreweryReposistory(InMemoryDbContext inMemoryDbContext, IMapper mapper)
    {
        _dbContext = inMemoryDbContext;
        _mapper = mapper;
    }


    public async Task<IEnumerable<BreweryEntity>> GetBreweries()
    {
        _ = GetBreweryInMemory();
        var Breweries = await _dbContext.Brewery.ToListAsync();
        return _mapper.Map<IEnumerable<BreweryEntity>>(Breweries);
    }
    public async Task<BreweryEntity> GetBreweryById(Guid Id)
    {
        _ = GetBreweryInMemory();
        var Brewery = await _dbContext.Brewery.Where(p => p.BreweryId == Id).FirstOrDefaultAsync();

        return _mapper.Map<BreweryEntity>(Brewery);
    }

    public async Task<BreweryEntity> GetBreweryByName(string Name)
    {
        _ = GetBreweryInMemory();
        var breweries = await _dbContext.Brewery
                       .Where(p => p.Name == Name).FirstOrDefaultAsync();
        return _mapper.Map<BreweryEntity>(breweries);
    }
    public async Task<IEnumerable<BreweryEntity>> GetBreweryByCity(string City)
    {
        _ = GetBreweryInMemory();
        var breweries = await _dbContext.Brewery
                       .Where(p => p.City == City).ToListAsync();
        return _mapper.Map<IEnumerable<BreweryEntity>>(breweries);
    }
    public async Task<IEnumerable<BreweryEntity>> GetBreweryByDistance(double latitude, double longitude)
    {
        _ = GetBreweryInMemory();
        var breweries = await _dbContext.Brewery
                       .Where(p => p.Latitude == latitude && p.Longitude == longitude).ToListAsync();
        return _mapper.Map<IEnumerable<BreweryEntity>>(breweries);
    }
    public async Task GetBreweryInMemory()
    {
        await BrewerySeedData.Seed(_dbContext).ConfigureAwait(false);
    }
}
