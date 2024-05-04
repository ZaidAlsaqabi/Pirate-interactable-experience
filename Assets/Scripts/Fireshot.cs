using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireShot : MonoBehaviour
{
    public AudioClip shotSound; 
    public ParticleSystem shotParticles; 
    public TextMeshPro hintText; 

   
    public float displayDistance = 5f;

  
    private bool playerNearCollider = false;

    void Update()
    {
        if (playerNearCollider && IsPlayerClose())
        {
          
            hintText.gameObject.SetActive(true);

           
            if (Input.GetKeyDown(KeyCode.F))
            {
                
                Fire();
            }
        }
        else
        {
            
            hintText.gameObject.SetActive(false);
        }
    }

    bool IsPlayerClose()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            return Vector3.Distance(transform.position, player.transform.position) <= displayDistance;
        }
        return false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearCollider = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearCollider = false;
        }
    }

    void Fire()
    {
       
        AudioSource.PlayClipAtPoint(shotSound, transform.position);

        
        shotParticles.Play();

       
    }
}