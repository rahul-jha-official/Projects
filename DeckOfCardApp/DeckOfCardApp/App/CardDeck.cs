using DeckOfCardApp.Model;

namespace DeckOfCardApp.App;

public class CardDeck
{
    private readonly Card[] _cardDeck;
    private readonly Face[] _faces;
    private readonly int _totalCards;
    private readonly int _noneCards;

    public CardDeck(int noneCards)
    {
        _faces = Enum.GetValues(typeof(Face)).Cast<Face>().ToArray();
        _noneCards = noneCards;
        _totalCards = noneCards + (Enum.GetValues(typeof(Suit)).Length - 1) * _faces.Length;
        _cardDeck = new Card[_totalCards];

        Init();
    }

    private void Init()
    {
        int index = 0;
        //Initializing Non-None Card
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            if (suit.Equals(Suit.None)) continue;
            Init(suit, ref index);
        }
        //Initializing None Card
        for (int j = 1; j <= _noneCards; j++)
        {
            _cardDeck[index++] = new Card
            {
                suit = Suit.None,
                face = Face.Jack
            };
        }
    }

    private void Init(Suit suit, ref int start_index)
    {
        foreach (var face in _faces)
        {
            Card card = new Card()
            {
                suit = suit,
                face = face
            };

            _cardDeck[start_index++] = card;
        }
    }

    public Card[] Cards => _cardDeck;
    public int Total => _totalCards;
    public int NoneCardsCount => _noneCards;
}
