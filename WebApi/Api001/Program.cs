using Api001.DB;
using Api001.Account.Interop;
using Api001.Account.Repository;
using Api001.Account.UseCase;
using Api001.Domain.Account;
using Api001.SignalR.Chat;

var builder = WebApplication.CreateBuilder(args);

// add db context
builder.Services.AddDbContext<AccountContext>();

// Add SignalR.
builder.Services.AddSignalR();

// Add services to the container.

builder.Services.AddScoped<AccountRepository, AccountBaseRepository>();
builder.Services.AddScoped<AccountUseCase, AccountBaseUseCase>();
builder.Services.AddScoped<AccountInterop, AccountBaseInterop>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>("/chatHub");

app.Run();
