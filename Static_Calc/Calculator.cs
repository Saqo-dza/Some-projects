using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Calc
{
    static class Calculator
    {
        static string str;
        static double a;
        static double b;
        static int index;
        static char[] signs = { '-', '+', '*', '/' ,'^','#','%'};
        public static void Calculate()//calculate method
        {
            str = "";
            while (!(str.ToLower() == "exit"))
            {
                Input();
                Execute();
            }
        }
        private static void Input()// string convert to integer
        {
            str = Console.ReadLine();
            index = -1;
            Console.Clear();

            for (int i = 0; i < signs.Length; i++)
            {
                if (!str.Contains(signs[i]))
                {
                    continue;
                }
                string[] s = str.Split(signs[i]);
                index = i;
                double.TryParse(s[0], out a);
                double.TryParse(s[1], out b);
            }
        }
        private static void Execute()// Operations +, -, *, /
        {
            if (index >= 0)
            {
                switch (signs[index])
                {
                    case '+':
                        PrintResult('+', MathMethod.Sum(a, b));
                        break;

                    case '-':
                        PrintResult('-', MathMethod.Difference(a, b));
                        break;

                    case '*':
                        PrintResult('*', MathMethod.Mult(a, b));
                        break;

                    case '/':
                        PrintResult('/', MathMethod.Divide(a, b));
                        break;

                    case '^':
                        PrintResult('^', MathMethod.Pow(a, b));
                        break;
                    case '#':
                        PrintResult('#', MathMethod.Sqrt(a));
                        break;

                    case '%':
                        PrintResult('%', MathMethod.Pracent(a,b));
                        break;
                    default:
                        Console.WriteLine("Error: Something is wrong");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Error: Something is wrong");
            }
        }
        private static void PrintResult(char c,double result)// print result
        {
            string s;
            if (!(result==0.000))
            {
                s = string.Format("{0:0.####}", result);
                Console.WriteLine("{0} {1} {2} = {3}", a, c, b, s);
            }
            else
            {
                Console.WriteLine("Error: Cannot divide by zero ");
            }

        }
    }
    
}
