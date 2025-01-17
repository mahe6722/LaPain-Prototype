﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEnemy : MonoBehaviour {

    public int turtleCount;
    public int currentTurtles;
    public int hamsterCount;
    public int currentHamsters;

    public bool spawnLane1 = false;
    public bool spawnLane2 = false;
    public bool spawnLane3 = false;

    public bool hamsterLane1 = false;

    public GameObject hoveringTurtle;
    TurtleMovement turtleMovement;

    GameObject hamsterSpawnLane;
    public GameObject hamsterEnemy;
  
    SnekoMovement snekoMovementScript;

    // Use this for initialization
    void Start ()
    {
        currentTurtles = turtleCount;
        currentHamsters = hamsterCount;
        turtleMovement = GameObject.Find("Hovering Turtle").GetComponent<TurtleMovement>();
        hamsterSpawnLane = GameObject.Find("HamsterLane");

        snekoMovementScript = GameObject.Find("Sneko").GetComponent<SnekoMovement>();
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        if (snekoMovementScript.bossFightWaiting == false && snekoMovementScript.bossFightComencing == false)
        {
            if (currentTurtles < 3 && spawnLane1 == false)
            {
                print("Spawning in Lane 1");
                Instantiate(hoveringTurtle, turtleMovement.SpawnLane1.transform.position, turtleMovement.SpawnLane1.transform.rotation);
                currentTurtles++;
            }

            if (currentTurtles < 3 && spawnLane2 == false)
            {
                print("Spawning in Lane 2");
                Instantiate(hoveringTurtle, turtleMovement.SpawnLane2.transform.position, turtleMovement.SpawnLane1.transform.rotation);
                currentTurtles++;
            }

            if (currentTurtles < 3 && spawnLane3 == false)
            {
                print("Spawning in Lane 3");
                Instantiate(hoveringTurtle, turtleMovement.SpawnLane3.transform.position, turtleMovement.SpawnLane1.transform.rotation);
                currentTurtles++;
            }

            if (currentHamsters < 1)
            {
                Instantiate(hamsterEnemy, hamsterSpawnLane.transform.position, hamsterSpawnLane.transform.rotation);
                currentHamsters++;
            }
        }
		
	}
}
