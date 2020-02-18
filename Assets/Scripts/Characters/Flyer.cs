using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flyer : RangedCharacter 
{
    NavMeshAgent navMeshAgent;
    Vector3 destenation;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }
    public void SetDesenation()
    {

    }
    //MoveToDestenation, Check ->next animatiom
    

    
}
