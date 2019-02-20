using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterHealth : MonoBehaviour {

    public int startingHealth;
    public int currentHealth;

    ManagerEnemy managerEnemy;

    // Use this for initialization
    void Start () {
        currentHealth = startingHealth;
        managerEnemy = GameObject.Find("EnemyManager").GetComponent<ManagerEnemy>();
    }
	
	// Update is called once per frame
	void Update () {
        if (currentHealth <= 0) {
            Death();
            managerEnemy.currentHamsters--;
        }
    }

    void Death()
    {

        Destroy(gameObject);

    }
}
