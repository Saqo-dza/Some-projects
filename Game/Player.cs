using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less_7
{
    class Player
    {
        string Name;
        int Score=20;
        int PlayerBid;
        int[] PlayerNum;
        public bool exit=true;

        public Player()// constructor 
        {
            Console.Write("Player Name: ");
            Name = Console.ReadLine();
            Console.WriteLine($"Player Name is {Name}, Scor = {Score}\n");
            EnterPlNum();
        }
        public void EnterPlNum()// setter for PlayerBid
        {  
            Console.Write("Enter Your Bid Or Exit For Cancel: ");
            string str = Console.ReadLine();
            if (str.ToLower() == "exit")
            {
                exit = false;
            }
            else
            {       
                int.TryParse(str, out PlayerBid);
            }   
        }
        public int PlayerScore// getter & setter for Score
        {
            get { return Score; }
            set { Score = value; }  
        }
        public string PlayerName// getter & setter for Name
        {
            get { return Name; }
            set { Name = value; }
        }
        public int PlBid// getter for PlayerBid
        {
            get { return PlayerBid; } 
        }
        public void PlayerBidArr(int n)// player number 
        {
            Console.WriteLine("Enter Your Number: ");
            PlayerNum = new int[n];
            for (int i = 0; i < n; i++)
            {
                int.TryParse(Console.ReadLine(), out PlayerNum[i]);
            }
        }
        public int[] GetPlayerNum// getter for PlayerNum
        {
            get { return PlayerNum; }
        }
    }
}
