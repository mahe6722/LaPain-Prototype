using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceHolder_Health : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;

    public Slider healthSlider;
    public Image enrageImage;
    public Sprite enrageState2;
    public Sprite enrageState3;

    bool isDead;
    bool takesDamage;


	
	void Awake () {
        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {

        takesDamage = false;

        //Switching Between Enrage Sprites based on current health.
        if (currentHealth <= 75 && currentHealth > 25) {
            enrageImage.sprite = enrageState2;
        }
        if (currentHealth <= 25) {
            enrageImage.sprite = enrageState3;
        }
        
	}

    //Access this Script from DestroyByContact on the Laser_Projectiles. This will pass the damage value of the Turtle to "TakeDamage"
    public void TakeDamage (int amount)
    {
        takesDamage = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        if(currentHealth <= 0 && !isDead) 
        {
            //Call the Function that takes care of the Death of the Player
            Death();
        }
    }

    //Kill the Player. Remove the Player GameObject from the Scene.
    void Death ()
    {
        isDead = true;
        Destroy(gameObject);
    }
}
