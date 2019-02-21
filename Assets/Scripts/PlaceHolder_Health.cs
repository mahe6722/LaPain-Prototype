using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceHolder_Health : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public int actualHealth;

    public Slider healthSlider;
    public Image enrageImage;
    public Sprite enrageState2;
    public Sprite enrageState3;

    bool isDead;
    bool takesDamage;


	
	void Awake () {
        currentHealth = startingHealth;
        actualHealth = startingHealth + 50;
	}
	
	// Update is called once per frame
	void Update () {

        takesDamage = false;

        //Switching Between Enrage Sprites based on current health.
        if (currentHealth <= 75 && currentHealth > 25) {
            enrageImage.sprite = enrageState2;
            Gun.startTimeBtwShots = 0.4f;
            
        }
        if (currentHealth <= 25) {
            enrageImage.sprite = enrageState3;
            Gun.startTimeBtwShots = 0.2f;
        }
        
	}

    //Access this Script from DestroyByContact on the Laser_Projectiles. This will pass the damage value of the Turtle to "TakeDamage"
    public void TakeDamage (int amount)
    {
        takesDamage = true;

        if (currentHealth > 25) {
        currentHealth -= amount;
        }

        actualHealth -= amount;
        
        if (actualHealth > 25) {
        healthSlider.value = currentHealth;
        }
        else {
            healthSlider.value = actualHealth;
        }

        if(actualHealth <= 0 && !isDead) 
        {
            currentHealth = 0;
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
