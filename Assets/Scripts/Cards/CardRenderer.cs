using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class CardRenderer : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Render(Sprite face)
    {
        _spriteRenderer.sprite = face;
    }
}
