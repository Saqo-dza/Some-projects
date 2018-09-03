using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class Ingredients
    { 
        public double Coffee { get;internal set; } 
        public double Water { get; internal set; }
        public double Sugar { get; internal set; }
        string path = @"c:\CoffeeMachine\DB.txt";

        public Ingredients()
        {
            GetIngredients();
        }
        #region Get Ingredients
        private void GetIngredients()
        {
            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        int index = 0;
                        double count;
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] s = { ": " };
                            index++;
                            if (index == 1)
                            {
                                double.TryParse(line.Split(s, StringSplitOptions.None)[1].ToString(), out count);
                                Water = count;
                            }
                            if (index == 2)
                            {
                                double.TryParse(line.Split(s, StringSplitOptions.None)[1].ToString(), out count);
                                Sugar = count;
                            }
                            if (index == 3)
                            {
                                double.TryParse(line.Split(s, StringSplitOptions.None)[1].ToString(), out count);
                                Coffee = count;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                } 
            }
            else
            {
                throw new FileNotFoundException("Error: File not exists");
            }     
        }
        #endregion

        #region Upgrade Ingredients
        internal void UpgradeIngredients()
        {
            if (File.Exists(path))
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine("water: " + Water);
                        sw.WriteLine("sugar: " + Sugar);
                        sw.WriteLine("coffee: " + Coffee);
                        sw.AutoFlush = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                } 
            }
            else
            {
                throw new FileNotFoundException("Error: File not exists");
            }

        }
        #endregion
    }
}
