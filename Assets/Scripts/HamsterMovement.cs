using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterMovement : MonoBehaviour {

    public float hamsterSpeed;

    float direction = -1; //Start Moving the Hamster Left
    int leftBorder = 2;
    int rightBorder = 5;
    float unitID;
    public float frequency;


    // Use this for initialization
    void Start () {
        unitID = Random.Range(1, 10);

    }
	
	// Update is called once per frame
	void Update ()
    {
        MainMovement();

    }

    private void MainMovement()
    {
        if (transform.position.x <= leftBorder) {
            direction = 1;
        } else if (transform.position.x >= rightBorder) {
            direction = -1;
        } else {
            //Use Sinus Curve to Shift the direction of the Enemies with the offset of unitID
            direction = Mathf.Sin((Time.time + unitID) * frequency);
        }

        transform.Translate(0.5f * hamsterSpeed * direction * Time.deltaTime, 0, 0);
    }

}
