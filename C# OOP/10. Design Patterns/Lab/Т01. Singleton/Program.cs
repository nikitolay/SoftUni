using System;

namespace Т01._Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("Washington"));
            var db2 = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("London"));
        }
    }
}
