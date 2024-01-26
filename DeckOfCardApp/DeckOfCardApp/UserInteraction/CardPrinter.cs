using DeckOfCardApp.Model;

namespace DeckOfCardApp.UserInteraction;

public class CardPrinter : ICardPrinter
{
    private readonly IUserInteractor _userInteractor;

    public CardPrinter(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }
    public void Print(IEnumerable<Card> cards)
    {
        foreach (Card card in cards)
        {
            _userInteractor.PrintMessage(card.ToString());
        }

        _userInteractor.PrintMessage(Environment.NewLine);
        _userInteractor.PrintMessage(Environment.NewLine);
    }
}
