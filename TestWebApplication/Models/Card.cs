using System;

namespace TestWebApplication.Models
{
  public class Сard
  {
    private Сard()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Тип карты (черви, крести, бубей, пики)
    /// </summary>
    public CardKind Kind { get; set; }

    /// <summary>
    /// Ранг карты
    /// </summary>
    public CardRang Rang { get; set; }

    /// <summary>
    /// Позиция карты в колоде
    /// </summary>
    public int Position { get; set; }

    /// <summary>
    /// Создание новой колоды
    /// </summary>
    /// <param name="kind">Масть карты</param>
    /// <param name="rang">Достоинство карты</param>
    /// <param name="position">Позиция в колоде</param>
    /// <returns></returns>
    public static Сard New(CardKind kind, CardRang rang, int position)
      => new Сard()
      {
        Kind = kind,
        Rang = rang,
        Position = position
      };
  }
}
