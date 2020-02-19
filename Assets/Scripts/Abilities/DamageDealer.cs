using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer :MonoBehaviour 
{

    [SerializeField] float radius;
    [SerializeField] LayerMask whatIsPlayer;
    public IDamageTaker CanAtack()
    {
        Collider[] coll = Physics.OverlapSphere(transform.position, radius, whatIsPlayer);
        if (coll.Length != 0)
        {
            Debug.Log(coll[0].name);
            Debug.Log(coll[0].GetComponent<IDamageTaker>());
            return coll[0].GetComponent<IDamageTaker>();
        }
        else return null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
