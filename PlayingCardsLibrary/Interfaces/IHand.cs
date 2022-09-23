using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCardsLibrary.Interfaces
{
    public interface IHand
    {
        public List<ICard> Contents { get; set; }
        public int[] Analyze(List<ICard> cards);
    }
}
