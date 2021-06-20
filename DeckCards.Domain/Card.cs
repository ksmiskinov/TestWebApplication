using Microsoft.EntityFrameworkCore;
using System;

namespace DeckCards.Domain
{
  /// <summary>
  /// �������� �����
  /// </summary>
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
    public PositionCard PositionCard { get; set; }

    /// <summary>
    /// ���������� ������������� �������
    /// </summary>
    public Guid PositionCardId { get; set; }

    /// <summary>
    /// ��� ����� (�����, ������, �����, ����)
    /// </summary>
    public CardKind Kind { get; set; }

    /// <summary>
    /// ���� �����
    /// </summary>
    public CardRank Rank { get; set; }

    public string GetName()
      => Kind.ToString() + " " + Rank.ToString();

    /// <summary>
    /// �������� ����� ������
    /// </summary>
    /// <param name="kind">����� �����</param>
    /// <param name="rank">����������� �����</param>
    /// <returns></returns>
    public static Card New(CardKind kind, CardRank rank)
      => new Card()
      {
        Kind = kind,
        Rank = rank
      };
  }
}
