using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    class CoffeeStore
    {
        Ingredients ingredients;
        Operations operations;
        public int Balance { get; private set; }
        public CoffeeStore()
        {
            operations = new Operations();
            ingredients = new Ingredients();

        }
        #region Enter Money     
        public void EnterCoins()
        {
            Console.Write($"\nYour balance is {Balance}\nPlease enter coins: ");
            int coins;
            int.TryParse(Console.ReadLine(), out coins);
            if(coins == 50 || coins == 100 || coins == 200 || coins == 500)
            {
                Balance += coins;
            }
            else
            {
                throw new NotSupportedException("Error:Trying input incorrect coins");
            }
            Console.Write("Press 1 to for add coints or any key to continue: ");   
            if (Console.ReadKey().Key==ConsoleKey.NumPad1)
            {
               EnterCoins();
            }
            else
            {
                CoffeeKind();
            }
            
            Console.Clear();
        }
        #endregion

        #region Choose Coffee
        public void CoffeeKind()
        {
            if (ingredients.Coffee < 10 || ingredients.Water < 50 || ingredients.Sugar < 10)
            {
                Console.WriteLine("Sorry coffee Machine dont work");
                Console.WriteLine($"You returned your {Balance} change ");
                Balance -= Balance;
                return;
            }
            Console.Write($"\nYour balance is {Balance}\nChoose your coffee from 1 to 10 and push it: ");
            int num;
            int.TryParse(Console.ReadLine(), out num);
            if (Balance < 50)
            {
                EnterCoins();
            }
            switch (num)
            {
                case 1:
                case 2:
                case 3:
                    CoffeeKindSmall(num);
                    break;
                case 4:
                case 5:     
                    CoffeeKindMedium(num);
                    break;
                case 6:
                case 7:
                    CoffeeKindBig(num);
                    break;
                case 8:
                case 9:
                case 10:
                    CoffeeKindBigPlus(num);
                    break;
                default:
                    Console.WriteLine("Error:Incorrect choose\nEnter from 1 to 10 number");
                    CoffeeKind();
                    break;
            }
        }
        #endregion

        #region Coffee Kinds
        private void CoffeeKindSmall(double  num)
        {
            Balance -= 50;
            ingredients.Water -= 50 ;
            ingredients.Coffee -= num / 10 * 3;
            ingredients.Sugar -= num / 10 * 2;
            Upgrade(num);

        }
        private void CoffeeKindMedium(int num)
        {
            if (Balance>=100)
            {
                Balance -= 100;
                ingredients.Water -= 100;
                ingredients.Coffee -= num * 3;
                ingredients.Sugar -= num * 2;
                Upgrade(num);
            }
            else
            {
                Console.WriteLine($"you don't have enough money, your balance is {Balance}");
                CoffeeKind();
            }
        }
        private void CoffeeKindBig(int num)
        {
            if (Balance >= 200)
            {
                Balance -= 200;
                ingredients.Water -= 100;
                ingredients.Coffee -= num * 3;
                ingredients.Sugar -= num * 2;
                Upgrade(num);
            }
            else
            {
                Console.WriteLine($"you don't have enough money, your balance is {Balance}");
                CoffeeKind();
            }

        }
        private void CoffeeKindBigPlus(int num)
        {
            if (Balance >= 250)
            {
                Balance -= 250;
                ingredients.Water -= 100;
                ingredients.Coffee -= num * 3;
                ingredients.Sugar -= num * 2;
                Upgrade(num);
            }
            else
            {
                Console.WriteLine($"you don't have enough money, your balance is {Balance}");
                CoffeeKind();
            }
        }
        #endregion

        #region Update changes
        private void Upgrade(double num)
        {
            Console.Clear();
            Console.WriteLine($"You choose number {num}: coffee Ready, please take it");
            Console.WriteLine($"your Balance = {Balance}");
            ingredients.UpgradeIngredients();
            
            if (Balance >= 50)
            {
                Console.Write("If you want to take your change enter 0\nElse` any key to continue ");      
                if (Console.ReadKey().Key == ConsoleKey.NumPad0)
                {
                    Console.WriteLine($"\nYou returned your {Balance} change ");
                    Balance -= Balance;
                    EnterCoins();
                }
                else
                {
                    CoffeeKind();
                }               
            }
            else
            {
                EnterCoins();
            }
        }
        #endregion
    }
}
