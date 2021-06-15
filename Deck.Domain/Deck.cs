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
      var cards = new List<Card>();
      var position = 1;
      foreach (CardKind kind in Enum.GetValues(typeof(CardKind)))
      {
        foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
        {
          cards.Add(Card.New(kind, rank, position++));
        }
      }
      Cards = cards;
    }

    /// <summary>
    /// Перетасовать колоду карт в соответствии со стратегией тасовки.
    /// </summary>
    /// <param name="shuffle"></param>
    public void ShuffleDeck(IShuffleStrategy shuffle)
    {
      Cards = shuffle.ToShuffle(Cards);
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
    /// Карты
    /// </summary>
    public IList<Card> Cards { get; set; }

    public static Deck New(string name)
      => new Deck(name);

  }
}
