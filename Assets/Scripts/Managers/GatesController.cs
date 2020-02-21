using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GatesController : MonoBehaviour
{
    public UnityEvent OnGatesCrosed;
    // Start is called before the first frame update
    void Start()
    {
        if (OnGatesCrosed == null)
            OnGatesCrosed = new UnityEvent();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
             OnGatesCrosed.Invoke();
    }
}
