using PlayingCardsLibrary.Classes;
using PlayingCardsLibrary.Interfaces;



Deck deck = new Deck();
Hand hand = new Hand();


deck.InitializeStandardDeck();

Console.WriteLine("First Deck: ");
for(int i = deck.Cards.Count; i > 0; i--)
{
    ICard card = deck.Draw();
    Console.WriteLine(card.Name);
}

Console.WriteLine();
Console.WriteLine("------------------------");
Console.WriteLine();

deck.InitializeStandardDeck();
deck.Shuffle();

Console.WriteLine("Second Deck: ");
for (int i = deck.Cards.Count; i > 0; i--)
{
    ICard card = deck.Draw();
    Console.WriteLine(card.Name);
}

Console.WriteLine();
Console.WriteLine("------------------------");
Console.WriteLine();

deck.InitializeStandardDeck();
deck.Shuffle();
Console.WriteLine("Drawing Cards...");
Console.WriteLine();
for(int i = 0; i < 5; i++)
{
    ICard card = deck.Draw();
    int[] atts = card.GetAttributes();
    Console.WriteLine(card.Name);
    Console.WriteLine($"Value: {atts[0]}, Suit: {atts[1]}");
    Console.WriteLine();
}

Console.ReadKey(true);