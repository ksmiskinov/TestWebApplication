using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApplication.Models.ShuffleDeck
{
  public interface IShuffle
  {
    IList<Card>  ToShuffle(IList<Card> cards);
  }
}
