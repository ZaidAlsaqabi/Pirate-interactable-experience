using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autodoor : MonoBehaviour
{
    public Animator doorAnim;
    public AudioSource openSound; 
    public AudioSource closeSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.SetTrigger("open");
            if (openSound != null)
            {
                openSound.Play(); 
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.SetTrigger("close");
            if (closeSound != null)
            {
                doorAnim.SetTrigger("close");
            }
        }
    }
}