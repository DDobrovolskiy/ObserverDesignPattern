using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverDesignPattern.Observer;

namespace ObserverDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Делегаты отношения 1:1 - есть обратная связь
            //События отношения 1:n - обратной связи нет, не гарантии что на события кто-то подписан.
            //Interface (IObserver/IObservable) - 

            Console.WriteLine("Observer design pattern");

            string directory = @"C:\Users\Dmitry\Desktop\CSharp Project\ObserverDesignPattern\ObserverDesignPattern\ObserverDesignPattern\Directory";

            //delegate

            //FileStatusDelegate fileStatusDelegate = new FileStatusDelegate(directory, new Subscriber("Delegate").ItIsSubscribe);

            //event

            var eObserver = new FileStatusEvent(directory);
            var subscriber1 = new Subscriber("event 1");
            var subscriber2 = new Subscriber("event 2");

            eObserver.removeFile += subscriber1.ItIsSubscribe;
            eObserver.removeFile += subscriber2.ItIsSubscribeTwo;

            Console.ReadKey();
        }
    }
}
