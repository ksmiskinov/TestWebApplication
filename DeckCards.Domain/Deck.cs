using DeckCards.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace DeckCards.Domain
{
  public class Deck
  {
    private Deck() { }

    /// <summary>
    /// Перетасовать колоду карт в соответствии со стратегией тасовки.
    /// </summary>
    /// <param name="shuffle"></param>
    public void ShuffleDeck(IShuffleStrategy shuffle)
    {
      PositionCards = shuffle.ToShuffle(PositionCards);
    }

    /// <summary>
    /// Уникальный идентификатор объекта
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Нименование колоды
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Позиция карты в колоде
    /// </summary>
    public IList<PositionCard> PositionCards { get; set; }

    /// <summary>
    /// Создать колоду карт
    /// </summary>
    /// <param name="name">Наименование </param>
    /// <param name="positionCards">Позиции карт</param>
    /// <returns></returns>
    public static Deck New(string name, IList<PositionCard> positionCards)
      => new Deck()
      {
        Name = name,
        PositionCards = positionCards,
      };

  }
}
