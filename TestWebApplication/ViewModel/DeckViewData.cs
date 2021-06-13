namespace TestWebApplication.ViewModel
{
  public class DeckViewData
  {
    private DeckViewData()
    {
    }

    /// <summary>
    /// Наименование колоды карт
    /// </summary>
    public string Name { get; set; }

    public static DeckViewData New(string name)
      => new DeckViewData
      {
        Name = name
      };
  }
}
