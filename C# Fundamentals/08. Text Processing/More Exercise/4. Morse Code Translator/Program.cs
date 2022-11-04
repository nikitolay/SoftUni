using System;
using System.Collections.Generic;

namespace _4._Morse_Code_Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] morseCode = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, char> morseToEnglish = new Dictionary<string, char>()
            {
                {".-" ,'A'},
                {"-..." ,'B'},
                {"-.-." ,'C'},
                {"-.." ,'D'},
                {"." ,'E'},
                {"..-." ,'F'},
                {"--." ,'G'},
                {"...." ,'H'},
                {".." ,'I'},
                {".---" ,'J'},
                {"-.-" ,'K'},
                {".-.." ,'L'},
                {"--" ,'M'},
                {"-." ,'N'},
                {"---" ,'O'},
                {".--." ,'P'},
                {"--.-" ,'Q'},
                {".-." ,'R'},
                {"..." ,'S'},
                {"-" ,'T'},
                {"..-" ,'U'},
                {"...-" ,'V'},
                {".--" ,'W'},
                {"-..-" ,'X'},
                {"-.--" ,'Y'},
                {"--.." ,'Z'},
            };
            string finalText = "";
            for (int i = 0; i < morseCode.Length; i++)
            {
                if (morseCode[i].Contains("|"))
                {
                    morseCode[i].Replace("|", " ");
                }
                if (morseToEnglish.ContainsKey(morseCode[i]))
                {
                    finalText += morseToEnglish[morseCode[i]];
                }
                else
                {
                    finalText += " ";
                }
            }
            Console.WriteLine(finalText);
        }
    }
}
