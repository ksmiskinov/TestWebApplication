using Microsoft.EntityFrameworkCore;
using System;

namespace DeckCards.Domain
{
  /// <summary>
  /// Сущность карта
  /// </summary>
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
    public PositionCard PositionCard { get; set; }

    /// <summary>
    /// Уникальный идентификатор объекта
    /// </summary>
    public Guid PositionCardId { get; set; }

    /// <summary>
    /// Тип карты (черви, крести, бубей, пики)
    /// </summary>
    public CardKind Kind { get; set; }

    /// <summary>
    /// Ранг карты
    /// </summary>
    public CardRank Rank { get; set; }

    public string GetName()
      => Kind.ToString() + " " + Rank.ToString();

    /// <summary>
    /// Создание новой колоды
    /// </summary>
    /// <param name="kind">Масть карты</param>
    /// <param name="rank">Достоинство карты</param>
    /// <returns></returns>
    public static Card New(CardKind kind, CardRank rank)
      => new Card()
      {
        Kind = kind,
        Rank = rank
      };
  }
}
