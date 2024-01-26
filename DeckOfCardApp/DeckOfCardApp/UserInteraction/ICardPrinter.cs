using DeckOfCardApp.Model;

namespace DeckOfCardApp.UserInteraction;

public interface ICardPrinter
{
    void Print(IEnumerable<Card> cards);
}
