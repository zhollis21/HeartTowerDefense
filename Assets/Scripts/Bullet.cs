using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage = 1;
    public int Pierce = 1;
    public int Speed = 1;
    public int Range = 7;

    private int _pierceRemaining;
    private Vector2 _startPoint;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = transform.up * Speed;

        _pierceRemaining = Pierce;
        _startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(_startPoint, transform.position) > Range)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Guard against hitting 2 at the same time
        if (_pierceRemaining > 0)
        {
            other.gameObject.SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);
        }

        _pierceRemaining--;

        if (_pierceRemaining < 1)
        {
            Destroy(gameObject);
        }
    }
}
