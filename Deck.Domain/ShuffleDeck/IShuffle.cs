using System.Collections.Generic;

namespace Deck.Domain.ShuffleDeck
{
  public interface IShuffle
  {
    IList<Card>  ToShuffle(IList<Card> cards);
  }
}
