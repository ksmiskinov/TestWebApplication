using System;

namespace DeckCards.Domain
{
  public class Card
  {
    private Card() { }

    /// <summary>
    /// ���������� ������������� �������
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// ����������  � ��������
    /// </summary>
    public Deck Deck { get; set; }

    /// <summary>
    /// ���������� ������������� �������
    /// </summary>
    public Guid DeckId { get; set; }

    /// <summary>
    /// ��� ����� (�����, ������, �����, ����)
    /// </summary>
    public CardKind Kind { get; set; }

    /// <summary>
    /// ���� �����
    /// </summary>
    public CardRank Rank { get; set; }

    /// <summary>
    /// ������� ����� � ������
    /// </summary>
    public int Position { get; set; }

    public string GetName()
      => Kind.ToString() + " " + Rank.ToString();

    /// <summary>
    /// �������� ����� ������
    /// </summary>
    /// <param name="kind">����� �����</param>
    /// <param name="rank">����������� �����</param>
    /// <param name="position">������� � ������</param>
    /// <returns></returns>
    public static Card New(CardKind kind, CardRank rank, int position)
      => new Card()
      {
        Kind = kind,
        Rank = rank,
        Position = position
      };
  }
}
