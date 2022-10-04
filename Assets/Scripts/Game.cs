using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Game : MonoBehaviour
{
    [SerializeField] private Transform _playersContainer;
    [SerializeField] private Deck _deck;
    [SerializeField] private float _delay;
    [SerializeField] private CardTemplate _cardTemplate;

    private List<Player> _players = new List<Player>();

    private void Start()
    {
        FillPlayers();
        InitPlayers();
        DealCards();
        DealCards();
       StartCoroutine(MoveCards());
    }

    /*private void MoveCards()
    {
        foreach (var player in _players)
        {
            CardTemplate newCard1 = Instantiate(_cardTemplate, _deck.transform.position, Quaternion.identity);
            CardTemplate newCard2 = Instantiate(_cardTemplate, _deck.transform.position, Quaternion.identity);
            player.PullCard(newCard1, newCard2);
        }
    }*/
    
    private void InitPlayers()
    {
        foreach (var player in _players)
        {
            player.Init(_deck.P);
            player.EncodeDeck(_deck);
        }
    }

    private void FillPlayers()
    {
        for (int i = 0; i < _playersContainer.childCount; i++)
        {
            _players.Add(_playersContainer.GetChild(i).GetComponent<Player>());
        }
    }

    private void DealCards()
    {
        foreach (var player in _players)
        {
            var otherPlayers = from Player plr in _players
                               where plr != player
                               select plr;

            player.DecodeCardFromPlayers(_deck.GetRandomCard(), otherPlayers.ToList());
        }
    }

    private IEnumerator MoveCards()
    {
        foreach (var player in _players)
        {
            CardTemplate newCard1 = Instantiate(_cardTemplate, _deck.transform.position, Quaternion.identity);
            CardTemplate newCard2 = Instantiate(_cardTemplate, _deck.transform.position, Quaternion.identity);
            player.PullCardAsync(newCard1, newCard2);
            yield return new WaitForSeconds(_delay);
        }
    }
}
