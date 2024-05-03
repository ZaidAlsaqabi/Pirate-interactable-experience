using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform Player; // The target object to look at

    void Update()
    {
        if (Player != null)
        {
            // Rotate this object to look at the target
            transform.LookAt(Player);
        }
    }
}