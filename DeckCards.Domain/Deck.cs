using DeckCards.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace DeckCards.Domain
{
  public class Deck
  {
    private Deck() { }

    /// <summary>
    /// ������������ ������ ���� � ������������ �� ���������� �������.
    /// </summary>
    /// <param name="shuffle"></param>
    public void ShuffleDeck(IShuffleStrategy shuffle)
    {
      PositionCards = shuffle.ToShuffle(PositionCards);
    }

    /// <summary>
    /// ���������� ������������� �������
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// ����������� ������
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// ������� ����� � ������
    /// </summary>
    public IList<PositionCard> PositionCards { get; set; }

    /// <summary>
    /// ������� ������ ����
    /// </summary>
    /// <param name="name">������������ </param>
    /// <param name="positionCards">������� ����</param>
    /// <returns></returns>
    public static Deck New(string name, IList<PositionCard> positionCards)
      => new Deck()
      {
        Name = name,
        PositionCards = positionCards,
      };

  }
}
