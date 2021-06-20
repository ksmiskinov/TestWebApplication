using DeckCards.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace DeckCards.Domain
{
  public class Deck
  {
    private Deck() { }

    /// <summary>
    /// Конструктор. Получить колоду карт.
    /// </summary>
    /// <param name="name"></param>
    private Deck(string name)
    {
      Name = name;

      //TODO: необходимо понять, что такое сортированная колоды по умолчанию
      var positionCards = new List<PositionCard>();
      var position = 1;
      foreach (CardKind kind in Enum.GetValues(typeof(CardKind)))
      {
        foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
        {
          positionCards.Add(PositionCard.New(kind, rank, position++));
        }
      }
      PositionCards = positionCards;
    }

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

    public static Deck New(string name)
      => new Deck(name);

  }
}
