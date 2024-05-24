using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex05_logic
{
    public class Input
    {
        private readonly GameManeger m_GameManeger;
        private readonly int r_Rows, r_Columns;
        
        public Input(Board i_Board, string i_FirstName, string i_SecondName, int i_Rows, int i_Columns)
        {
            this.r_Rows = i_Rows;
            this.r_Columns = i_Columns;
            this.m_GameManeger = new GameManeger(this.r_Rows, this.r_Columns, (this.r_Rows * this.r_Columns) / 2,
            i_Board.EmptyArr, i_Board.CharArrayForTheBord);
        }

        public GameManeger GameManeger
        {
            get
            {
                return m_GameManeger;
            }
        }

        public Player InputPlayer(Player io_Player, string i_FirstChar, string i_SeconedChar)
        {
            io_Player = this.m_GameManeger.CheckPairs(io_Player, i_FirstChar, i_SeconedChar);

            return io_Player;
        }
    }
}