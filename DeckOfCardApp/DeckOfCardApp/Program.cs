using DeckOfCardApp.App;
using DeckOfCardApp.Logging;
using DeckOfCardApp.UserInteraction;

IUserInteractor interactor = new ConsoleUserInteractor();
ICardPrinter printer = new CardPrinter(interactor);
CardDeck deck = new CardDeck(2);

Logger logger = new Logger("log.txt");
CardGame game = new CardGame(interactor, printer, deck, 4, false);

try
{
    game.Play(true);
    interactor.PrintMessage("Exiting Game!!");
}

catch(Exception ex)
{
    interactor.PrintError(ex.Message);
    interactor.PrintError("Exiting Game with Error :(");
    logger.Log(ex);
}
interactor.PrintMessage("Press Any key to Exit");
Console.ReadKey();