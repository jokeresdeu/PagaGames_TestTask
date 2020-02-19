using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]float speed;
    float direcction = 1;
    [SerializeField] Transform target;
    [SerializeField] LayerMask obstacles;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        rb.velocity = transform.forward * speed;
        Collider[] colls = Physics.OverlapSphere(target.position, 0.1f, obstacles);
        if (colls.Length != 0)
        {
            transform.Rotate(rb.rotation.x, rb.rotation.y+180, rb.rotation.z);
        }
    }
        
}
