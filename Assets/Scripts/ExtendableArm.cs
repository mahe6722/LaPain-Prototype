using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendableArm : MonoBehaviour
{
    public float armReach;//5
    public float speed;

    //public LayerMask whatIsSolid;

    SnekoMovement snekoMovement;

    GameObject player;

    private int borderReset;

    private float distance = 0.1f;

    private bool extending = false;
    private bool returning = false;
    private bool isActive = false;

    private Vector2 origLocation;


    void Start()
    {
        player = GameObject.Find("Player");
        snekoMovement = GameObject.Find("Sneko").GetComponent<SnekoMovement>();
        borderReset = snekoMovement.currentBorder;
    }

    void Update()
    {
        if (extending && gameObject.transform.position.x < armReach)
        {
            gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime);
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.CompareTag("Carrot"))
                {
                    //Accessing the movement script for Sneko. This tells Sneko to retreat because the arm would reach his carrot.
                    snekoMovement.direction = 1;
                    snekoMovement.currentBorder = borderReset;
                    //Counting how many times Spitfire almost caught the carrot with "stageCounter". After 3 "Close Calls" Sneko will change his behavior. Boss fight is not imminent. 
                    snekoMovement.stageCounter++;
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
            if (Vector2.Distance(gameObject.transform.position, origLocation) < 0.3)
            {
                returning = false;
                isActive = false;
                gameObject.transform.parent = player.transform;
                player.GetComponent<PlayerMovement>().enabled = true;
                gameObject.transform.position = origLocation;
            }
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
            origLocation = gameObject.transform.position;
        }
    }

    public void DetachFromParent()
    {
        // Detaches the transform from its parent.
        transform.parent = null;
    }
}
