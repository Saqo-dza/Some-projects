using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    class Program
    {
        static void Main()
        {
            
            Console.WriteLine("Dear buyer our coffee maker can only take these coins` 50, 100, 200, 500");
            CoffeeStore coffeeStore = new CoffeeStore();
            try
            {
                coffeeStore.EnterCoins();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Main();
            }
            
        }

    }
}
