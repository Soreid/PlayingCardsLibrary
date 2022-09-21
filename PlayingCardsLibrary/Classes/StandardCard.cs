using PlayingCardsLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCardsLibrary.Classes
{
    public class StandardCard : ICard
    {
        public string Name { get; set; }
        public int Value { get;set; }
        public int Suit { get; set; }

        public StandardCard(string name, int value, int suit)
        {
            this.Name = name;
            this.Value = value;
            this.Suit = suit;
        }

        public int[] GetAttributes()
        {
            return new int[] { Value, Suit };
        }
    }
}
