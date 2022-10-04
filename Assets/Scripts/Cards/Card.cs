using System.Numerics;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Create new Cars", order = 51)]

public class Card : ScriptableObject
{
    [SerializeField] private Sprite _iconFace;
    [SerializeField] private Sprite _iconShirt;
    [SerializeField] private int _number;

    private BigInteger _encodeNumber;

    public BigInteger EncodeNumber => _encodeNumber;
    public Sprite IconFace => _iconFace;
    public Sprite IconShirt => _iconShirt;
    
    public void InitEncodeNumber()
    {
        _encodeNumber = _number;
    }

    public void EnDecode(BigInteger degree, BigInteger p)
    {
        _encodeNumber = BigInteger.Pow(_encodeNumber, (int)degree) % p;
    }
}
