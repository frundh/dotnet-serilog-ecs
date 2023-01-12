using Serilog;
using Serilog.Events;
using Elastic.CommonSchema.Serilog;
using Serilog.Sinks.Http;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.ConfigureLogging((context, builder) =>
    {
        builder.AddSerilog();
    })
    .UseSerilog((ctx, provider, config) =>
        {
            var httpAccessor = ctx.Configuration.Get<HttpContextAccessor>();
            var formatterConfig = new EcsTextFormatterConfiguration();
            
            formatterConfig.MapHttpContext(httpAccessor);
            var formatter = new EcsTextFormatter(formatterConfig);

            config.WriteTo.Console();
            //config.WriteTo.Console(formatter);
            config.WriteTo.Http(requestUri: ctx.Configuration["Logstash:Url"], queueLimitBytes: null, textFormatter: formatter);
        });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();
