using System;

namespace DeckCards.Domain
{
  /// <summary>
  /// Описывает позицию карты в колоде.
  /// </summary>

  public class PositionCard
  {
    private PositionCard() { }

    /// <summary>
    /// Уникальный идентификатор объекта
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Ассоциация  с объектом
    /// </summary>
    public Deck Deck { get; set; }

    ///// <summary>
    ///// Уникальный идентификатор объекта 
    ///// </summary>
    public Guid DeckId { get; set; }
    
    /// <summary>
    /// Ассоциация  с объектом
    /// </summary>
    public Card Card { get; set; }

    /// <summary>
    /// Позиция карты в колоде
    /// </summary>
    public int Position { get; set; }
    
    /// <summary>
    /// Создание новой колоды
    /// </summary>
    /// <param name="kind">Масть карты</param>
    /// <param name="rank">Достоинство карты</param>
    /// <param name="position">Позиция в колоде</param>
    /// <returns></returns>
    public static PositionCard New(CardKind kind, CardRank rank, int position)
      => new PositionCard()
      { 
        Card = Card.New(kind, rank),
        Position = position
      };
  }
}
