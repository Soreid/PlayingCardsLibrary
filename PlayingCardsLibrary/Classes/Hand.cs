using PlayingCardsLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace PlayingCardsLibrary.Classes
{
    public class Hand : IHand
    {
        public List<ICard> Contents { get; set; }

        public Hand()
        {
            Contents = new();
        }

        public int[] Analyze()
        {
            return new int[2];
        }

        public bool Compare(List<int> hand, List<int> model)
        {
            model.Sort();
            bool result = false;

            List<int> dist = hand.Distinct().ToList();
            List<int> values = new List<int>();

            for(int i = 0; i < dist.Count(); i++)
            {
                values.Add(0);
                foreach(int j in hand)
                {
                    if (dist[i] == j)
                        values[i]++;
                }
            }

            values.Sort();

            for (int i = 0; i < values.Count; i++)
            {
                if (values[i] == model[i])
                {
                    result = true;
                }
                else
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}
