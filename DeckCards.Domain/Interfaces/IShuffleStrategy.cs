using System.Collections.Generic;

namespace DeckCards.Domain.Interfaces
{
  public interface IShuffleStrategy
  {
    /// <summary>
    /// Перетасовать колоду карт.
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    IList<Card>  ToShuffle(IList<Card> cards);
  }
}
