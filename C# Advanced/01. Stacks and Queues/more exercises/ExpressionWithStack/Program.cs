using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionWithStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var expression = "3/3*0";
            //ne poddurja 2 + -3       ako imame poweche operatori otkolkoto chisla//ako ne ni stigat chislata da si napravim operaciite//vinagi trqbwa d aimame edin chislo poweche otkolkoto operacii
            var result = Evaluate(expression);
            Console.WriteLine(result);




        }
        static double Evaluate(string expression)
        {
            var allowedOperators = "+-/*";//TODO: pow ^
            var numbers = new Stack<double>();
            var operators = new Stack<char>();//operacii

            for (int i = 0; i < expression.Length; i++)
            {
                var @char = expression[i];
                if (@char == '(')
                {
                    operators.Push(@char);
                }
                else if (@char == ')')
                {
                    while (operators.Peek() != '(')
                    {
                        var op = operators.Pop();
                        var param2 = numbers.Pop();
                        var param1 = numbers.Pop();
                        var newValue = ApplyOperations(op, param1, param2);
                        numbers.Push(newValue);
                    }
                    operators.Pop();// (

                }
                else if (allowedOperators.Contains(@char))
                {
                    while (operators.Count > 0 && Priority(operators.Peek()) >= Priority(@char))//ako ima operatori s po-visok prioritet ot dadeniq (char)
                    {
                        var op = operators.Pop();//vzemame operatora i go prilagame vurhu poslednite dwe natrupani chisla
                        var param2 = numbers.Pop();
                        var param1 = numbers.Pop();
                        var newValue = ApplyOperations(op, param1, param2);
                        numbers.Push(newValue);
                    }
                    operators.Push(@char);
                }
                else if (char.IsDigit(@char) || @char == '.')
                {
                    var number = new StringBuilder();
                    while (char.IsDigit(@char) || @char == '.')
                    {
                        number.Append(@char);
                        i++;
                        if (i == expression.Length)
                        {
                            break;
                        }
                        @char = expression[i];
                        
                    }
                    i --;
                    numbers.Push(double.Parse(number.ToString()));
                }

            }
            while (operators.Count>0)
            {
                var op = operators.Pop();
                var param2 = numbers.Pop();
                var param1 = numbers.Pop();
                var newValue = ApplyOperations(op, param1, param2);
                numbers.Push(newValue);
            }
            return numbers.Pop();
        }
        static double ApplyOperations(char operation, double operand1, double operand2)
        {
            switch (operation)
            {
                case '+': return operand1 + operand2;
                case '-': return operand1 - operand2;
                case '*': return operand1 * operand2;
                case '/': return operand1 / operand2;
                default: return 0.0;

            }
        }
        static int Priority(char operation)
        {
            switch (operation)
            {
                case '+': return 1;
                case '-': return 1;
                case '*': return 2;
                case '/': return 2;
                default: return 0;

            }
        }
    }
}
