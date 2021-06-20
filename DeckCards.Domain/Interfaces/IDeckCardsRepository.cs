using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeckCards.Domain.Interfaces
{
  public interface IDeckCardsRepository
  {
    /// <summary>
    /// Получить список колод
    /// </summary>
    /// <returns></returns>
    Task<IList<Deck>> FetchDecksAsync();
    /// <summary>
    /// Получить колоду по имени
    /// </summary>
    /// <param name="deckId"></param>
    /// <returns></returns>
    Task<Deck> FetchDeckAsync(Guid deckId);
    /// <summary>
    /// Добавить колоду
    /// </summary>
    /// <param name="deck"></param>
    /// <returns></returns>
    Task AddDeckAsync(Deck deck);
    /// <summary>
    /// Удалить колоду
    /// </summary>
    /// <param name="deckId"></param>
    /// <returns></returns>
    Task RemoveDeckAsync(Guid deckId);
    /// <summary>
    /// Обновить колоду
    /// </summary>
    /// <param name="deck"></param>
    /// <returns></returns>
    Task UpdateDeckAsync(Deck deck);
  }
}
