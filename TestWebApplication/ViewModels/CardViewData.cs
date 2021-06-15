namespace TestWebApplication.ViewModel
{
  public class CardViewData
  {
    private CardViewData()
    {
    }

    /// <summary>
    /// ������������ ������ ����
    /// </summary>
    public string Name { get; set; }

    public static CardViewData New(string name)
      => new CardViewData
      {
        Name = name
      };
  }
}
