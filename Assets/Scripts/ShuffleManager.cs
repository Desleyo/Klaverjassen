using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleManager : MonoBehaviour
{
    [SerializeField] List<Card> allCards;
    List<Card> cardsToBeShuffled;

    [SerializeField] Deck[] allDecks;

    [SerializeField] int[] shuffleSequence;

    void Start()
    {
        ResetCardsToShuffle();
    }

    public void ResetCardsToShuffle()
    {
        cardsToBeShuffled = allCards;

        foreach(int sequence in shuffleSequence)
        {
            ShuffleCards(sequence);
        }
    }

    public void ShuffleCards(int sequence)
    {
        foreach(Deck deck in allDecks)
        {
            for (int i = 1; i <= sequence; i++)
            {
                Card randomCard = cardsToBeShuffled[Random.Range(0, cardsToBeShuffled.Count)];
                deck.CreateNewCard(randomCard);

                cardsToBeShuffled.Remove(randomCard);
            }
        }
    }
}
