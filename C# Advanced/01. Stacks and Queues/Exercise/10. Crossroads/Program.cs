using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            int currentTime = greenLightDuration;

            Queue<string> cars = new Queue<string>();

            bool isCrashed = false;

            int carPass = 0;

            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command == "green")
                {
                    if (greenLightDuration == 0)
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    while (cars.Count > 0)
                    {

                        if (cars.Peek().Length < currentTime)
                        {
                            currentTime -= cars.Peek().Length;
                            cars.Dequeue();
                            carPass++;
                        }
                        else
                        {
                            if (cars.Peek().Length <= currentTime + freeWindowDuration)
                            {
                                carPass++;
                                cars.Dequeue();
                                break;
                            }
                            else
                            {
                                isCrashed = true;
                                Console.WriteLine("A crash happened!");
                                int indexCrashed = currentTime + freeWindowDuration;
                                string carText = cars.Peek();
                                string subs = carText.Substring(indexCrashed, 1);
                                Console.WriteLine($"{carText} was hit at {subs}.");
                                return;
                            }
                        }

                    }
                    currentTime = greenLightDuration;

                }
                else
                {
                    cars.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            if (!isCrashed)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carPass} total cars passed the crossroads.");
            }


        }
    }
}
