using DeckCards.Domain;
using DeckCards.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestWebApplication.Models;
using TestWebApplication.ViewModel;

namespace TestWebApplication.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class DeckManagerController : ControllerBase
  {
    private readonly ILogger<DeckManagerController> _logger;
    private readonly IDeckCardsServices _deckCardsServices;

    public DeckManagerController(ILogger<DeckManagerController> logger, IDeckCardsServices deckCardsServices)
    {
      _deckCardsServices = deckCardsServices ?? throw new ArgumentNullException(nameof(IDeckCardsServices));
      _logger = logger;
    }

    /// <summary>
    /// Получить список всех колод
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Decks")]
    async public Task<IActionResult> GetDecks()
    {
      //Todo: Нужно вынести в сервис builderDeckCards
      var decks =  await _deckCardsServices.GetDecksAsync();
      var deckViewDataList = decks.Select(x => DeckViewData.New(x.Id, x.Name)).ToList();

      return new ObjectResult(deckViewDataList);
    }

    /// <summary>
    /// Получить колоду по имени(в её текущем упорядоченном/перетасованном состоянии) TODO: Сделано по deckId
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Deck")]
    async public Task<IActionResult> GetDeck(Guid deckId)
    {
      var deck = await _deckCardsServices.GetDeckAsync(deckId);

      if (deck == null)
      {
        _logger.LogInformation("GetDeck: Объект не найден");
        return new BadRequestResult();
      }

      var deckInfoViewData = DeckInfoViewData.New(deck.Name,
                                  deck.Cards.OrderBy(x => x.Position)
                                            .Select(x => CardViewData.New(x.GetName()))
                                            .ToList());

      return new ObjectResult(deckInfoViewData);

    }

    /// <summary>
    /// Создать именованную колоду карт(колода создаётся упорядоченной)
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    [Route("Deck")]
    async public Task<IActionResult> CreateDeck(string name)
    {
      var newDeck = Deck.New(name);
      await _deckCardsServices.AddDeckAsync(newDeck);

      return new OkResult();
    }



    /// <summary>
    /// Удалить именованную колоду TODO: Сделано по deckId
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    [Route("Deck")]
    async public Task<IActionResult> DeleteDeck(Guid deckId)
    {
      await _deckCardsServices.RemoveDeckAsync(deckId);
      return new OkResult();
    }


    /// <summary>
    /// Перетасовать колоду TODO: Сделано по deckId
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Route("ShuffleDeck")]
    async public Task<IActionResult> ShuffleDeck(Guid deckId)
    {
      var deck = await _deckCardsServices.GetDeckAsync(deckId);

      if (deck == null)
      {
        _logger.LogInformation("GetDeck: Объект не найден");
        return new BadRequestResult();
      }
      deck.ShuffleDeck(new ShuffleRandom());

      await _deckCardsServices.UpdateDeckAsync(deck);

      return new OkResult();
    }

  }
}
