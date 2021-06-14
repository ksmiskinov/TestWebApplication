using DeckCards.Data.cs;
using DeckCards.Domain;
using DeckCards.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckCards.Repository
{
  public class DeckCardsRepository : IDeckCardsRepository
  {
    private readonly DeckData _context;

    public DeckCardsRepository(DeckData context)
    {
      _context = context;
    }

    async Task<Deck> IDeckCardsRepository.FetchDeckAsync(Guid deckId)
    {
      return await _context.Decks
                         .Include(x => x.Cards)
                         .FirstOrDefaultAsync(x => x.Id == deckId);
    }

    async Task<IList<Deck>> IDeckCardsRepository.FetchDecksAsync()
    {
      return await _context.Decks
                         .Include(x => x.Cards)
                         .ToListAsync();
    }
    async Task IDeckCardsRepository.AddDeckAsync(Deck deck)
    {
      _context.Decks.Add(deck);
      await _context.SaveChangesAsync();
    }

    async Task IDeckCardsRepository.RemoveDeckAsync(Guid deckId)
    {
      var deck = await _context.Decks.FirstOrDefaultAsync(x => x.Id == deckId);
      _context.Decks.Remove(deck);

      await _context.SaveChangesAsync();
    }

    async Task IDeckCardsRepository.UpdateDeckAsync(Deck deck)
    {
      var deckOld = await _context.Decks.FirstOrDefaultAsync(x => x.Id == deck.Id);

      deckOld.Name = deck.Name;
      deckOld.Cards = deck.Cards;

      await _context.SaveChangesAsync();
    }
  }
}
