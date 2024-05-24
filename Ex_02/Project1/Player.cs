using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_logic
{
    public class Player
    {
        private string m_PlayerName;
        private int m_PreviousPoints;
        private int m_CurrentPoints;

        public Player(string i_Name, int i_PreviousPoints, int i_CurrentPoints)
        {
            this.m_PlayerName = i_Name;
            this.m_PreviousPoints = i_PreviousPoints;
            this.m_CurrentPoints = i_CurrentPoints;
        }
        
        public string PlayerName
        {
            get
            {
                return m_PlayerName;
            }
            set
            {
                m_PlayerName = (string)value;
            }
        }   
        
        public int PreviousPoints
        {
            get
            {
                return m_PreviousPoints;
            }
            set
            {
                m_PreviousPoints = (int)value;
            }
        }      
        
        public int CurrentPoints
        {
            get
            {
                return m_CurrentPoints;
            }
            set
            {
                m_CurrentPoints = (int)value;
            }
        }
    }
}