using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using RecognitionCore.Domain.Entities;

namespace ApplicationCore.Persistance;

public class AppDbContextInitialiser
{
    private readonly ILogger<AppDbContextInitialiser> _logger;
    private readonly AppDbContext _context;

    public AppDbContextInitialiser(ILogger<AppDbContextInitialiser> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsRelational())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedDataAsync()
    {
        try
        {
            if (!_context.Users.Any())
            {
                var user1 = await _context.Users.AddAsync(new User(){UserName = "bek", FirstName = "Bekzod", LastName = "Masharipov"});
                var user2 = await _context.Users.AddAsync(new User(){UserName = "madina", FirstName = "Madina", LastName = "Akramova"});
                await _context.Users.AddAsync(new User(){UserName = "bek", FirstName = "Bekzod", LastName = "Masharipov"});
                await _context.Users.AddAsync(new User(){UserName = "bek2", FirstName = "Bekber", LastName = "Rarviop"});
                await _context.Users.AddAsync(new User(){UserName = "bek3", FirstName = "Zodbek", LastName = "Mashari"});

                await _context.SaveChangesAsync();
                await _context.Recognitions.AddAsync(new Recognition(user1.Entity.Id, user2.Entity.Id,
                    "Bek is great guy!", "He is great employee. He was really helpfull past month"));
                await _context.Recognitions.AddAsync(new Recognition(user2.Entity.Id, user1.Entity.Id,
                    "Madina is awesome colleague!", "She was really helpfull during my probation period!"));
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while seeding the database.");
            throw;
        }
    }
}