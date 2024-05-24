using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_logic
{

    public class StartGame
    {
        public StartGame()
        {
           FormMemoryGame memoryGame = new FormMemoryGame();
            memoryGame.Create();
        }
    }
}