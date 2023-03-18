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

        sortedCards.AddRange(SeparateAndSortLists(troefCard));

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
            CardTypes type = card.GetComponent<EmptyCard>().type;

            if (type == CardTypes.Harten)
            {
                hartenCards.Add(card);
            }
            else if (type == CardTypes.Klavers)
            {
                klaversCards.Add(card);
            }
            else if (type == CardTypes.Ruiten)
            {
                ruitenCards.Add(card);
            }
            else if (type == CardTypes.Schoppen)
            {
                schoppenCards.Add(card);
            }
        }
    }

    List<GameObject> SeparateAndSortLists(CardTypes troefCard)
    {
        List<GameObject> redList1 = hartenCards;
        List<GameObject> blackList1 = klaversCards;
        List<GameObject> redList2 = ruitenCards;
        List<GameObject> blackList2 = schoppenCards;

        if (klaversCards.Count == 0 && ruitenCards.Count != 0)
        {
            blackList1 = schoppenCards;
            blackList2 = klaversCards;
        }
        else if (ruitenCards.Count == 0 && klaversCards.Count != 0)
        {
            redList1 = ruitenCards;
            redList2 = hartenCards;
        }

        List<GameObject> combinedList = new();

        combinedList.AddRange(OrderListByWaarde(redList1, troefCard));
        combinedList.AddRange(OrderListByWaarde(blackList1, troefCard));
        combinedList.AddRange(OrderListByWaarde(redList2, troefCard));
        combinedList.AddRange(OrderListByWaarde(blackList2, troefCard));

        return combinedList;
    }

    List<GameObject> OrderListByWaarde(List<GameObject> cards, CardTypes troefCard)
    {
        if (cards.Count == 0)
            return new List<GameObject>();

        Dictionary<GameObject, int> cardValues = new();

        foreach(GameObject card in cards)
        {
            EmptyCard emptyCard = card.GetComponent<EmptyCard>();

            int cardRanking = emptyCard.type == troefCard ? emptyCard.troefRanking : emptyCard.speelRanking;
            cardValues.Add(card, cardRanking);
        }

        List<GameObject> keys = new();

        foreach (KeyValuePair<GameObject, int> pair in cardValues.OrderBy(key => key.Value).Reverse())
        {
            keys.Add(pair.Key);
        }

        return keys;
    }
}
