using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Calc
{
    public static class MathMethod
    {
        public static double Sum(double a, double b)//sum
        {
            return a + b;
        }
        public static double Difference(double a, double b)//Difference
        {
            return a - b;
        }
        public static double Mult(double a, double b)//Mult
        {
            return a * b;
        }
        public static double Divide(double a, double b)//Divide
        {
            if (!(b == 0))
            {
                return a / b;
            }
            return 0.000;
        }
        public static double Pracent(double a, double b)//Pracent
        { 
            return (a*b)/100;
        }
        public static double Pow(double a, double b)//Pow
        {
            double res=1;
            if (b == 0)
            {
                return 1;
            }
            else if(b == 1)
            {
                return a;
            }
            else if (b > 1)// tvi drakan astichan
            {
                for (int i = 1; i <= b; i++)
                {
                    res *= a;
                }
            }
            else
            {
                for (int i = 0; i > b; i--)// tvi minus astichan
                {
                    res = res * a;
                }
                res= 1 / res;
            }
            return res;
        }
        public static double Sqrt(double a)//sqrt
        {
            double res = 1 ; 
            double b = 1;

            if (a > 0 && a < 1000000000001 )
            {
                if (a <= 25)
                {
                    for (int i = 0; i < a; i++)
                    {
                        res = (b + a / b) / 2;
                        b = res;
                    }
                }
                else
                {
                    for (int i = 0; i <= 25; i++)
                    {
                        res = (b + a / b) / 2;
                        b = res;
                    }
                }  
            }
            else
            {
                Console.WriteLine("ERROR: Number diapason must be from 1 to 100000000000");
            }    
            return res;
        }
       
        
    }
}
