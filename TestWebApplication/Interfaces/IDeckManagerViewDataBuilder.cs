using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebApplication.ViewModel;

namespace TestWebApplication.Interfaces
{
  /// <summary>
  /// Подготовка данных для контроллера Manager
  /// </summary>
  public interface IDeckManagerViewDataBuilder
  {
    /// <summary>
    /// Получить модель представления списка колод карт
    /// </summary>
    /// <returns></returns>
    Task<IList<DeckViewData>> DecksViewDataBuild();

    /// <summary>
    /// Получить модель представления колоды карт
    /// </summary>
    /// <param name="deckId"></param>
    /// <returns></returns>
    Task<DeckInfoViewData> DeckViewDataBuild(Guid deckId);
  }
}
