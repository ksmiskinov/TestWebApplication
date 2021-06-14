using System;
using System.Collections.Generic;
using TestWebApplication.Models;
using TestWebApplication.Models.ShuffleDeck;

namespace TestWebApplication
{
  public class Deck
  {
    private Deck() { }

    private Deck(string name)
    {
      Name = name;

      var cards = new List<Card>();
      var position = 1;
      foreach (CardKind kind in Enum.GetValues(typeof(CardKind)))
      {
        foreach (CardRang rang in Enum.GetValues(typeof(CardRang)))
        {
          cards.Add(Card.New(kind, rang, position++));
        }
      }
      Cards = cards;
    }

    public void ShuffleDeck(IShuffle shuffle)
    {
      Cards = shuffle.ToShuffle(Cards);
    }

    /// <summary>
    /// 
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
