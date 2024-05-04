using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform Player; 
    public float maxDistance = 2f; 
    public float rotationSpeed = 5f; 

    void Update()
    {
        if (Player != null)
        {
            
            Vector3 direction = Player.position - transform.position;
            direction.y = 0f; 
            float distance = direction.magnitude;
            
            if (distance <= maxDistance)
            {
               
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}