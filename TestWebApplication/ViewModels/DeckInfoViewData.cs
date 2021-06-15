using System.Collections.Generic;

namespace TestWebApplication.ViewModel
{
  public class DeckInfoViewData
  {
    private DeckInfoViewData()
    {
    }

    /// <summary>
    /// Наименование колоды карт
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Карты
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
