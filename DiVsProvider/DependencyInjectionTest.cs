using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiVsProvider.DependencyInjection;

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

public class Client
{
    private IService _service;

    public Client(IService service)
    {
        this._service = service;
    }

    public void Start()
    {
        Console.WriteLine("Service Started!");
        this._service.Serve();
    }
}

//public class Program
//{
//    static void Main(string[] args)
//    {
//        // 의존성 주입
//        Client client = new Client(new Service1());
//        client.Start();
//    }
//}


internal class DependencyInjectionTest
{

}
