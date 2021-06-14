using System;

namespace DeckCards.Domain
{
  public class Card
  {
    private Card()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Deck Deck { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid DeckId { get; set; }

    /// <summary>
    /// ��� ����� (�����, ������, �����, ����)
    /// </summary>
    public CardKind Kind { get; set; }

    /// <summary>
    /// ���� �����
    /// </summary>
    public CardRang Rang { get; set; }

    /// <summary>
    /// ������� ����� � ������
    /// </summary>
    public int Position { get; set; }

    /// <summary>
    /// �������� ����� ������
    /// </summary>
    /// <param name="kind">����� �����</param>
    /// <param name="rang">����������� �����</param>
    /// <param name="position">������� � ������</param>
    /// <returns></returns>
    public static Card New(CardKind kind, CardRang rang, int position)
      => new Card()
      {
        Kind = kind,
        Rang = rang,
        Position = position
      };
  }
}
