using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PELib;
using System.IO;

namespace PE54
{
    public class Card : IComparable
    {
        const int JACK = 11;
        const int QUEEN = 12;
        const int KING = 13;
        public const int ACE = 14;

        string card;

        public Card( string card)
        {
            this.card = card;
        }

        public string GetSuit()
        {
            return card.Substring(1, 1);
        }

        public int GetRank()
        {
            int rank;
            string srank = card.Substring(0, 1);
            if (srank == "T") rank = 10;
            else if (srank == "J") rank = JACK;
            else if( srank == "Q") rank = QUEEN;
            else if( srank == "K") rank = KING;          
            else if( srank == "A") rank = ACE;
            else rank = int.Parse(srank);
            return rank;
        }

        public int CompareTo(Object card2)
        {
            int Rank1 = this.GetRank();
            int Rank2 = ((Card) card2).GetRank();
            return Rank1.CompareTo(Rank2); // 0 = same, 
        }

        public double CompareRank(Card card2)
        {
            int cmp = CompareTo(card2);
            switch( cmp)
            {
                case -1: return 0;
                case 0: return 0.5;
                case 1: return 1;
                default: throw new Exception( "bad cmp");
            }

            
        }

        public string ToString()
        {
            return card;
        }


    }

    public class Hand : List<Card>
    {
        public string Dump()
        {
            string s = "";
            for (int ii = 0; ii < this.Count; ii++)
            {
                s += this[ii].ToString() + " ";
            }
            return s;
        }

        public bool IsStraight(ref int tieBreak)
        {
            int prevRank = this[0].GetRank();
            for (int ii = 1; ii < 5; ii++)
            {
                if (this[ii].GetRank() - prevRank != 1)
                {
                    return false;
                }
                prevRank = this[ii].GetRank();
            }
            tieBreak = this[4].GetRank();
            return true;
        }

        public bool IsFlush( ref int tieBreak)
        {
            string prevSuit = this[0].GetSuit();
            for (int ii = 1; ii < 5; ii++)
            {
                if (this[ii].GetSuit() != prevSuit)
                {
                    return false;
                }
            }
            tieBreak = this[4].GetRank();
            return true;
        }

        public bool IsStraightFlush( ref int tieBreak)
        {
            return (this[4].GetRank() != Card.ACE) && IsStraight(ref tieBreak) && IsFlush(ref tieBreak);
        }

        public bool Is4OfAKind( ref int tieBreak)
        {
            if (this[0].GetRank() == this[3].GetRank() )
            {
                tieBreak = this[0].GetRank() * 15 + this[4].GetRank();
                return true;
            }
            else if( this[1].GetRank() == this[4].GetRank())
            {

                tieBreak = this[1].GetRank() * 15 + this[0].GetRank();
                return true;
            }
            return false;
        }

        public bool Is3OfAKind(ref int tieBreak)
        {
            if (this[0].GetRank() == this[2].GetRank())
            {
                tieBreak = this[0].GetRank();
                return true;
            }
            else if (this[1].GetRank() == this[3].GetRank())
            {

                tieBreak = this[1].GetRank();
                return true;
            }
            else if (this[2].GetRank() == this[4].GetRank())
            {

                tieBreak = this[2].GetRank();
                return true;
            }
            return false;
        }

        public bool Is2Pair(ref int tieBreak)
        {
            if (this[0].GetRank() == this[1].GetRank() && this[2].GetRank() == this[3].GetRank())
            {
                tieBreak = this[2].GetRank() * 15 + this[0].GetRank();
                return true;
            }
            else if (this[0].GetRank() == this[1].GetRank() && this[3].GetRank() == this[4].GetRank())
            {

                tieBreak = this[3].GetRank() * 15 + this[0].GetRank();
                return true;
            }
            else if (this[1].GetRank() == this[2].GetRank() && this[3].GetRank() == this[4].GetRank())
            {
                tieBreak = this[3].GetRank() * 15 + this[1].GetRank();
                return true;
            }
            return false;
        }

