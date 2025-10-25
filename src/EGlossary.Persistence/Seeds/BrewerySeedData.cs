using EGlossary.Persistence.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGlossary.Persistence.Seeds;

public class BrewerySeedData
{

    public static async Task Seed(InMemoryDbContext context)
    {
        var brewery = new List<BreweryDataModel>
        {
            new()
            {
               BreweryId = Guid.Parse("b54b16e1-ac3b-4bff-a11f-f7ae9ddc27e0"),
               Name = "MadTree Brewing 2.0",
               BreweryType = "regional",
               Address1 = "5164 Kennedy Ave",
               Address2 = null,
               Address3 = null,
               City = "Cincinnati",
               StateProvince = "Ohio",
               PostalCode = "45213",
               Country = "United States",
               Longitude = -84.4137736,
               Latitude = 39.1885752,
               Phone = "5138368733",
               WebsiteUrl = "http://www.madtreebrewing.com",
               State = "Ohio",
               Street = "5164 Kennedy Ave"

            },
            new() 
            {
                BreweryId = Guid.Parse("5128df48-79fc-4f0f-8b52-d06be54d0cec"),
                Name = "(405) Brewing Co",
                BreweryType = "micro",
                Address1 = "1716 Topeka St",
                Address2 = null,
                Address3 = null,
                City = "Norman",
                StateProvince = "Oklahoma",
                PostalCode = "73069-8224",
                Country = "United States",
                Longitude = -97.46818222,
                Latitude = 35.25738891,
                Phone = "4058160490",
                WebsiteUrl = "http://www.405brewing.com",
                State = "Oklahoma",
                Street = "1716 Topeka St"
            },
            new() 
            {
                BreweryId = Guid.Parse("9c5a66c8-cc13-416f-a5d9-0a769c87d318"),
                Name = "(512) Brewing Co",
                BreweryType = "micro",
                Address1 = "407 Radam Ln Ste F200",
                Address2 = null,
                Address3 = null,
                City = "Austin",
                StateProvince = "Texas",
                PostalCode = "78745-1197",
                Country = "United States",
                Longitude = null,
                Latitude = null,
                Phone = "5129211545",
                WebsiteUrl = "http://www.512brewing.com",
                State = "Texas",
                Street = "407 Radam Ln Ste F200"
            },
            new()
            {
                BreweryId = Guid.Parse("34e8c68b-6146-453f-a4b9-1f6cd99a5ada"),
                Name = "1 of Us Brewing Company",
                BreweryType = "micro",
                Address1 = "8100 Washington Ave",
                Address2 = null,
                Address3 = null,
                City = "Mount Pleasant",
                StateProvince = "Wisconsin",
                PostalCode = "53406-3920",
                Country = "United States",
                Longitude = -87.883363502094,
                Latitude = 42.720108268996,
                Phone = "2624847553",
                WebsiteUrl = "https://www.1ofusbrewing.com",
                State = "Wisconsin",
                Street = "8100 Washington Ave"
            }

          };

        context.Brewery.AddRange(brewery);
        await context.SaveChangesAsync();
    }
}
