using DeckCards.Domain;
using DeckCards.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestWebApplication.Interfaces;
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

    private readonly IDeckManagerViewDataBuilder _deckManagerViewDataBuilder;
    private readonly IDeckManagerSaveDataBuilder _deckManagerSaveDataBuilder;

    public DeckManagerController(ILogger<DeckManagerController> logger,
                                 IDeckCardsServices deckCardsServices,
                                 IDeckManagerViewDataBuilder deckManagerViewDataBuilder, 
                                 IDeckManagerSaveDataBuilder deckManagerSaveDataBuilder)
    {
      _deckCardsServices = deckCardsServices ?? throw new ArgumentNullException(nameof(IDeckCardsServices));
      _deckManagerViewDataBuilder = deckManagerViewDataBuilder ?? throw new ArgumentNullException(nameof(IDeckManagerViewDataBuilder));
      _deckManagerSaveDataBuilder = deckManagerSaveDataBuilder ?? throw new ArgumentNullException(nameof(IDeckManagerSaveDataBuilder));
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
      var deckViewDataList = await _deckManagerViewDataBuilder.DecksViewDataBuild();
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
      var deckInfoViewData = await _deckManagerViewDataBuilder.DeckViewDataBuild(deckId);
      return new ObjectResult(deckInfoViewData);
    }

    /// <summary>
    /// Создать именованную колоду карт(колода создаётся упорядоченной)
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    [Route("Deck")]
    async public Task<IActionResult> CreateDeck(string name, DeckKind deckKind)
    {
      var deck =await _deckManagerSaveDataBuilder.NewDeckSaveBuild(name, deckKind);
      if (deck == null)
        return new BadRequestResult();

      await _deckCardsServices.AddDeckAsync(deck);

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

      var deck = await _deckManagerSaveDataBuilder.ShuffleDeckSaveBuild(deckId);
      if (deck == null)
        return new BadRequestResult();

      await _deckCardsServices.UpdateDeckAsync(deck);

      return new OkResult();
    }

  }
}
