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

    GameObject target;
    private Vector3 targetLocation;
    private Vector3 lookAngle;

    public GameObject hamsterLane1;
    ManagerEnemy managerEnemy;

    // Use this for initialization
    void Start () {
        unitID = Random.Range(1, 10);
        target = GameObject.Find("Player");

        managerEnemy = GameObject.Find("EnemyManager").GetComponent<ManagerEnemy>();
        hamsterLane1 = GameObject.Find("HamsterLane");

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x == hamsterLane1.transform.position.x) {
            managerEnemy.hamsterLane1 = true;
           
        }

        lookAngle = new Vector3(0, 0, 0);
        if (target != null) {
        targetLocation = -(transform.position - target.transform.position);
        }
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

       if (target != null) {

        Vector3 difference = -(target.transform.position - transform.position);
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        // -90 <= z <= 90
       
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        }

        transform.Translate(0.5f * hamsterSpeed * direction * Time.deltaTime, 0, 0, Space.World);
    }

}
