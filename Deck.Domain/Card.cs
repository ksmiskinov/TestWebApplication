using System;

namespace DeckCards.Domain
{
  public class Card
  {
    private Card()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Deck Deck { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid DeckId { get; set; }

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
    public static Card New(CardKind kind, CardRang rang, int position)
      => new Card()
      {
        Kind = kind,
        Rang = rang,
        Position = position
      };
  }
}
