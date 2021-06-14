using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using TestWebApplication.Models;
using TestWebApplication.Models.ShuffleDeck;
using TestWebApplication.ViewModel;

namespace TestWebApplication.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class DeckMangerController : ControllerBase
  {
    private readonly ILogger<DeckMangerController> _logger;
    private ApplicationContext _context;

    public DeckMangerController(ILogger<DeckMangerController> logger, ApplicationContext context)
    {
      _context = context;
      _logger = logger;
    }

    /// <summary>
    /// Получить список всех колод
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Decks")]
    public IActionResult GetDecks()
    {
      var deckViewDataList = _context.Decks.Select(x => DeckViewData.New(x.Name));
      return new ObjectResult(deckViewDataList);
    }

    /// <summary>
    /// Получить колоду по имени(в её текущем упорядоченном/перетасованном состоянии)
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Deck")]
    public IActionResult GetDeck(string name)
    {
      var deck = _context.Decks
                         .Include(x => x.Cards)
                         .FirstOrDefault(x => x.Name == name);

      if (deck == null)
      {
        _logger.LogInformation("GetDeck: Объект не найден");
        return null;
      }

      var deckInfoViewData = DeckInfoViewData.New(deck.Name,
                                  deck.Cards.OrderBy(x => x.Position)
                                            .Select(x => CardViewData.New(x.Kind.ToString() + " " + x.Rang.ToString()))
                                            .ToList());

      return new ObjectResult(deckInfoViewData);

    }

    /// <summary>
    /// Создать именованную колоду карт(колода создаётся упорядоченной)
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    [Route("Deck")]
    public IActionResult CreateDeck(string name)
    {
      _context.Decks.Add(Deck.New(name));
      _context.SaveChanges();

      return new OkResult();
    }



    /// <summary>
    /// Удалить именованную колоду
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    [Route("Deck")]
    public IActionResult DeleteDeck(string name)
    {
      var deck = _context.Decks.FirstOrDefault(x => x.Name == name);
      if (deck is null)
      {
        _logger.LogInformation("DeleteDeck: Объект не найден");
        return new BadRequestResult();
      }

      _context.Decks.Remove(deck);
      _context.SaveChanges();
      return new OkResult();
    }


    /// <summary>
    /// Перетасовать колоду
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Route("ShuffleDeck")]
    public IActionResult ShuffleDeck(string name)
    {
      var deck = _context.Decks
                         .Include(x => x.Cards)
                         .FirstOrDefault(x => x.Name == name);
      if (deck is null)
      {
        _logger.LogInformation("ShuffleDeck: Объект не найден");
        return new BadRequestResult();
      }

      deck.ShuffleDeck(new ShuffleRandom());
      _context.SaveChanges();

      return new OkResult();
    }

  }
}
