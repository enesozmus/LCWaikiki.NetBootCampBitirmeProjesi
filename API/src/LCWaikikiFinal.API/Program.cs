using FluentValidation.AspNetCore;
using LCWaikikiFinal.Application;
using LCWaikikiFinal.Application.Features.AuthenticationOperations;
using LCWaikikiFinal.Application.Features.CategoryOperations.Command;
using LCWaikikiFinal.Infrastructure;
using LCWaikikiFinal.Infrastructure.SeedData;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region @ Layers @

builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.ConfigureApplicationServices();

#endregion

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
        opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
})
        .AddFluentValidation(
        a => a.RegisterValidatorsFromAssemblyContaining<CreateCategoryCommandValidator>()).AddFluentValidation(
        a => a.RegisterValidatorsFromAssemblyContaining<RegisterCommandValidator>()
        );

builder.Services.AddEndpointsApiExplorer();

#region Swagger

builder.Services.AddSwaggerGen(options =>
{
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
                Name = "JWT Authentication",
                Description = "Jwt Bearer Token **_only_**",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                },
        });

        var security =
                new OpenApiSecurityRequirement
                {
                        {
                                new OpenApiSecurityScheme
                                {
                                        Reference = new OpenApiReference
                                        {
                                                Id = "Bearer",
                                                Type = ReferenceType.SecurityScheme
                                        },
                                        UnresolvedReference = true
                                },
                                new List<string>()
                        }
                };
        options.AddSecurityRequirement(security);
});

#endregion

#region Cors

builder.Services.AddCors(options =>
{
        options.AddPolicy("GlobalCors",  config =>
        {
                //WithOrigins
                config.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

#endregion

#region Cookie and JwtBearer

builder.Services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                        ValidIssuer = "http://localhost",
                        ValidAudience = "http://localhost",
                        ValidateAudience = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Enesenesenes1.LC")),
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                };

        });



// 1.   .AddAuthentication              => middleware’i aracýlýðýyla bir þema oluþturulur
// 2.   .AddJwtBearer               =>  Microsoft.AspNetCore.Authentication.JwtBearer
// 3.   Json Web Token Http s ile beraber çalýþýr
// 4.  Audience”, “Issuer”, “LifeTime”, “SigningKey” ve “ClockSkew”

// ValidIssuer               => Oluþturulacak token deðerini kimin daðýttýðýný ifade edeceðimiz alandýr.
// ValidAudience         => Oluþturulacak token deðerini kimlerin/hangi originlerin/sitelerin kullanacaðýný belirlediðimiz alandýr.

// LifeTime => Oluþturulan token deðerinin süresini kontrol edecek olan doðrulamadýr.
// SigningKey => Üretilecek token deðerinin uygulamamýza ait bir deðer olduðunu ifade eden security key verisinin doðrulamasýdýr.
// ClockSkew => Üretilecek token deðerinin expire süresinin belirtildiði deðer kadar uzatýlmasýný saðlayan özelliktir.
//                     => Örneðin; kullanýlabilirlik süresi 5 dakika olarak ayarlanan token deðerinin ClockSkew deðerine 3 dakika verilirse eðer ilgili token 5 + 3 = 8 dakika kullanýlabilir olacaktýr
// ClockSkew =>

#endregion

var app = builder.Build();

#region @ SeedData@

DbInitializer.Initialize(app);

#endregion

#region ErrorHandlerMiddleware

//app.UseMiddleware<ErrorHandlerMiddleware>();

#endregion

if (app.Environment.IsDevelopment())
{
        app.UseSwagger();
        app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("GlobalCors");

#region Identity

app.UseAuthentication();
app.UseAuthorization();

#endregion

app.MapControllers();

app.Run();
