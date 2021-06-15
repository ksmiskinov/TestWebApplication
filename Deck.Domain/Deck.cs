using DeckCards.Domain.ShuffleDeck;
using System;
using System.Collections.Generic;

namespace DeckCards.Domain
{
  public class Deck
  {
    private Deck() { }

    private Deck(string name)
    {
      Name = name;

      //TODO: ���������� ������, ��� ����� ������������� ������ �� ���������
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

    public void ShuffleDeck(IShuffle shuffle)
    {
      Cards = shuffle.ToShuffle(Cards);
    }

    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// ����������� ������
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// �����
    /// </summary>
    public IList<Card> Cards { get; set; }

    public static Deck New(string name)
      => new Deck(name);

  }
}
