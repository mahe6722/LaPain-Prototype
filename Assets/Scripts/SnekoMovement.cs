using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnekoMovement : MonoBehaviour {

    public float snekoSpeed;
    public float retreatSpeed;
    public float currentSpeed;

    public int direction = -1;

    public bool retreating = false;
    //This value counts how many times the carrot almost got caught by Spitfire. Use this value to change the behavior of Sneko after 3 "Close Calls". Boss fight will now begin when all enemies are cleared! 
    public int stageCounter;
   

    //Maximum travel distance towards middle of the screen
    public int leftBorder = 2;

    //Maximum travel distance towards the right endge of the screen.
    public int rightBorder = 10;

    //Use this to Progress Boss movement towards player. Decrement as Enemies die!
    public int currentBorder;

  
    void Start () {
        currentSpeed = snekoSpeed;
	}
	
	
	void FixedUpdate () {

        //if boss is going to start retreating we want fast speed and set retreating to true
        if (direction > 0) 
        {
            currentSpeed = retreatSpeed;
            retreating = true;
        }
        else {
            currentSpeed = snekoSpeed;
        }

        if (transform.position.x > leftBorder) {
        
            //reset direction and stop retreating when boss hits right border.
            if (transform.position.x > rightBorder) 
            {
                direction = -direction;
                retreating = false;
            }
            
            //Gradually Approaching leftBorder, currentBorder is changed as the player damages the enemies. (Done in Player Projectile script)
            if (transform.position.x > currentBorder) {

            //Moving the Boss
            transform.Translate(direction * currentSpeed * Time.deltaTime, 0, 0);
            }
            
            
        }
    }

    private void LateUpdate()
    {
        if (retreating == true) {
            print("Boss is Retreating!");
            //Moving the Boss
            transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
        }
    }
}
