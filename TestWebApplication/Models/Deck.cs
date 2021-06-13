using System;
using System.Collections.Generic;
using TestWebApplication.Models;

namespace TestWebApplication
{
  public class Deck
  {
    private Deck() { }

    private Deck(string name)
    {
      Name = name;

      //var position = 1;
      //foreach (CardKind kind in Enum.GetValues(typeof(CardKind)))
      //{
      //  foreach (CardRang rang in Enum.GetValues(typeof(CardRang)))
      //  {
      //    Cards.Add(�ard.New(kind, rang, position++));
      //  }
      //}
    }

    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// ����������� ������
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// �����
    /// </summary>
    public IList<�ard> Cards { get; set; }

    public static Deck New(string name)
      => new Deck(name);

  }
}
