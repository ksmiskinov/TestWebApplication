using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeckCards.Domain.Interfaces
{
  public interface IDeckCardsRepository
  {
    Task<IList<Deck>> FetchDecksAsync();

    Task<Deck> FetchDeckAsync(Guid deckId);

    Task AddDeckAsync(Deck deck);

    Task RemoveDeckAsync(Guid deckId);

    Task UpdateDeckAsync(Deck deck);
  }
}
