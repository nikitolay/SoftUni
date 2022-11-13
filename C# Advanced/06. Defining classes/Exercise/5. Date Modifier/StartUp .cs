using System;

namespace _5._Date_Modifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DateModifier dateModifier = new DateModifier(DateTime.Parse(Console.ReadLine()), DateTime.Parse(Console.ReadLine()));
            Console.WriteLine(dateModifier.DifferenceInDay());
        }
    }
}
