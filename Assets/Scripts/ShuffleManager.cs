using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleManager : MonoBehaviour
{
    [SerializeField] List<Card> allCards;
    List<Card> cardsToBeShuffled;

    [SerializeField] Deck[] allDecks;

    [SerializeField] int cardsPerPlayer = 8;

    void Start()
    {
        ResetCardsToBeShuffled();
        ShuffleCards();
    }

    public void ResetCardsToBeShuffled()
    {
        cardsToBeShuffled = allCards;
    }

    public void ShuffleCards()
    {
        foreach(Deck deck in allDecks)
        {
            for (int i = 1; i <= 8; i++)
            {
                Card randomCard = cardsToBeShuffled[Random.Range(0, cardsToBeShuffled.Count)];
                deck.CreateNewCard(randomCard);

                cardsToBeShuffled.Remove(randomCard);
            }
        }
    }
}
