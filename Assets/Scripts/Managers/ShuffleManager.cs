using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleManager : MonoBehaviour
{
    public static ShuffleManager instance;

    [SerializeField] List<Card> allCards;
    List<Card> cardsToBeShuffled;

    [SerializeField] Deck[] allDecks;

    [SerializeField] int[] shuffleSequence;

    private void Awake()
    {
        instance = this;
    }

    public void ShuffleCards()
    {
        cardsToBeShuffled = allCards;

        foreach(int sequence in shuffleSequence)
        {
            ShuffleCardsBySequence(sequence);
        }
    }

    void ShuffleCardsBySequence(int sequence)
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
