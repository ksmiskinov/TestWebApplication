namespace TestWebApplication.ViewModel
{
  public class CardViewData
  {
    private CardViewData()
    {
    }

    /// <summary>
    /// Наименование колоды карт
    /// </summary>
    public string Name { get; set; }

    public static CardViewData New(string name)
      => new CardViewData
      {
        Name = name
      };
  }
}
