using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotGrab : MonoBehaviour
{
    SnekoMovement snekoMovementScript;
    ExtendableArm extendableArmScript;


	void Start ()
    {
        snekoMovementScript = GameObject.Find("Sneko").GetComponent<SnekoMovement>();
        extendableArmScript = GameObject.Find("ExtArm").GetComponent<ExtendableArm>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (snekoMovementScript.stageCounter == snekoMovementScript.numberOfStages)
        {
            if (other.tag == "ExtArm")
            {
                gameObject.transform.parent = null;
                gameObject.transform.parent = GameObject.Find("ExtArm").transform;
                Destroy(gameObject);
            }
        }
    }
}
