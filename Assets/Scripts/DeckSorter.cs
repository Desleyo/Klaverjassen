using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckSorter : MonoBehaviour
{
    [SerializeField] CardTypes[] allCardTypes;

    public List<GameObject> GetSortedCards(List<GameObject> cards)
    {
        List<GameObject> sortedCards = new();

        foreach (CardTypes cardType in allCardTypes)
        {
            foreach (GameObject card in cards)
            {
                if(card.GetComponent<EmptyCard>().type == cardType)
                {
                    sortedCards.Add(card);
                }
            }
        }

        return sortedCards;
    }
}
