using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]Rigidbody rb;
    [SerializeField] Transform lookAt;
    Vector3 destenation;
    
    public void Move(Vector3 direction, float speed)
    {
        if (direction != Vector3.zero)
        {
            direction.y = 0;
            destenation = transform.position + direction * 2;
            lookAt.position = destenation;
            transform.LookAt(lookAt);
            rb.velocity = transform.forward * speed;

        }
        else rb.velocity = Vector3.zero;
    }
}
