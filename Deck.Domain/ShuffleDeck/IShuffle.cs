using System.Collections.Generic;

namespace DeckCards.Domain.ShuffleDeck
{
  public interface IShuffle
  {
    IList<Card>  ToShuffle(IList<Card> cards);
  }
}
