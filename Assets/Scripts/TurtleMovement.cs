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

    public GameObject SpawnLane1;  
    public GameObject SpawnLane2; 
    public GameObject SpawnLane3;

    ManagerEnemy managerEnemy;

    public int laneID;

    // Use this for initialization
    void Start () {
       unitID = Random.Range(1, 10);

        managerEnemy = GameObject.Find("EnemyManager").GetComponent<ManagerEnemy>();
        SpawnLane1 = GameObject.Find("TurtleSpawnLane1");
        SpawnLane2 = GameObject.Find("TurtleSpawnLane2");
        SpawnLane3 = GameObject.Find("TurtleSpawnLane3");
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        //What Lane is the Enemy located at? That lane is occupied.
        if (transform.position.x == SpawnLane1.transform.position.x) {
            managerEnemy.spawnLane1 = true;
            laneID = 1;
        }
        if (transform.position.x == SpawnLane2.transform.position.x) {
            managerEnemy.spawnLane2 = true;
            laneID = 2;
        }
        if (transform.position.x == SpawnLane3.transform.position.x) {
            managerEnemy.spawnLane3 = true;
            laneID = 3;
        }

        MainMovement();
    }

    void MainMovement()
    {
        if (transform.position.y >= topBorder) {
            direction = -1;
        } else if (transform.position.y <= botBorder) {
            direction = 1;
        } else {
            //Use Sinus Curve to Shift the direction of the Enemies with the offset of unitID
            direction = Mathf.Sin((Time.time + unitID) * frequency);
        }

        transform.Translate(0, 0.5f * turtleSpeed * direction * Time.deltaTime, 0);
    }
}
