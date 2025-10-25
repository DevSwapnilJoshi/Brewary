namespace EGlossary.Domain.Models;

public class BrewerySearchRequest
{
    public string Name { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Type { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string Phone { get; set; }
}
