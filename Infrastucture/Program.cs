using Application.Interfaces;
using Application.Services;
using DotNetEnv;
using Infrastucture;
using Refit;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

string discordAuthToken = Environment.GetEnvironmentVariable("DISCORD_AUTH_TOKEN");
string discordAccept = Environment.GetEnvironmentVariable("ACCEPT");
string discordAcceptLanguage = Environment.GetEnvironmentVariable("ACCEPT_LANGUAGE");
string discordDebugOptions = Environment.GetEnvironmentVariable("DEBUG_OPTIONS");
string discordLocale = Environment.GetEnvironmentVariable("DISCORD_LOCALE");
string discordTimezone = Environment.GetEnvironmentVariable("DISCORD_TIMEZONE");
string discordSuperProps = Environment.GetEnvironmentVariable("SUPER_PROPS");

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

builder.Services.Configure<GuildParams>(options =>
{
    options.Accept = discordAccept;
    options.AcceptLanguage = discordAcceptLanguage;
    options.DebugOptions = discordDebugOptions;
    options.DiscordLocale = discordLocale;
    options.DiscordTimezone = discordTimezone;
    options.SuperProps = discordSuperProps;
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
