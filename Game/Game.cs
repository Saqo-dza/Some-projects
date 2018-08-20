using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less_7
{
    class Game
    {
        Bot B;
        Player P;
        int GameLevel;
        public Game(Player x)
        {
            this.B = new Bot();
            P=x;
        }
        public void YesOrNo()
        {
            int correctAnswers = 0;      
            while (P.PlayerScore > 0 && P.PlBid < P.PlayerScore && P.exit)
            {
                Console.Write("Enter game level: 1 = easy 2 = medium 3 = difficult. Game level = ");
                int.TryParse(Console.ReadLine(), out GameLevel);
                B.BotGenNumber(GameLevel);
                P.PlayerBidArr(GameLevel);

                for (int i = 0; i < GameLevel; i++)
                {
                    for (int j = 0; j < GameLevel; j++)
                    {
                        if (B.GetGenNumber[i] == P.GetPlayerNum[j])
                        {
                            correctAnswers++;
                        }
                    }
                }
                if (correctAnswers == GameLevel)
                {
                    P.PlayerScore += P.PlBid * correctAnswers;
                    Console.WriteLine($"Yra {P.PlayerName} Win.!!!, new Score = {P.PlayerScore}");
                    P.EnterPlNum();
                }
                else
                {
                    P.PlayerScore -= P.PlBid;
                    Console.WriteLine($"Bot Win.!!!, new Score = {P.PlayerScore}");
                    P.EnterPlNum();
                }
            }
        }
    }
}
