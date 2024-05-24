using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_logic
{
    public class GameManeger
    {
        private int  m_Pairs;
        private readonly char[,] m_EmptyArr, m_CharArr;

        public GameManeger(int i_Rows, int i_Columns, int i_Pairs, char[,] i_EmptyArr, char[,] i_CharArr)
        {
            this.m_EmptyArr = i_EmptyArr;
            this.m_CharArr = i_CharArr;
            m_Pairs = i_Pairs;
        }

        public int Pairs
        {
            get
            {
                return m_Pairs;
            }
        }

        public Player CheckPairs(Player io_Player, string i_FirstChar, string i_SeconedChar)
        {
            io_Player.PreviousPoints = io_Player.CurrentPoints;
            if (i_SeconedChar.Equals(i_FirstChar))
            {
                io_Player.CurrentPoints++;
                this.m_Pairs--;
            }

            return io_Player;
        }

        public Player Winner(Player i_FirstPlayer, Player i_SeconedPlayer)
        {
            Player winner = new Player(null, 0, 0);


            if (i_FirstPlayer.CurrentPoints > i_SeconedPlayer.CurrentPoints)
            {
                winner = i_FirstPlayer;
            }
            else if (i_FirstPlayer.CurrentPoints < i_SeconedPlayer.CurrentPoints)
            {
                winner = i_SeconedPlayer;
            }
            else
            {
                winner = null;
            }

            return winner;
        }
    }
}