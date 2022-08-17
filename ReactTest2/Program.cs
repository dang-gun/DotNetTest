using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

#region ConfigureServices
//API모델을 파스칼 케이스 유지하기
builder.Services.AddControllers().AddNewtonsoftJson(options => { options.SerializerSettings.ContractResolver = new DefaultContractResolver(); });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddControllersWithViews();
#endregion



#region Configure
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();

	app.UseSwagger();
	app.UseSwaggerUI();
}

//3.0 api 라우트
app.UseRouting();
//https로 자동 리디렉션
app.UseHttpsRedirection();
app.UseRouting();
//기본 페이지
//app.UseDefaultFiles();

//웹 루트
//app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{
	app.UseStaticFiles(new StaticFileOptions
	{
		FileProvider = new PhysicalFileProvider(
	   Path.Combine(builder.Environment.ContentRootPath, @"wwwroot\development")),
	});
}
else
{
	app.UseStaticFiles(new StaticFileOptions
	{
		FileProvider = new PhysicalFileProvider(
	   Path.Combine(builder.Environment.ContentRootPath, @"wwwroot\production")),
	});
}



app.MapControllers();
//app.MapControllerRoute(
//	name: "default",
//	pattern: "{controller}/{action=Index}/{id?}");

//app.MapFallbackToFile("index.html"); ;

app.Run();
#endregion
