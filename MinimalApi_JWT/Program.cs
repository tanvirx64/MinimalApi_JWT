using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MinimalApi_JWT.Models;
using MinimalApi_JWT.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IMovieService, MovieService>();
builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthentication();
app.UseSwagger();


app.MapGet("/", () => "Hello World!");
app.MapPost("/create", (Movie movie, IMovieService service) => Create(movie, service));
app.MapGet("/get", (int id, IMovieService service) => Get(id, service));
app.MapGet("/list", (IMovieService service) => GetAll(service));
app.MapPut("/update", (Movie movie , IMovieService service) => Update(movie, service));
app.MapDelete("/delete", (int id, IMovieService service) => Delete(id, service));

IResult Create(Movie movie, IMovieService service)
{
    return Results.Ok(service.Create(movie));
}
IResult Get(int id, IMovieService service)
{
    var movie = service.Get(id);
    if (movie is null) return Results.NotFound("Movie Not Found");
    
    return Results.Ok(movie);
}
IResult GetAll(IMovieService service)
{
    return Results.Ok(service.GetAll());
}
IResult Update(Movie movie, IMovieService service)
{
    var updateMovie = service.Update(movie);
    if (updateMovie is null) return Results.NotFound("Movie Not Found");

    return Results.Ok(updateMovie);
}
IResult Delete(int id, IMovieService service)
{
    var result = service.Delete(id);
    if (!result) return Results.BadRequest("Something went wrong!");
    return Results.Ok(result);
}

app.UseSwaggerUI();
app.Run();
