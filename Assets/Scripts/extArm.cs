using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extArm : MonoBehaviour
{
    private bool isActive = false;
    private float maxDistance = 1.9f;    // maxDistance of extArm on x Axis in 1.9

    public float speed;

    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Vector3 startPos = GameObject.Find("Player").transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == false)
        {
            isActive = true;
            transform.position = transform.forward * speed;
        }
	}
}
