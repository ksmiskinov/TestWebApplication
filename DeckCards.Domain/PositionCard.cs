using System;

namespace DeckCards.Domain
{
  /// <summary>
  /// ��������� ������� ����� � ������.
  /// </summary>

  public class PositionCard
  {
    private PositionCard() { }

    /// <summary>
    /// ���������� ������������� �������
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// ����������  � ��������
    /// </summary>
    public Deck Deck { get; set; }

    ///// <summary>
    ///// ���������� ������������� ������� 
    ///// </summary>
    public Guid DeckId { get; set; }
    
    /// <summary>
    /// ����������  � ��������
    /// </summary>
    public Card Card { get; set; }

    /// <summary>
    /// ������� ����� � ������
    /// </summary>
    public int Position { get; set; }
    
    /// <summary>
    /// �������� ����� ������
    /// </summary>
    /// <param name="kind">����� �����</param>
    /// <param name="rank">����������� �����</param>
    /// <param name="position">������� � ������</param>
    /// <returns></returns>
    public static PositionCard New(CardKind kind, CardRank rank, int position)
      => new PositionCard()
      { 
        Card = Card.New(kind, rank),
        Position = position
      };
  }
}
