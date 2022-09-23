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

        public int[] Analyze(List<ICard> cards)
        {
            int[] result = new int[2];
            int rank = 0;
            int value = 0;

            Dictionary<int, int> frequency = new Dictionary<int, int>();

            foreach(ICard card in cards)
            {
                if (frequency.ContainsKey(card.GetAttributes()[0]))
                    frequency[card.GetAttributes()[0]]++;
                else
                    frequency.Add(card.GetAttributes()[0], 1);
            }

            List<int> valueFrequency = frequency.Values.ToList();

            bool straight = (Compare(valueFrequency, new List<int>() { 1, 1, 1, 1, 1 }) && 
                             frequency.Keys.Max() - frequency.Keys.Min() < 5);

            bool flush = !cards.Any(x => cards[0].GetAttributes()[1] != x.GetAttributes()[1]);

            if(flush && straight && frequency.Keys.Max() == 14)
            {
                rank = 9;
                value = 14;
            }
            else if (flush && straight)
            {
                rank = 8;
                value = frequency.Keys.Max();
            }
            else if (Compare(valueFrequency, new List<int>() { 4, 1 }))
            {
                rank = 7;
                foreach(int v in frequency.Keys)
                {
                    if (frequency[v] == 4) { value = v; break; }
                }
            }
            else if (Compare(valueFrequency, new List<int>() { 3, 2 }))
            {
                rank = 6;
                foreach (int v in frequency.Keys)
                {
                    if (frequency[v] == 3) { value = v; break; }
                }
            }
            else if (flush)
            {
                rank = 5;
                value = frequency.Keys.Max();
            }
            else if (straight)
            {
                rank = 4;
                value = frequency.Keys.Max();
            }
            else if (Compare(valueFrequency, new List<int>() { 3, 1, 1 }))
            {
                rank = 3;
                foreach (int v in frequency.Keys)
                {
                    if (frequency[v] == 3) { value = v; break; }
                }
            }
            else if (Compare(valueFrequency, new List<int>() { 2, 2, 1 }))
            {
                rank = 2;
                foreach (int v in frequency.Keys)
                {
                    if (frequency[v] == 2 && v > value) { value = v; }
                }
            }
            else if (Compare(valueFrequency, new List<int>() { 2, 1, 1, 1 }))
            {
                rank = 1;
                foreach (int v in frequency.Keys)
                {
                    if (frequency[v] == 2) { value = v; break; }
                }
            }
            else
            {
                value = frequency.Keys.Max();
            }

            result[0] = rank;
            result[1] = value;

            return result;
        }

        public bool Compare(List<int> values, List<int> model)
        {
            model.Sort();
            values.Sort();
            bool result = false;

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
