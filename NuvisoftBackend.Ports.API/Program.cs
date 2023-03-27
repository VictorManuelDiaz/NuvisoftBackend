using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using NuvisoftBackend.Adapters.SQLServerDataAccess.Contexts;
using NuvisoftBackend.Ports.API;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddCors(
    options =>
        options.AddDefaultPolicy(builder =>
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
        )
);

builder.Services.AddDbContext<NuvisoftDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"))
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new ApiVersion(1, 0);
    opt.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllers(options =>
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);


var app = builder.Build();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), "Storage")),
    RequestPath = "/Storage"
});

app.MapControllers();

app.Run();
