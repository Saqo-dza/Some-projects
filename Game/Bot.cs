using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less_7
{
    class Bot
    {      
        Random random = new Random();
        int[] BotArr;
        public void BotGenNumber(int n)// gen. rondom number 
        {
            BotArr = new int[n];
            for (int i = 0; i < n; i++)
            {
                BotArr[i] = random.Next(0, 10); 
            }
        }
        public int[] GetGenNumber// getter for BotArr
        {
            get { return BotArr; }
        }
    }
}
