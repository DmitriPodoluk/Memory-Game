using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_logic
{
    public class Board
    {
        private readonly int r_Rows = 0, r_Columns = 0;
        private char[,] m_EmptyArr, m_CharArrayForTheBord;

        public Board(int i_Rows, int i_Columns)
        {
            this.m_EmptyArr = new char[i_Rows, i_Columns];
            this.m_CharArrayForTheBord = new char[i_Rows, i_Columns];
            this.r_Rows = i_Rows;
            this.r_Columns = i_Columns;

            for (int i = 0; i < this.r_Rows; i++)
            {
                for (int j = 0; j < this.r_Columns; j++)
                {
                    this.m_EmptyArr[i, j] = ' ';
                    this.m_CharArrayForTheBord[i, j] = ' ';
                }
            }

            this.m_CharArrayForTheBord = Build(' ', (this.r_Columns * this.r_Rows) / 2);
        }

        public char[,] CharArrayForTheBord
        {
            get
            {
                return m_CharArrayForTheBord;
            }
            set
            {
                m_CharArrayForTheBord = (char[,])value;
            }
        }

        public char[,] EmptyArr
        {
            get
            {
                return m_EmptyArr;
            }
            set
            {
                m_EmptyArr = (char[,])value;
            }
        }

        public char[,] Build(char i_CharToAddToTheBord, int i_HowMenyCharsLeftToAdd)
        {
            Random rnd = new Random();
            int currentI, currentJ, row, columns;

            while (i_HowMenyCharsLeftToAdd != 0)
            {
                if (i_CharToAddToTheBord != ' ')
                {
                    currentI = rnd.Next(0, this.r_Rows);
                    currentJ = rnd.Next(0, this.r_Columns);

                    while (this.m_CharArrayForTheBord[currentI, currentJ] != ' ')
                    {
                        currentI = rnd.Next(0, this.r_Rows);
                        currentJ = rnd.Next(0, this.r_Columns);
                    }
                    this.m_CharArrayForTheBord[currentI, currentJ] = i_CharToAddToTheBord;
                    i_HowMenyCharsLeftToAdd -= 1;
                    i_CharToAddToTheBord = ' ';

                    return Build(i_CharToAddToTheBord, i_HowMenyCharsLeftToAdd);
                }

                i_CharToAddToTheBord = (char)rnd.Next('A', 'z');
                while (i_CharToAddToTheBord < 'a' && i_CharToAddToTheBord > 'Z')
                {
                    i_CharToAddToTheBord = (char)rnd.Next('A', 'z');
                }

                for (row = 0; row < this.r_Rows; row++)
                {
                    for (columns = 0; columns < this.r_Columns; columns++)
                    {
                        if (i_CharToAddToTheBord == this.m_CharArrayForTheBord[row, columns])
                        {
                            i_CharToAddToTheBord = ' ';
                        }
                    }
                }

                currentI = rnd.Next(0, this.r_Rows);
                currentJ = rnd.Next(0, this.r_Columns);
                while (this.m_CharArrayForTheBord[currentI, currentJ] != ' ')
                {
                    currentI = rnd.Next(0, this.r_Rows);
                    currentJ = rnd.Next(0, this.r_Columns);
                }

                this.m_CharArrayForTheBord[currentI, currentJ] = i_CharToAddToTheBord;
            }
            return this.m_CharArrayForTheBord;
        }
    }
}