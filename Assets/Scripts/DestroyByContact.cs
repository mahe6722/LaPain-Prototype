using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    PlaceHolder_Health playerHealth;

    public int turtleDamage;

    void Awake()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlaceHolder_Health>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //If Bullet Hits Player we want to damage player and destory the bullet.
        if (other.tag == "Player") {
            print("Enemy Damaged the Player");
            Destroy(gameObject);

            playerHealth.TakeDamage(turtleDamage);
            
        }

        //Make sure that if the bullet collides with any other collider it should also destroy. 
        // However we remove destruction IF impact on Enemy or Carrot occurs. This is a safety-net for the FriendlyFire system.
        else if(other.tag != "Enemy" && other.tag != "Carrot") {
        Destroy(gameObject);
        }
    }

}
