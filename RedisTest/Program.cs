namespace RedisTest;

/// <summary>
/// https://medium.com/net-core/in-memory-distributed-redis-caching-in-asp-net-core-62fb33925818
/// https://docs.microsoft.com/ko-kr/aspnet/core/performance/caching/distributed?view=aspnetcore-6.0
/// https://docs.microsoft.com/ko-kr/aspnet/core/performance/caching/memory?view=aspnetcore-6.0
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}