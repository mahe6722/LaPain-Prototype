using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolder_EnemyHealth : MonoBehaviour {

    public int startingHealth;
    public int currentHealth;

    ManagerEnemy managerEnemy;
    TurtleMovement turtleMovement;

	// Use this for initialization
	void Awake () {
        currentHealth = startingHealth;
        managerEnemy = GameObject.Find("EnemyManager").GetComponent<ManagerEnemy>();
        turtleMovement = GetComponent<TurtleMovement>();
    }
	
	// Update is called once per frame
	void Update () {

		if (currentHealth <= 0) {
            Death();
            managerEnemy.currentTurtles--;
        }

    }

    void Death()
    {
        

        //Tell the game the the lane this Turtle occupied now is free!
        if (turtleMovement.laneID == 1) {
            managerEnemy.spawnLane1 = false;
        } else if (turtleMovement.laneID == 2) {
            managerEnemy.spawnLane2 = false;
        } else if (turtleMovement.laneID == 3) {
            managerEnemy.spawnLane3 = false;
        }

        Destroy(gameObject);      

    }
}
