using ProjektGameCardentis.Domain.Enums;

namespace ProjektGameCardentis.Domain.Entities
{
    public class Deck
    {
        private readonly List<Card> _cards = new();

        public IReadOnlyCollection<Card> Cards => _cards.AsReadOnly();

        public void AddCard(Card card)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));

            _cards.Add(card);
        }

        public void RemoveCard(Card card)
        {
            if (!_cards.Remove(card)) throw new InvalidOperationException("Karta nie została znaleziona w talii.");
        }

        public IEnumerable<Card> GetCardsByType(CardType type)
        {
            return _cards.Where(c => c.Type == type);
        }
    }
}
