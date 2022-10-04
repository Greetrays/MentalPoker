using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _slot1;
    [SerializeField] private Transform _slot2;
    [SerializeField] private int _delay;

    private BigInteger _c;
    private BigInteger _d;
    private CriptoHelper _criptoHelper = new CriptoHelper();
    private List<Card> _cards = new List<Card>();
    private BigInteger _p;

    public void EncodeDeck(Deck deck)
    {
        deck.EnDecodeCards(_c);
        deck.Shuffle();
    }
    
    public void Init(BigInteger p)
    {
        _p = p;
        _c = Random.Range(1, (int)_p - 1);

        while (_criptoHelper.CheckForMutualSimplicity(_c, _p - 1) == false)
        {
            _c = Random.Range(1, (int)_p - 1);
        }

        _d = _criptoHelper.FindGCDEvklid(_c, _p - 1)[2];

        if (_d < 0)
        {
            _d = (_d + _p - 1) % (_p - 1);
        }
    }

    public void DecodeCardFromPlayers(Card card, List<Player> players)
    {
        foreach (var player in players)
        {
            player.DecodeCard(card);
        }

        DecodeCard(card);
        _cards.Add(card);
    }

    public void DecodeCard(Card card)
    {
        card.EnDecode(_d, _p);
    }

    public async Task PullCardAsync(CardTemplate card1, CardTemplate card2)
    {
        if (gameObject.TryGetComponent(out MainPlayer mainPlayer))
        {
            card1.Init(_cards[0].IconFace, _slot1.position);
            await Task.Delay(_delay);
            card2.Init(_cards[1].IconFace, _slot2.position);
        }
        else
        {
            card1.Init(_cards[0].IconShirt, _slot1.position);
            await Task.Delay(_delay);
            card2.Init(_cards[1].IconShirt, _slot2.position);
        }
    }
}
