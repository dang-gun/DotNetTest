using MiddlewareOptionsTest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//appsettings.json load
builder.Services
	.Configure<TestUtilsSettingModel>(
		builder.Configuration.GetSection("TestUtilsSetting"));

	TestUtilsSettingModel temp = new TestUtilsSettingModel()
	{
		Test01 = 1000,
		Test03 = "Input!!"
	};


	////error
	//builder.Services
	//	.Configure<TestUtilsSettingModel>(temp);

	////error
	//builder.Services
	//	.Configure<TestUtilsSettingModel>(
	//		new Action<TestUtilsSettingModel>(temp));

	//https://stackoverflow.com/a/45324839/6725889
	builder.Configuration["TestUtilsSetting:Test01"] = 1000.ToString();




builder.Services.AddScoped<ITestUtils, TestUtils>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}


//app.UseMiddleware<TestMiddleware>();

app.UseHttpsRedirection();



app.UseAuthorization();

app.MapControllers();

app.Run();
