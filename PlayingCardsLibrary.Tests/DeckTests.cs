using PlayingCardsLibrary.Classes;
using PlayingCardsLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PlayingCardsLibrary.Tests
{
    public class DeckTests
    {
        [Fact]
        public void Shuffle_RetainsDeckSize()
        {
            Deck deck = new Deck();
            deck.InitializeStandardDeck();

            int expected = deck.Cards.Count();

            deck.Shuffle();

            int actual = deck.Cards.Count();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Shuffle_RandomizesDeck()
        {
            Deck deck = new Deck();
            deck.InitializeStandardDeck();

            List<ICard> startState = new();
            startState.AddRange(deck.Cards);

            deck.Shuffle();

            List<ICard> endState = new();
            endState.AddRange(deck.Cards);

            Assert.NotEqual(startState, endState);
        }
    }
}
