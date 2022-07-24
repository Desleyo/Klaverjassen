using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DeckSorter : MonoBehaviour
{
    [HideInInspector] public List<GameObject> hartenCards;
    [HideInInspector] public List<GameObject> klaversCards;
    [HideInInspector] public List<GameObject> ruitenCards;
    [HideInInspector] public List<GameObject> schoppenCards;

    public List<GameObject> GetSortedCards(List<GameObject> cards, CardTypes troefCard)
    {
        if(troefCard == CardTypes.None)
        {
            SortCards(cards);
        }

        List<GameObject> sortedCards = new();

        sortedCards.AddRange(OrderListByWaarde(hartenCards, troefCard));
        sortedCards.AddRange(OrderListByWaarde(klaversCards, troefCard));
        sortedCards.AddRange(OrderListByWaarde(ruitenCards, troefCard));
        sortedCards.AddRange(OrderListByWaarde(schoppenCards, troefCard));

        return sortedCards;
    }

    void SortCards(List<GameObject> cards)
    {
        hartenCards = new();
        klaversCards = new();
        ruitenCards = new();
        schoppenCards = new();

        foreach (GameObject card in cards)
        {
            if (card.GetComponent<EmptyCard>().type == CardTypes.Harten)
            {
                hartenCards.Add(card);
            }
            else if (card.GetComponent<EmptyCard>().type == CardTypes.Klavers)
            {
                klaversCards.Add(card);
            }
            else if (card.GetComponent<EmptyCard>().type == CardTypes.Ruiten)
            {
                ruitenCards.Add(card);
            }
            else if (card.GetComponent<EmptyCard>().type == CardTypes.Schoppen)
            {
                schoppenCards.Add(card);
            }
        }
    }

    List<GameObject> OrderListByWaarde(List<GameObject> cards, CardTypes troefCard)
    {
        if (cards.Count == 0)
            return new List<GameObject>();

        Dictionary<GameObject, int> cardValues = new();
        List<GameObject> keys = new();

        foreach(GameObject card in cards)
        {
            EmptyCard emptyCard = card.GetComponent<EmptyCard>();

            int cardRanking = emptyCard.type == troefCard ? emptyCard.troefRanking : emptyCard.speelRanking;
            cardValues.Add(card, cardRanking);
        }

        foreach(KeyValuePair<GameObject, int> pair in cardValues.OrderBy(key => key.Value).Reverse())
        {
            keys.Add(pair.Key);
        }

        return keys;
    }
}
