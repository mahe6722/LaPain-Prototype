using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendableArm : MonoBehaviour
{
    public float armReach;
    public float speed;

    GameObject invisibleCollider;

    SnekoMovement snekoMovementScript;

    GameObject player;

    private int borderReset;

    private float distance = 0.01f;

    private bool extending = false;
    private bool returning = false;
    private bool isActive = false;

    private Vector2 origArmLocation;
    private Vector2 origSnekoLocation;


    void Start()
    {
        player = GameObject.Find("Player");

        snekoMovementScript = GameObject.Find("Sneko").GetComponent<SnekoMovement>();
        borderReset = snekoMovementScript.currentBorder;

        invisibleCollider = GameObject.Find("InvisibleShield");

        origSnekoLocation = GameObject.Find("Sneko").GetComponent<Transform>().position;
    }

    void Update()
    {
        if (extending && gameObject.transform.position.x < armReach)
        {
            gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime);
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.CompareTag("NotCarrot"))
                {
                    snekoMovementScript.direction = 1;
                    snekoMovementScript.currentBorder = borderReset;

                    if (snekoMovementScript.stageCounter < 5)
                    {
                        snekoMovementScript.stageCounter++;
                    }                  

                    invisibleCollider.transform.position = invisibleCollider.transform.position + new Vector3(0.5f, 0, 0);
                    invisibleCollider.SetActive(false);
                }
                if (hitInfo.collider.CompareTag("Carrot"))
                {
                    //Accessing the movement script for Sneko. This tells Sneko to retreat because the arm would reach his carrot.

                    //Counting how many times Spitfire almost caught the carrot with "stageCounter". After 3 "Close Calls" Sneko will change his behavior. Boss fight is not imminent. 

                    snekoMovementScript.direction = 1;
                    snekoMovementScript.currentBorder = borderReset;

                    extending = false;
                    returning = true;
                }
            }

            if (gameObject.transform.position.x >= armReach)
            {
                extending = false;
                returning = true;
            }
        }

        if (returning)
        {
            gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (Vector2.Distance(gameObject.transform.position, origArmLocation) < 0.3)
            {
                returning = false;
                isActive = false;
                gameObject.transform.position = origArmLocation;
                if (player != null)
                {
                    gameObject.transform.parent = player.transform;
                    player.GetComponent<PlayerMovement>().enabled = true;
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }

        if (snekoMovementScript.stageCounter > 1 && Vector2.Distance(origSnekoLocation, GameObject.Find("Sneko").transform.position) < 0.1f && snekoMovementScript.stageCounter < 4)
        {
            invisibleCollider.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if (isActive == false && extending == false && returning == false && Input.GetKeyUp(KeyCode.Space) && player.GetComponent<Rigidbody2D>().velocity.magnitude <= 0)
        {
            isActive = true;
            extending = true;
            DetachFromParent();
            player.GetComponent<PlayerMovement>().enabled = false;
            //Vector2 origLocation = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            origArmLocation = gameObject.transform.position;
        }
    }

    public void DetachFromParent()
    {
        // Detaches the transform from its parent.
        transform.parent = null;
    }
}
