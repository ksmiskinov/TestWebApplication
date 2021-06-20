using DeckCards.Services.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApplication.Interfaces;
using TestWebApplication.ViewModel;

namespace TestWebApplication.Builders
{
  public class DeckManagerViewDataBuilder : IDeckManagerViewDataBuilder
  {

    private readonly IDeckCardsServices _deckCardsServices;

    public DeckManagerViewDataBuilder(IDeckCardsServices deckCardsServices)
    {
      _deckCardsServices = deckCardsServices ?? throw new ArgumentNullException(nameof(IDeckCardsServices));
    }


    async Task<IList<DeckViewData>> IDeckManagerViewDataBuilder.DecksViewDataBuild()
    {
      var decks = await _deckCardsServices.GetDecksAsync();
      return decks.Select(x => DeckViewData.New(x.Id, x.Name)).ToList();
    }

    async Task<DeckInfoViewData> IDeckManagerViewDataBuilder.DeckViewDataBuild(Guid deckId)
    {
      var deck = await _deckCardsServices.GetDeckAsync(deckId);
      if (deck == null)
        return null;

      return DeckInfoViewData.New(deck.Name,
                                  deck.PositionCards.OrderBy(x => x.Position)
                                            .Select(x => CardViewData.New(x.Card.GetName()))
                                            .ToList());
    }
  }
}
