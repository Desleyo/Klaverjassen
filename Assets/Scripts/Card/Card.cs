using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card", fileName = "New Card")]
public class Card : ScriptableObject
{
    public Sprite cardSprite;

    public CardTypes type;

    public int troefRanking;
    public int speelRanking;

    public int troefWaarde;
    public int speelWaarde;
}
