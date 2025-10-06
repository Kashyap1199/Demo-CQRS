using CQRS.Common.Commands;
using CQRS.EF;
using CQRS.EF.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class ProductCommandHandlerTests
{
    private readonly string _connectionString;

    public ProductCommandHandlerTests()
    {
        // Build configuration to read from appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    private ApplicationDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(_connectionString)
            .Options;
        return new ApplicationDbContext(options);
    }

    [Fact]
    public async Task Handle_ShouldAddProductToDatabase()
    {
        var context = GetDbContext();
        var handler = new ProductCommandHandler(context);
        var command = new CreateProductCommand("Test Product", 99.99m);

        var result = await handler.Handle(command, CancellationToken.None);
        var exists = context.Products.Any(p => p.Name == "Test Product");
        Assert.NotNull(result);
        Assert.Equal("Test Product", result.Name);
        Assert.Equal(99.99m, result.Price);
        //Assert.Single(context.Products);

        // Additional check: verify "Test Product" exists in the database
        
        Assert.True(exists);
    }

    [Fact]
    public async Task Handle_ShouldSetProductIdAfterSave()
        {
        var context = GetDbContext();
        var handler = new ProductCommandHandler(context);
        var command = new CreateProductCommand("Another Product", 10.00m);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result.Id > 0);
    }
}