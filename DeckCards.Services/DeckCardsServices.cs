using DeckCards.Domain;
using DeckCards.Domain.Interfaces;
using DeckCards.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeckCards.Services
{
  public class DeckCardsServices : IDeckCardsServices
  {

    private readonly IDeckCardsRepository _deckCardsRepository;

    public DeckCardsServices(IDeckCardsRepository deckCardsRepository)
      => _deckCardsRepository = deckCardsRepository ?? throw new ArgumentNullException(nameof(IDeckCardsRepository));

    async Task<IList<Deck>> IDeckCardsServices.GetDecksAsync()
      => await _deckCardsRepository.FetchDecksAsync();
    
    async Task<Deck> IDeckCardsServices.GetDeckAsync(Guid deckId)
      => await _deckCardsRepository.FetchDeckAsync(deckId);

    async Task IDeckCardsServices.AddDeckAsync(Deck deck)
      => await _deckCardsRepository.AddDeckAsync(deck);

    async Task IDeckCardsServices.RemoveDeckAsync(Guid deckId)
      => await _deckCardsRepository.RemoveDeckAsync(deckId);

    async Task IDeckCardsServices.UpdateDeckAsync(Deck deck)
       => await _deckCardsRepository.UpdateDeckAsync(deck);
  }
}
