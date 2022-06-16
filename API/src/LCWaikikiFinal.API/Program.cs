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



// 1.   .AddAuthentication              => middleware�i arac�l���yla bir �ema olu�turulur
// 2.   .AddJwtBearer               =>  Microsoft.AspNetCore.Authentication.JwtBearer
// 3.   Json Web Token Http s ile beraber �al���r
// 4.  Audience�, �Issuer�, �LifeTime�, �SigningKey� ve �ClockSkew�

// ValidIssuer               => Olu�turulacak token de�erini kimin da��tt���n� ifade edece�imiz aland�r.
// ValidAudience         => Olu�turulacak token de�erini kimlerin/hangi originlerin/sitelerin kullanaca��n� belirledi�imiz aland�r.

// LifeTime => Olu�turulan token de�erinin s�resini kontrol edecek olan do�rulamad�r.
// SigningKey => �retilecek token de�erinin uygulamam�za ait bir de�er oldu�unu ifade eden security key verisinin do�rulamas�d�r.
// ClockSkew => �retilecek token de�erinin expire s�resinin belirtildi�i de�er kadar uzat�lmas�n� sa�layan �zelliktir.
//                     => �rne�in; kullan�labilirlik s�resi 5 dakika olarak ayarlanan token de�erinin ClockSkew de�erine 3 dakika verilirse e�er ilgili token 5 + 3 = 8 dakika kullan�labilir olacakt�r
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
