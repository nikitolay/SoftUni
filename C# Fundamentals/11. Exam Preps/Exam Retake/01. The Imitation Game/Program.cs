using System;

namespace _01._The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            while (true)
            {
                string[] command = Console.ReadLine().Split("|");
                if (command[0] == "Decode")
                {
                    break;
                }
                switch (command[0])
                {
                    case "Move":
                        string endOfString = "";
                        int length = int.Parse(command[1]);
                        for (int i = 0; i < length; i++)
                        {
                            endOfString += text[i];
                            text = text.Remove(i, 1);
                            i--;
                            length--;
                        }
                        text += endOfString;
                        break;
                    case "Insert":
                        text = text.Insert(int.Parse(command[1]), command[2]);
                        break;
                    case "ChangeAll":
                        for (int i = 0; i < text.Length; i++)
                        {
                            if (text[i] == char.Parse(command[1]))
                            {
                                text = text.Replace(text[i], char.Parse(command[2]));
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"The decrypted message is: {text}");
        }
    }
}
