namespace Lab_Intro_and_Basic_Syntax
{
    public class Program
    {
        static void Main(string[] args)
        {
            string name=Console.ReadLine();
            int age=int.Parse(Console.ReadLine());
            double averageGrade=double.Parse(Console.ReadLine());
            Console.WriteLine($"Name: {name}, Age: {age}, Grade: {averageGrade:f2}");
        }
    }
}