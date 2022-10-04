using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class Deck : MonoBehaviour
{
    [SerializeField] private List<Card> _deck;

    private BigInteger p;
    private CriptoHelper _criptoHelper = new CriptoHelper();

    public BigInteger P => p;

    private void Awake()
    {
        foreach (var card in _deck)
        {
            card.InitEncodeNumber();
        }

        p = _criptoHelper.GetPrimeRandomNumber(_deck.Count + 1, 2);
    }

    public void EnDecodeCards(BigInteger degree)
    {
        foreach (var card in _deck)
        {
            card.EnDecode(degree, p);
        }
    }

    public void Shuffle()
    {
        int value1;
        int value2;
        Card tempValue;

        for (int i = 0; i < _deck.Count; i++)
        {
            value1 = Random.Range(0, _deck.Count);
            value2 = Random.Range(0, _deck.Count);

            tempValue = _deck[value1];
            _deck[value1] = _deck[value2];
            _deck[value2] = tempValue;
        }
    }

    public Card DecodeCard(Card card, BigInteger degree)
    {
        card.EnDecode(degree, p);
        return card;
    }

    public Card GetRandomCard()
    {
        int rundomNumberCard = Random.Range(0, _deck.Count);
        Card card = _deck[rundomNumberCard];
        _deck.RemoveAt(rundomNumberCard);
        return card;
    }
}
