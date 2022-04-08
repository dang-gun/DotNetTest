
//https://docs.microsoft.com/ko-kr/aspnet/core/tutorials/signalr-typescript-webpack?view=aspnetcore-6.0&tabs=visual-studio

using SignalRWebpack.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();

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

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<ChatHub>("/hub");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
