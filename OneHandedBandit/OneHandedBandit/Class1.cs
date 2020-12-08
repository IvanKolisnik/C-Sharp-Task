using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace OneHandedBandit
{
    public class Bandit
    {
        private const int SYMBOL_COUNT = 5;
        private const int CYLINDERS = 3;
        private const double WIN_MULTIPLIER = 10;
        private int _wallet;
        Random rand = new Random();

        public int Wallet
        {
            get
            {
                return _wallet;
            }

             set
            {
                _wallet = value;
            }
        }
        public Bandit(int wallet)
        {
            _wallet = wallet;
        }

        public int Vypocet(int a, int b)
        {
            int vypocet = b + a * 10;
          
            return  vypocet;
          

        }
        public int vypocet2(int a, int b)
        {
            int vypocet2 = b - a;
            
            return vypocet2;
            
        }

        public Symbol x;
        public Symbol y;
        public Symbol z;
        public bool Verify()
        {

             int ot1 = rand.Next(0, 5);
            int ot2 = rand.Next(0, 5);
             int ot3 = rand.Next(0, 5);
             x = (Symbol)ot1;
             y = (Symbol)ot2;
             z = (Symbol)ot3;

            if (ot1 == ot2 && ot1 == ot3)
            {
                return true;
            }
            else
            {
                return false;
            }






        }
    }
}
