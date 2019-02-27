using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class sound : MonoBehaviour
{


    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            this.GetComponent<AudioSource>().Play();
            Debug.Log("PLayed Sound!");

        }
    }

}