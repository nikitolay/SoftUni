using System;

namespace _7._Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] namesWithAddresses = Console.ReadLine().Split();
            string firstName = namesWithAddresses[0];
            string lastName = namesWithAddresses[1];
            string address = namesWithAddresses[2];
            Tuple<string, string> tuple1 = new Tuple<string, string>($"{firstName} {lastName}", address);

            string[] namesWithBeer = Console.ReadLine().Split();
            string name = namesWithBeer[0];
            int beerLitters = int.Parse(namesWithBeer[1]);
            Tuple<string, int> tuple2 = new Tuple<string, int>(name, beerLitters);


            string[] numbers = Console.ReadLine().Split();
            int first = int.Parse(numbers[0]);
            double second = double.Parse(numbers[1]);
            Tuple<int, double> tuple3 = new Tuple<int, double>(first, second);
            Console.WriteLine(tuple1.ToString());
            Console.WriteLine(tuple2.ToString());
            Console.WriteLine(tuple3.ToString());
        }
    }
}
