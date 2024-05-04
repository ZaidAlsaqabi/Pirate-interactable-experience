using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    public Component openchest;
    public GameObject keygone;

    void OnTriggerStay(Collider other) 
    {
        if (Input.GetKey(KeyCode.F))
        {
            openchest.GetComponent<BoxCollider>().enabled = true; 
        }

        if (Input.GetKey(KeyCode.F))
        {
            keygone.SetActive(false);
        }
    }
}