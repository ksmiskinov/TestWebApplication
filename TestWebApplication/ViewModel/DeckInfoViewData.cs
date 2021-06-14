using System.Collections.Generic;

namespace TestWebApplication.ViewModel
{
  public class DeckInfoViewData
  {
    private DeckInfoViewData()
    {
    }

    /// <summary>
    /// ������������ ������ ����
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// �����
    /// </summary>
    public IList<CardViewData> Cards { get; set; }

    public static DeckInfoViewData New(string name, IList<CardViewData> cards)
      => new DeckInfoViewData
      {
        Name = name,
        Cards = cards
      };
  }
}
