using DeckCards.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeckCards.Services.Abstractions
{
  public interface IDeckCardsServices
  {
    Task<Deck> GetDeckAsync(Guid deckId);

    Task<IList<Deck>> GetDecksAsync();

    Task AddDeckAsync(Deck deck);

    Task RemoveDeckAsync(Guid deckId);

    Task UpdateDeckAsync(Deck deck);
  }
}
