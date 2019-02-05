using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMovement : MonoBehaviour {

    public float turtleSpeed;
    

    float direction = 1; //Start Moving the Turtle Up
    int topBorder = 4;
    int botBorder = -4;
    float unitID;
    public float frequency;


    // Use this for initialization
    void Start () {
       unitID = Random.Range(1, 10);
        
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.y >= topBorder) {
            direction = -1;
        }

        else if (transform.position.y <= botBorder) {
            direction = 1;
        } 
        else {
            //Use Sinus Curve to Shift the direction of the Enemies with the offset of unitID
            direction = Mathf.Sin((Time.time + unitID) * frequency);
        }

        transform.Translate(0, 0.5f * turtleSpeed * direction * Time.deltaTime, 0);
	}
}
