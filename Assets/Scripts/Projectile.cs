using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;

    public int playerDamage;

    SnekoMovement snekoMovement;
    PlaceHolder_EnemyHealth enemyHealth;
    HamsterHealth hamsterHealth;

    SpriteRenderer TurtleSprite;
    Color startColorTurtle;
    private float flashSpeed = 5f;

    SpriteRenderer HamsterSprite;
    Color startColorHamster;
    

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        snekoMovement = GameObject.Find("Sneko").GetComponent<SnekoMovement>();
        
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsSolid);
        if (hitInfo.collider != null) {

            if (hitInfo.collider.CompareTag("Enemy")) {
                Debug.Log("Enemy must take damage!");
                enemyHealth = hitInfo.collider.gameObject.GetComponent<PlaceHolder_EnemyHealth>();

                //Accessing the Sprite of the Enemy to make it flash red when taking damage
                TurtleSprite = hitInfo.collider.gameObject.GetComponent<SpriteRenderer>();
                startColorTurtle = TurtleSprite.color;

                if (TurtleSprite.color == startColorTurtle) {
                TurtleSprite.color = new Color(1f, 0f, 0f, 1);
                }
                              
                enemyHealth.currentHealth -= playerDamage;

                //Reduce currentBorder in SnekoMovement Script by 1. Not using "--" because this value might need to be changed to a smaller value for each shot.
                snekoMovement.currentBorder = snekoMovement.currentBorder - 1;
                
            }
            if (hitInfo.collider.CompareTag("Hamster")) {
                hamsterHealth = hitInfo.collider.gameObject.GetComponent<HamsterHealth>();

                HamsterSprite = hitInfo.collider.gameObject.GetComponent<SpriteRenderer>();
                startColorHamster = HamsterSprite.color;

                if (HamsterSprite.color == startColorHamster) {
                    HamsterSprite.color = new Color(1f, 0f, 0f, 1);
                }

                hamsterHealth.currentHealth -= playerDamage;
            }
                DestroyProjectile();
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}