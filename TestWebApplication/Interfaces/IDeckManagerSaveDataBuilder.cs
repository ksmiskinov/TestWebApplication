using DeckCards.Domain;
using System;
using System.Threading.Tasks;
using TestWebApplication.Models;

namespace TestWebApplication.Interfaces
{
  /// <summary>
  /// Подготовка данных для обновления колод
  /// </summary>
  public interface IDeckManagerSaveDataBuilder
  {
    /// <summary>
    /// Получить перемешанную колоду карт.
    /// </summary>
    /// <returns></returns>
    Task<Deck> ShuffleDeckSaveBuild(Guid deckId);

    /// <summary>
    /// Добавить новую колоду
    /// </summary>
    /// <param name="name">Наименование колоды</param>
    /// <param name="deckKind">Варианты колоды</param>
    /// <returns></returns>
    Task<Deck> NewDeckSaveBuild(string name, DeckKind deckKind);
  }
}
