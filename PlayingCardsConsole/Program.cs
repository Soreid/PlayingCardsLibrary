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

Dictionary<int, string> nameMatch = new Dictionary<int, string>() { 
    { 2, "two" } ,
    { 3, "three" },
    { 4, "four" },
    { 5, "five" },
    { 6, "six" },
    { 7, "seven" },
    { 8, "eight" },
    { 9, "nine" },
    { 10, "ten" },
    { 11, "Jack" },
    { 12, "Queen" },
    { 13, "King" },
    { 14, "Ace" }
};

char exit = 'a';

while (exit != 'x') 
{
    Console.WriteLine();
    Console.WriteLine("------------------------");
    Console.WriteLine();

    deck.InitializeStandardDeck();
    deck.Shuffle();
    hand = new Hand();
    Console.WriteLine("Drawing Cards...");
    Console.WriteLine();
    for (int i = 0; i < 5; i++)
    {
        ICard card = deck.Draw();
        int[] atts = card.GetAttributes();
        Console.WriteLine(card.Name);
        //Console.WriteLine($"Value: {atts[0]}, Suit: {atts[1]}");
        //Console.WriteLine();
        hand.Contents.Add(card);
    }

    Console.WriteLine();
    int[] stats = hand.Analyze(hand.Contents);

    switch (stats[0])
    {
        case 0:
            Console.WriteLine($"A {nameMatch[stats[1]]} high card!");
            break;
        case 1:
            Console.WriteLine($"A pair of {nameMatch[stats[1]]}s!");
            break;
        case 2:
            Console.WriteLine($"Two pair with {nameMatch[stats[1]]}s high!");
            break;
        case 3:
            Console.WriteLine($"Three-of-a-Kind of {nameMatch[stats[1]]}s!");
            break;
        case 4:
            Console.WriteLine($"A straight, {nameMatch[stats[1]]} high!");
            break;
        case 5:
            Console.WriteLine($"A flush with a high {nameMatch[stats[1]]}!");
            break;
        case 6:
            Console.WriteLine($"A full house of {nameMatch[stats[1]]}s!");
            break;
        case 7:
            Console.WriteLine($"Four-of-a-Kind of {nameMatch[stats[1]]}s!");
            break;
        case 8:
            Console.WriteLine($"A straight flush! A {nameMatch[stats[1]]} is the high card!");
            break;
        case 9:
            Console.WriteLine($"Royal Flush! Amazing!");
            break;
    }
    Console.WriteLine();
    Console.WriteLine("Press x to exit, or any other key to get a new hand.");
    exit = Console.ReadKey(true).KeyChar;
}