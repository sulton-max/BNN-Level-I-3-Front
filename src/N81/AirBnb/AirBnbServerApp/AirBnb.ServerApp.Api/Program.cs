using AirBnb.ServerApp.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(
    options =>
    {
        options.AddDefaultPolicy(
            policyBuilder =>
            {
                policyBuilder.AllowAnyOrigin();
                policyBuilder.AllowAnyMethod();
                policyBuilder.AllowAnyHeader();
            }
        );
    }
);

var images = new List<string>
{
    "https://a0.muscache.com/im/pictures/miso/Hosting-852899544635683289/original/c627f47e-8ca9-4471-90d4-1fd987dd2362.jpeg?im_w=720",
    "https://a0.muscache.com/im/pictures/miso/Hosting-40792948/original/f603aac0-729b-41e0-932a-823c27142204.jpeg?im_w=720",
    "https://a0.muscache.com/im/pictures/177ed8a7-557b-480f-8319-4f8330e2c692.jpg?im_w=720",
    "https://a0.muscache.com/im/pictures/miso/Hosting-696847375839509250/original/9686a3bd-dfff-4ae6-bb51-514154308bdb.png?im_w=720",
    "https://a0.muscache.com/im/pictures/d879c12a-9259-4080-847e-faeecfe176d9.jpg?im_w=720"
};

var app = builder.Build();

app.MapGet(
    "api/locations",
    () =>
    {
        var count = 0;
        var random = new Random();

        return Results.Ok(
            Enumerable.Range(1, 5)
                .Select(
                    _ => new Location
                    {
                        ImageUrl = images[count++],
                        Name = "Bujra. India Bujra. India Bujra. India Bujra. India Bujra. India Bujra. IndiaBujra. IndiaBujra. India",
                        BuiltYear = random.Next(2010, 2023),
                        PricePerNight = random.Next(300, 5000)
                    }
                )
        );
    }
);

app.MapGet(
    "api/locations/categories",
    () =>
    {
        var apiUrl = app.Configuration.GetSection("ApiConfigurations:ApiUrl").Get<string>();
        
        return Results.Ok(new List<LocationCategories>
        {
            new()
            {
                Name = "Castles",
                ImageUrl = @"Assets\LocationCategories\Castle.jpg".ToUrl(apiUrl)
            }
        });
    }
);

app.UseCors();
app.UseStaticFiles();

app.Run();

public class Location
{
    public string ImageUrl { get; set; } = default!;
    public string Name { get; set; } = default!;
    public int BuiltYear { get; set; }
    public int PricePerNight { get; set; }
}

public class LocationCategories
{
    public string Name { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
}