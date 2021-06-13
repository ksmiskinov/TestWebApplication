using System;

namespace TestWebApplication.Models
{
  public class �ard
  {
    private �ard()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; }

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
    public static �ard New(CardKind kind, CardRang rang, int position)
      => new �ard()
      {
        Kind = kind,
        Rang = rang,
        Position = position
      };
  }
}
