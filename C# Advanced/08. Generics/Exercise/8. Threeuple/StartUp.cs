
using System;

namespace _8._Threeuple
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] nameAddressTowm = Console.ReadLine().Split(' ');
            string firstName = nameAddressTowm[0];
            string lastName = nameAddressTowm[1];
            string address = nameAddressTowm[2];
            string town = nameAddressTowm[3];

            Tuple<string, string, string> tuple1 = new Tuple<string, string, string>($"{firstName} {lastName}", address, town);


            string[] nameLitterDrunkOrNot = Console.ReadLine().Split(' ');
            string name = nameLitterDrunkOrNot[0];
            int litters = int.Parse(nameLitterDrunkOrNot[1]);
            bool IsDrunk = nameLitterDrunkOrNot[2] == "drunk" ? true : false;

            Tuple<string, int, bool> tuple2 = new Tuple<string, int, bool>(name, litters, IsDrunk);


            string[] nameBalanceBankName = Console.ReadLine().Split(' ');
            name = nameBalanceBankName[0];
            double accountBalance = double.Parse(nameBalanceBankName[1]);
            string bankName = nameBalanceBankName[2];
            Tuple<string, double, string> tuple3 = new Tuple<string, double, string>(name, accountBalance, bankName);

            Console.WriteLine(tuple1.ToString());
            Console.WriteLine(tuple2.ToString());
            Console.WriteLine(tuple3.ToString());

        }
    }
}
