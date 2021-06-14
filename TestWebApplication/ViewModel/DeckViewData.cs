using System;

namespace TestWebApplication.ViewModel
{
  public class DeckViewData
  {
    private DeckViewData()
    {
    }

    /// <summary>
    /// ���������� ������������� �������
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// ������������ ������ ����
    /// </summary>
    public string Name { get; set; }

    public static DeckViewData New(Guid id, string name)
      => new DeckViewData
      {
        Id = id,
        Name = name,
      };
  }
}
