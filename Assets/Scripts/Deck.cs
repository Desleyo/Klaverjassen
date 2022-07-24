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
            SortCards(CardTypes.None);
        }
    }

    void SortCards(CardTypes troefCard)
    {
        currentCards = deckSorter.GetSortedCards(currentCards, troefCard);

        foreach(GameObject card in currentCards)
        {
            card.transform.SetParent(transform);
            card.transform.rotation = transform.rotation;
        }
    }
}
