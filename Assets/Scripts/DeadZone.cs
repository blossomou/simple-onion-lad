using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision) 
   {
        if(collision.tag == "Target" || collision.tag == "Player")
        {
            UI.instance.OpenEndScreen(); //this will end the game!
        }
    
   }
}
