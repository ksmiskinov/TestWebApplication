using System;
using System.Collections.Generic;
using System.Linq;

namespace TestWebApplication.Models.ShuffleDeck
{
  /// <summary>
  /// «простой» алгоритм перетасовки "Получить две карты и поменять местами, повторить много раз"
  /// </summary>
  public class ShuffleRandom : IShuffle
  {
    public IList<Card> ToShuffle(IList<Card> inputCards)
    {
      Random rnd = new Random();
      for (int i = 0; i < 1000; i++)
      {
        var positionToShuffle1 = rnd.Next(inputCards.Count) + 1;
        var positionToShuffle2 = rnd.Next(inputCards.Count) + 1;

        var card1 = inputCards.First(x => x.Position == positionToShuffle1);
        var card2 = inputCards.First(x => x.Position == positionToShuffle2);
        card1.Position = positionToShuffle2;
        card2.Position = positionToShuffle1;
      }

      return inputCards;
    }
  }
}
