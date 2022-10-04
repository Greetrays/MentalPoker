using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardMover))]
[RequireComponent(typeof(CardRenderer))]

public class CardTemplate : MonoBehaviour
{
    private CardMover _cardMover;
    private CardRenderer _cardRenderer;

    private void Awake()
    {
        _cardMover = GetComponent<CardMover>();
        _cardRenderer = GetComponent<CardRenderer>();
    }

    public void Init(Sprite faceSprite, Vector3 targetPosition)
    {
        _cardMover.Init(targetPosition);
        _cardRenderer.Render(faceSprite);
    }
}
