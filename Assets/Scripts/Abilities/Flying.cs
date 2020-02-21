using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    [SerializeField]Rigidbody rb;
    public Rigidbody RB { get { return rb; } }
 
    [SerializeField] Transform target;
    [SerializeField] LayerMask obstacles;
   

    public void Move(float speed)
    {
        rb.velocity = transform.forward * speed;
        Collider[] colls = Physics.OverlapSphere(target.position, 0.1f, obstacles);
        if (colls.Length != 0)
        {
            transform.Rotate(rb.rotation.x, rb.rotation.y+180, rb.rotation.z);
        }
    }

        
}
