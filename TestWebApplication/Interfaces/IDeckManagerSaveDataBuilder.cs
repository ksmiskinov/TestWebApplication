using DeckCards.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebApplication.ViewModel;

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

  }
}
