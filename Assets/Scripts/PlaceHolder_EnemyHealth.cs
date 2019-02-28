using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolder_EnemyHealth : MonoBehaviour {

    public int startingHealth;
    public int currentHealth;

    ManagerEnemy managerEnemy;
    TurtleMovement turtleMovement;
    SpriteRenderer turtleSprite;
    Color startColor;
    private float flashSpeed = 5f;

	// Use this for initialization
	void Awake () {
        currentHealth = startingHealth;
        managerEnemy = GameObject.Find("EnemyManager").GetComponent<ManagerEnemy>();
        turtleMovement = GetComponent<TurtleMovement>();

        turtleSprite = GetComponent<SpriteRenderer>();
        startColor = turtleSprite.color;

    }
	
	// Update is called once per frame
	void Update () {

		if (currentHealth <= 0) {
            Death();
            managerEnemy.currentTurtles--;
        }

        //Player Projectiles will on collision make the enemies Red. If they are red, next frame they will lerp towards their original color!
        if (turtleSprite.color != startColor) 
        {
            turtleSprite.color = Color.Lerp(turtleSprite.color, startColor, flashSpeed * Time.deltaTime);
        }
            
    }

    void Death()
    {
        
        //Tell the game that the lane this Turtle occupied now is free!
        if (turtleMovement.laneID == 1) {
            managerEnemy.spawnLane1 = false;
        } else if (turtleMovement.laneID == 2) {
            managerEnemy.spawnLane2 = false;
        } else if (turtleMovement.laneID == 3) {
            managerEnemy.spawnLane3 = false;
        }

        Destroy(gameObject);
        AudioSource sound = gameObject.GetComponent<AudioSource>();
        sound.Play();
    }
}
