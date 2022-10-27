using System;

namespace _11._Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int snowBallValueMax = int.MinValue;
            int snowballSnowMax = 0;
            int snowballTimeMax = 0;
            int snowballQualityMax = 0;
            for (int i = 0; i < n; i++)
            {

                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                int snowBallValue = (int)Math.Pow((snowballSnow / snowballTime), snowballQuality);
                if (snowBallValue > snowBallValueMax)
                {
                    snowBallValueMax = snowBallValue;
                    snowballSnowMax = snowballSnow;
                    snowballTimeMax = snowballTime;
                    snowballQualityMax = snowballQuality;
                }
            }
            Console.WriteLine($"{snowballSnowMax} : {snowballTimeMax} = {snowBallValueMax} ({snowballQualityMax})");

        }
    }
}
