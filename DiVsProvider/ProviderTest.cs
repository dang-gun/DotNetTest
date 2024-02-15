using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiVsProvider.Provider;

public interface IService
{
    void Serve();
}

public class Service1 : IService
{
    public void Serve()
    {
        Console.WriteLine("Service1 Called!");
    }
}

public class ServiceProvider
{
    private static IService _service;

    public static IService Service
    {
        get
        {
            if (_service == null)
            {
                _service = new Service1();
            }
            return _service;
        }
    }
}

public class Client
{
    public void Start()
    {
        Console.WriteLine("Service Started!");
        ServiceProvider.Service.Serve();
    }
}

public class Program
{
    static void Main(string[] args)
    {
        // 프로바인더 패턴
        Client client = new Client();
        client.Start();
    }
}