using Amazon.Runtime;
using Amazon.SQS;
using Api.Database;
using Api.Handlers;
using Api.Interfaces;
using Api.Messages;
using Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddDbContext<ApplicationDbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseNpgsql(connectionString);
        })
        .AddHostedService<QueueConsumer>()
        .AddSingleton<IAmazonSQS>(_ =>
            {
                var credentials = new BasicAWSCredentials("x", "x");
                var endpoint = "http://localhost:9324";
                var client = new AmazonSQSClient(credentials, new AmazonSQSConfig
                {
                    ServiceURL = endpoint,
                });
                return client;
            })
        .AddScoped<IMessageHandler<EquipmentStateChanged>, EquipmentStateChangedHandler>()
        .AddControllers();
}

var app = builder.Build();
{
    app.MapControllers(); 
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await context.Database.MigrateAsync();
}

app.Run();


