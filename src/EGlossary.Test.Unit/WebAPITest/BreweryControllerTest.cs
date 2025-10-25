using EGlossary.Controllers;
using EGlossary.Domain.Entities;
using EGlossary.Service.Features.BreweryFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EGlossary.UnitTest.WebAPITest;


public class BreweryControllerTest
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<IMemoryCache> _cacheMock;
    private readonly Mock<ILogger<BreweryController>> _loggerMock;
    private readonly BreweryController _controller;

    public BreweryControllerTest()
    {
        _mediatorMock = new Mock<IMediator>();
        _cacheMock = new Mock<IMemoryCache>();
        _loggerMock = new Mock<ILogger<BreweryController>>();
        _controller = new BreweryController(_mediatorMock.Object, _cacheMock.Object, _loggerMock.Object);
    }

    [Fact]
    public async Task GetAll_ReturnsCachedResult_WhenAvailable()
    {
        var cachedData = new List<BreweryEntity> { new BreweryEntity { Name = "Test Brewery" } };
        object cacheValue = cachedData;

        _cacheMock.Setup(c => c.TryGetValue("all_breweries", out cacheValue)).Returns(true);

        var result = await _controller.GetAll();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var breweries = Assert.IsType<List<BreweryEntity>>(okResult.Value);
        Assert.Single(breweries);
    }

    [Fact]
    public async Task GetBreweryById_ReturnsBrewery_WhenFound()
    {
        var id = Guid.NewGuid();
        var brewery = new BreweryEntity { BreweryId = id, Name = "Found Brewery" };

        _mediatorMock.Setup(m => m.Send(It.Is<GetBreweryByIdQuery>(q => q.Id == id), default)).ReturnsAsync(brewery);

        var result = await _controller.GetBreweryById(id);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returned = Assert.IsType<BreweryEntity>(okResult.Value);
        Assert.Equal("Found Brewery", returned.Name);
    }

    [Fact]
    public async Task GetBreweryById_ReturnsNotFound_WhenNull()
    {
        var id = Guid.NewGuid();

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetBreweryByIdQuery>(), default)).ReturnsAsync((BreweryEntity)null);

        var result = await _controller.GetBreweryById(id);

        var notFound = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Contains(id.ToString(), notFound.Value.ToString());
    }
    [Fact]
    public async Task SearchByName_ReturnsBrewery_WhenFound()
    {
        var name = "Brew";
        var brewery = new BreweryEntity { Name = name };

        _mediatorMock.Setup(m => m.Send(It.Is<GetBreweryByNameQuery>(q => q.Name == name), default)).ReturnsAsync(brewery);

        var result = await _controller.SearchByName(name);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returned = Assert.IsType<BreweryEntity>(okResult.Value);
        Assert.Equal(name, returned.Name);
    }

    [Fact]
    public async Task SearchByCity_ReturnsBreweries_WhenFound()
    {
        var city = "Pune";
        var breweries = new List<BreweryEntity> { new BreweryEntity { City = city } };

        _mediatorMock.Setup(m => m.Send(It.Is<GetBreweryByCityQuery>(q => q.City == city), default)).ReturnsAsync(breweries);

        var result = await _controller.SearchByCity(city);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returned = Assert.IsType<List<BreweryEntity>>(okResult.Value);
        Assert.Single(returned);
    }
    [Fact]
    public async Task SearchByDistance_ReturnsNearbyBreweries()
    {
        double lat = 18.52, lon = 73.85;
        var breweries = new List<BreweryEntity> { new BreweryEntity { Latitude = lat, Longitude = lon } };

        _mediatorMock.Setup(m => m.Send(It.Is<GetBreweryByDistanceQuery>(q => q.latitude == lat && q.longitude == lon), default)).ReturnsAsync(breweries);

        var result = await _controller.SearchByDistance(lat, lon);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returned = Assert.IsType<List<BreweryEntity>>(okResult.Value);
        Assert.Single(returned);
    }
}