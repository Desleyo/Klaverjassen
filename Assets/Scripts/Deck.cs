using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] DeckSorter deckSorter;
    [SerializeField] GameObject emptyCard;

    [HideInInspector] public List<GameObject> currentCards;

    public void CreateNewCard(Card randomCard)
    {
        GameObject newEmptyCard = Instantiate(emptyCard);
        newEmptyCard.GetComponent<EmptyCard>().CopyCardInformation(randomCard);

        currentCards.Add(newEmptyCard);

        if(currentCards.Count == 8)
        {
            SortCards();
        }
    }

    void SortCards()
    {
        currentCards = deckSorter.GetSortedCards(currentCards);

        foreach(GameObject card in currentCards)
        {
            card.transform.SetParent(transform);
            card.transform.rotation = transform.rotation;
        }
    }
}
