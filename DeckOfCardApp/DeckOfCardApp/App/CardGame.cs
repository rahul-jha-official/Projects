using DeckOfCardApp.Model;
using DeckOfCardApp.UserInteraction;

namespace DeckOfCardApp.App
{
    public class CardGame
    {
        private readonly List<Card>[] _game;
        private readonly IUserInteractor _userInteractor;
        private readonly ICardPrinter _printer;
        private readonly CardDeck _deck;
        private readonly int _totalPlayers;
        private readonly bool _dealNoneCard;
        private int _totalCards;
        private int _index;

        public CardGame(IUserInteractor userInteractor, ICardPrinter printer, CardDeck deck, int totalPlayers, bool dealNoneCard = false)
        {
            _userInteractor = userInteractor;
            _printer = printer;
            _deck = deck;
            _totalPlayers = totalPlayers;
            _dealNoneCard = dealNoneCard;
            _game = new List<Card>[totalPlayers];

            for (int i = 0; i < totalPlayers; i++)
            {
                _game[i] = new List<Card>();
            }

            _totalCards = _deck.Total - (dealNoneCard ? 0 : _deck.NoneCardsCount);
            _index = 0;
        }
        public void Play(bool shuffleCard)
        {

            if (shuffleCard)
            {
                Shuffle();
            }

            _userInteractor.PrintMessage("Enter number of cards per Player to deal: ");
            
            var input = Console.ReadLine();
            if (input == null) throw new ArgumentNullException("Invalid User Input");

            var cardsToDealPerPlayer = int.Parse(input);

            Deal(cardsToDealPerPlayer);

            DisplayCardPerPlayer();

            _userInteractor.PrintMessage("Want to deal again [Y/N]: ");


            input = Console.ReadLine();
            if (input == null) throw new ArgumentNullException("Invalid User Input");
            if (!"Y,y,N,n".Split(',').Contains(input)) throw new ArgumentException("Invalid User Input");

            var dealAgain = string.Equals(input, "Y", StringComparison.OrdinalIgnoreCase);

            if (dealAgain)
            {
                DealAgain(cardsToDealPerPlayer);
            }

            DisplayCardPerPlayer();
            DisplayRemainingCards();

            Conclude();
        }

        private Card GetCard()
        {
            if (_dealNoneCard)
            {
                return _deck.Cards[_index++];
            }

            while (_deck.Cards[_index++].suit.Equals(Suit.None));

            return _deck.Cards[_index];
        }

        private void StartDealing(int cardsToDealPerPlayer)
        {
            for (int i = 0; i < cardsToDealPerPlayer; i++)
            {
                for (int j = 0; j < _totalPlayers; j++)
                {
                    _game[j].Add(GetCard());
                }
            }
        }

        private void Deal(int cardsToDealPerPlayer)
        {
            var totalCardsToBeDealt = cardsToDealPerPlayer * _totalPlayers;

            if (totalCardsToBeDealt > _totalCards)
            {
                _userInteractor.PrintError("Cards cannot be distributed");

                throw new ArgumentException("Cards cannot be distributed");
            }

            StartDealing(cardsToDealPerPlayer);
        }

        private void DealAgain(int cardsToDealPerPlayer)
        {
            var _availableCard = _totalCards - _index;
            var totalCardsToBeDealt = cardsToDealPerPlayer * _totalPlayers;

            if (totalCardsToBeDealt > _availableCard)
            {
                _userInteractor.PrintError("Cards cannot be distributed");
            }
            StartDealing(cardsToDealPerPlayer);
        }

        public void Conclude()
        {
            int winnerPoint = -1;
            var sum = new int[_totalPlayers];
            for (int i = 0; i < _totalPlayers; i++)
            {
                foreach (Card card in _game[i])
                {
                    sum[i] += (int)card.face;
                }

                winnerPoint = Math.Max(winnerPoint, sum[i]);
            }

            _userInteractor.PrintMessage("*** SCORE BOARD ***");

            for (int i = 0; i < _totalPlayers; i++)
            {
                if (sum[i] == winnerPoint)
                {
                    _userInteractor.PrintSuccessMessage($"PLAYER {i + 1} Won with Score: {sum[i]}");
                }
                else
                {
                    _userInteractor.PrintWarning($"PLAYER {i + 1} lost with Score: {sum[i]}");
                }
            }
        }

        public void Display()
        {
            _printer.Print(_deck.Cards);
        }

        public void DisplayCardPerPlayer()
        {
            for (int i = 0; i < _totalPlayers; i++)
            {
                _userInteractor.PrintMessage($"*** PLAYER {i + 1} CARDS ***");
                _printer.Print(_game[i]);
                _userInteractor.PrintMessage(Environment.NewLine);
            }
        }

        public void DisplayRemainingCards()
        {
            DisplayCardPerPlayer();

            _userInteractor.PrintMessage($"*** REMAINING CARDS ***");
            _printer.Print(_deck.Cards.Skip(_index));
            _userInteractor.PrintMessage(Environment.NewLine);
        }

        public void Shuffle()
        {
            var random = new Random();
            random.Shuffle(_deck.Cards);
        }
    }
}
