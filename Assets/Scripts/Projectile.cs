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

                enemyHealth.currentHealth -= playerDamage;

                //Reduce currentBorder in SnekoMovement Script by 1. Not using "--" because this value might need to be changed to a smaller value for each shot.
                snekoMovement.currentBorder = snekoMovement.currentBorder - 1;
                
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