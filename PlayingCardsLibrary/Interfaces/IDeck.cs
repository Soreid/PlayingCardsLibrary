using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCardsLibrary.Interfaces
{
    public interface IDeck
    {
        List<ICard> Cards { get; set; }
        public ICard Draw();
        public void Shuffle();
    }
}
