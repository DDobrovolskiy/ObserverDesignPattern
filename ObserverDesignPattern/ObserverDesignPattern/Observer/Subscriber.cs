using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignPattern.Observer
{
    public class Subscriber
    {
        private readonly string _name;

        public Subscriber(string name)
        {
            _name = name;
        }

        public void ItIsSubscribe(string fileDeleteName)
        {
            Console.WriteLine($"{_name} {fileDeleteName} was deleted!");
        }

        public void ItIsSubscribe(object sendler, string fileDeleteName)
        {
            Console.WriteLine($"{_name} {fileDeleteName} was deleted!");
        }

        public void ItIsSubscribeTwo(object sendler, string fileDeleteName)
        {
            Console.WriteLine("---");
            Console.WriteLine($"{_name} {fileDeleteName} was deleted!");
        }
    }
}
