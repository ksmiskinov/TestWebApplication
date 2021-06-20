using System.Collections.Generic;

namespace DeckCards.Domain.Interfaces
{
  public interface IShuffleStrategy
  {
    /// <summary>
    /// Перетасовать колоду карт.
    /// </summary>
    /// <param name="positionCards"> передаются позиции карт в колоде</param>
    /// <returns></returns>
    IList<PositionCard>  ToShuffle(IList<PositionCard> positionCards);
  }
}
