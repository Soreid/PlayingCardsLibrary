using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCardsLibrary.Interfaces
{
    public interface ICard
    {
        public string Name { get; set; }
        public int[] GetAttributes();
    }
}