        public bool IsPair(ref int tieBreak)
        {
            if (this[0].GetRank() == this[1].GetRank())
            {
                tieBreak = this[0].GetRank() *15 + this[4].GetRank();
                return true;
            }
            else if (this[1].GetRank() == this[2].GetRank())
            {
                tieBreak = this[1].GetRank() * 15 + this[4].GetRank();
                return true;
            }
            else if (this[2].GetRank() == this[3].GetRank())
            {
                tieBreak = this[2].GetRank() * 15 + this[4].GetRank();
                return true;
            }
            else if (this[3].GetRank() == this[4].GetRank())
            {
                tieBreak = this[3].GetRank()*15 + this[2].GetRank();
                return true;
            }
            return false;
        }



        public bool IsFullHouse( ref int tieBreak)
        {
            if ((this[0].GetRank() == this[2].GetRank()) && (this[3].GetRank() == this[4].GetRank()))
            {
                tieBreak = this[0].GetRank();
                return true;
            }
            else if ((this[0].GetRank() == this[1].GetRank()) && (this[2].GetRank() == this[4].GetRank()))
            {

                tieBreak = this[2].GetRank();
                return true;
            }
            return false;
        }

        public void GetScore(ref int score, ref int tieBreak)
        {
            if (this.IsStraightFlush(ref tieBreak)) // No special logic for royal flush.
            {
                score = 8;
                return;
            }
            else if (Is4OfAKind( ref tieBreak))
            {
                score = 7;
                return;
            }
            else if (IsFullHouse( ref tieBreak))
            {
                score = 6;
                return;
            }
            else if (IsFlush( ref tieBreak))
            {
                score = 5;
                return;
            }
            else if (IsStraight(ref tieBreak ))
            {
                score = 4;
                return;
            }
            else if (Is3OfAKind(ref tieBreak))
            {
                score = 3;
                return;
            }
            else if (Is2Pair( ref tieBreak))
            {
                score = 2;
                return;
            }
            else if (IsPair( ref tieBreak))
            {
                score = 1;
                return;
            }
            else
            {
                score = 0;
                tieBreak = this[4].GetRank(); // highest sorted card;
                return;
            }


        }

        // 1=win 0.5=tie 0=lose
        public float CompareHands( Hand that)
        {
            int thisScore =0;
            int thatScore =0;
            int thisTieBreak =0;
            int thatTieBreak =0;

            this.GetScore( ref thisScore, ref thisTieBreak);
            that.GetScore(ref thatScore, ref thatTieBreak);

            float compare = thisScore.CompareTo(thatScore);
            if (compare != 0)
            {
                return compare;
            }
            return thisTieBreak.CompareTo(thatTieBreak);
        }
        

    }

    class Program
    {
        static void Main(string[] args)
        {
            int playerOneWins = 0;

            

            string[] lines = File.ReadAllLines("hands.txt");
            var Hands1 = new List<Hand>();
            var Hands2 = new List<Hand>();

            foreach (string line in lines)
            {
                string[] cards = line.Split(' ');
                Hand hand = new Hand();
                for( int ii=0; ii<5; ii++)
                {
                    hand.Add( new Card(cards[ii]));
                }
                hand.Sort();
                Hands1.Add( hand);

                hand = new Hand();
                for( int ii=5; ii<10; ii++)
                {
                    hand.Add(new Card(cards[ii]));
                }
                hand.Sort();
                Hands2.Add(hand);
            }

            for(int ii=0; ii<Hands1.Count; ii++)
            {
                Console.WriteLine(Hands1[ii].Dump() + " - " + Hands2[ii].Dump() );

                if( Hands1[ii].CompareHands( Hands2[ii]) > 0)
                {
                    playerOneWins++;
                }
            }

            // Player one wins.
            Util.ShowResult(playerOneWins);

        }


    }
}
