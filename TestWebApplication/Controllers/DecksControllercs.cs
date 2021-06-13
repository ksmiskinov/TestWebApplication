using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using TestWebApplication.Models;
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
    /// Получить список колод
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Decks")]
    public IEnumerable<DeckViewData> GetDecks()
    {
      _logger.LogInformation("GetDecks");
      return _context.Decks.Select(x=> DeckViewData.New(x.Name));
    }

    /// <summary>
    /// Получить колоду по имени(в её текущем упорядоченном/перетасованном состоянии)
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("Deck")]
    public DeckViewData GetDeck(string name)
    {
      //поиск нужной колоды

      return DeckViewData.New("Колода");
    }

    /// <summary>
    /// Создать именованную колоду карт(колода создаётся упорядоченной)
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    public IActionResult CreateDeck(string name)
    {
      return new OkResult();
    }



    /// <summary>
    /// Удалить именованную колоду
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    public IActionResult DeleteDeck()
    {
      return new OkResult();
    }


    /// <summary>
    /// Перетасовать колоду
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public IActionResult ShuffleDeck(string name)
    {
      return new OkResult();
    }

  }
}
