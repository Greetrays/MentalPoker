using System.Collections;
using UnityEngine;

public class CardMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _targetPosition;

    public void Init(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (transform.position != _targetPosition)
        {
            transform.position = Vector3.Lerp(transform.position, _targetPosition, _speed * Time.deltaTime);
            yield return null;
        }
    } 
}
