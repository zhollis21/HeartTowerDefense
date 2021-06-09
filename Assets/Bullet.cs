using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage = 1;
    public int Pierce = 1;
    public int Speed = 1;
    public int Range = 5;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = transform.up * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);
    }
}
