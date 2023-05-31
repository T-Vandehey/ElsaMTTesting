using Elsa.Activities.MassTransit.Extensions;
using ElsaMTTestng;
using ElsaMTTestng.Models;
using MassTransit;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services
    .AddMassTransit(x =>
    {
        x.AddConsumer(MTHelper.CreateWorkflowConsumer<One>());
        x.AddConsumer(MTHelper.CreateWorkflowConsumer<Two>());
        x.AddConsumer(MTHelper.CreateWorkflowConsumer<Three>());
        x.AddConsumer(MTHelper.CreateWorkflowConsumer<Four>());
        x.AddConsumer(MTHelper.CreateWorkflowConsumer<Five>());

        x.UsingRabbitMq((ctx, cfg) =>
        {
            cfg.ConfigureEndpoints(ctx);
            cfg.Host("rabbitmq://guest:guest@localhost");

            cfg.AutoStart = true;
            cfg.Durable = true;
        });

    });

services.AddElsa(options =>
{
    options.AddMassTransitActivities();
    options.AddConsoleActivities();
    options.AddWorkflow<MTTestingWorkflow>();
});

services.AddControllers();

services.AddEndpointsApiExplorer();

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ElsaMTTesting", Version = "v1" });
});



var app = builder.Build();



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.EnableTryItOutByDefault();
    c.SwaggerEndpoint("../swagger/v1/swagger.json", "ElsaMTTesting V1");
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
