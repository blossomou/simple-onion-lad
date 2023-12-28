using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rigidBody => GetComponent<Rigidbody2D>();

    void Update() => transform.right = rigidBody.velocity;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Target")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        
    }
}
