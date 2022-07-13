using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmptyCard : MonoBehaviour
{
    Image image;

    public CardTypes type;

    public int troefRanking;
    public int speelRanking;

    public int troefWaarde;
    public int speelWaarde;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void CopyCardInformation(Card randomCard)
    {
        image.sprite = randomCard.cardSprite;

        type = randomCard.type;

        troefRanking = randomCard.troefRanking;
        speelRanking = randomCard.speelRanking;

        troefWaarde = randomCard.troefWaarde;
        speelWaarde = randomCard.speelWaarde;
    }
}
