using System;

namespace DeckCards.Domain
{
  public class Card
  {
    private Card() { }

    /// <summary>
    /// Уникальный идентификатор объекта
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Ассоциация  с объектом
    /// </summary>
    public Deck Deck { get; set; }

    /// <summary>
    /// Уникальный идентификатор объекта
    /// </summary>
    public Guid DeckId { get; set; }

    /// <summary>
    /// Тип карты (черви, крести, бубей, пики)
    /// </summary>
    public CardKind Kind { get; set; }

    /// <summary>
    /// Ранг карты
    /// </summary>
    public CardRank Rank { get; set; }

    /// <summary>
    /// Позиция карты в колоде
    /// </summary>
    public int Position { get; set; }

    public string GetName()
      => Kind.ToString() + " " + Rank.ToString();

    /// <summary>
    /// Создание новой колоды
    /// </summary>
    /// <param name="kind">Масть карты</param>
    /// <param name="rank">Достоинство карты</param>
    /// <param name="position">Позиция в колоде</param>
    /// <returns></returns>
    public static Card New(CardKind kind, CardRank rank, int position)
      => new Card()
      {
        Kind = kind,
        Rank = rank,
        Position = position
      };
  }
}
