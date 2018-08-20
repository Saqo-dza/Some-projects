using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p = new Player();
            Game g = new Game(p);
            g.YesOrNo();

        }
    }
}
