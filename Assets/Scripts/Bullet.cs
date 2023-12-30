using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rigidBody => GetComponent<Rigidbody2D>();

    [Space]
    [SerializeField] private GunController gunController;


     private void Awake() 
     {
        gunController = FindObjectOfType<GunController>();
     }

    void Update() => transform.right = rigidBody.velocity;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Target")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            UI.instance.AddScore();
        }

        if(collision.tag == "Reload")
        {
          
            gunController.ReloadGun();
            Destroy(gameObject);
            Destroy(collision.gameObject);

        }
        
    }
}
