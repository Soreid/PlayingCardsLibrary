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
            yield return new object[] { new List<int> { 5, 3, 7, 9, 5 }, new List<int> { 1, 1, 1, 2 } };
            yield return new object[] { new List<int> { 8, 8, 8, 7, 8 }, new List<int> { 1, 4 } };
            yield return new object[] { new List<int> { 3, 3, 2, 2, 4 }, new List<int> { 1, 2, 2 } };
            yield return new object[] { new List<int> { 14, 13, 12, 11, 10 }, new List<int> { 1, 1, 1, 1, 1 } };
        }

        [Theory]
        [MemberData(nameof(CompareTestData))]
        void Compare_ReturnsCorrectValue(List<int> values, List<int> target)
        {
            Hand hand = new Hand();

            bool actual = hand.Compare(values, target);

            Assert.True(actual);
        }
    }
}
