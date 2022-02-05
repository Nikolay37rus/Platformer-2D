using System;
using UnityEngine;

public class LevelObjectView : MonoBehaviour
{

    public Transform _Transform;
    public SpriteRenderer SpriteRenderer;
    public Rigidbody2D _rigidbody2D;
    public Collider2D _collider2D;

    public Action<CoinView> OnObjectContact;

    void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.TryGetComponent(out CoinView levelObject);
        OnObjectContact?.Invoke(levelObject);
    }

}
