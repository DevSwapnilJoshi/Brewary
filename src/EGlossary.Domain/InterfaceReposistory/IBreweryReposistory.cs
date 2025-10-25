using EGlossary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGlossary.Domain.InterfaceReposistory;

public interface IBreweryReposistory
{
    Task GetBreweryInMemory();
    Task<IEnumerable<BreweryEntity>> GetBreweries();
    Task<BreweryEntity> GetBreweryById(Guid Id);
    Task<BreweryEntity> GetBreweryByName(string Name);
    Task<IEnumerable<BreweryEntity>> GetBreweryByCity(string City);
    Task<IEnumerable<BreweryEntity>> GetBreweryByDistance(double latitude, double longitude);
}
