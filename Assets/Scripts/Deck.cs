using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public GameObject emptyCard;

    public List<GameObject> currentCards;

    public void CreateNewCard(Card randomCard)
    {
        GameObject newEmptyCard = Instantiate(emptyCard, transform);
        newEmptyCard.GetComponent<EmptyCard>().CopyCardInformation(randomCard);

        currentCards.Add(newEmptyCard);
    }
}
