using Application.Interfaces;
using Application.Services;
using DotNetEnv;
using Infrastucture;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// переменные из .env файла
Env.Load();

// чтение значения токена из переменных среды
string discordAuthToken = Environment.GetEnvironmentVariable("DISCORD_AUTH_TOKEN");

builder.Services.AddTransient<GuildService>();
builder.Services.AddTransient<ChannelService>();

builder.Services.AddRefitClient<IDiscordApiGuild>()
    .ConfigureHttpClient(x => x.BaseAddress = new Uri("https://discord.com/api/v7"));
builder.Services.AddRefitClient<IDiscordApiChannel>()
    .ConfigureHttpClient(x => x.BaseAddress = new Uri("https://discord.com/api/v7"));

builder.Services.Configure<Authorization>(options =>
{
    options.Token = discordAuthToken;
});


builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
