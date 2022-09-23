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
    public class HandTests
    {
        public static IEnumerable<object[]> CompareTestData()
        {
            yield return new object[] { new List<int> { 2, 1, 1, 1 }, new List<int> { 1, 1, 1, 2 } };
            yield return new object[] { new List<int> { 4, 1 }, new List<int> { 1, 4 } };
            yield return new object[] { new List<int> { 2, 2, 1 }, new List<int> { 1, 2, 2 } };
            yield return new object[] { new List<int> { 1, 1, 1, 1, 1 }, new List<int> { 1, 1, 1, 1, 1 } };
        }

        [Theory]
        [MemberData(nameof(CompareTestData))]
        void Compare_ReturnsCorrectValue(List<int> values, List<int> target)
        {
            Hand hand = new Hand();

            bool actual = hand.Compare(values, target);

            Assert.True(actual);
        }

        public static IEnumerable<object[]> AnalyzeTestData()
        {
            yield return new object[] { 
                new List<ICard> { 
                    new StandardCard("Three of Diamonds", 3, 3), 
                    new StandardCard("Five of Hearts", 5, 1), 
                    new StandardCard("Eight of Diamonds", 8, 3), 
                    new StandardCard("Ace of Hearts", 14, 1), 
                    new StandardCard("Three of Spades", 3, 2) 
                }, 
                new int[] { 1, 3 }
            };

            yield return new object[] {
                new List<ICard> {
                    new StandardCard("King of Spades", 13, 2),
                    new StandardCard("King of Clubs", 13, 0),
                    new StandardCard("King of Diamonds", 13, 3),
                    new StandardCard("Six of Hearts", 6, 1),
                    new StandardCard("Six of Diamonds", 6, 3)
                },
                new int[] { 6, 13 }
            };

            yield return new object[] {
                new List<ICard> {
                    new StandardCard("Four of Clubs", 4, 0),
                    new StandardCard("Seven of Clubs", 7, 0),
                    new StandardCard("Eight of Clubs", 8, 0),
                    new StandardCard("Five of Clubs", 5, 0),
                    new StandardCard("Six of Clubs", 6, 0)
                },
                new int[] { 8, 8 }
            };
        }

        [Theory]
        [MemberData(nameof(AnalyzeTestData))]
        void Analyze_ReturnsCorrectValues(List<ICard> cards, int[] expected)
        {
            Hand hand = new Hand();
            int[] actual = hand.Analyze(cards);
            Assert.Equal(actual, expected);
        }
    }
}
