using PlayingCardsLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCardsLibrary.Classes
{
    public class Deck : IDeck
    {
        public List<ICard> Cards { get; set; }

        public void InitializeStandardDeck()
        {
            Cards = new List<ICard>();
            for(int i = 2; i < 15; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    //Set display name for each card
                    string suitN, valueN;
                    switch (j)
                    {
                        case 0:
                            suitN = "Clubs";
                            break;
                        case 1:
                            suitN = "Hearts";
                            break;
                        case 2:
                            suitN = "Spades";
                            break;
                        case 3:
                            suitN = "Diamonds";
                            break;
                        default:
                            suitN = "";
                            break;
                    }
                    switch (i)
                    {
                        case 11:
                            valueN = "Jack";
                            break;
                        case 12:
                            valueN = "Queen";
                            break;
                        case 13:
                            valueN = "King";
                            break;
                        case 14:
                            valueN = "Ace";
                            break;
                        default:
                            valueN = i.ToString();
                            break;
                    }
                    Cards.Add(new StandardCard(valueN + " of " + suitN, i, j));
                }
            }
        }

        public ICard Draw()
        {
            if (Cards.Count > 0)
            {
                ICard card = Cards[0];
                Cards.RemoveAt(0);
                return card;
            }
            else
            {
                return null;
            }
        }

        public void Shuffle()
        {
            Random r = new Random();

            List<ICard> shuffle = new List<ICard>();
            while(Cards.Count > 0)
            {
                int i = r.Next(Cards.Count);
                ICard card = Cards[i];
                Cards.RemoveAt(i);
                shuffle.Add(card);
            }

            Cards = shuffle;
        }
    }
}
